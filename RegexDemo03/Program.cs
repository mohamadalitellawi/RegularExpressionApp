using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegexDemo03
{
    class Program
    {
        static void Main(string[] args)
        {
            var patterns = new List<string>
            {
                @"([A-Za-z]+).*\$(\d+.\d+)"
            };

            var inputs = new List<string>
            {
                @"
                    |------------------------|
                    | Receipt from           |
                    | Alexanderu's shop      |
                    |                        |
                    | Thanks for shopping!   |
                    |-----------|------------|
                    | Item      | Price $USD |
                    |-----------|------------|
                    | Shoes     |   $47.99   |
                    | Cabbage   |    $2.99   |
                    | Carrots   |    $1.99   |
                    | Chicken   |    $9.99   |
                    | Beef      |   $12.47   |
                    | Shirt     |    $5.97   |
                    | Salt      |    $2.99   |
                    |-----------|------------|
                "
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

                    Console.WriteLine("Simple replacement results: {0}",
                        Regex.Replace(input,@"(Chicken)(.*) \$(9.99)", @"$1$2 $$0.00"));

                    // advanced replacement
                    var results = Regex.Replace(input, pattern, match =>
                     {
                         if (match.Groups[1].Value == "Chicken")
                         {
                             return match.Value.Replace(match.Groups[2].Value,"0.00");
                         }
                         return match.Value;
                     });
                    Console.WriteLine("Advanced replacement results: {0}", results);

                });
            });
            Console.ReadKey();
        }
    }
}
