using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace SchemaFactor
{
    public static class Utilities
    {
        private static Mutex m_Mutex;

        // If firstInstance is now true, we're the first instance of the application;
        // otherwise another instance is running.
        public static bool IsFirstInstance(String someUniqueName)
        {
            bool firstInstance;
            m_Mutex = new Mutex(true, someUniqueName, out firstInstance);
            return firstInstance;
        }

        static public Random random = new Random();

        private static UInt16 SwapUInt16(UInt16 inValue)
        {
            return (UInt16)(((inValue & 0xff00) >> 8) |
                            ((inValue & 0x00ff) << 8));
        }

        private static UInt32 SwapUInt32(UInt32 inValue)
        {
            return (UInt32)(((inValue & 0xff000000) >> 24) |
                            ((inValue & 0x00ff0000) >> 8) |
                            ((inValue & 0x0000ff00) << 8) |
                            ((inValue & 0x000000ff) << 24));
        }

        public static byte GetHighByte(UInt16 value)
        {
            return BitConverter.GetBytes(value)[1];
        }

        public static byte GetLowByte(UInt16 value)
        {
            return BitConverter.GetBytes(value)[0];
        }

        public static byte GetHighByte(int value)
        {
            return GetHighByte((UInt16)value);
        }

        public static byte GetLowByte(int value)
        {
            return GetLowByte((UInt16)value);
        }

        public static byte GetHighByte(uint value)
        {
            return GetHighByte((UInt16)value);
        }

        public static byte GetLowByte(uint value)
        {
            return GetLowByte((UInt16)value);
        }

        public static byte[] GetBytes(uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] StringToByteArray(String hex)
        {
            // Strip out spaces and dashes
            hex = hex.Replace(" ", "");
            hex = hex.Replace("-", "");

            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        /// <summary>
        /// Convert a double into a "fixed point" signed integer.
        /// *Note* that it actually returns an unsigned integer, as it's really representing the twos compliment of the value in this series of bits.
        /// </summary>
        /// <param name="num">Input value</param>
        /// <param name="resolution">LSB value</param>
        /// <returns>An *unsigned* integer containing the value.  Twos complement if negative.</returns>
        public static UInt16 ToFixedPointSigned(double num, double resolution)
        {
            double tempd = num / resolution;
            Int16 tempi = Convert.ToInt16(tempd);   // This roundabout approach is more robust for negative numbers.
            UInt16 tempu = (UInt16)tempi;
            return tempu;
        }

        /// <summary>
        /// Convert a double into a "fixed point" unsigned integer.
        /// </summary>
        /// <param name="num">Input value</param>
        /// <param name="resolution">LSB value</param>
        /// <returns>Unsigned integer returning the value</returns>
        public static UInt16 ToFixedPointUnsigned(double num, double resolution)
        {
            double tempd = num / resolution;
            UInt16 tempi = Convert.ToUInt16(tempd);
            return tempi;
        }

        public static double FromFixedPoint(byte[] contents, int wordoffset, int bitoffset, double resolution)
        {
            UInt16 integer = GetUInt16Swapped(contents, wordoffset, bitoffset);
            return integer * resolution;
        }

        // Not tested !!!!
        public static double FromFixedPointSigned(byte[] contents, int wordoffset, int bitoffset, double resolution)
        {
            Int16 integer = (Int16)GetUInt16Swapped(contents, wordoffset, bitoffset);   // Cast to force it negative
            return integer * resolution;
        }

        public static byte[] GetBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static byte[] GetBytesInverted(string str)
        {
            string temp = ToggleCase(str);
            return Encoding.ASCII.GetBytes(temp);
        }

        private static string ToggleCase(string input)
        {
            string result = string.Empty;
            char[] inputArray = input.ToCharArray();

            foreach (char c in inputArray)
            {
                if (char.IsLower(c))
                    result += c.ToString().ToUpper();
                else if (char.IsUpper(c))
                    result += c.ToString().ToLower();
                else
                    result += c.ToString();
            }

            return result;
        }

        public static byte ASCIItoPETSCII(char c)
        {
            if (char.IsLower(c))
                return (byte)(c - 32);
            else if (char.IsUpper(c))
                return (byte)(c + 128);
            else
                return (byte)c;
        }

        private static UInt32 GetUInt32(byte[] contents, int wordoffset)
        {
            return BitConverter.ToUInt32(contents, wordoffset * 4);
        }

        public static UInt32 GetUInt32Swapped(byte[] contents, int wordoffset)
        {
            UInt32 temp = GetUInt32(contents, wordoffset);
            return SwapUInt32(temp);
        }

        public static UInt16 GetUInt16Swapped(byte[] contents, int wordoffset)
        {
            UInt16 temp = BitConverter.ToUInt16(contents, wordoffset * 4);
            return SwapUInt16(temp);
        }

        public static UInt16 GetUInt16Swapped(byte[] contents, int wordoffset, int bitoffset)
        {
            UInt32 word = GetUInt32(contents, wordoffset);     // Get the word containing uint16 we want.  Note not swapped!
            word = word & (UInt32)(0xFFFF << bitoffset);       // Mask the uint16 we want
            word = word >> bitoffset;                          // Shift the result back
            return SwapUInt16((UInt16)word);                   // And swap
        }

        public static UInt16 GetNybble(byte[] contents, int wordoffset, int bitoffset)
        {
            UInt32 word = GetUInt32Swapped(contents, wordoffset);     // Get containing word
            int bitoffset_fixed = 32 - bitoffset - 4;  // OLA ordering

            UInt32 temp = (UInt32)(0xF << bitoffset_fixed) & word;
            UInt32 temp2 = temp >> bitoffset_fixed;
            return (UInt16)temp2;
        }

        public static byte GetByte(byte[] contents, int wordoffset, int bitoffset)
        {
            UInt32 word = GetUInt32(contents, wordoffset);   // Get the word containing byte we want.  Note not swapped!
            word = word & (UInt32)(0xFF << bitoffset);       // Mask the byte we want
            word = word >> bitoffset;                        // Shift the result back
            return (byte)word;
        }

        private static int FixMSb(int offset)
        {
            int retvalue = 8 * ((int)(offset / 8));
            retvalue += 7;
            retvalue -= (offset % 8);
            return retvalue;
        }

        public static bool GetBoolean(byte[] contents, int wordoffset, int bitoffset)
        {
            BitArray ba = new BitArray(contents);
            return ba[(wordoffset * 32) + FixMSb(bitoffset)];
        }

        public static UInt16 Get2Bits(byte[] contents, int wordoffset, int firstbitoffset)
        {
            UInt16 temp1 = Convert.ToUInt16(GetBoolean(contents, wordoffset, firstbitoffset));
            UInt16 temp2 = Convert.ToUInt16(GetBoolean(contents, wordoffset, firstbitoffset + 1));

            return (UInt16)((temp1 << 1) | temp2);
        }

        public static UInt16 Get2Bits(BitArray bits, int firstbitoffset)
        {
            UInt16 temp = 0;

            if (bits[firstbitoffset])
            {
                temp |= 2;
            }

            if (bits[firstbitoffset + 1])
            {
                temp |= 1;
            }

            return temp;
        }


        /// <summary>
        /// Get a 24-bit value.  Must align with the start of the 32-bit word!
        /// </summary>
        /// <param name="contents">Byte array (usually IDPMessage)</param>
        /// <param name="wordoffset">Word offset</param>        
        /// <returns>The value as a UInt32</returns>
        public static UInt32 Get24BitsUnsigned(byte[] contents, int wordoffset)
        {
            UInt32 ValueTemp = (UInt32)(contents[wordoffset * 4 + 0] << 16) |
                               (UInt32)(contents[wordoffset * 4 + 1] << 8) |
                               (UInt32)(contents[wordoffset * 4 + 2] << 0);
            return ValueTemp;
        }

        /// <summary>
        /// Get a 24-bit value.  Must align with the start of the 32-bit word!
        /// </summary>
        /// <param name="contents">Byte array (usually IDPMessage)</param>
        /// <param name="wordoffset">Word offset</param>        
        /// <returns>The value as an Int32</returns>
        /// 
        // NEEDS TESTING!
        public static Int32 Get24BitsSigned(byte[] contents, int wordoffset)
        {
            UInt32 ValueTemp = Get24BitsUnsigned(contents, wordoffset);
            return (Int32)ValueTemp;
        }

        /// <summary>
        /// Extract an ACII string from the message.
        /// </summary>
        /// <param name="contents">Byte array (IDPMessage)</param>
        /// <param name="wordoffset">Starting word</param>
        /// <param name="bitoffset">Bit offset.  Must be divisible by 8!</param>
        /// <param name="digits">Number of digits</param>
        /// <returns></returns>
        public static string GetASCII(byte[] contents, int wordoffset, int bitoffset, int digits)
        {
            if ((bitoffset % 8) != 0)
            {
                throw new ArgumentException("Bit offset must be disible by 8", "bitoffset");
            }

            int offset = (wordoffset * 4) + (bitoffset / 8);
            return Encoding.ASCII.GetString(contents, offset, digits);
        }

        public static float GetFloat(byte[] input, int wordoffset)
        {
            int byteoffset = wordoffset * 4;
            byte[] newArray = new byte[4];
            Array.Copy(input, byteoffset, newArray, 0, 4);
            Array.Reverse(newArray);
            return BitConverter.ToSingle(newArray, 0);
        }

        public static byte[] FromFloat(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);               // Assume little-endian machine
            return bytes;
        }

        private static readonly byte[] _RevBitsTable =
        {
            0x00,0x08,0x04,0x0C,
            0x02,0x0A,0x06,0x0E,
            0x01,0x09,0x05,0x0D,
            0x03,0x0B,0x07,0x0F
        };

        private static byte ReverseBits(byte data)
        {
            byte ln = _RevBitsTable[data & 0x0F];
            byte hn = _RevBitsTable[(data >> 4) & 0x0F];
            return (byte)((ln << 4) | hn);
        }

        /// <summary>
        /// Return a string representing a BitArray, formatted MSB to LSB (more intuitive to read)
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static string ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = bits.Count - 1; i >= 0; i--)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Helper function for the signed and unsigned cases.  
        /// Returns a BitArray with length of 14 bits extracted from the given byte array at the given byte/bit offset.
        /// Padded with zeros if there are not 14 bits to the end of the array.
        /// </summary>
        /// <param name="contents">Source byte array</param>
        /// <param name="byteoffset">32-bit word offset</param>
        /// <param name="bitoffset">bit offset within the word (not byte!)</param>
        /// <returns>BitArray with the bits, lowest value first.</returns>
        private static BitArray Extract14Bits(byte[] contents, int wordoffset, int bitoffset)
        {
            byte[] tempbytes = new byte[4];    // There are cases where the 14 bits can span 3 bytes.  Use 4 to keep BitConverter happy below.

            // 1. Extract just the bytes we want and copy.
            int offsetbits = (wordoffset * 32) + bitoffset;
            int startbyte = (int)Math.Floor(offsetbits / 8.0);
            int leftoverbits = offsetbits - (startbyte * 8);

            // Not so fast!  We copy either two words' worth (8 bytes), *or* to the end of the input array and leave the rest as zeroes.

            int endbyte = startbyte + tempbytes.Length;
            if (endbyte > contents.Length)
            {
                endbyte = contents.Length;
            }

            for (int i = startbyte; i < endbyte; i++)
            {
                tempbytes[i - startbyte] = contents[i];     // Leave the rest at 0.
            }

            // 2. Convert to Bitarray
            Array.Reverse(tempbytes);    // Because BitArray assumes little-endian
            BitArray tempbits = new BitArray(tempbytes);

            // 3. Extract just the 14 bits of interest
            BitArray retbits = new BitArray(14);

            for (int i = 0; i < 14; i++)
            {
                retbits[i] = tempbits[32 - 14 - leftoverbits + i];
            }

            // 4. Return
            return retbits;
        }


        /// <summary>
        /// Helper function to parse an *unsigned* 14-bit value at an arbitrary location in the array, potentially spanning 32-bit word boundaries.
        /// Messy!
        /// </summary>
        /// <param name="contents">Byte array</param>
        /// <param name="wordoffset">32-bit word offset into the array.</param>
        /// <param name="bitoffset">bit offset into the word to start of value</param>
        /// <returns>UInt16 holding the unsigned value.</returns>
        public static UInt16 Get14BitsUnsigned(byte[] contents, int wordoffset, int bitoffset)
        {
            BitArray bits = Extract14Bits(contents, wordoffset, bitoffset);

            // Add up the bits
            UInt16 retval = 0;

            for (int i = 0; i < 14; i++)
            {
                if (bits[i])
                {
                    retval |= (UInt16)(1 << i);
                }
            }

            // Return
            return retval;
        }


        /// <summary>
        /// Helper function to parse an *unsigned* 14-bit value at an arbitrary location in a bitarray.
        /// </summary>
        /// <param name="bits">Bit array</param>
        /// <param name="bitoffset">bit offset into the array to start of value</param>
        /// <returns>UInt16 holding the unsigned value.</returns>
        public static UInt16 Get14BitsUnsigned(BitArray bits, int bitoffset)
        {
            // Add up the bits
            UInt16 retval = 0;

            for (UInt16 i = 0; i < 14; i++)
            {
                if (bits[bitoffset + i])
                {
                    UInt16 iswap = (UInt16)(13 - i);
                    UInt16 bitval = (UInt16)(1 << iswap);
                    retval |= bitval;
                }
            }

            // Return
            return retval;
        }

        /// <summary>
        /// Helper function to parse a *signed* 14-bit value at an arbitrary location in a bitarray.
        /// </summary>
        /// <param name="bits">Bit array</param>
        /// <param name="bitoffset">bit offset into the array to start of value</param>
        /// <returns>Int16 holding the Signed value.</returns>        
        public static Int16 Get14BitsSigned(BitArray bits, int bitoffset)
        {
            // 1. Get the raw value (unsigned).
            UInt16 raw = Get14BitsUnsigned(bits, bitoffset);

            // 2. (Trick) if bit 14 is set, force the upper 3 bits high so C# sees it as a signed int.
            if ((raw & 0x2000) != 0)
            {
                raw = (UInt16)(raw | 0xE000);   // 0b1110000000000000
            }

            // 3. Force to signed
            var retsigned = (Int16)raw;

            // 4. Return
            return retsigned;
        }



        /// <summary>
        /// Helper function to parse a *signed* 14-bit value at an arbitrary location in the array, potentially spanning 32-bit word boundaries.
        /// Messy!
        /// </summary>
        /// <param name="contents">Byte array</param>
        /// <param name="wordoffset">32-bit word offset into the array.</param>
        /// <param name="bitoffset">bit offset into the word to start of value</param>
        /// <returns>Int16 holding the signed value.</returns>
        public static Int16 Get14BitsSigned(byte[] contents, int wordoffset, int bitoffset)
        {
            // 1. Get the raw value (unsigned).
            UInt16 raw = Get14BitsUnsigned(contents, wordoffset, bitoffset);

            // 2. (Trick) if bit 14 is set, force the upper 3 bits high so C# sees it as a signed int.
            if ((raw & 0x2000) != 0)
            {
                raw = (UInt16)(raw | 0xE000);   // 0b1110000000000000
            }

            // 3. Force to signed
            var retsigned = (Int16)raw;

            // 4. Return
            return retsigned;
        }


        public static DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }



        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }


        /// <summary>
        /// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
        /// Provides a method for performing a deep copy of an object.
        /// Binary Serialization is used to perform the copy.
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static UInt16 InternetChecksum(byte[] buffer)
        {
            int length = buffer.Length;
            int i = 0;
            UInt32 sum = 0;
            UInt32 data = 0;
            while (length > 1)
            {
                data = 0;
                data = (UInt32)(
                ((UInt32)(buffer[i]) << 8)
                |
                ((UInt32)(buffer[i + 1]) & 0xFF)
                );

                sum += data;
                if ((sum & 0xFFFF0000) > 0)
                {
                    sum = sum & 0xFFFF;
                    sum += 1;
                }

                i += 2;
                length -= 2;
            }

            if (length > 0)
            {
                sum += (UInt32)(buffer[i] << 8);

                if ((sum & 0xFFFF0000) > 0)
                {
                    sum = sum & 0xFFFF;
                    sum += 1;
                }
            }
            sum = (~sum) & 0xFFFF;

            // Special case for OLA: Checksums are never 0 (use 0xFFFF instead)
            if (sum == 0)
            {
                sum = 0xFFFF;
            }

            return (UInt16)sum;
        }


        /**
         * Search the data byte array for the first occurrence 
         * of the byte array pattern.
         */
        public static int IndexOf(byte[] data, byte[] pattern, int startLoc)
        {
            int[] failure = computeFailure(pattern);

            int j = 0;

            for (int i = startLoc; i < data.Length; i++)
            {
                while (j > 0 && pattern[j] != data[i])
                {
                    j = failure[j - 1];
                }
                if (pattern[j] == data[i])
                {
                    j++;
                }
                if (j == pattern.Length)
                {
                    return i - pattern.Length + 1;
                }
            }
            return -1;
        }

        public static int IndexOf(byte[] data, byte[] pattern)
        {
            return IndexOf(data, pattern, 0);
        }

        /**
        * Computes the failure function using a boot-strapping process,
        * where the pattern is matched against itself.
        */
        private static int[] computeFailure(byte[] pattern)
        {
            int[] failure = new int[pattern.Length];

            int j = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                while (j > 0 && pattern[j] != pattern[i])
                {
                    j = failure[j - 1];
                }
                if (pattern[j] == pattern[i])
                {
                    j++;
                }
                failure[i] = j;
            }

            return failure;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public class CircularBuffer<T> : IEnumerable<T>
        {
            private T[] _buffer;

            private int _latestIndex = -1;
            private bool bufferFull = false;

            public int bufferSize { get; private set; }

            public int Count
            {
                get
                {
                    if (bufferFull)
                        return bufferSize;
                    else
                        return _latestIndex + 1;
                }
            }

            public CircularBuffer(int size)
            {
                bufferSize = size;
                _latestIndex = -1;
                _buffer = new T[bufferSize];
            }

            public void Add(T item)
            {
                _latestIndex++;

                if (_latestIndex == bufferSize)
                {
                    bufferFull = true;
                    _latestIndex = 0;
                }

                _buffer[_latestIndex] = item;
            }

            public void Clear()
            {
                _buffer = new T[bufferSize];
                _latestIndex = -1;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (_latestIndex < 0)
                    yield break;

                int currentIndex = _latestIndex;
                int loopCounter = 0;
                while (loopCounter != bufferSize)
                {
                    loopCounter++;
                    yield return _buffer[currentIndex];

                    currentIndex--;
                    if (currentIndex < 0)
                    {
                        if (bufferFull)
                            currentIndex = bufferSize - 1;
                        else
                            yield break;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public static int SearchBytes(byte[] haystack, byte[] needle)
        {
            var len = needle.Length;
            var limit = haystack.Length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != haystack[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}