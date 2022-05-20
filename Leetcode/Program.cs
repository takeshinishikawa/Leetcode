using System;
using strstr;


namespace strstr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int result = StrStr("hello", "ll");
            //Console.WriteLine(result);
            int result = StrStr("mississippi", "issipi");
            Console.WriteLine(result);
        }


        public static int StrStr(string haystack, string needle)
        {
            int h = 0;
            int n;
            int aux;

            n = needle.Length;
            if (n == 0)
                return 0;
            //while (haystack[h] != '\0' && (h < haystack.Length))

            while (h < haystack.Length && needle.Length <= haystack.Length)
            {
                aux = 0;
                while (((h + aux) < haystack.Length) && (haystack[h + aux] == needle[aux]))
                {
                    if (aux + 1 == n)
                        return (h);
                    aux++;
                }
                h++;
            }
            return (-1);
        }

    }
}