using AdventOfCode2023.utils;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day06
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var times = new Regex("\\d+").Matches(input[0].Split(':')[1]).Select(x => int.Parse(x.Value)).ToArray();
            var records = new Regex("\\d+").Matches(input[1].Split(':')[1]).Select(x => int.Parse(x.Value)).ToArray();

            var errorMargin = 1;

            for (var i = 0; i <= times.Length - 1; i++)
            {
                var winningWays = 0;

                for (var t = 1; t <= times[i] - 1; t++)
                {
                    if ((times[i] - t) * t > records[i])
                    {
                        winningWays++;
                    }
                }

                errorMargin *= winningWays;
            }

            Console.WriteLine($"Total error margin after all races: {errorMargin}");
        }
    }
}