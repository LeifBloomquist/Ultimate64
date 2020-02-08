using System;
using System.IO;
using System.Windows.Forms;

namespace Ultimate64Test
{
    class FileUtilities
    {
        public static string LastPathFileName { get; private set; }

        public static byte[] SelectandReadBinaryFile(string path)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open PRG File";
            theDialog.Filter = "PRG files|*.prg";
            theDialog.InitialDirectory = path;

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LastPathFileName = theDialog.FileName;
                    return File.ReadAllBytes(theDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
