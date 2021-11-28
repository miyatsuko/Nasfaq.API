//Translated from the original yeast library: https://github.com/unshiftio/yeast

using System.Collections.Generic;
using System;

namespace YeastLib
{
    public static class Yeast
    {
        private static readonly char[] alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_".ToCharArray();
        private static readonly Dictionary<char, int> map = new Dictionary<char, int>();
        private static int seed = 0;
        private static string prev;

        static Yeast()
        {
            for(int i = 0 ; i < alphabet.Length; i++)
            {
                map.Add(alphabet[i], i);
            }
        }

        public static string Encode(long num)
        {
            string encoded = "";

            do{
                encoded = alphabet[num % alphabet.Length] + encoded;
                num = num / alphabet.Length;
            } while(num > 0L);

            return encoded;
        }

        public static long Decode(string str)
        {
            long decoded = 0L;

            for(int i = 0; i < str.Length; i++)
            {
                decoded = decoded * alphabet.LongLength + (long)map[str[i]]; 
            }

            return decoded;
        }

        public static string GetTimestamp()
        {
            string now = Encode(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            if(now != prev)
            {
                seed = 0;
                prev = now;
                return now;
            }
            return now + "." + Encode(seed++);
        }
    }
}