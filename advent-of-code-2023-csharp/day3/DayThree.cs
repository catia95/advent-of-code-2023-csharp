using System.Text.RegularExpressions;

namespace advent_of_code_2023_csharp.day3;

public class DayThree
{
    public static void Run()
    {
        Console.WriteLine("Day 3!");
        string fileloc =
            "/Users/catiaribeiro/RiderProjects/advent-of-code-2023-csharp/advent-of-code-2023-csharp/day3/input.txt";
        int total = 0;

        using (StreamReader read = new StreamReader(fileloc))
        {
            string line1 = "";
            string line2 = "";
            string line3 = "";

            string currentLine;
            while ((currentLine = read.ReadLine()) != null)
            {
                if (String.IsNullOrEmpty(line1))
                {
                    line1 = currentLine;
                    continue;
                }

                if (String.IsNullOrEmpty(line2))
                {
                    line2 = currentLine;
                    continue;
                }

                if (String.IsNullOrEmpty(line3))
                {
                    line3 = currentLine;
                }

                Console.WriteLine("line1: " + line1);
                Console.WriteLine("line2: " + line2);
                Console.WriteLine("line3: " + line3);

                var symbolMatches = Regex.Matches(line2, @"[^.\d]").Cast<Match>().ToList();
                foreach (Match match in symbolMatches)
                {
                    int index = match.Index;
                    // Console.WriteLine("Match: " + match);
                    total = addNumbersParrallel(match, false, line1, total);
                    total = addNumbersParrallel(match, true, line2, total);
                    total = addNumbersParrallel(match, false, line3, total);
                    // Console.WriteLine("Total: " +  total + "\n");
                }

                //Reset for next iteration
                line1 = line2;
                line2 = line3;
                line3 = "";
                Console.WriteLine("Answer: " + total);
            }
        }
    }

    private static int addNumbersParrallel(Match match, bool skipCurrentIndex, string line, int total)
    {
        var number = 0;
        var earliestNumberIndex = match.Index;
        var lastNumberIndex = match.Index;
        if (char.IsNumber(line[match.Index]) && !skipCurrentIndex)
        {
            (number, earliestNumberIndex, lastNumberIndex) = getNumber(line, match.Index);
            total += number;
            return total;
        }

        if (line.Length >= match.Index + 1 && char.IsNumber(line[match.Index - 1]))
        {
            (number, earliestNumberIndex, lastNumberIndex) = getNumber(line, match.Index - 1);
            total += number;
        }

        if (line.Length >= match.Index + 1 && char.IsNumber(line[match.Index + 1]) && lastNumberIndex <= match.Index)
        {
            (number, earliestNumberIndex, lastNumberIndex) = getNumber(line, match.Index + 1);
            total += number;
        }

        return total;
    }

    private static (int, int earliestNumberIndex, int lastNumberIndex) getNumber(string line, int matchIndex)
    {
        int earliestNumberIndex = matchIndex;
        int lastNumberIndex = matchIndex;
        char[] number = Array.Empty<char>();
        for (int i = matchIndex; i >= 0; i--)
        {
            if (!char.IsNumber(line[i]))
            {
                earliestNumberIndex = i + 1;
                break;
            }

            number = number.Concat(new char[] { line[i] }).ToArray();
        }

        Array.Reverse(number);

        for (int i = matchIndex + 1; i < line.Length; i++)
        {
            if (!char.IsNumber(line[i]))
            {
                lastNumberIndex = i - 1;
                break;
            }

            number = number.Concat(new char[] { line[i] }).ToArray();
        }

        string s = new string(number);
        return (Int32.Parse(s), earliestNumberIndex, lastNumberIndex);
    }
}