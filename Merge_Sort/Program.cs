using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 3, 534, 10239, 2, 0, 22 };

            Console.WriteLine("Given array is:");
            PrintArray(arr);

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted array is:");
            PrintArray(arr);
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;

            /* create temp arrays */
            int[] L = new int[n1], R = new int[n2];

            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            /* Merge the temp arrays back into arr[l..r]*/
            i = 0; // Initial index of first subarray 
            j = 0; // Initial index of second subarray 
            k = left; // Initial index of merged subarray 
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

            /* Copy the remaining elements of L[], if there 
               are any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy the remaining elements of R[], if there 
               are any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}
