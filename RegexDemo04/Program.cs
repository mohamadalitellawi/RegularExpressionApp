using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexDemo04
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string>
            {
                @"\b",
                @"\B",
                @"^hi",
                @"^hi$"
            };


            var inputs = new List<string>
            {
                "a b", "a", " ", "", "hi", " hi" , " hi ", "him", " him", " him "
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

                    foreach (Match matche in matches)
                        Console.WriteLine($"\t\tMatch found at index {matche.Index}. Length: {matche.Length}");
                });
            });

            Console.ReadKey();
        }
    }
}
