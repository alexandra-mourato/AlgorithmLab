namespace Algorithms;

public static class Sort
{
    private static readonly Random Rng = new Random(123);

    public static void QuickSort(int[] array)
    {
        if (array.Length <= 1)
            return;

        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int low, int high)
    {
        while (true)
        {
            if (low >= high)
            {
                return;
            }

            var pivotIndex = Rng.Next(low, high + 1);
            Swap(array, pivotIndex, high);

            var p = Partition(array, low, high);
            QuickSort(array, low, p - 1);
            low = p + 1;
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        var pivot = array[high];
        var i = low - 1;

        for (var j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    private static void Swap(int[] array, int i, int j)
    {
        if (i == j) return;
        (array[i], array[j]) = (array[j], array[i]);
    }
}