using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksort : MonoBehaviour
{
    public void Quick_Sort(Item[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                Quick_Sort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(arr, pivot + 1, right);
            }
        }
    }
    public int Partition(Item[] arr, int left, int right)
        {
        int pivot = arr[left].value;
        while (true)
        {

            while (arr[left].value < pivot)
            {
                left++;
            }

            while (arr[right].value > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;

                int temp = arr[left].value;
                arr[left] = arr[right];
                arr[right].value = temp;


            }
            else
            {
                return right;
            }
        }
    }
}
