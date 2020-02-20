using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");

            int width = 25;
            int height = 6;

            int dictionaryTracker = 0;
            int layerTracker = 0;
            int charTracker = 0;

            int fewestOnesIndex = int.MaxValue;
            int fewestOnesCount = int.MaxValue;

            Dictionary<int,List<string>> Layers = new Dictionary<int, List<string>>();

            while (charTracker < input.Length)
            {
                if(!Layers.ContainsKey(dictionaryTracker))
                    Layers.Add(dictionaryTracker,new List<string>());

                Layers[dictionaryTracker].Add(input.Substring(charTracker,width));
                charTracker += width;
                layerTracker += 1;
                if (layerTracker % height == 0)
                {
                    dictionaryTracker++;
                    layerTracker = 0;
                }
            }

            foreach (var kvp in Layers)
            {
                int tempOnes = 0;

                foreach (var curString in kvp.Value)
                {
                    tempOnes += curString.Count(x => x == '0');
                }

                if (tempOnes < fewestOnesCount)
                {
                    fewestOnesCount = tempOnes;
                    fewestOnesIndex = kvp.Key;
                }
            }

            int Ones = 0;
            int Twos = 0;

            foreach (var curString in Layers[fewestOnesIndex])
            {
                Ones += curString.Count(x => x == '1');
                Twos += curString.Count(x => x == '2');
            }

            Console.WriteLine(Ones * Twos);
            Console.Read();
        }
    }
}