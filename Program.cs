using System;

namespace AdventOfCode2023
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    var day = args[0].PadLeft(2, '0');
                    var dayNamespace = $"AdventOfCode2023.Day{day}";
                    try
                    {
                        Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle1"));

                        if (args[0] != "25")
                        {
                            try
                            {
                                Activator.CreateInstance(Type.GetType(dayNamespace + ".Puzzle2"));
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine($"\nDay {day} - Puzzle 2 does not exist.");
                            }
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"\nDay {day} - Puzzle 1 does not exist.");
                    }
                    break;

                case 2:
                    var day_ = args[0].PadLeft(2, '0');
                    var dayNamespace_ = $"AdventOfCode2023.Day{day_}";
                    try
                    {
                        Activator.CreateInstance(Type.GetType($"{dayNamespace_}.Puzzle{args[1]}"));
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"\nDay {day_} Puzzle {args[1]} does not exist.");
                    }
                    break;

                default:
                    Console.WriteLine("Please supply a day to run the puzzle(s) for.");
                    break;
            }
        }
    }
}
