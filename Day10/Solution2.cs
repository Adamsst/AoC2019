using System;
using System.Collections.Generic;
using System.Drawing;
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
            int curMax = 0;
            Dictionary<Point, char> galaxy= new Dictionary<Point,Char>();
            int yTrack = 0;

            while ((line = file.ReadLine()) != null)
            {
                int xTrack = 0;
                var temp = line.ToCharArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    galaxy.Add(new Point(xTrack,yTrack), temp[i]);
                    xTrack++;
                }
                
                yTrack++;
            }
            Console.WriteLine();

            //CurMax: 296 at 17,23
            #region Part 2
            int baseX = 17;    //17;
            int baseY = 23;    //23;

            int vaporTarget = 200;//actual 200
            int curVapor = 0;

            Dictionary<Point,Char> newGalaxy = new Dictionary<Point, char>();

            var tempGalaxy = galaxy
                .Where(x => x.Key.X == baseX && x.Key.Y < baseY)
                .OrderByDescending(x => x.Key.Y)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }

            tempGalaxy = galaxy
                .Where(x => x.Key.X > baseX && x.Key.Y < baseY)
                .OrderByDescending(x => (float)(Math.Abs(x.Key.Y-baseY)) / (Math.Abs(x.Key.X - baseX)))
                .ThenByDescending(x => x.Key.Y)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }

            tempGalaxy = galaxy
                .Where(x => x.Key.X > baseX && x.Key.Y == baseY)
                .OrderBy(x => x.Key.X)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }
            
            tempGalaxy = galaxy
                .Where(x => x.Key.X > baseX && x.Key.Y > baseY)
                .OrderBy(x => (float)(Math.Abs(x.Key.Y - baseY)) / (Math.Abs(x.Key.X - baseX)))
                .ThenBy(x => x.Key.X)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }

            tempGalaxy = galaxy
                .Where(x => x.Key.X == baseX && x.Key.Y > baseY)
                .OrderBy(x => x.Key.X)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }
            
            tempGalaxy = galaxy
                .Where(x => x.Key.X < baseX && x.Key.Y > baseY)
                .OrderByDescending(x => (float)(Math.Abs(x.Key.Y - baseY)) / (Math.Abs(x.Key.X - baseX)))
                .ThenBy(x => x.Key.Y)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }

            tempGalaxy = galaxy
                .Where(x => x.Key.X < baseX && x.Key.Y == baseY)
                .OrderByDescending(x => x.Key.X)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }
            
            tempGalaxy = galaxy
                .Where(x => x.Key.X < baseX && x.Key.Y < baseY)
                .OrderBy(x => (float)(Math.Abs(x.Key.Y - baseY)) / (Math.Abs(x.Key.X - baseX)))
                .ThenByDescending(x => x.Key.Y)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var g in tempGalaxy)
            {
                newGalaxy.Add(g.Key, g.Value);
            }

            foreach (var p in newGalaxy.Keys)
            {
                Console.WriteLine($"{p.X},{p.Y}");
            }

            Point prevKey = new Point(int.MaxValue,int.MaxValue);
           
            while (curVapor < vaporTarget)
            {
                for (int i = 0; i < newGalaxy.Count; i++)
                {
                    var item = newGalaxy.ElementAt(i);
           
                    if (((float)Math.Abs(item.Key.Y - baseY) / Math.Abs(item.Key.X - baseX)) == ((float)Math.Abs(prevKey.Y - baseY) / Math.Abs(prevKey.X - baseX)))
                    {
                        continue;
                    }
           
                    if (item.Value == '#')
                    {
                        newGalaxy[item.Key] = '.';
                        prevKey = item.Key;
                        curVapor++;
                        Console.WriteLine($"CurVapor: {curVapor} at {item.Key.X},{item.Key.Y}");
                    }
                    else
                    {
                        prevKey = new Point(100, 1);//This is Hacky
                    }

                    if(curVapor == 200)
                        Console.WriteLine(item.Key.X*100 + item.Key.Y);

                }
            }

            #endregion Part 2

            Console.WriteLine("Done.");
            Console.Read();
        }
    }
}
