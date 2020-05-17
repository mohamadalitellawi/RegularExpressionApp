using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegularExpressionSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var patterns = new List<string> { "a*b", "a+b", "a?b" };
            //var inputs = new List<string> { "a", "b", "ab", "aab", "abb" };

            // Escaping Special Characters
            var patterns = new List<string> { "\\?", @"\?", Regex.Escape("?") };
            var inputs = new List<string> { "Hello?" };

            patterns.ForEach(pattern =>
            {
                Console.WriteLine($"Regular Expression: {pattern }");
                var regex = new Regex(pattern);
                inputs.ForEach(input =>
                {
                    Console.WriteLine($"\tInput Pattern: {input }");
                    var results = regex.Matches(input);

                    if (results.Count <= 0)
                        Console.WriteLine("\t\tNo matches found.");


                    foreach (Match result in results)
                        Console.WriteLine($"\t\tMatch found at index {result.Index}. Length: {result.Length}");

                });
            });
            Console.ReadKey();
        }
    }
}
