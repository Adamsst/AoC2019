using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int index = 0;
            bool go = true;

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                numbers = line.Split(',').ToList().Select(int.Parse).ToList();
            }

            numbers[1] = 12;
            numbers[2] = 2;

            while (go)
            {
                switch (numbers[index])
                {
                    case 1:
                        numbers[numbers[index + 3]] = numbers[numbers[index + 1]] + numbers[numbers[index + 2]];
                        break;
                    case 2:
                        numbers[numbers[index + 3]] = numbers[numbers[index + 1]] * numbers[numbers[index + 2]];
                        break;
                    case 99:
                        go = false;
                        break;
                    default:
                        Console.WriteLine($"Error: {index}");
                        break;
                }

                index += 4;
            }

            Console.WriteLine(numbers[0]);
            Console.Read();
        }
    }
}