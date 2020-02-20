using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader file = new StreamReader(@"input.txt");
            Dictionary<string, List<string>> galaxy = new Dictionary<string, List<string>>();
            var entries = new List<(string,string)>();

            while ((line = file.ReadLine()) != null)
            {
                entries.Add((line.Split(')')[0], line.Split(')')[1]));
            }

            var You = new List<string>();
            var San = new List<string>();

            bool go = true;
            var target = "YOU";
            while (go)
            {
                HERE:
                foreach (var entry in entries)
                {
                    if (entry.Item2 == target)
                    {
                        You.Add(entry.Item1);
                        target = entry.Item1;
                        goto HERE;
                    }
                }
                go = false;
            }

            go = true;
            target = "SAN";
            while (go)
            {
                HEREAGAIN:
                foreach (var entry in entries)
                {
                    if (entry.Item2 == target)
                    {
                        San.Add(entry.Item1);
                        target = entry.Item1;
                        goto HEREAGAIN;
                    }
                }
                go = false;
            }

            var min = int.MaxValue;

            for (int i = 0; i < You.Count; i++)
            {
                if (San.Contains(You[i]))
                {
                    if(i + San.IndexOf(You[i]) < min)
                    {
                        min = i + San.IndexOf(You[i]);
                    }
                }
            }

            Console.WriteLine(min);

            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}