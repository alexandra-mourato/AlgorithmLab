namespace Algorithms;

public static class Search
{
    public static int LinearSearch(int[] array, int target)
    {
        for (var i = 0; i < array.Length; ++i)
        {
            if (array[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    
    public static int BinarySearch(int[] array, int target)
    {
        var low = 0;
        var high = array.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2; 

            if (array[mid] == target)
            {
                return mid;
            }

            if (array[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }
}
