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
}