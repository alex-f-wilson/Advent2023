using System.Text.RegularExpressions;

namespace AdventOfCode.Day2;

public class Part2
{
    public static int Execute()
    {
        var input = File.ReadAllLines("Day2/Day2Input.txt");
        return GetPowerOfSetOfCubes(input);
    }

    private static int GetPowerOfSetOfCubes(string[] games)
    {
        var countsRegex = new Regex(@"(\d+ (blue|red|green))");

        return games.Select(x =>
        {
            var sets = countsRegex.Matches(x).Select(r =>
                {
                    var values = r.Value.Split(' ');
                    return new GameSet(int.Parse(values.First()), values.Last());
                })
                .GroupBy(set => set.Color, (_, gameSets) => gameSets.OrderByDescending(e => e.Count).First());
            return sets.Aggregate(1, (current, num) => current * num.Count);
        }).Sum();
     }
}