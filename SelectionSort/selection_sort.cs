using System;

class Program {
    static void Main(string[] args) {
        int[] arr = new int[] {31,56,49,49,14,62,34,81};
        SelectionSort(ref arr);

        foreach(int i in arr)
          Console.Write(i.ToString() + " ");
    }

  public static void SelectionSort(ref int[] A)
  {
    for(int i = 0; i < A.Length-1; i++)
    {
      int min = A[i];
      int indx = i;
      for(int j = i; j < A.Length; j++)
        if(A[j] < min)
        {
          min = A[j];
          indx = j;
        }
      
      int temp = A[i];
      A[i] = min;
      A[indx] = temp;
    }
  }
}

// Best-case: O(n^2)
// Worst-case: O(n^2)
// Finding min value is: sum from i to (n-1) = j which means n(n-1)/2 for each cases;
