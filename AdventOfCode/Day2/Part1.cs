﻿using System.Text.RegularExpressions;

namespace AdventOfCode.Day2;

public static class Part1
{
    public static int Execute()
    {
        var input = File.ReadAllLines("Day2/Day2Input.txt");
        return GetSumOfValidGameNumbers(input);
    }

    private static int GetSumOfValidGameNumbers(string[] games)
    {
        return games
            .Where(s => !IsInvalidGame(s))
            .Sum(x => int.Parse(new Regex(@"(\d+)(?=:)").Matches(x).First().Value));
    }

    private static bool IsInvalidGame(string gameString)
    {
        var countsRegex = new Regex(@"(\d+ (blue|red|green))");

        return countsRegex.Matches(gameString).Select(match =>
            {
                var values = match.Value.Split(' ');
                return new GameSet(int.Parse(values.First()), values.Last());
            })
            .Any(gameSet => !Validator.IsValidGameSet(gameSet));
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