using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums1 = new List<string>();
            List<string> nums2 = new List<string>();
            int index = 0;
            bool go = true;
            int minimumManhatten = int.MaxValue;

            foreach (string line in File.ReadLines(@"input.txt"))
            {
                if (nums1.Count == 0)
                {
                    nums1 = line.Split(',').ToList();
                }
                else
                {
                    nums2 = line.Split(',').ToList();
                }
            }

            List<(int,int)> path1 = new List<(int, int)>();
            List<(int, int)> path2 = new List<(int, int)>();

            GenerateLocs(nums1, path1);
            GenerateLocs(nums2, path2);

            foreach (var coords in path1)
            {
                if (path2.Contains(coords))
                {
                    if ((Math.Abs(coords.Item1) + Math.Abs(coords.Item2)) < minimumManhatten)
                    {
                        Console.WriteLine((Math.Abs(coords.Item1) + Math.Abs(coords.Item2)));
                        minimumManhatten = (Math.Abs(coords.Item1) + Math.Abs(coords.Item2));
                    }
                }
            }

            Console.Read();
        }

        static void GenerateLocs(List<string> input, List<(int, int)> output)
        {
            int x = 0;
            int y = 0;

            foreach (string s in input)
            {
                int max = Convert.ToInt32(s.Substring(1));
                int temp = 0;
                switch (s[0])
                {
                    case 'U':
                        while (temp < max)
                        {
                            y++;
                            output.Add((x,y));
                            temp++;
                        }
                        break;
                    case 'D':
                        while (temp < max)
                        {
                            y--;
                            output.Add((x, y));
                            temp++;
                        }
                        break;
                    case 'L':
                        while (temp < max)
                        {
                            x--;
                            output.Add((x, y));
                            temp++;
                        }
                        break;
                    case 'R':
                        while (temp < max)
                        {
                            x++;
                            output.Add((x, y));
                            temp++;
                        }
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
    }
}