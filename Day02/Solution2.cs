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
            List<int> nums = new List<int>();
            List<int> numbers = new List<int>();
            int index = 0;
            bool go = true;

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                nums= line.Split(',').ToList().Select(int.Parse).ToList();
            }

            int noun = 0;
            int verb = 0;

            numbers = new List<int>(nums);
            numbers[1] = noun;//noun
            numbers[2] = verb;//verb
            var answer = 19690720;

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

                if (!go)
                {
                    if (numbers[0] == answer)
                    {
                        Console.WriteLine((100*noun) + verb);
                    }
                    else
                    {
                        go = true;
                        noun++;
                        if (noun == 100)
                        {
                            noun = 0;
                            verb++;
                        }
                        index = 0;
                        numbers = new List<int>(nums);
                        numbers[1] = noun;//noun
                        numbers[2] = verb;//verb
                    }
                }
                else
                {
                    index += 4;
                }

            }

            Console.Read();
        }
    }
}