class HP
{


    public static void HeapSort(int[] array)
    {
        MaxHeap(array);

        for (int i = array.Length - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, 0, i);
        }
    }

    private static void MaxHeap(int[] array)
    {
        for (int i = (array.Length / 2) - 1; i >= 0; i--)
        {
            Heapify(array, i, array.Length);
        }
    }

    private static void Heapify(int[] array, int i, int size)
    {
        int largest = i;
        int left = GetLeft(i);
        int right = GetRight(i);

        if (left < size && array[i] < array[left])
        {
            largest = left;
        }

        if (right < size && array[largest] < array[right])
        {
            largest = right;
        }

        if (i != largest)
        {
            (array[i], array[largest]) = (array[largest], array[i]);
            Heapify(array, largest, size);
        }

    }

    private static int GetLeft(int i)
    {
        return i * 2 + 1;
    }

    private static int GetRight(int i)
    {
        return i * 2 + 2;
    }
}