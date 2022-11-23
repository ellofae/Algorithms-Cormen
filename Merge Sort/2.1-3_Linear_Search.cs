/*
Worst-Case time complexity: O(n)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 5, 2, 4, 7, 1, 3, 2, 6 };
        int indx = LinearSearch(arr, 7);
        Console.WriteLine($"index of 7: {indx}");
        
    }

    public static int LinearSearch(int[] A, int value)
    {
        for (int i = 0; i < A.Length; i++)
            if (A[i] == value)
                return i;
        return -1;
    }

}
