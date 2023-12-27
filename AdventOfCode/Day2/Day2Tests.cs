using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day2;

public class Day2Tests
{
    [Fact(DisplayName = "Execute")]
    public void Execute()
    {
        Day2.Execute().Should().Be(2617);
    }
}