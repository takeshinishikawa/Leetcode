using System;
using pascal;


namespace pascal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generate(0);
            for (int numRows = 1; numRows <= 30; numRows++)
            {
                int counter1 = 1;

                foreach (var item in Generate(numRows))
                {
                    int counter2 = 1;

                    Console.Write("[");
                    foreach (var number in item)
                    {
                        if (counter2 != item.Count)
                            Console.Write($"{number},");
                        else
                            Console.Write($"{number}");
                        counter2++;
                    }
                    if (counter1 != numRows)
                        Console.Write("],");
                    else
                        Console.Write("]");
                    counter1++;
                }
                Console.WriteLine();
            }
        }
        static public IList<IList<int>> Generate(int numRows)
        {
            if (numRows < 1 || numRows > 30)
                throw new ArgumentOutOfRangeException(null, "The program accepts only inputs from 1 to 30.");
                        
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> currRow = new List<int>();

            while (numRows > 0)
            {
                var nextRow = new List<int>();

                nextRow.Add(1);
                if (currRow.Count > 0)
                {
                    for (var i = 0; i < currRow.Count - 1; i++)
                    {
                        var val = currRow[i] + currRow[i + 1];
                        nextRow.Add(val);
                    }
                    nextRow.Add(1);
                }
                currRow = nextRow;
                result.Add(currRow);
                numRows--;
            }
            return result;
        }
    }
}