namespace Tests.Sort;

public class QuickSortTest
{
    [Theory]
    [MemberData(nameof(ArraysToSort))]
    public void QuickSort_SortsCorrectly(int[] input)
    {
        // Arrange
        var array = (int[])input.Clone();
        
        // Act
        Algorithms.Sort.QuickSort(array);
        
        // Arrange
        AssertSameMultiset(array, input);
    }
    
    public static TheoryData<int[]> ArraysToSort =>
    [
        [],
        [1],
        [2, 1],
        [3, 1, 2],
        [5, 3, 8, 4, 2],
        [1, 2, 3, 4, 5],
        [5, 4, 3, 2, 1],
        [7, 7, 7, 7],
        [0, -1, 5, -10, 3],
        [int.MaxValue, 0, int.MinValue]
    ];
    
    private static void AssertSameMultiset(int[] original, int[] sorted)
    {
        var a = (int[])original.Clone();
        var b = (int[])sorted.Clone();

        Array.Sort(a);
        Array.Sort(b);

        Assert.Equal(a, b);
    }
}