using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2023.utils
{
    abstract class Puzzle
    {
        public Puzzle()
        {
            Console.WriteLine($"Day {GetType().Namespace[^2..]} - Puzzle {GetType().Name[^1..]}");
            RunPuzzle();
        }

        public virtual void RunPuzzle()
        {
            throw new NotImplementedException();
        }

        public List<string> ReadPuzzleInputAsStringList()
        {
            using var streamReader = new StreamReader(@$"Day{GetType().Namespace[^2..]}/input.txt");

            var input = new List<string>();

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                input.Add(line);
            }

            return input;
        }

        public List<int> ReadPuzzleInputAsIntList()
        {
            using var streamReader = new StreamReader(@$"Day{GetType().Namespace[^2..]}/input.txt");

            var input = new List<int>();

            string line;

            while ((line = streamReader.ReadLine()) != null)
            {
                input.Add(int.Parse(line));
            }

            return input;
        }
    }
}