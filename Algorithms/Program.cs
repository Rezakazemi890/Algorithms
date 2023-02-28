public class Program
{
    public static void Main()
    {
        int[] arr = { 2, 3, 4, 10, 40 };
        int x = 10;

        #region Linear Search Test O(n)

        int linearSearchResult = LinearSearch(arr, x);
        if (linearSearchResult == -1)
            Console.WriteLine(
                "LinearSearch: Element is not present in array");
        else
            Console.WriteLine("LinearSearch: Element is present at index "
                              + linearSearchResult);

        //--------------------------------------------------------
        int linearSearchRecursiveResult = LinearSearchRecursive(arr, arr.Count(), x);
        if (linearSearchRecursiveResult == -1)
            Console.WriteLine(
                "LinearSearchRecursive: Element is not present in array");
        else
            Console.WriteLine("LinearSearchRecursive: Element is present at index "
                              + linearSearchRecursiveResult);
        #endregion

        Console.ReadLine();
    }

    /// <summary>
    /// LinearSearch
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int LinearSearch(int[] arr, int x)
    {
        int N = arr.Length;
        for (int i = 0; i < N; i++)
        {
            if (arr[i] == x)
                return i;
        }
        return -1;
    }

    /// <summary>
    /// LinearSearchRecursive
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="size"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static int LinearSearchRecursive(int[] arr, int size, int key)
    {
        if (size == 0)
        {
            return -1;
        }
        else if (arr[size - 1] == key)
        {
            // Return the index of found key.
            return size - 1;
        }
        else
        {
            return LinearSearchRecursive(arr, size - 1, key);
        }
    }
}