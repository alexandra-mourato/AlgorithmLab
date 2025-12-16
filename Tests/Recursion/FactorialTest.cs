namespace Tests.Recursion;

public class FactorialTest
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    [InlineData(6, 720)]
    [InlineData(7, 5040)]
    [InlineData(8, 40320)]
    [InlineData(10, 3628800)]
    public void Factorial_ReturnsCorrectValue(int n, long expected)
    {
        var result = Algorithms.Recursion.Factorial(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(8)]
    public void Factorial_RespectsRecursiveDefinition(int n)
    {
        var fn = Algorithms.Recursion.Factorial(n);
        var fnMinus1 = Algorithms.Recursion.Factorial(n - 1);

        Assert.Equal(n * fnMinus1, fn);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(6)]
    public void Factorial_IsStrictlyIncreasing(int n)
    {
        var current = Algorithms.Recursion.Factorial(n);
        var next = Algorithms.Recursion.Factorial(n + 1);

        Assert.True(next > current);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(int.MinValue)]
    public void Factorial_ThrowsException_ForNegativeInput(int n)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Algorithms.Recursion.Factorial(n));
    }
}