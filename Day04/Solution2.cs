using System;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            int puzzleMin = 271973;
            int puzzleMax = 785961;

            int count = 0;

            for (int temp = puzzleMin; temp <= puzzleMax; temp++)
            {
                var tempString = temp.ToString();
                bool foundConsecutive = false;
                for (int i = 0; i < tempString.Length - 1; i++)
                {
                    if ((int) tempString[i] > (int) tempString[i + 1])
                    {
                        goto TheEnd;
                    }
                    else if (tempString[i] == tempString[i + 1])
                    {

                        if (i == 0)
                        {
                            if (tempString[i + 1] != tempString[i + 2])
                                foundConsecutive = true;
                        }
                        else if (i == 4)
                        {
                            if (tempString[i] != tempString[i - 1])
                                foundConsecutive = true;
                        }
                        else
                        {
                            if (!(tempString[i - 1] == tempString[i] || tempString[i + 2] == tempString[i]))
                            {
                                foundConsecutive = true;
                            }
                        }
                    }
                }

                if (foundConsecutive)
                    count++;

                TheEnd: ;//continue
            }
 
            Console.WriteLine(count);
            Console.Read();
        }
    }
}