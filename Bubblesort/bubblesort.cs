/*
Worst-case time complexity: T(n) = sum from (j = 1) to (n = N - 1) = n - i, witch is n(n-1)/2, so O(n^2)
Best-case time complexity: O(n)
*/

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] {15, 12, 95, 34, 61, 52, 90, 73 };
        Console.Write("Initial array: ");
        foreach (var i in arr)
            Console.Write(i + " ");

        BubbleSort(arr);

        Console.Write("\nSorted array: ");
        foreach (var i in arr)
            Console.Write(i + " ");
    }

    public static void BubbleSort(int[] A)
    {
        for(int i = 0; i < A.Length - 1; i++)
        {
            for(int j = 0; j < A.Length - i - 1; j++)
            {
                if (A[j] > A[j+1])
                {
                    int temp = A[j];
                    A[j] = A[j + 1];
                    A[j + 1] = temp;
                }
            }
        }
    }


}
