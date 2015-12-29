using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace aoc_day_04
{
    public class Program
    {
        static void Main(string[] args)
        {
            string secretKeyRoot = args[0];
            string hashRootToFind = args[1];

            int minKeyInt = FindMinPositiveIntUsingKeyRootThatCreatesHasWithHashRoot(secretKeyRoot, hashRootToFind);
            System.Console.WriteLine("\nThe minimum positive number concatenated to a key-root of \"{0}\" producing a MD5 hash-root of \"{1}\" is \"{2}\".",
                secretKeyRoot, hashRootToFind, minKeyInt);
        }

        public static int FindMinPositiveIntUsingKeyRootThatCreatesHasWithHashRoot(string keyRoot, string hashRoot)
        {
            bool foundHash = false;
            int iteration = 0;

            while (!foundHash)
            {
                string input = keyRoot + iteration;
                string output = string.Empty;

                using (MD5 md5hash = MD5.Create())
                {
                    output = GetMd5Hash(md5hash, input);
                }

                if (!output.StartsWith(hashRoot))
                {
                    iteration++;
                }
                else
                {
                    foundHash = true;
                }

                //// Report status
                //if (0 == iteration % 1000)
                //{
                //    System.Console.Write(".");
                //}
            }

            return iteration;
        }

        static private string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
