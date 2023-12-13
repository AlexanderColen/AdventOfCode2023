using AdventOfCode2023.utils;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day01
{
    class Puzzle2 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalCalibrationValues = 0;

            foreach (var line in input) {
                var re = new Regex("[0-9]");
                var matches = re.Matches(ReplaceWords(line));
                totalCalibrationValues += int.Parse($"{matches[0]}{matches[^1]}");
            }

            Console.WriteLine($"Sum of calibration values: {totalCalibrationValues}");
        }

        private static string ReplaceWords(string line)
        {
            var re = new Regex("(zero)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)");
            
            var matches = re.Matches(line);
            while (matches.Count > 0)
            {
                var toReplace = matches[0].ToString();
                var replaceWith = "";
                switch (toReplace)
                {
                    case "zero":
                        replaceWith = "z0o";
                        break;

                    case "one":
                        replaceWith = "o1e";
                        break;

                    case "two":
                        replaceWith = "t2o";
                        break;

                    case "three":
                        replaceWith = "t3e";
                        break;

                    case "four":
                        replaceWith = "f4r";
                        break;

                    case "five":
                        replaceWith = "f5e";
                        break;

                    case "six":
                        replaceWith = "s6x";
                        break;

                    case "seven":
                        replaceWith = "s7n";
                        break;

                    case "eight":
                        replaceWith = "e8t";
                        break;

                    case "nine":
                        replaceWith = "n9e";
                        break;

                    default:
                        break;
                }

                line = line.Replace(toReplace, replaceWith);
                matches = re.Matches(line);
            }

            return line;
        }
    }
}
