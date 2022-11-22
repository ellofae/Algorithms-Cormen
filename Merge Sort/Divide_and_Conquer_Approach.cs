using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 2, 4, 5, 7, 1, 2, 3, 6 };
        MergeSort(arr, 0, arr.Length);

        foreach (int i in arr)
            Console.Write(i.ToString() + " ");
    }

    public static void MergeSort(int[] A, int p, int r)
    {
        int q = (p + r) / 2;
        Merge(A, p, q, r);
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
