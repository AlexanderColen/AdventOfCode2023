using AdventOfCode2023.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day03
{
    class Puzzle2 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalGearRatioSum = 0;
            var symbolRegex = new Regex("\\*");
            
            for (var y = 0; y < input.Count; y++)
            {
                foreach (var symbol in symbolRegex.Matches(input[y]))
                {
                    var x = input[y].IndexOf(symbol.ToString());

                    var partNumbers = new List<int>();

                    // Check line above.
                    partNumbers.AddRange(ExtractPartNumbers(input[y - 1].Substring(x - 3, 7), true));

                    // Check directly to left or right.
                    partNumbers.AddRange(ExtractPartNumbers(input[y].Substring(x - 3, 7), false));

                    // Check line below.
                    partNumbers.AddRange(ExtractPartNumbers(input[y+1].Substring(x - 3, 7), true));

                    // Filter out all zeroes.
                    partNumbers = partNumbers.Where((x) => x != 0).ToList();

                    if (partNumbers.Count() == 2)
                    {
                        totalGearRatioSum += partNumbers.Aggregate((x, a) => x * a);
                    }

                    // Replace the symbol with a period afterwards to prevent issues with duplicate symbols in lines.
                    var chars = input[y].ToCharArray();
                    chars[x] = '.';
                    input[y] = new string(chars);
                }
            }

            Console.WriteLine($"Sum of gear ratios: {totalGearRatioSum}");
        }

        private List<int> ExtractPartNumbers(string line, bool includeMiddle)
        {
            var leftPartNumber = 0;
            var rightPartNumber = 0;

            // Middle.
            if (includeMiddle)
            {
                if (!int.TryParse(line.Substring(1, 3), out leftPartNumber))
                {
                    if (!int.TryParse(line.Substring(2, 3), out leftPartNumber))
                    {
                        if (!int.TryParse(line.Substring(3, 3), out leftPartNumber))
                        {
                            if (!int.TryParse(line.Substring(2, 2), out leftPartNumber))
                            {
                                if (!int.TryParse(line.Substring(3, 2), out leftPartNumber))
                                {
                                    int.TryParse(line.Substring(3, 1), out leftPartNumber);
                                }
                            }
                        }
                    }
                }
            }

            if (leftPartNumber == 0)
            {
                // Left side.
                if (!int.TryParse(line.Substring(0, 3), out leftPartNumber))
                {
                    if (!int.TryParse(line.Substring(1, 2), out leftPartNumber))
                    {
                        int.TryParse(line.Substring(2, 1), out leftPartNumber);
                    }
                }

                // Right side.
                if (!int.TryParse(line.Substring(4, 3), out rightPartNumber))
                {
                    if (!int.TryParse(line.Substring(4, 2), out rightPartNumber))
                    {
                        int.TryParse(line.Substring(4, 1), out rightPartNumber);
                    }
                }
            }

            return new List<int>() { leftPartNumber, rightPartNumber };
        }
    }
}