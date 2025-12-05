using System.Diagnostics;

namespace Playground.Utils;

public static class Benchmark
{
    public static TimeSpan TimeIt(Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        
        return sw.Elapsed;
    }
}