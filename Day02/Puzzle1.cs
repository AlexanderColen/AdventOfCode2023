using AdventOfCode2023.utils;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day02
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalInvalidIDSum = 0;
            // Regular expression matching invalid 2 digit draws.
            var regExp = new Regex("(([1][3-9]|[2-9][0-9]) red)|(([1][4-9]|[2-9][0-9]) green)|(([1][5-9]|[2-9][0-9]) blue)");

            for (var i = 0; i < input.Count; i++) {
                if (regExp.IsMatch(input[i]))
                {
                    totalInvalidIDSum += i + 1;
                }
            }

            Console.WriteLine($"Sum of valid game IDs: {Enumerable.Range(1, 100).Sum() - totalInvalidIDSum}");
        }
    }
}