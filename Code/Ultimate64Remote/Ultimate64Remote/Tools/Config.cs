using System;
using System.IO;

namespace Ultimate64
{
    class Config
    {
        public string Hostname { get; set; }
        public readonly int Port = 64;
        public const string Filename = "u64remote.ini";

        public Config()
        {
            Load();
        }

        public void Save()
        {
            string[] lines = { Hostname };
            File.WriteAllLines(Filename, lines);
        }

        private void Load()
        {
            try
            {
                string[] lines = File.ReadAllLines(Filename);
                Hostname = lines[0];
            }
            catch (Exception)
            {
                Hostname = "192.168.1.64";
                Save();
            }
        }
    }
}
