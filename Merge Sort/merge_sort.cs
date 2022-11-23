/*
The key operation of the merge sort algorithm is the merging of two sorted
sequences in the “combine” step. We merge by calling an auxiliary procedure
MERGE(A, p, q, r), where A is an array and p, q, and r are indices into the array
such that p <= q < r. The procedure assumes that the subarrays a[p..q] and
A[q+1..r] are in sorted order. It merges them to form a single sorted subarray
that replaces the current subarray A[p..r].

Since we perform at most n basic steps, merging takes O(n) time
where n = r - p + 1 is the total number of elements being merged

It takes time T(n/b) to solve one subproblem of size n=b (where b is 2 in merge sort).
So it takes aT(n/b) to solve a of them (where a is 2 in merge sort).

If we take D(n) time to divide the problem into subproblems and C(n) time to combine the solutions
to the subproblems into the solution to the original problem. We get the recurrence:

T(n) = { O(1), if n <= c,
       { aT(n/b) + D(n) + C(n) otherwise.
       
       
Merge sort on just one element takes constant time. When we have n>1 elements, we break down the running time as follows.

 - Divide: The divide step just computes the middle of the subarray, which takes
   constant time. Thus, D(n)=O(1).
 - Conquer: We recursively solve two subproblems, each of size n=2, which contributes 2T(n/2) to the running time.
 - Combine: We have already noted that the MERGE procedure on an n-element
   subarray takes time O(n), and so C(n)=O(n).
 
 Adding D(n)=O(1) and C(n)=O(n), we get a sum that is a linear function of n, that is, O(n).
 Adding it to the 2T(n/2) term gives the recurrence for the WORST-CASE running time T(n):
 
 T(n) = { O(1), if n = 1,
        { 2T(n/2) + O(n), if n > 1.
 
 To compute the total cost represented by the recurrence (2.2), we simply add up
the costs of all the levels. The recursion tree has lg (n) + 1 levels, each costing cn,
for a total cost of cn(lg(n) + 1), each costing cn for a total cost of cn(lg(n) + 1) = cn*log(n) + cn
Ignoring the low-order term and the constant c gives the desired result of O(n*lg(n))
 
*/

using System;

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
}

