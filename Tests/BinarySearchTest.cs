using Algorithms;

namespace Tests;

public class BinarySearchTest
{
    [Theory]
    [InlineData(new int[0], 5)]
    [InlineData(new[] { 10, 20, 30 }, 1)]
    [InlineData(new[] { 10, 20, 30 }, 100)]
    [InlineData(new []{ 1, 2, 3, 4, 5 }, 6)]
    [InlineData(new []{ 1 }, 6)]
    [InlineData(new[] { -10, -3, 0, 2, 9 }, 1)]
    public void Test_OutOfRange(int[] array, int target)
    {
        // Arrange
        var expectedIndex = -1;
        
        // Act
        var index = Search.BinarySearch(array, target);

        // Assert
        Assert.Equal(expectedIndex, index);
    }
    
    [Theory]
    [InlineData(new [] { 1, 2, 3, 4, 5 }, 1, 0)]
    [InlineData(new [] { 1, 2, 3, 4, 5 }, 5, 4)]
    public void Test_Boundaries(int[] array, int target, int expectedIndex)
    {
        // Arrange & Act
        var index = Search.BinarySearch(array, target);

        // Assert
        Assert.Equal(expectedIndex, index);
        Assert.True(array[index] == target);
    }
    
    [Theory]
    [InlineData(new[] { -10, -3, 0, 2, 9 }, -10, 0)]
    [InlineData(new[] { -10, -3, 0, 2, 9 }, -3, 1)]
    [InlineData(new[] { -10, -3, 0, 2, 9 }, 9, 4)]
    public void Test_Negatives(int[] array, int target, int expectedIndex)
    {
        // Arrange & Act
        var index = Search.BinarySearch(array, target);
        
        // Assert
        Assert.Equal(expectedIndex, index);
        Assert.True(array[index] == target);
    }
    
    [Theory]
    [InlineData(new [] { 1, 1, 2, 3, 3, 4 }, 1, 0)]
    [InlineData(new [] { 1, 2, 3, 4, 5 }, 3, 2)]
    [InlineData(new [] { 1, 2, 3, 4, 5, 5 }, 5, 4)]
    public void Test_Duplicates_Returns_First_Occurrence(int[] array, int target, int expectedIndex)
    {
        // Arrange & Act
        var index = Search.BinarySearch(array, target);

        // Assert
        Assert.Equal(expectedIndex, index);
        Assert.True(array[index] == target);
    }
}
