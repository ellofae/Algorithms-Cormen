using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 31, 41, 59, 26, 41, 58 };
            InsertionSort(ref intArray);

            foreach (int i in intArray)
                Console.Write(i + " ");
        }

        public static void InsertionSort(ref int[] A)
        {
            for (int j = 1; j < A.Length; j++)
            {
                int key = A[j];
                int i = j - 1;
                while (i >= 0 && A[i] > key)
                {
                    A[i + 1] = A[i];
                    i = i - 1;
                }
                A[i + 1] = key;
            }
        }
    }
}
