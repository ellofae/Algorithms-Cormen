/*
T(N) = T(N/2) + O(1) (the recurrence relation)
So, worst-case running time is O(log(n))
*/

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] {15, 12, 95, 34, 61, 52, 90, 73 };
        Console.WriteLine("Initial array: ");
        foreach (var i in arr)
            Console.Write(i + " ");
        Console.WriteLine();

        MergeSort(arr, 0, arr.Length);

        Console.WriteLine("\n\nSorted array: ");
        foreach (var i in arr)
            Console.Write(i + " ");

        int indx = BinarySearch(arr, 0, arr.Length, 90);
        Console.WriteLine($"\nIndex of 90: {indx}");
    }
    public static void MergeSort(int[] A, int start, int end)
    {
        if(end - start != 1)
        {
            int middle = (int)Math.Floor((decimal)(start + end) / 2);
            MergeSort(A, start, middle); // 0 (1) 2 -> 0 2     ->  0 1  and 1 2    so, that's the reason (end-start != 1)
            MergeSort(A, middle, end); // 2 (3) 4 -> 2 4       ->  2 3  and 3 4
            Merge(A, start, middle, end); 
        }
    }

    public static void Merge(int[] A, int start, int middle, int end)
    {
        List<int> L = new List<int>();
        List<int> R = new List<int>();

        for (int i = start; i < middle; i++)
            L.Add(A[i]);
        for (int j = middle; j < end; j++)
            R.Add(A[j]);

        L.Add(int.MaxValue);
        R.Add(int.MaxValue);

        int leftIndex = 0;
        int rightIndex = 0;

        for (int k = start; k < end; k++)
        {
            if (L[leftIndex] <= R[rightIndex])
            {
                A[k] = L[leftIndex];
                leftIndex += 1;
            }
            else
            {
                A[k] = R[rightIndex];
                rightIndex += 1;
            }
        }
    }

    
     public static int BinarySearch(int[] A, int start, int end, int key)
    {
        int middle = (end - start) / 2 + start;
        if (A[middle] > key)
        {
            return BinarySearch(A, 0, middle, key);
        }
        else if (A[middle] < key)
        {
            return BinarySearch(A, middle + 1, end, key);
        }
        else
            return middle;

    }
}
