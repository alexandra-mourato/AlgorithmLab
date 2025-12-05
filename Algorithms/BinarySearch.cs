namespace Algorithms;

public static class BinarySearch
{
    public static int Search(int[] array, int value)
    {
        var low = 0;
        var high = array.Length - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2; 

            if (array[mid] == value)
            {
                return mid;
            }

            if (array[mid] < value)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }
}
