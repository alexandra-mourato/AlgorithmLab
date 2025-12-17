using Algorithms;

namespace Playground.Experiments;

public static class RecursionExperiment
{
    public static void Factorial(int n)
    {
        var factorial = Recursion.Factorial(n);
        Console.WriteLine("=== Factorial ===");
        Console.WriteLine($"Factorial of {n}: {factorial}");
    }

    public static void Fibonacci(int n)
    {
        var fibonacci = Recursion.Fibonacci(n);
        Console.WriteLine("=== Fibonacci ===");
        Console.WriteLine($"Fibonacci of {n}: {fibonacci}");
    }
}