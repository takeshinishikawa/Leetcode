using System;
using roman;


namespace roman
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }


        static int RomanToInt(string s)
        {
            if (s.Length < 1 || s.Length > 15)
            {
                Console.WriteLine("The value do not respect the constraints");
                return 0;
            }
            var romanChars = new Dictionary<char, int>();
            romanChars.Add('I', 1);
            romanChars.Add('V', 5);
            romanChars.Add('X', 10);
            romanChars.Add('L', 50);
            romanChars.Add('C', 100);
            romanChars.Add('D', 500);
            romanChars.Add('M', 1000);

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int currNumber = 0;
                int nextNumber = 0;
                romanChars.TryGetValue(s[i], out currNumber);
                if (i < s.Length - 1)
                    romanChars.TryGetValue(s[i + 1], out nextNumber);
                if (i + 1 < s.Length && currNumber < nextNumber)
                    result -= currNumber;
                else
                    result += currNumber;
            }
            return result;
        }
    }
}