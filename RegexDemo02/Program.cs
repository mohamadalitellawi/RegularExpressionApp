using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexDemo02
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string>
            {
                @"^\d\d\d-\d\d\d-\d\d\d\d$"
            };

            var inputs = new List<string>
            {
                "5555555555",
                "(555)-555-5555",
                "012-345-6789",
                "555-555-5555",
                "555-555-555a",
                "5555-555-5555",
                "555-5555555",
                "000-000-0000",
                "a",
                "5.55-555-5555",
                "...-...-...."
            };

            patterns.ForEach(pattern =>
            {
                Console.WriteLine($"Regular Expression: {pattern }");
                var regex = new Regex(pattern);
                inputs.ForEach(input =>
                {
                    Console.WriteLine($"\tInput Pattern: {input }");
                    var isMatch = regex.IsMatch(input);
                    Console.WriteLine("\t\t{0}", isMatch ? "Accepted" : "Rejected");

                    if (!isMatch)
                        return;
                    var splits = Regex.Split(input, @"-\d\d\d-").ToList();
                    Console.WriteLine($"\t\t\tArea cpde: {splits[0]}");
                    Console.WriteLine($"\t\t\tLast 4 digits: {splits[1]}");
                });
            });
            Console.ReadKey();
        }
    }
}
