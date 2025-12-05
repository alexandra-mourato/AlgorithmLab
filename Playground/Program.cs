using Algorithms;
using Playground.Utils;

const int n = 20_000_000;
var array = Enumerable.Range(0, n).ToArray();

const int target = n - 1;

_ = Search.LinearSearch(array, target);
_ = Search.BinarySearch(array, target);

var linearIndex = -1;
var linearTime = Benchmark.TimeIt(() =>
{
    linearIndex = Search.LinearSearch(array, target);
});

var binaryIndex = -1;
var binaryTime = Benchmark.TimeIt(() =>
{
    binaryIndex = Search.BinarySearch(array, target);
});

Console.WriteLine($"N = {n:n0}, target = {target:n0}");
Console.WriteLine($"Linear index: {linearIndex}, time: {linearTime.TotalMilliseconds:0.000} ms");
Console.WriteLine($"Binary index: {binaryIndex}, time: {binaryTime.TotalMilliseconds:0.000} ms");
Console.WriteLine($"Speedup: ~{linearTime.TotalMilliseconds / binaryTime.TotalMilliseconds:0.0}x");

