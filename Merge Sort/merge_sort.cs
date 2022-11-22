/*
The key operation of the merge sort algorithm is the merging of two sorted
sequences in the “combine” step. We merge by calling an auxiliary procedure
MERGE(A, p, q, r), where A is an array and p, q, and r are indices into the array
such that p <= q < r. The procedure assumes that the subarrays a[p..q] and
A[q+1..r] are in sorted order. It merges them to form a single sorted subarray
that replaces the current subarray A[p..r].

Since we perform at most n basic steps, merging takes O(n) time
where n = r - p + 1 is the total number of elements being merged
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 5, 2, 4, 7, 1, 3, 2, 6 };
        MergeSort(arr, 0, arr.Length);

        foreach (int i in arr)
            Console.Write(i.ToString() + " ");
    }

    public static void MergeSort(int[] A, int p, int r)
    {
        if (p < r)
        {
            int q = (p + r) / 2;
            MergeSort(A, p, q);
            MergeSort(A, q+1, r);
            Merge(A, p, q, r);
        }
    }

    public static void Merge(int[] A, int p, int q, int r)
    {
        int n1 = q - p;
        int n2 = r - q;
        int[] L = new int[n1 + 1];
        int[] R = new int[n2 + 1];


        for (int i = 0; i < n1; i++)
            L[i] = A[p + i];
        for (int i = 0; i < n2; i++)
            R[i] = A[q + i];

        L[n1] = int.MaxValue;
        R[n2] = int.MaxValue;

        int i1 = 0;
        int j1 = 0;
        for(int k = p; k < r; k++)
        {
            if (L[i1] <= R[j1])
            {
                A[k] = L[i1];
                i1 = i1 + 1;
            }
            else
            {
                A[k] = R[j1];
                j1 = j1 + 1;
            }
        }

    }

}
