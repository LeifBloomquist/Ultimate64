using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Ultimate64;

namespace Ultimate64Debug
{
    public partial class Form_Debug : Form
    {
        public class MemoryCell
        {
            public UInt16 address { get; set; }
            public byte value { get; set; }
            public double reads { get; set; }
            public double writes { get; set; }
        }

        Config cfg = new Config();        
        const int LISTEN_PORT = 3064;

        // Statistics
       ulong packets_received = 0;
       ulong packets_bad = 0;
       uint packets_per_second = 0;
       int packets_missed = 0;
       int last_sequence = -1;

        // Image to display
        static DirectBitmap bmp = new DirectBitmap(256, 256);
        //Graphics gfx = Graphics.FromImage(bmp);

        // Internal Memory Map
        MemoryCell[] memory = new MemoryCell[65536];

        // Thread control
        bool run_udp = true;

        public Form_Debug()
        {
            InitializeComponent();
            tbIPAddress.Text = cfg.Hostname;

            SetupGrid();

            SetTimer();

            Thread t = new Thread(new ThreadStart(UDPListener));
            t.Priority = ThreadPriority.Highest;
            t.Start();

            for (int a = 0; a < memory.Length; a++)
            {
                memory[a] = new MemoryCell();
                memory[a].address = (UInt16)a;
            }           
        }

        private void SetupGrid()
        {
            grid.ColumnCount = 17;

            grid.Columns[0].Name = "Address";
            grid.Columns[0].Width = 50;

            for (int col = 1; col < 17; col++)
            {
                grid.Columns[col].Width = 25;
                grid.Columns[col].Name = "-";
            }
            grid.RowCount = 4096;

            DataGridViewCell cell = null;

            for (int row = 0; row < 4096; row++)
            {
                grid.Rows[row].Cells[0].Value = (row * 16).ToString("X4");               

                for (int col = 0; col < 16; col++)
                {
                    offset = (16 * row) + col;

                    cell = grid.Rows[row].Cells[col + 1];  // +1 to skip over address column
                    cell.Style.BackColor = Color.Gray;
                    cell.Style.ForeColor = Color.White;                  
                }
            }

            // Double Buffered
            Type dgvType = grid.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(grid, true, null);

            // Virtual
            grid.VirtualMode = true;
            grid.CellValueNeeded += grid_CellValueNeeded;
        }

        private void grid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int offset = 0;
            int red;
            int grn;
            DataGridViewCell cell = null;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (col == 0) // Address
            {
                e.Value = (16 * row).ToString("X4");
                return;
            }

            offset = (16 * row) + col - 1;   // -1 because of the address column
            red = (int)(memory[offset].writes * 255d);
            grn = (int)(memory[offset].reads * 255d);

            cell = grid.Rows[row].Cells[col]; 
            cell.Style.BackColor = Color.FromArgb(red, grn, 0);

            e.Value = memory[offset].value.ToString("X2");
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            if (cbConfirmReset.Checked)
            {
                var result = MessageBox.Show("Reset Ultimate 64, are you sure?", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) return;
            }
            Ultimate64Commands.SendReset(cfg);
        }

        private void bSaveConfig_Click(object sender, EventArgs e)
        {
            cfg.Hostname = tbIPAddress.Text;
            cfg.Save();
        }

        private void bStartStream_Click(object sender, EventArgs e)
        {
           
            Ultimate64Commands.StartStream(cfg, Ultimate64Commands.StreamID.STREAM_DEBUG, "192.168.7.14:" + LISTEN_PORT.ToString());
        }

        private void bStopStream_Click(object sender, EventArgs e)
        {
            Ultimate64Commands.StopStream(cfg, Ultimate64Commands.StreamID.STREAM_DEBUG);
        }

        // Timer

        private void SetTimer()
        {
            System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();            
            aTimer.Tick += OnTimedEvent; 
            aTimer.Interval = 25;
            aTimer.Start();
        }

        private void OnTimedEvent(Object myObject, EventArgs myEventArgs)
        {
            lPackets.Text = packets_received.ToString() + "\n" +
                            packets_bad.ToString() + "\n" +
                            (packets_per_second * 20).ToString() + "\n" + 
                            packets_missed.ToString() + "\n";

            packets_per_second = 0;

            lSequence.Text = last_sequence.ToString();

            ShowMemory(memory);
            Animate(memory);

            //grid.Invalidate();
            //grid.Update();
        }

        // Method to listen (Separate thread)
        public void UDPListener()
        {
            UdpClient listener = new UdpClient(LISTEN_PORT);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, LISTEN_PORT);

            listener.Client.ReceiveBufferSize = 10000000;

            while (run_udp)
            {
                try
                {              
                    byte[] bytes = listener.Receive(ref RemoteIpEndPoint);   // Blocks

                    packets_received++;

                    if (bytes.Length == 1444)
                    {                       
                        packets_per_second++;
                        Analyze(bytes);
                    }
                    else
                    {
                        packets_bad++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }        
        }

        int address = 0;
        byte data = 0;
        byte flags = 0;

        int offset;

        private void Analyze(byte[] bytes)
        {         
            int sequence = GetWord(bytes, 0);  // 0, 1
            // 2 and 3 reserved

            for (int de=0; de<360; de++)
            {
                offset = 4 + (de * 4);
                address = GetWord(bytes, offset);
                data = bytes[offset + 2];
                flags = bytes[offset + 3];
                BitArray flagbits = new BitArray(new byte[] { flags });

                if (flagbits[0])  // Read = 1, write = 0
                {
                    memory[address].reads = 1f;
                }
                else
                {
                    memory[address].writes = 1f;
                }
                memory[address].value = data;
            } 

            if (last_sequence > 0)
            {
                last_sequence++;
                int delta = sequence - last_sequence;

                if ((delta > 0) && (delta < 0x8000))
                {
                    packets_missed += delta;
                }
            }

            last_sequence = sequence;
        }

        private void WriteTextSafe(string text)
        {
            try
            {
                lSequence.Invoke(new Action(() => lSequence.Text = text));
            }
            catch (Exception)
            {
                ;
            }
        }

        private void ShowMemory(MemoryCell[] memory)
        {
            int offset;
            int red;
            int grn;

            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    offset = (256 * y) + x;
                    red = (int)(memory[offset].writes * 255d);
                    grn = (int)(memory[offset].reads * 255d);
                    bmp.SetPixel(x, y, Color.FromArgb(red, grn, 0));
                }
            }

            pbMemory.Image = bmp.Bitmap;
        }

        private void Animate(MemoryCell[] memory)
        {
            for (int offset = 0; offset < memory.Length; offset++)
            {
                memory[offset].writes *= 0.7;
                memory[offset].reads *= 0.7;
            }
        }

        private int GetWord(byte[] data, int offset)
        {
            return data[offset] + (data[offset + 1] << 8);
        }

        private void Form_Debug_FormClosed(object sender, FormClosedEventArgs e)
        {
            run_udp = false;
        }
    }
}
