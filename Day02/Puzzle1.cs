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
            var totalValidIDSum = Enumerable.Range(1, 100).Sum();
            // Regular expression matching invalid 2 digit draws.
            var regExp = new Regex("(([1][3-9]|[2-9][0-9]) red)|(([1][4-9]|[2-9][0-9]) green)|(([1][5-9]|[2-9][0-9]) blue)");

            for (var i = 0; i < input.Count; i++) {
                if (regExp.IsMatch(input[i]))
                {
                    totalValidIDSum -= i + 1;
                }
            }

            Console.WriteLine($"Sum of valid game IDs: {totalValidIDSum}");
        }
    }
}