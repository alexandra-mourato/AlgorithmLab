namespace Algorithms;

public static class Recursion
{
    public static int Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 0");
        }

        if (n <= 1)
        {
            return 1;
        }
        
        return n * Factorial(n - 1);
    }

    public static int Fibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 0");
        }

        if (n <= 1)
        {
            return n;
        }
        
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}