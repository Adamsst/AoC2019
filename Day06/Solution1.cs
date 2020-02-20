using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            foreach (var entry in entries)
            {
                if(!galaxy.ContainsKey(entry.Item1))
                    galaxy.Add(entry.Item1, new List<string>());

                Recursion:
                bool goAgain = false;
                foreach (var gal in galaxy)
                {
                    if (gal.Key == entry.Item1 || gal.Value.Contains(entry.Item1))
                    {
                        if (!gal.Value.Contains(entry.Item2))
                        {
                            gal.Value.Add(entry.Item2);
                            goAgain = true;
                        }
                    }
                }

                if(goAgain)
                    goto Recursion;
            }

            //What an absolute hack the below is 
            Recursion2:
            bool goAgain2 = false;
            foreach (var gal1 in galaxy)
            {
                foreach (var gal2 in galaxy)
                {
                    if (gal1.Key == gal2.Key)
                        continue;

                    if (gal1.Value.Contains(gal2.Key))
                    {
                        foreach (var val in gal2.Value)
                        {
                            if (!gal1.Value.Contains(val))
                            {
                                gal1.Value.Add(val);
                                goAgain2 = true;
                            }
                        }
                    }
                }
            }

            if(goAgain2)
                goto Recursion2;

            Console.WriteLine(galaxy.Sum(x => x.Value.Count));

            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}