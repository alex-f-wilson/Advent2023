using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day2;

public class Day2Tests
{
    [Fact(DisplayName = "Execute Part 1")]
    public void Execute()
    {
        Part1.Execute().Should().Be(2617);
    }
    
    [Fact(DisplayName = "Execute Part 2")]
    public void Execute2()
    {
        Part2.Execute().Should().Be(59795);
    }
}