using AdventOfCode2023.utils;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var totalPointsSum = 0;
            
            for (var i = 0; i < input.Count; i++)
            {
                var cardPoints = 0;

                input[i] = new Regex("Card\\s+\\d+:").Replace(input[i], "");

                var parts = input[i].Split(" | ");

                foreach (var winningNumber in  new Regex("\\s+").Split(parts[0].Trim()))
                {
                    foreach (var number in new Regex("\\s+").Split(parts[1].Trim()))
                    {
                        if (winningNumber == number)
                        {
                            if (cardPoints == 0)
                            {
                                cardPoints++;
                            } else
                            {
                                cardPoints *= 2;
                            }
                        }
                    }
                }

                totalPointsSum += cardPoints;
            }

            Console.WriteLine($"Sum of scratchcard points: {totalPointsSum}");
        }
    }
}