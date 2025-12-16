namespace Tests.Recursion;

public class FibonacciTest
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(7, 13)]
    [InlineData(8, 21)]
    [InlineData(9, 34)]
    [InlineData(10, 55)]
    public void Fibonacci_ReturnsCorrectValue(int n, long expected)
    {
        var result = Algorithms.Recursion.Fibonacci(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    public void Fibonacci_RespectsRecurrenceRelation(int n)
    {
        var fn = Algorithms.Recursion.Fibonacci(n);
        var fn1 = Algorithms.Recursion.Fibonacci(n - 1);
        var fn2 = Algorithms.Recursion.Fibonacci(n - 2);

        Assert.Equal(fn1 + fn2, fn);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    public void Fibonacci_IsNonDecreasing(int n)
    {
        var current = Algorithms.Recursion.Fibonacci(n);
        var next = Algorithms.Recursion.Fibonacci(n + 1);

        Assert.True(next >= current);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5)]
    [InlineData(int.MinValue)]
    public void Fibonacci_ThrowsException_ForNegativeInput(int n)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Algorithms.Recursion.Fibonacci(n));
    }
}