using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
	static void Main(string[] args)
	{
		int mass = 0;
	
		foreach (string line in File.ReadLines(@"input.txt"))
		{
			int temp = Convert.ToInt32(line);
	
			int fuel = (temp / 3) - 2;
	
			while (fuel >= 1)
			{
				mass += fuel;
				fuel = (fuel / 3) - 2;
			}
		}
	
		Console.WriteLine(mass);
		Console.Read();
	}
}