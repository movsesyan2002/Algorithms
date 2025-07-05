class BinaryHeap
{
    List<int> array;
    public int Size { get; private set; }

    public BinaryHeap(int[] array)
    {
        this.array = array.ToList<int>();
        Size = array.Length;
        BuildMaxHeap();
    }



    public int Top() => Size > 0 ? array[0] : throw new InvalidOperationException("Heap is empty.");

    public void Push(int value)
    {

        array.Add(value);
        Size++;
        int i = Size - 1;
        while (i > 0)
        {
            int parent = GetParent(i);

            if (array[parent] > array[i])
            {
                break;
            }

            else
            {
                (array[parent], array[i]) = (array[i], array[parent]);
                i = parent;
            }
        }

    }

    public int Pop()
    {
        if (array.Count < 1)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        int res = array[0];
        (array[0], array[Size - 1]) = (array[Size - 1], array[0]);
        array.RemoveAt(Size - 1);
        Size--;

        HeapifyMax(array, 0, Size);

        return res;
    }

    private void BuildMaxHeap()
    {
        for (int i = (Size / 2) - 1; i >= 0; i--)
        {
            HeapifyMax(array, i, Size);
        }

    }

    private void BuildMinHeap()
    {
        for (int i = (Size / 2) - 1; i >= 0; i--)
        {
            HeapifyMin(array, i, Size);
        }
    }

    private void HeapifyMax(List<int> array, int i, int size)
    {
        int largestIndex = i;
        int leftIndex = GetLeft(i);
        int rightIndex = GetRight(i);

        if (leftIndex < size && array[i] < array[leftIndex])
        {
            largestIndex = leftIndex;
        }

        if (rightIndex < size && array[largestIndex] < array[rightIndex])
        {
            largestIndex = rightIndex;
        }

        if (i != largestIndex)
        {
            (array[i], array[largestIndex]) = (array[largestIndex], array[i]);
            HeapifyMax(array, largestIndex, size);
        }
    }

    private void HeapifyMin(List<int> array, int i, int size)
    {
        int smallestIndex = i;
        int leftIndex = GetLeft(i);
        int rightIndex = GetRight(i);

        if (leftIndex < size && array[i] > array[leftIndex])
        {
            smallestIndex = leftIndex;
        }

        if (rightIndex < size && array[smallestIndex] > array[rightIndex])
        {
            smallestIndex = rightIndex;
        }

        if (i != smallestIndex)
        {
            (array[i], array[smallestIndex]) = (array[smallestIndex], array[i]);
            HeapifyMin(array, smallestIndex, size);
        }
    }

    private int GetLeft(int i) => 2 * i + 1;


    private int GetRight(int i) => 2 * i + 2;


    private int GetParent(int i) => (i - 1) / 2;

    public void PrintHeap()
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
    }

}