using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day1;

public class Day1
{
    [Fact]
    public void PartOneAnswer()
    {
        PartOne().Should().Be(54632);
    }

    private int PartOne()
    {
        var input = File.ReadAllLines("Day1Input.txt");

        const string regex = "([0-9])";

        return input.Sum(s =>
        {
            var matches = new Regex(regex).Matches(s);

            if (matches.Count > 1)
                return ConcatTwoStringNumbersToInt(matches.First().ToString(), matches.Last().ToString());

            return ConcatTwoStringNumbersToInt(matches.First().ToString(), matches.First().ToString());
        });
    }


    [Fact]
    public void PartTwoTest()
    {
        PartTwo().Should().Be(54019);
    }

    private int PartTwo()
    {
        var input = File.ReadAllLines("Day1Input.txt");
        return input.Sum(ParseStringIntoInt);
    }


    private static int ConcatTwoStringNumbersToInt(string first, string second)
    {
        var result = int.Parse(string.Concat(GetIntValueFromString(first), GetIntValueFromString(second)));
        return result;
    }

    private static int ParseStringIntoInt(string value)
    {
        const string regex = "([0-9]|one|two|three|four|five|six|seven|eight|nine)";

        var leftToRightMatches = new Regex(regex).Matches(value);
        var rightToLeftMatches = new Regex(regex, RegexOptions.RightToLeft).Matches(value);

        var lastMatchedValueInString = rightToLeftMatches.First().Value;

        if (rightToLeftMatches.Count >= 2)
            return ConcatTwoStringNumbersToInt(leftToRightMatches.First().Value, lastMatchedValueInString);

        var soleMatchedValue = GetIntValueFromString(lastMatchedValueInString);
        return ConcatTwoStringNumbersToInt(soleMatchedValue.ToString(), soleMatchedValue.ToString());
    }

    private static int GetIntValueFromString(string value)
    {
        var numbersAndSpellings = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        int number;
        if (!char.IsDigit(value.First()))
            numbersAndSpellings.TryGetValue(value, out number);
        else
            number = int.Parse(value);

        return number;
    }
}