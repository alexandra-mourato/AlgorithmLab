using Playground.Utils;

namespace Playground.Experiments;

public static class ArrayListComparison
{
    public static void SequentialRead(int n)
    {
        var (array, list) = CreateRandomArrayAndList(n);
        long sumArray = 0;
        long sumList = 0;

        var arrayTime = Benchmark.TimeIt(() =>
        {
            foreach (var t in array)
            {
                sumArray += t;
            }
        });

        var listTime = Benchmark.TimeIt(() =>
        {
            foreach (var t in list)
            {
                sumList += t;
            }
        });

        Console.WriteLine("=== Sequential Read ===");
        Console.WriteLine($"Array sum: {sumArray}");
        Console.WriteLine($"List sum:  {sumList}");
        Console.WriteLine($"Array sequential read: {arrayTime.TotalMilliseconds:F2} ms");
        Console.WriteLine($"List sequential read:  {listTime.TotalMilliseconds:F2} ms");
    }

    public static void RandomRead(int n)
    {
        var (array, list) = CreateRandomArrayAndList(n);
        var randomIndexes = CreateRandomArray(n / 10);
        
        long sumArray = 0;
        long sumList = 0;

        var arrayTime = Benchmark.TimeIt(() =>
        {
            foreach (var t in randomIndexes)
            {
                sumArray += array[t];
            }
        });

        var listTime = Benchmark.TimeIt(() =>
        {
            foreach (var t in randomIndexes)
            {
                sumList += list[t];
            }
        });

        Console.WriteLine("=== Random Read ===");
        Console.WriteLine($"Array random read: {arrayTime.TotalMilliseconds:F2} ms");
        Console.WriteLine($"List random read:  {listTime.TotalMilliseconds:F2} ms");
    }

    public static void InsertMiddle(int n)
    {
        var (array, list) = CreateRandomArrayAndList(n);

        var rand = new Random(123);
        var values = new int[n];
        for (var i = 0; i < n; i++)
        {
            values[i] = rand.Next();
        }

        long arraySink = 0;
        long listSink = 0;

        var arrayTime = Benchmark.TimeIt(() =>
        {
            var current = array;

            for (var i = 0; i < n; i++)
            {
                var mid = current.Length / 2;
                var next = new int[current.Length + 1];

                Array.Copy(current, 0, next, 0, mid);
                next[mid] = values[i];
                Array.Copy(current, mid, next, mid + 1, current.Length - mid);

                current = next;
            }

            arraySink = current.Length > 0 ? current[current.Length / 2] : 0;
        });

        var listTime = Benchmark.TimeIt(() =>
        {
            var l = new List<int>(list);

            for (var i = 0; i < n; i++)
            {
                var mid = l.Count / 2;
                l.Insert(mid, values[i]);
            }

            listSink = l.Count > 0 ? l[l.Count / 2] : 0;
        });

        Console.WriteLine("=== Middle Insert ===");
        Console.WriteLine($"Insertions: {n}");
        Console.WriteLine($"Array middle insert: {arrayTime.TotalMilliseconds:F2} ms");
        Console.WriteLine($"List  middle insert: {listTime.TotalMilliseconds:F2} ms");
    }


    private static (int[] array, List<int> list) CreateRandomArrayAndList(int n)
    {
        var array = new int[n];
        var list = new List<int>(n);

        for (var i = 0; i < n; i++)
        {
            array[i] = i;
            list.Add(i);
        }

        return (array, list);
    }

    private static int[] CreateRandomArray(int n)
    {
        var rand = new Random(100);
        var randomIndexes = new int[n];
        for (var i = 0; i < randomIndexes.Length; i++)
        {
            randomIndexes[i] = rand.Next(0, n);
        }
        
        return randomIndexes;
    }
}