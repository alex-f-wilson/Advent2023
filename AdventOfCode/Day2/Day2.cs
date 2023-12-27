using System.Text.RegularExpressions;

namespace AdventOfCode.Day2;

public static class Day2
{
    public static int Execute()
    {
        var input = File.ReadAllLines("Day2/Day2Input.txt");
        return GetSumOfValidGameNumbers(input);
    }

    private static bool IsInvalidGame(string gameString)
    {
        // Matches "3 green" or "6 blue" or "12 red"
        var countsRegex = new Regex(@"(\d+ (blue|red|green))");

        return countsRegex.Matches(gameString).Select(r =>
            {
                var values = r.Value.Split(' ');
                return new GameSet(int.Parse(values.First()), values.Last());
            })
            .Any(m => !Validator.IsValidGameSet(m));
    }

    private static int GetSumOfValidGameNumbers(string[] games)
    {
        return games
            .Where(s => !IsInvalidGame(s))
            .Sum(x => int.Parse(new Regex(@"(\d+)(?=:)").Matches(x).First().Value));
    }
}

public static class Validator
{
    public static bool IsValidGameSet(GameSet set)
    {
        return set.Color switch
        {
            "red" when set.Count > 12 => false,
            "green" when set.Count > 13 => false,
            "blue" when set.Count > 14 => false,
            _ => true
        };
    }
}

public record GameSet(int Count, string Color);