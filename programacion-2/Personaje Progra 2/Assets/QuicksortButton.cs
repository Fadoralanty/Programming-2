using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuicksortButton : MonoBehaviour
{
    public Item[] Items;
    public int rightItemValue;
    public int leftItemValue;

    private void quicksort(Item[] input, int low, int high)
    {
        int pivot_loc = 0;

        if (low < high)
        {
            pivot_loc = partition(input, low, high);
            quicksort(input, low, pivot_loc - 1);
            quicksort(input, pivot_loc + 1, high);
        }
    }

    private int partition(Item[] input, int low, int high)
    {
        int pivot = input[high].value;
        int i = low - 1;

        for (int j = low; j <= high-1; j++)
        {
            if (input[j].value <= pivot)
            {
                i++;
                swap(input, i, j);
            }
        }
        swap(input, i + 1, high);
        return i + 1;
    }



    private void swap(Item[] ar, int a, int b)
    {
        int temp = ar[a].value;
        ar[a].value = ar[b].value;
        ar[b].value = temp;
    }

    //private void print(int[] output, TextBox tbOutput)
    //{
    //    tbOutput.Clear();
    //    for (int a = 0; a < output.Length; a++)
    //    {
    //        tbOutput.Text += output[a] + " ";
    //    }
    //}
    public void QuicksortButtonCLick()
    {
        quicksort(Items, leftItemValue, rightItemValue);
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].transform.position=new Vector2((i*200)+20,200);
        }
    }
}
