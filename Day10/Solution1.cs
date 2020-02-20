using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static List<(int,int)> checkedPoints = new List<(int, int)>();
        static void Main(string[] args)
        {
            string line;
            StreamReader file = new StreamReader(@"input.txt");
            List<string> galaxy = new List<string>();
            int curMax = 0;
            while ((line = file.ReadLine()) != null)
            {
                galaxy.Add(line);
                Console.WriteLine(line);
            }
            Console.WriteLine();

            for (int i = 0; i < galaxy.Count; i++)
            {
                for (int j = 0; j < galaxy[i].Length; j++)
                {
                    if (galaxy[j][i] != '#')
                        continue;
            
                    AnalyzeSpacePoint(i, j, galaxy, out var total);
            
                    if (total >= curMax)
                    {
                        curMax = total;
                        Console.WriteLine($"CurMax:{curMax} at {i},{j}");
                    }
                }
            }

            Console.Read();
        }

        private static void AnalyzeSpacePoint(int i, int j, List<string> galaxy, out int total)
        {
            total = 0;

            //desc x, desc y
            for (int y = i; y >= 0; y--)
            {
                for (int x = j; x >= 0; x--)
                {
                    if (galaxy[y][x] != '#')
                        continue;
            
                    if (!PathIsNotUnique((x, y), (i, j)))
                    {
                        total++;
                        checkedPoints.Add((x,y));
                    }
                }
            }
            
            //desc x, asc y
            for (int y = i; y < galaxy.Count;  y++)
            {
                for (int x = j; x >= 0; x--)
                {
                    if (galaxy[y][x] != '#')
                        continue;
            
                    if (!PathIsNotUnique((x, y), (i, j)))
                    {
                        total++;
                        checkedPoints.Add((x, y));
                    }
                }
            }

            //asc x, desc y
            for (int y = i; y >= 0; y--)
            {
                for (int x = j + 1; x < galaxy[0].Length; x++)
                {
                    if (galaxy[y][x] != '#')
                        continue;

                    if (!PathIsNotUnique((x, y), (i, j)))
                    {
                        total++;
                        checkedPoints.Add((x, y));
                    }
                }
            }

            //asc x, asc y
            for (int y = i; y < galaxy.Count; y++)
            {
                for (int x = j + 1; x < galaxy[0].Length; x++)
                {
                    if (galaxy[y][x] != '#')
                        continue;

                    if (!PathIsNotUnique((x, y), (i,j)))
                    {
                        total++;
                        checkedPoints.Add((x, y));
                    }
                }
            }
            checkedPoints.Clear();
        }

        private static bool PathIsNotUnique((int, int) input, (int,int) comparePoint)//This function is all sorts of messed up, 2,2 & 3,3 have the same slope from 0. as do -2,-2 and -3,-3
        {
            if (input == comparePoint)
                return true;
            if (input.Item1 == comparePoint.Item1 && input.Item2 > comparePoint.Item2)
            {
                return checkedPoints.Any(x => x.Item1 == comparePoint.Item1 && x.Item2 > comparePoint.Item2);
            }
            if (input.Item1 == comparePoint.Item1 && input.Item2 < comparePoint.Item2)
            {
                return checkedPoints.Any(x => x.Item1 == comparePoint.Item1 && x.Item2 < comparePoint.Item2);
            }
            if (input.Item2 == comparePoint.Item2 && input.Item1 > comparePoint.Item1)
            {
                return checkedPoints.Any(x => x.Item2 == comparePoint.Item2 && x.Item1 > comparePoint.Item1);
            }
            if (input.Item2 == comparePoint.Item2 && input.Item1 < comparePoint.Item1)
            {
                return checkedPoints.Any(x => x.Item2 == comparePoint.Item2 && x.Item1 < comparePoint.Item1);
            }

            return checkedPoints.Any(x => (
                                            ((double)(comparePoint.Item2 - input.Item2) / (comparePoint.Item1 - input.Item1)) 
                                           == 
                                           ((double) (comparePoint.Item2 - x.Item2) / (comparePoint.Item1 - x.Item1)))
                                            && (Math.Sign(comparePoint.Item2 - input.Item2) == Math.Sign(comparePoint.Item2 - x.Item2))
                                            && (Math.Sign(comparePoint.Item1 - input.Item1) == Math.Sign(comparePoint.Item1 - x.Item1))
            );
        }
    }
}
