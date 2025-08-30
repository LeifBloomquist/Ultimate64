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
            Ultimate64Commands.SendReset(cfg);
        }

        private void bSendString_Click(object sender, EventArgs e)
        {
            String text = tbCommand.Text;

            if (cbAppendReturn.Checked)
            {
                text += "\r";
            }

            Ultimate64Commands.SendKeyboardString(cfg, text);
        }

        // Handle regular alphanumeric keys
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

                // Shift-"Pound"  (actually \)
                case '|':
                    c = (char)0xA9;
                    Ultimate64Commands.SendKeyboardKey(cfg, (byte)c);
                    return;

                // Tab -> Ignore (used as Commodore key)
                case '\t':
                    return;
            }

            bool handled = false;
            if (commKeyPressed)   // Commodore (Tab) key pressed, character may require modification
            {
                handled = HandleCommodoreKey(c);
            }

            if (handled)
            {
                return;
            }
            else
            {
                String key = new string(c, 1);
                Ultimate64Commands.SendKeyboardString(cfg, key);   // This handles ASCII/PETSCII conversion too
                e.Handled = true;
                tbKeyboardZone.Text = key;
            }
        }

        // Handle control keys, arrow keys, and modifiers
        private void tbKeyboardZone_KeyDown(object sender, KeyEventArgs e)
        {
            byte key = 0x00;

            switch (e.KeyCode)                 // Reference:  http://sta.c64.org/cbm64pet.html
            {
                case Keys.Up:
                    key = 0x91;
                    break;

                case Keys.Down:
                    key = 0x11;
                    break;

                case Keys.Left:
                    key = 0x9D;
                    break;

                case Keys.Right:
                    key = 0x1D;
                    break;

                case Keys.Home:
                    if (e.Shift)
                    {
                        key = 0x93;
                    }
                    else
                    {
                        key = 0x13;
                    }
                    break;

                case Keys.Insert:
                    key = 0x94;
                    break;

                case Keys.F1:
                    key = 0x85;
                    break;

                case Keys.F2:
                    key = 0x89;
                    break;

                case Keys.F3:
                    key = 0x86;
                    break;

                case Keys.F4:
                    key = 0x8A;
                    break;

                case Keys.F5:
                    key = 0x87;
                    break;

                case Keys.F6:
                    key = 0x8B;
                    break;  

                case Keys.F7:
                    key = 0x88;
                    break;

                case Keys.F8:
                    key = 0x8C;
                    break;

                case Keys.F9:
                    key = 0x0E;    // Upper Charset
                    break;

                case Keys.F10:
                    key = 0x8E;    // Lower Charset
                    break;

                case Keys.Tab:
                    commKeyPressed = true;
                    e.SuppressKeyPress = true;  // Disables the error beep
                    return;

                default:
                    return;  // Don't send anything, key may be handled by _KeyPress 
            }

            Ultimate64Commands.SendKeyboardKey(cfg, key);
            e.Handled = true;

            tbKeyboardZone.Text = "";
        }

        // Special handling for Tab, which we use as the Commodore key --------------------------------------------

        bool commKeyPressed = false;

        byte[] c_num_keys = { 129, 149, 150, 151, 152, 153, 154, 155, 41 };
        byte[] c_letter_keys = { 176, 191, 188, 172, 177, 187, 165, 180, 162, 181, 161, 182, 167, 170, 185, 175, 171, 178, 174, 163, 184, 190, 179, 189, 183, 173 };

        private bool HandleCommodoreKey(char c)
        {
            byte key = (byte)c;

            bool handled = false;

            // Letters
            if ((key >= 'a') && (key <= 'z'))
            {
                key = c_letter_keys[key - 'a'];
                handled = true;
            }

            // Numbers.  Note 0 is not modified by C=
            if ((key >= '1') && (c <= '9'))
            {
                key = c_num_keys[key - '1'];
                handled = true;
            }

            // Other random keys
            if (key == '+') { key = 166; handled = true; }
            if (key == '-') { key = 220; handled = true; }
            if (key == '*') { key = 223; handled = true; }
            if (key == '\\'){ key = 168; handled = true; } // "Pound"

            if (handled)
            {
                Ultimate64Commands.SendKeyboardKey(cfg, key);
            }

            return handled;
        }

        private void tbKeyboardZone_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;  // Prevents changing focus and allows other events to process the key
            }            
        }

        private void tbKeyboardZone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                commKeyPressed = false;
            }
        }       
        
        // --------------------------------------------------------------------------------------------------------

        private void bReadMemory_Click(object sender, EventArgs e)
        {
            byte[] buffer = Ultimate64Commands.ReadMemory(cfg);
            File.WriteAllBytes(@"c:\ultimate64mem.bin", buffer);    // Not sure what this file actually is??  TODO, prompt for filename and make it a config item
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

            Ultimate64Commands.WriteMemory(cfg, address, vals.ToArray());
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

        byte[] binary = null;

        private void bSelectFile_Click(object sender, EventArgs e)
        {
            binary = FileUtilities.SelectandReadBinaryFile(cfg.LastPath);

            if (binary != null)
            {
                cfg.LastPath = Path.GetDirectoryName(FileUtilities.LastPathFileName);
                cfg.Save();

                lFileName.Text = Path.GetFileName(FileUtilities.LastPathFileName);
                lLoadAddress.Text = ((binary[1] * 256) + binary[0]).ToString();
                lDataSize.Text = (binary.Length - 2).ToString();
            }            
        }

        private void bLoadRun_Click(object sender, EventArgs e)
        {
            if (binary == null) return;

            Ultimate64Commands.SendRamAndRun(cfg, binary);
        }

        private void bLoadMemory_Click(object sender, EventArgs e)
        {
            if (binary == null) return;

            Ultimate64Commands.WriteMemoryWithAddress(cfg, binary);
        }

        private void bLoadJump_Click(object sender, EventArgs e)
        {
            if (binary == null) return;

            Ultimate64Commands.SendRamAndJump(cfg, binary);
        }
    }
}
