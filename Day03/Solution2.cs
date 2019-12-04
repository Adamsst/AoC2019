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

            Dictionary<int, (int, int)> path1 = new Dictionary<int, (int, int)>();
            Dictionary<int, (int, int)> path2 = new Dictionary<int, (int, int)>();

            GenerateLocs(nums1, path1);
            GenerateLocs(nums2, path2);

            foreach (var kvp in path1)
            {
                if (path2.ContainsValue(kvp.Value))
                {
                    int p2Key = path2.Where(x => x.Value == kvp.Value).Select(p => p.Key).First();
                    if ((p2Key + kvp.Key) < minimumManhatten)
                    {
                        Console.WriteLine((p2Key + kvp.Key));
                        minimumManhatten = (p2Key + kvp.Key);
                    }
                }
            }

            Console.Read();
        }

        static void GenerateLocs(List<string> input, Dictionary<int, (int, int)> output)
        {
            int x = 0;
            int y = 0;
            int key = 1;

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
                            if (!output.ContainsValue((x, y)))
                            {
                                output.Add(key, (x, y));
                            }
                            key++;
                            temp++;
                        }
                        break;
                    case 'D':
                        while (temp < max)
                        {
                            y--;
                            if (!output.ContainsValue((x, y)))
                            {
                                output.Add(key, (x, y));
                            }
                            key++;
                            temp++;
                        }
                        break;
                    case 'L':
                        while (temp < max)
                        {
                            x--;
                            if (!output.ContainsValue((x, y)))
                            {
                                output.Add(key, (x, y));
                            }
                            key++;
                            temp++;
                        }
                        break;
                    case 'R':
                        while (temp < max)
                        {
                            x++;
                            if (!output.ContainsValue((x, y)))
                            {
                                output.Add(key, (x, y));
                            }
                            key++;
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