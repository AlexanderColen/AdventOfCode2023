using AdventOfCode2023.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04
{
    class Puzzle2 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var scratchcards = new Dictionary<int, int>();
            var scratchcardWinnings = new List<int>();

            for (var i = 0; i < input.Count; i++)
            {
                scratchcards.Add(i, 1);

                var matchingNumbers = 0;

                input[i] = new Regex("Card\\s+\\d+:").Replace(input[i], "");

                var parts = input[i].Split(" | ");

                foreach (var winningNumber in new Regex("\\s+").Split(parts[0].Trim()))
                {
                    foreach (var number in new Regex("\\s+").Split(parts[1].Trim()))
                    {
                        if (winningNumber == number)
                        {
                            matchingNumbers++;
                        }
                    }
                }

                scratchcardWinnings.Add(matchingNumbers);
            }

            for (var i = 0; i < scratchcards.Count; i++)
            {
                for (var j = 1; j < scratchcardWinnings[i] + 1; j++)
                {
                    scratchcards[j + i] += scratchcards[i];
                }
            }

            Console.WriteLine($"Total number of scratchcards: {scratchcards.Sum(x => x.Value)}");
        }
    }
}