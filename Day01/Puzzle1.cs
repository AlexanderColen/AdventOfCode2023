using AdventOfCode2023.utils;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day01
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalCalibrationValues = 0;

            foreach (var line in input) {
                var re = new Regex("[0-9]");
                var matches = re.Matches(line);
                totalCalibrationValues += int.Parse($"{matches[0]}{matches[^1]}");
            }

            Console.WriteLine($"Sum of calibration values: {totalCalibrationValues}");
        }
    }
}