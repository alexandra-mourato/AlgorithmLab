using Algorithms;
using Playground.Utils;

namespace Playground.Experiments;

public static class SearchComparison
{
    public static void LinearVsBinary(int[] lengths, int runsPerLength = 5)
    {
        Console.WriteLine();
        Console.WriteLine(" N (items) | Linear (ms) | Binary (ms) | Speedup ");
        Console.WriteLine(new string('-',  50));

        foreach (var n in lengths)
        {
            var array = Enumerable.Range(0, n).ToArray();
            var target = n - 1;

            var linearTotalMs = 0.0;
            var binaryTotalMs = 0.0;
            
            for(var i = 0; i < runsPerLength; i++)
            {
                linearTotalMs = Benchmark.TimeIt(() => { Search.LinearSearch(array, target); }).TotalMilliseconds;
                binaryTotalMs = Benchmark.TimeIt(() => { Search.BinarySearch(array, target); }).TotalMilliseconds;
            }
            
            var linearAvg = linearTotalMs / runsPerLength;
            var binaryAvg = binaryTotalMs / runsPerLength;
            var speedup = binaryAvg > 0 ? linearAvg / binaryAvg : double.PositiveInfinity;
        
            Console.WriteLine("{0,10:N0} | {1,11:0.000} | {2,11:0.000} | {3,7:0.0}x", n, linearTotalMs, binaryTotalMs, speedup);
        }
        
        Console.WriteLine();
    }
}