using AdventOfCode2023.utils;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day03
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalPartSum = 0;
            var symbolRegex = new Regex("[^\\d\\.]");
            
            for (var y = 0; y < input.Count; y++)
            {
                foreach (var symbol in symbolRegex.Matches(input[y]))
                {
                    var x = input[y].IndexOf(symbol.ToString());

                    // Check line above.
                    totalPartSum += ExtractPartNumbers(input[y - 1].Substring(x - 3, 7), true);

                    // Check directly to left or right.
                    totalPartSum += ExtractPartNumbers(input[y].Substring(x - 3, 7), false);

                    // Check line below.
                    totalPartSum += ExtractPartNumbers(input[y+1].Substring(x - 3, 7), true);

                    // Replace the symbol with a period afterwards to prevent issues with duplicate symbols in lines.
                    var chars = input[y].ToCharArray();
                    chars[x] = '.';
                    input[y] = new string(chars);
                }
            }

            Console.WriteLine($"Sum of part numbers: {totalPartSum}");
        }

        private int ExtractPartNumbers(string line, bool includeMiddle)
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

            return leftPartNumber + rightPartNumber;
        }
    }
}