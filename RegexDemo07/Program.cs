using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RegexDemo07
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string>
            {
                @"<.+>",
                @"<.+?>",
                @"(a+(aa)+(aaa)+(aa)+a+)+b."
            };


            var inputs = new List<string>
            {
                "a<tag>b</tag>c",
                "aaaaaaaaaaaaaaaaaaaab",
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
            };

            patterns.ForEach(pattern =>
            {
                Console.WriteLine($"Regular Expression: {pattern }");
                var regex = new Regex(pattern);
                inputs.ForEach(input =>
                {
                    Console.WriteLine($"\tInput Pattern: {input }");
                    var watch = new Stopwatch();
                    watch.Start();
                    var matches = regex.Matches(input);

                    if (matches.Count <= 0)
                        Console.WriteLine("\t\tNo matches found.");

                    foreach (Match match in matches)
                    {
                        Console.WriteLine($"\t\tMatch found at index {match.Index}. Length: {match.Length}");
                    }
                    watch.Stop();
                    Console.WriteLine("\t\tRuntime: {0}ms", watch.Elapsed.TotalMilliseconds);
                });
            });

            Console.ReadKey();
        }
    }
}
