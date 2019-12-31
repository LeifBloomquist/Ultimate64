using SchemaFactor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ultimate64;

namespace Ultimate64Test
{
    public partial class MainForm : Form
    {
        Config cfg = new Config();

        public MainForm()
        {
            InitializeComponent();
            tbIPAddress.Text = cfg.Hostname;
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            if (cbConfirmReset.Checked)
            {
                var result = MessageBox.Show("Reset Ultimate 64, are you sure?", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) return;
            }
            Ultimate64Tools.SendReset(cfg);
        }

        private void bSendString_Click(object sender, EventArgs e)
        {
            String text = tbCommand.Text;

            if (cbAppendReturn.Checked)
            {
                text += "\r";
            }

            Ultimate64Tools.SendKeyboardString(cfg, text);
        }

        private void tbKeyboardZone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            // Special cases
            switch (c)
            {
                // Backspace -> Delete
                case '\b':  
                    c = (char)0x14;
                    break;

                // Escape -> Run/Stop
                case (char)27:
                    c = (char)0x03;
                    break;
            }

            String key = new string(c, 1);            
            Ultimate64Tools.SendKeyboardString(cfg, key);
            e.Handled = true;

            tbKeyboardZone.Text = key;
        }

        private void tbKeyboardZone_KeyDown(object sender, KeyEventArgs e)
        {
            char key = '?';

            switch (e.KeyCode)                 // Reference:  http://sta.c64.org/cbm64pet.html
            {
                case Keys.Up:
                    key = (char)0x91;
                    break;

                case Keys.Down:
                    key = (char)0x11;
                    break;

                case Keys.Left:
                    key = (char)0x9D;
                    break;

                case Keys.Right:
                    key = (char)0x1D;
                    break;

                case Keys.Home:                    
                    if (e.Shift)
                    {
                        key = (char)0x93;
                    }
                    else
                    {
                        key = (char)0x13;
                    }                    
                    break;

                case Keys.Insert:
                    key = (char)0x94;
                    break;

                case Keys.F1:
                    key = (char)0x85;
                    break;

                case Keys.F2:
                    key = (char)0x89;
                    break;

                case Keys.F3:
                    key = (char)0x86;
                    break;

                case Keys.F4:
                    key = (char)0x8A;
                    break;

                case Keys.F5:
                    key = (char)0x87;
                    break;

                case Keys.F6:
                    key = (char)0x8B;
                    break;

                case Keys.F7:
                    key = (char)0x88;
                    break;

                case Keys.F8:
                    key = (char)0x8C;
                    break;

                default:
                    return;  // Don't send anything, key may be handled by _KeyPress 
            }

            Ultimate64Tools.SendKeyboardKey(cfg, key);
            e.Handled = true;

            tbKeyboardZone.Text = "";
        }

        private void bReadMemory_Click(object sender, EventArgs e)
        {
            byte[] buffer = Ultimate64Tools.ReadMemory(cfg);
            File.WriteAllBytes("c:\\Leif\\u64mem.bin", buffer);    // Not sure what this file actually is??  TODO, prompt for filename and make it a config item
            MessageBox.Show("Memory Dump Complete!");
        }

        private void bWriteMemory_Click(object sender, EventArgs e)
        {
            UInt16 address = (UInt16)udAddress.Value;

            char[] delimiters = new char[] {' ',','};
            string[] parts = tbValues.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            List<byte> vals = new List<byte>();

            foreach (string p in parts)
            {
                vals.Add(byte.Parse(p));
            }

            Ultimate64Tools.WriteMemory(cfg, address, vals.ToArray());
        }

        private void cbCommonCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCommand.Text = cbCommonCommands.Text;
        }

        private void bSaveConfig_Click(object sender, EventArgs e)
        {
            cfg.Hostname = tbIPAddress.Text;
            cfg.Save();
        }
    }
}
