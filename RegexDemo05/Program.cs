using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexDemo05
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string>
            {
                "(?x)Hey#This is a comment",
                "He(?# This is a comment ...)y",
                "H(?i)e(?-i)y",
                @"(?m)^hey$",
                "(he)y",
                "(?n)(he)(?-n)y",
                "(?x) \r\n h e y"
            };


            var inputs = new List<string>
            {
                "hey\nhey", " hey\nhey", " hey\n hey", "Hey", "hey", " HEy" , "HEY", " hey", "hey ", " hey "
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

                        foreach (Group group in match.Groups)
                        {
                            Console.WriteLine($"\t\t\tGroup at index {group.Index} has value {group.Value}");
                        }
                    }
                });
            });

            Console.ReadKey();
        }
    }
}
