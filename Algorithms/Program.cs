public class Program
{
    public static void Main()
    {
        int[] arr = { 2, 3, 4, 10, 40 };
        int[] unSortedArr = { 24, 3, 44, 10, 78, 1, 2 };
        int x = 10;

        #region Linear Search Test O(n)

        int linearSearchResult = LinearSearch(arr, x);
        if (linearSearchResult == -1)
            Console.WriteLine(
                "LinearSearch O(n): Element is not present in array");
        else
            Console.WriteLine("LinearSearch O(n): Element is present at index "
                              + linearSearchResult);

        //--------------------------------------------------------
        int linearSearchRecursiveResult = LinearSearchRecursive(arr, arr.Length, x);
        if (linearSearchRecursiveResult == -1)
            Console.WriteLine(
                "LinearSearchRecursive O(n): Element is not present in array");
        else
            Console.WriteLine("LinearSearchRecursive O(n): Element is present at index "
                              + linearSearchRecursiveResult);
        #endregion

        #region Binary Search Test O(Log n)

        int binarySearchResult = BinarySearch(arr, x);
        if (binarySearchResult == -1)
            Console.WriteLine(
                "BinarySearch O(Log n): Element is not present in array");
        else
            Console.WriteLine("BinarySearch O(Log n): Element is present at index "
                              + binarySearchResult);

        //--------------------------------------------------------
        int binarySearchRecursiveResult = BinarySearchRecursive(arr, 0, arr.Length, x);
        if (binarySearchRecursiveResult == -1)
            Console.WriteLine(
                "BinarySearchRecursive O(Log n): Element is not present in array");
        else
            Console.WriteLine("BinarySearchRecursive O(Log n): Element is present at index "
                              + binarySearchRecursiveResult);
        #endregion

        #region FibonaccianSearch Test O(Log n)

        int FibonaccianSearchResult = FibonaccianSearch(arr, x, arr.Length);
        if (FibonaccianSearchResult == -1)
            Console.WriteLine(
                "FibonaccianSearch O(Log n): Element is not present in array");
        else
            Console.WriteLine("FibonaccianSearch O(Log n): Element is present at index "
                              + FibonaccianSearchResult);
        #endregion

        #region Selection sort Test O(n^2)        

        Console.WriteLine(
            "Selection Sort O(n^2): " +
            SelectionSort(unSortedArr)
            .Select(x => x.ToString())
            .Aggregate((c, n) => c + ',' + n));

        #endregion

        #region Bubble Sort O(n^2)

        unSortedArr = new int[] { 24, 3, 44, 10, 78, 1, 2 };

        Console.WriteLine(
            "Bubble Sort O(n^2): " +
            BubbleSort(unSortedArr)
            .Select(x => x.ToString())
            .Aggregate((c, n) => c + ',' + n));

        #endregion

        #region Insertation Sort O(n^2)

        unSortedArr = new int[] { 24, 3, 44, 10, 78, 1, 2 };

        Console.WriteLine(
            "Insertation Sort O(n^2): " +
            InsertationSort(unSortedArr)
            .Select(x => x.ToString())
            .Aggregate((c, n) => c + ',' + n));

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

    /// <summary>
    /// BinarySearch
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int BinarySearch(int[] arr, int x)
    {
        int l = 0, r = arr.Length - 1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;

            // Check if x is present at mid
            if (arr[m] == x)
                return m;

            // If x greater, ignore left half
            if (arr[m] < x)
                l = m + 1;

            // If x is smaller, ignore right half
            else
                r = m - 1;
        }

        // if we reach here, then element was
        // not present
        return -1;
    }

    /// <summary>
    /// BinarySearch
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="firstIndex"></param>
    /// <param name="length"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int BinarySearchRecursive(int[] arr, int firstIndex, int length, int x)
    {
        if (length >= firstIndex)
        {
            int mid = firstIndex + (length - firstIndex) / 2;

            // If the element is present at the
            // middle itself
            if (arr[mid] == x)
                return mid;

            // If element is smaller than mid, then
            // it can only be present in left subarray
            if (arr[mid] > x)
                return BinarySearchRecursive(arr, firstIndex, mid - 1, x);

            // Else the element can only be present
            // in right subarray
            return BinarySearchRecursive(arr, mid + 1, length, x);
        }

        // We reach here when element is not present
        // in array
        return -1;
    }

    public static int FibonaccianSearch(int[] arr, int x, int length)
    {
        /* Initialize fibonacci numbers */
        int fibMMm2 = 0; // (m-2)'th Fibonacci No.
        int fibMMm1 = 1; // (m-1)'th Fibonacci No.
        int fibM = fibMMm2 + fibMMm1; // m'th Fibonacci

        /* fibM is going to store the smallest
        Fibonacci Number greater than or equal to n */
        while (fibM < length)
        {
            fibMMm2 = fibMMm1;
            fibMMm1 = fibM;
            fibM = fibMMm2 + fibMMm1;
        }

        // Marks the eliminated range from front
        int offset = -1;

        /* while there are elements to be inspected.
        Note that we compare arr[fibMm2] with x.
        When fibM becomes 1, fibMm2 becomes 0 */
        while (fibM > 1)
        {
            // Check if fibMm2 is a valid location
            int i = Math.Min(offset + fibMMm2, length - 1);

            /* If x is greater than the value at
            index fibMm2, cut the subarray array
            from offset to i */
            if (arr[i] < x)
            {
                fibM = fibMMm1;
                fibMMm1 = fibMMm2;
                fibMMm2 = fibM - fibMMm1;
                offset = i;
            }

            /* If x is less than the value at index
            fibMm2, cut the subarray after i+1 */
            else if (arr[i] > x)
            {
                fibM = fibMMm2;
                fibMMm1 = fibMMm1 - fibMMm2;
                fibMMm2 = fibM - fibMMm1;
            }

            /* element found. return index */
            else
                return i;
        }

        /* comparing the last element with x */
        if (fibMMm1 == 1 && arr[length - 1] == x)
            return length - 1;

        /*element not found. return -1 */
        return -1;
    }


    public static int[] SelectionSort(int[] arr)
    {
        int length = arr.Length;

        // One by one move boundary of unsorted subarray
        for (int i = 0; i < length - 1; i++)
        {
            // Find the minimum element in unsorted array
            int min_idx = i;
            for (int j = i + 1; j < length; j++)
                if (arr[j] < arr[min_idx])
                    min_idx = j;

            // Swap the found minimum element with the first
            // element
            int temp = arr[min_idx];
            arr[min_idx] = arr[i];
            arr[i] = temp;
        }
        return arr;
    }

    /// <summary>
    /// BubbleSort
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] BubbleSort(int[] arr)
    {
        int length = arr.Length;
        for (int i = 0; i < length - 1; i++)
            for (int j = 0; j < length - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    // swap temp and arr[i]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
        return arr;
    }

    /// <summary>
    /// InsertationSort
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] InsertationSort(int[] arr)
    {
        int length = arr.Length;
        for (int i = 1; i < length; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            // Move elements of arr[0..i-1],
            // that are greater than key,
            // to one position ahead of
            // their current position
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
        return arr;
    }
}