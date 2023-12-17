using AdventOfCode2023.utils;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day06
{
    class Puzzle2 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var time = long.Parse(input[0].Replace(" ", "").Split(':')[1]);
            var record = long.Parse(input[1].Replace(" ", "").Split(':')[1]);

            var winningWays = 0;

            for (var t = 1; t <= time - 1; t++)
            {
                if ((time - t) * t > record)
                {
                    winningWays++;
                }
            }

            Console.WriteLine($"Total ways to beat the record: {winningWays}");
        }
    }
}