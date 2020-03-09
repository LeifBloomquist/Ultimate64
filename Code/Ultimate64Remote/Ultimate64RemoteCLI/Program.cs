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
                if (args.Length == 0)
                {
                    Usage();
                    return;
                }

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
                        Type(config, args);
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
            Console.WriteLine();
            Console.WriteLine("Command is one of:");
            Console.WriteLine("   reset");
            Console.WriteLine("   type <text>");
            Console.WriteLine("   poke <startaddress> <byte 1> <byte 2> <byte n>");
            Console.WriteLine("   load <filename>  (start address in file)");
            Console.WriteLine("   run  <filename>  (loads and runs)");
            Console.WriteLine("   jump <filename>  (loads and jumps to start address)");
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

        private static void Type(Config config, string[] args)
        {
            try  
            {
                // Combine all the arguments into a single string.
                string[] vals = args.SubArray(2, args.Length - 2);
                string text = String.Join(" ", vals);

                Ultimate64Commands.SendKeyboardString(config, text);
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
