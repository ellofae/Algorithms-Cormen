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
