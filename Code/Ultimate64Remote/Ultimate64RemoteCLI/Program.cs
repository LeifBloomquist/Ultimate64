using System;
using System.IO;
using Ultimate64;
using SchemaFactor;

namespace Ultimate64RemoteCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ip = args[0];
                string cmd = args[1];
                string param = "";
                if (args.Length >= 3) param = args[2];

                Config config = new Config(ip, 64);
                byte[] data = null;

                switch (cmd)
                {
                    case "reset":
                        Ultimate64Commands.SendReset(config);
                        break;

                    case "type":
                        Ultimate64Commands.SendKeyboardString(config, param);
                        break;

                    case "poke":
                        Poke(config, param, args);
                        break;

                    case "write":
                    case "load":
                        data = File.ReadAllBytes(param);
                        Ultimate64Commands.WriteMemoryWithAddress(config, data);
                        break;

                    case "run":
                        data = File.ReadAllBytes(param);
                        Ultimate64Commands.SendRamAndRun(config, data);
                        break;

                    case "jump":
                        data = File.ReadAllBytes(param);
                        Ultimate64Commands.SendRamAndJump(config, data);
                        break;

                    default:
                        Usage();
                        break;
                }
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        private static void Usage()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: u64remote.exe <ip> <command> <parameters>");
            Console.WriteLine("Command is one of reset|type|poke|write|run|jump");           
        }

        private static void Poke(Config config, string param, string[] args)
        {
            try
            {
                string[] vals = args.SubArray(3, args.Length - 3);
                byte[] data = new byte[vals.Length];

                for (int i = 0; i < vals.Length; i++)
                {
                    data[i] = Byte.Parse(vals[i]);
                }

                Ultimate64Commands.WriteMemory(config, UInt16.Parse(param), data);
            }
            catch (Exception e)
            {
                Handle(e);
            }
        } 

        private static void Handle(Exception e)
        {
            Console.WriteLine();
            Console.WriteLine("Error: " + e.Message);
            Usage();
        }
    }
}
