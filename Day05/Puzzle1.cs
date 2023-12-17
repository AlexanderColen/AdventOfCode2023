using AdventOfCode2023.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day05
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var maps = new List<List<string>>();
            List<string> currentMap = null;

            foreach (var line in input)
            {
                if (line.EndsWith(':')) {
                    currentMap = new List<string>();
                } else if (currentMap != null)
                {
                    if (line.Length == 0)
                    {
                        maps.Add(currentMap);
                        currentMap = null;
                    } else
                    {
                        currentMap.Add(line);
                    }
                }
            }

            maps.Add(currentMap);

            var lowestLocation = long.MaxValue;

            foreach (var seed in input[0].Replace("seeds: ", "").Split(' '))
            {
                var value = long.Parse(seed);

                foreach (var map in maps)
                {
                    foreach (var line in map)
                    {
                        var numbers = new Regex("\\d+").Matches(line).ToList().Select((x, a) => long.Parse(x.Value)).ToList();

                        if (numbers[1] <= value && value <= (numbers[1] + numbers[2] - 1))
                        {
                            value += numbers[0] - numbers[1];
                            break;
                        }
                    }
                }

                if (value < lowestLocation)
                {
                    lowestLocation = value;
                }
            }

            Console.WriteLine($"Lowest location number: {lowestLocation}");
        }
    }
}