namespace advent_of_code_2023_csharp.day1;

public class DayOne
{
    public static void Run()
    {
        Console.WriteLine("Day 1!");

        string fileloc =
            "/Users/catiaribeiro/RiderProjects/advent-of-code-2023-csharp/advent-of-code-2023-csharp/day1/input.txt";

        int total = 0;

        using (StreamReader read = new StreamReader(fileloc))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                char[] numbers = Array.Empty<char>();
                foreach (char c in line)
                {
                    if (char.IsNumber(c))
                    {
                        numbers = numbers.Concat(new char[] { c }).ToArray();
                    }
                }

                if (numbers.Length == 0)
                {
                    continue;
                }

                total += int.Parse(numbers[0] + numbers[^1].ToString());
            }

            Console.WriteLine("Answer: " + total);
        }
    }
}