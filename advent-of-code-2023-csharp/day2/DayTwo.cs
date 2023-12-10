using System.Text.RegularExpressions;

namespace advent_of_code_2023_csharp.day2;

public class DayTwo
{
    public static void Run()
    {
        Console.WriteLine("Day 2!");

        string fileloc =
            "/Users/catiaribeiro/RiderProjects/advent-of-code-2023-csharp/advent-of-code-2023-csharp/day2/input.txt";

        int total = 0;

        using (StreamReader read = new StreamReader(fileloc))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                Console.WriteLine("line: " + line);
                char[] chars = { ';', ':', '\n' };
                string[] gamePart = line.Split(chars);
                Console.WriteLine("game parts: " + gamePart.Length);

                
                bool valid = true;
                for (int i = 1; i < gamePart.Length; i++)
                {
                    string part = gamePart[i];
                    Console.WriteLine("game part: " + part);

                    List<string> redCounterCount;
                    redCounterCount = Regex.Matches(part, @"(\d+)(?=[ ]{1}red)").Cast<Match>().Select(p => p.Value).ToList();
                    if (redCounterCount.Count > 0 && int.Parse(redCounterCount[0]) > 12)
                    {
                        valid = false;
                        break;
                    }
                    
                    List<string> greenCounterCount;
                    greenCounterCount = Regex.Matches(part, @"(\d+)(?=[ ]{1}green)").Cast<Match>().Select(p => p.Value).ToList();
                    if (greenCounterCount.Count > 0 && int.Parse(greenCounterCount[0]) > 13)
                    {
                        valid = false;
                        break;
                    }
                    
                    List<string> blueCounterCount;
                    blueCounterCount = Regex.Matches(part, @"(\d+)(?=[ ]{1}blue)").Cast<Match>().Select(p => p.Value).ToList();
                    if (blueCounterCount.Count > 0 && int.Parse(blueCounterCount[0]) > 14)
                    {
                        valid = false;
                        break;
                    }
                }
                
                Console.WriteLine("**valid: " + valid + "\n");
                
                if (valid)
                {
                    List<string> gameNumber;
                    gameNumber = Regex.Matches(gamePart[0], @"(\d+)").Cast<Match>().Select(p => p.Value).ToList();
                    Console.WriteLine("**game number: " + gameNumber[0] + "\n");
                    
                    total += int.Parse(gameNumber[0]); 
                }
                
            }

            Console.WriteLine("Answer: " + total);
        }
    }
}