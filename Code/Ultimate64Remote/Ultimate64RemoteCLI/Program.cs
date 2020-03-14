using System;
using System.IO;
using Ultimate64;
using SchemaFactor;
using System.Collections.Generic;
using System.Text;

namespace Ultimate64RemoteCLI
{
    class Program
    {
        private const char ESCAPE = '\\';

        static int Main(string[] args)
        { 
            try
            {
                if (args.Length == 0)
                {
                    Usage();
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

            return 0;
        }

        private static void Usage()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: u64remote.exe <ip> <command> <parameters>");
            Console.WriteLine();
            Console.WriteLine("Command is one of:");
            Console.WriteLine("   reset");
            Console.WriteLine("   type <text>      (-n for no RETURN)");
            Console.WriteLine("   poke <startaddress> <byte 1> <byte 2> <byte n>");
            Console.WriteLine("   load <filename>  (start address in file)");
            Console.WriteLine("   run  <filename>  (loads and runs)");
            Console.WriteLine("   jump <filename>  (loads and jumps to start address)");
            Environment.Exit(1);
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

        // TODO - Support petcat-style control codes?

        private static void Type(Config config, string[] args)
        {
            try  
            {
                // Combine all the arguments into a single string.
                string[] vals = args.SubArray(2, args.Length - 2);
                string text = String.Join(" ", vals);

                // Automatically add RETURN?
                if (text.StartsWith("-n "))
                {
                    text = text.Replace("-n ", "");
                }
                else
                {
                    text += "\r";   // RETURN
                }

                // Convert into char array
                char[] textAsChars = text.ToCharArray();

                // List of bytes to send.  Has to be bytes to handle 8-bit control characters in escape sequences.
                List<byte> bytesToSend = new List<byte>();

                // Loop through input string
                for (int i=0; i< textAsChars.Length; i++)
                {
                    char c = textAsChars[i];
                    
                    if (c == ESCAPE)
                    {
                        byte cc = SubstituteControlChar(textAsChars[++i]);  // Skips over control char on next loop
                        bytesToSend.Add(cc);
                    }
                    else
                    {
                        byte pet = Utilities.ASCIItoPETSCII(c);
                        bytesToSend.Add(pet);
                    }
                }

                Ultimate64Commands.SendKeyboardBytes(config, bytesToSend.ToArray());
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        // Reference: https://www.c64-wiki.com/wiki/control_character
        //
        private static byte SubstituteControlChar(char c)
        {
            switch (c)
            {
                case 'c': return   3;  // Run-Stop
                case 'e': return   5;  // Character color White
                case 'h': return   8;  // Disable case change
                case 'i': return   9;  // Enable  case change
                case 'm': return  13;  // RETURN
                case 'n': return  14;  // Mixed case
                case 'q': return  17;  // Cursor down
                case 'r': return  18;  // Reverse ON
                case 's': return  19;  // Home
                case 't': return  20;  // Delete
                case '3': return  28;  // Character color Red
                case ']': return  29;  // Cursor right
                case '6': return  30;  // Character color Green
                case '7': return  31;  // Character color Blue
                case ' ': return  32;  // Space
                case 'M': return 141;  // Shift+RETURN (new row)
                case 'N': return 142;  // Upper case + graphical characters
                case '1': return 144;  // Character color black
                case 'Q': return 145;  // Cursor up
                case '0': return 146;  // Reverse OFF
                case 'S': return 147;  // Clear Screen
                case 'T': return 147;  // Insert

                case ESCAPE: return 205;  // \

                default: throw new Exception("Unknown control character: "+c);
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
