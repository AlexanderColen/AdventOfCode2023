using AdventOfCode2023.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day07
{
    class Puzzle1 : Puzzle
    {
        public override void RunPuzzle()
        {
            var input = ReadPuzzleInputAsStringList();
            var rankedList = new List<Tuple<string, int, int>>();

            foreach (var line in input)
            {
                var hand = new Regex("[A-Z0-9]+").Match(line).Value.ToList();
                var dict = new Dictionary<char, int>();

                foreach (var card in hand)
                {
                    if (dict.ContainsKey(card))
                    {
                        dict[card]++;
                    } else
                    {
                        dict[card] = 1;
                    }
                }

                var sortedKeys = dict.Keys.ToList();
                sortedKeys.Sort((k1, k2) => dict[k2] - dict[k1]);
                var cards = "";
                foreach (var key in sortedKeys)
                {
                    for (var i = 0; i <= dict[key] - 1; i++)
                    {
                        cards += key;
                    }
                }

                var cardCount = cards.Count((c) => c == cards[0]);
                var rank = 7;

                if (cardCount == 5)
                {
                    rank = 1;
                } else if (cardCount == 4)
                {
                    rank = 2;
                } else if (cardCount == 3)
                {
                    if (cards.Count((c) => c == cards[4]) == 2)
                    {
                        rank = 3;
                    } else
                    {
                        rank = 4;
                    }
                } else if (cardCount == 2)
                {
                    if (cards.Count((c) => c == cards[3]) == 2)
                    {
                        rank = 5;
                    } else
                    {
                        rank = 6;
                    }
                }
                    
                rankedList.Add(Tuple.Create(line, rank, int.Parse(new Regex("\\d+").Match(line.Split(' ')[1]).Value)));
            }

            rankedList.Sort((h1, h2) =>
            {
                var sort = 0;

                if (h1.Item2 != h2.Item2)
                {
                    sort = h2.Item2 - h1.Item2;
                }

                var i = 0;
                while (sort == 0)
                {
                    var order = "AKQJT98765432";
                    sort = order.IndexOf(h2.Item1[i]) - order.IndexOf(h1.Item1[i]); 
                    i++;
                }

                return sort;
            });

            var totalWinnings = 0;
               
            for (var i = 0; i <= rankedList.Count - 1; i++)
            {
                totalWinnings += rankedList[i].Item3 * (i + 1);
            }

            Console.WriteLine($"Total winnings: {totalWinnings}");
        }
    }
}