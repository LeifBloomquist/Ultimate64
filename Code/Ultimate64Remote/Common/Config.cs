using System;
using System.IO;

namespace Ultimate64
{
    class Config
    {
        public const string Filename = "u64remote.ini";

        public string Hostname { get; set; }
        public readonly int Port = 64;

        public string LastPath { get; set; }

        public Config()
        {
            Load();
        }

        public Config(string host, int port)
        {
            this.Hostname = host;
            this.Port = port;
        }

        public void Save()
        {
            string[] lines = { Hostname, LastPath };
            File.WriteAllLines(Filename, lines);
        }

        private void Load()
        {
            try
            {
                string[] lines = File.ReadAllLines(Filename);
                Hostname = lines[0];
                LastPath = lines[1];
            }
            catch (Exception)
            {
                Hostname = "192.168.1.64";
                LastPath = @"C:\";
                Save();
            }
        }
    }
}
