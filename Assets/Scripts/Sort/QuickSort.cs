using UnityEngine;

public class QuickSort : MonoBehaviour
{
    [ContextMenu("Test")]
    public void Test()
    {
        int[] numbers = new[] { 10, 120, 40, 30, 32, 2, 3, 6, 5 };
        Sort(numbers);

        string result = "";
        foreach (int num in numbers)
        {
            result += " " + num.ToString();
        }
        Debug.Log(result);
    }

    public void Sort(int[] numbers)
    {
        if (numbers == null || numbers.Length <= 1)
        {
            return;
        }

        Sort(numbers, 0, numbers.Length - 1);
    }

    private void Sort(int[] numbers, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int pivot = Partition(numbers, left, right);

        Sort(numbers, left, pivot - 1);
        Sort(numbers, pivot + 1, right);
    }

    private int Partition(int[] numbers, int left, int right)
    {
        int i = left;
        int j = right;

        while (i < j)
        {
            while (i < j && numbers[j] >= numbers[left])
            {
                j--;
            }

            while (i < j && numbers[i] <= numbers[left])
            {
                i++;
            }

            if (i < j)
            {
                Swap(numbers, i, j);
            }
        }
        Swap(numbers, i, left);

        return i;
    }

    public void Swap(int[] numbers, int i, int j)
    {
        /*
        int temp = numbers[i];
        numbers[i] = numbers[j];
        numbers[j] = temp;
        */

        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);

        /* int z = x & y; AND
        // int z = x | y; OR
        // int z = x >> 1; Bit shift right
        // int z = x << 1; Bit shift left
        // int z = ~x; NOT
        // ^ XOR

        //XOR Swap / Breaks if i = j
        numbers[i] = numbers[i] ^ numbers[j];
        numbers[j] = numbers[i] ^ numbers[j];
        numbers[i] = numbers[i] ^ numbers[j]; */
    }
}
