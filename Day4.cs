using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AdventOfCode2015
{
    public class Day4
    {
        public static void TheIdealStockingStuffer(string secretKey) {

            string startsWith = "00000";
            Console.WriteLine(String.Format("Answer is (Starts with {0}): {1}", startsWith, FindLowestPositiveNumber(secretKey)));
            startsWith = "000000";
            Console.WriteLine(String.Format("Answer is (Starts with {0}): {1}", startsWith, FindLowestPositiveNumber(secretKey, startsWith)));

        }

        public static string FindLowestPositiveNumber(string secretKey)
        {
            return FindLowestPositiveNumber(secretKey, "00000");
        }

        /// <summary>
        /// I am using the brute force!!!
        /// </summary>
        /// <param name="secretKey"></param>
        /// <param name="startsWith"></param>
        /// <returns></returns>
        public static string FindLowestPositiveNumber(string secretKey, string startsWith)
        {
            string ret = String.Empty;
            int i = 0;
            while (true)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, secretKey + i.ToString());
                    if (hash.StartsWith(startsWith))
                    {
                        ret = hash;
                        break;
                    }
                }
                i++;
            }
            return i.ToString();
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
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
