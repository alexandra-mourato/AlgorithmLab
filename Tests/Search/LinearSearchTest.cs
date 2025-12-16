namespace Tests.Search;

public class LinearSearchTest
{
    [Theory]
    [InlineData(new[] { 10, 20, 30 }, 10, 0)]
    [InlineData(new[] { 10, 20, 30 }, 20, 1)]
    [InlineData(new[] { 10, 20, 30 }, 30, 2)]
    [InlineData(new[] { 5, 7, 7, 9  }, 7, 1)]
    [InlineData(new[] { -3, -2, -1, 0, 1 }, -3, 0)]
    [InlineData(new[] { -3, -2, -1, 0, 1 }, 0, 3)]
    [InlineData(new[] { -3, -2, -1, 0, 1 }, 1, 4)]
    public void LinearSearch_FindsElement(int [] array, int target, int expectedIndex)
    {
        var index = Algorithms.Search.LinearSearch(array, target);
        Assert.Equal(expectedIndex, index);
    }

    [Theory]
    [MemberData(nameof(MinusOneIndexData))]
    public void LinearSearch_ReturnsMinusOne(int [] array, int target, int expectedIndex)
    {
        var index = Algorithms.Search.LinearSearch(array, target);
        Assert.Equal(expectedIndex, index);
    }

    public static IEnumerable<object[]> MinusOneIndexData() =>
        new List<object[]>
        {
            new object[] { new[] { 10, 20, 30 }, 99, -1 },
            new object[] { Array.Empty<int>(), 10, -1 },
        };
}