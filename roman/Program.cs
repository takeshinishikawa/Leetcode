using System;
using roman;


namespace roman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("IIII"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
            Console.WriteLine(RomanToInt("T"));
            Console.WriteLine(RomanToInt("MMMM"));
        }


        static int RomanToInt(string s)
        {
            //Verify if respects the min and max lenght
            if (s.Length < 1 || s.Length > 15)
            {
                Console.WriteLine("The value do not respect the constraints");
                return 0;
            }

            int needle = 0;
            //Verify if there is any invalid numeric roman symbol
            while (needle < s.Length)
            {
                if (s[needle] != 'I' && s[needle] != 'V' && s[needle] != 'X' && s[needle] != 'L' && s[needle] != 'C' && s[needle] != 'D' && s[needle] != 'M')
                {
                    Console.Write("The value do not respect the constraints. Invalid symbol. ");
                    return 0;
                }
                needle++;
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
            //Verify if respects the range proposed
            if (result < 1 || result > 3999)
            {
                Console.Write("The value do not respect the constraints. Value is not in the range from 1 to 3999. ");
                return 0;
            }
            return result;
        }
    }
}