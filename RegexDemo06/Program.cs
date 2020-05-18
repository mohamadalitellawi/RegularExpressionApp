using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexDemo06
{
    class Program
    {
        static void Main(string[] args)
        {
           
                var patterns = new List<string>
            {
                "[A-Z]",
                "[A-Z-[Z]]",
                "a(?=b)",
                "a(?!b)",
                "(?<=c)a",
                "(?<!c)a"
            };


                var inputs = new List<string>
            {
                "", "a", "b", "ab", "ca", "cab" , "A", "B", "Z", "AA"
            };

                patterns.ForEach(pattern =>
                {
                    Console.WriteLine($"Regular Expression: {pattern }");
                    var regex = new Regex(pattern);
                    inputs.ForEach(input =>
                    {
                        Console.WriteLine($"\tInput Pattern: {input }");
                        var matches = regex.Matches(input);

                        if (matches.Count <= 0)
                            Console.WriteLine("\t\tNo matches found.");

                        foreach (Match match in matches)
                        {
                            Console.WriteLine($"\t\tMatch found at index {match.Index}. Length: {match.Length}");
                        }
                    });
                });

                Console.ReadKey();
            }
        }
    }

