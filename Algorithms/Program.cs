using System.Globalization;

public class Program
{
    public static void Main()
    {
        int[] arr = { 2, 3, 4, 10, 40 };
        int[] unSortedArr = { 24, 3, 44, 10, 78, 1, 2 };
        int x = 10;

        var aa = solution("09:00", "11:42");
        var bb = solution("10:00", "13:21");
        var cc = solution("09:00", "16:00");
        var dd = solution("09:00", "10:00");
        var ff = solution("09:00", "09:10");
        Console.WriteLine(solution(999999999));


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

        #region Merge Sort O(n log n)

        unSortedArr = new int[] { 24, 3, 44, 10, 78, 1, 2 };

        Console.WriteLine(
            "Merge Sort O(n log n): " +
            MergeSort(unSortedArr, 0, unSortedArr.Length - 1)
            .Select(x => x.ToString())
            .Aggregate((c, n) => c + ',' + n));

        #endregion

        #region Quick Sort O(n^2)

        unSortedArr = new int[] { 24, 3, 44, 10, 78, 1, 2 };

        Console.WriteLine(
            "Quick Sort O(n^2): " +
            QuickSort(unSortedArr, 0, unSortedArr.Length - 1)
            .Select(x => x.ToString())
            .Aggregate((c, n) => c + ',' + n));

        #endregion

        #region Radix Sort O(nk)

        unSortedArr = new int[] { 24, 3, 44, 10, 78, 1, 2 };

        Console.WriteLine(
            "Radix Sort O(nk): " +
            Radixsort(unSortedArr, unSortedArr.Length)
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

    /// <summary>
    /// Merge
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="l"></param>
    /// <param name="m"></param>
    /// <param name="r"></param>
    public static void Merge(int[] arr, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];

        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;

        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements
        // of L[] if any
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Copy remaining elements
        // of R[] if any
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    /// <summary>
    /// MergeSort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public static int[] MergeSort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            // Find the middle
            // point
            int m = l + (r - l) / 2;

            // Sort first and
            // second halves
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);

            // Merge the sorted halves
            Merge(arr, l, m, r);
        }
        return arr;
    }

    /// <summary>
    /// Swap
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    /// <summary>
    /// Partition
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    static int Partition(int[] arr, int low, int high)
    {

        // pivot
        int pivot = arr[high];

        // Index of smaller element and
        // indicates the right position
        // of pivot found so far
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {

            // If current element is smaller
            // than the pivot
            if (arr[j] < pivot)
            {

                // Increment index of
                // smaller element
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return (i + 1);
    }

    /// <summary>
    /// Quick Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="low"></param>
    /// <param name="high"></param>
    public static int[] QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {

            // pi is partitioning index, arr[p]
            // is now at right place
            int pi = Partition(arr, low, high);

            // Separately sort elements before
            // partition and after partition
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
        return arr;
    }

    /// <summary>
    /// get max
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int GetMax(int[] arr, int n)
    {
        int mx = arr[0];
        for (int i = 1; i < n; i++)
            if (arr[i] > mx)
                mx = arr[i];
        return mx;
    }

    /// <summary>
    /// Count Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    /// <param name="exp"></param>
    public static void CountSort(int[] arr, int n, int exp)
    {
        int[] output = new int[n]; // output array
        int i;
        int[] count = new int[10];

        // initializing all elements of count to 0
        for (i = 0; i < 10; i++)
            count[i] = 0;

        // Store count of occurrences in count[]
        for (i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        // Change count[i] so that count[i] now contains
        // actual
        //  position of this digit in output[]
        for (i = 1; i < 10; i++)
            count[i] += count[i - 1];

        // Build the output array
        for (i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        // Copy the output array to arr[], so that arr[] now
        // contains sorted numbers according to current
        // digit
        for (i = 0; i < n; i++)
            arr[i] = output[i];
    }

    /// <summary>
    /// Radix Sort
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="n"></param>
    public static int[] Radixsort(int[] arr, int n)
    {
        // Find the maximum number to know number of digits
        int m = GetMax(arr, n);

        // Do counting sort for every digit. Note that
        // instead of passing digit number, exp is passed.
        // exp is 10^i where i is current digit number
        for (int exp = 1; m / exp > 0; exp *= 10)
            CountSort(arr, n, exp);

        return arr;
    }



    public static int solution(string E, string L)
    {
        TimeSpan e = TimeSpan.ParseExact(E, "hh\\:mm", CultureInfo.InvariantCulture);
        TimeSpan l = TimeSpan.ParseExact(L, "hh\\:mm", CultureInfo.InvariantCulture);

        int h = (l - e).Hours;
        int m = (l - e).Minutes;

        int finalCost = 2;

        if (h < 1 && m > 0)
            return finalCost + 3;
        if (h > 0 && h < 2 && m <= 0)
            return finalCost + 3;
        if (h >= 2 && m <= 0)
            return finalCost + 3 + ((h - 1) * 4);
        if (h >= 2 && m > 0)
        {
            return finalCost + 3 + (h * 4);
        }
        return finalCost;
    }


    public static int solution(int N)
    {
        int result = 0;
        for (int i = 0; i < N / 2; i++)
        {
            int num = (int)Math.Pow(2, i);
            if (N % num == 0)
            {
                result = i;
            }
        }
        return N > 0 && N <= 2 ? 1 : result;
    }


    public static int arrr(int[] A)
    {
        int result = -1;
        foreach (int item in A)
        {
            if (A.Count(x => x == item) > 1)
            {
                result = item;
                return result;
            }
        }
        return result;
    }
}