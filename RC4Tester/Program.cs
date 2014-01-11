using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] keyBytes1 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
            byte[] keyBytes2 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            byte[] keyBytes3 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
            byte[] keyBytes4 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a };
            byte[] keyBytes5 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10 };
            byte[] keyBytes6 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18 };
            byte[] keyBytes7 = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 0x20 };
            byte[] textBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
           
            Byte[] output = runRC4(keyBytes1, textBytes);

            String outputString = ByteArrayToString(output);

            Byte[] decrypt = runRC4(keyBytes1, output);

            String decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes1) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes2, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes2, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes2) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes3, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes3, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes3) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes4, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes4, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes4) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes5, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes5, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes5) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes6, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes6, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes6) + "\nResult : " + outputString);

            Console.WriteLine();

            output = runRC4(keyBytes7, textBytes);

            outputString = ByteArrayToString(output);

            decrypt = runRC4(keyBytes7, output);

            decryptString = Encoding.ASCII.GetString(decrypt);

            Console.WriteLine("Key : " + ByteArrayToString(keyBytes7) + "\nResult : " + outputString);

            Console.ReadLine();
        }

        private static Byte[] runRC4(byte[] keyBytes, byte[] textBytes)
        {
            //inicjalizacja klucza
            int[] S = new int[256];
            int i;
            int j;
            for (i = 0; i < 256; i++)
            {
                S[i] = i;
            }
            j = 0;
            int keyBytesLength = keyBytes.GetLength(0);
            for (i = 0; i < 256; i++)
            {
                j = (j + S[i] + keyBytes[i % keyBytesLength]) % 256;
                int temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }

            //pseudolosowa generacja
            List<Byte> result = new List<Byte>();
            i = 0;
            j = 0;
            int textBytesLength = textBytes.GetLength(0);

            Byte[] output = new Byte[textBytes.GetLength(0)];
            for (long offset = 0; offset < textBytesLength; offset++)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                byte temp = (byte)S[i];
                S[i] = S[j];
                S[j] = temp;
                byte a = textBytes[offset];
                byte b = (byte)S[(S[i] + S[j]) % 256];
                output[offset] = (byte)((int)a ^ (int)b);
            }
            return output;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
