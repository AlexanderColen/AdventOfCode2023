using AdventOfCode2023.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day02
{
    class Puzzle2 : Puzzle
    {
        public override void RunPuzzle()
        {
            var games = ReadPuzzleInputAsStringList();
            var totalPowerSum = 0;
            var colors = new List<string>() { "red", "green", "blue" };

            foreach (var game in games)
            {
                var fewestCubes = new List<int>();

                foreach (var color in colors)
                {
                    var fewest = 0;

                    foreach (var match in new Regex($"\\d+ {color}").Matches(game))
                    {
                        var current = int.Parse(match.ToString().Split(' ')[0]);
                        if (fewest < current)
                        {
                            fewest = current;
                        }
                    }

                    fewestCubes.Add(fewest);
                }

                totalPowerSum += fewestCubes.Aggregate((a, x) => a * x);
            }

            Console.WriteLine($"Sum of total set powers: {totalPowerSum}");
        }
    }
}