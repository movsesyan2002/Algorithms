using System.Collections;
using System.Collections.Generic;
using System.Xml;

class Vector<T> : IEnumerable<T>
{

    public int Size { get; private set; } = 0;
    private int Capacity = 0;

    private T[] values = new T[0];

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return values[i];
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return values[i];
        }
    }

    public T this[int index]
    {
        get
        {
            return values[index];
        }

        set
        {
            values[index] = value;
        }
    }
 
    public void Push_Back(T val)
    {
        if (Capacity == 0)
        {
            values = new T[Capacity + 1];
            Capacity += 1;
        }

        if (Size == Capacity)
        {
            Capacity *= 2;
            T[] newValues = new T[Capacity];
            Array.Copy(values, newValues, Size);
            values = newValues;
        }

        values[Size] = val;
        Size += 1;
    }

    public void Push_Back(T val, int count)
    {

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count is less than 0");
        }

        if (Capacity == 0)
        {
            values = new T[Capacity + count];
            Capacity += count;
        }

        for (int i = 0; i < count; ++i)
        {
            Push_Back(val);
        }

    }

    public void Insert(T val, int pos, int count = 1)
    {
        T[] newvalues;

        if (pos < 0 || pos >= Size)
        {
            throw new IndexOutOfRangeException("Position is out of range");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count is less than 0");
        }

        if (Capacity - Size < count)
        {
            newvalues = new T[(Capacity + (count - (Capacity - Size))) * 2];
            Capacity = Capacity + (count - (Capacity - Size)) * 2;
            Array.Copy(values, newvalues, Size);
            values = newvalues;
        }

        for (int i = pos; i < Size; i++)
        {
            values[i + count] = values[i];
        }

        for (int i = pos; i < pos + count; i++)
        {
            values[i] = val;
        }

        Size += count;
    }

    public void Pop_Back()
    {
        if (Size <= 0)
        {
            throw new Exception("Size is Zero");
        }

        Size -= 1;
    }

    public void Erase(int pos)
    {

        if (pos < 0 || pos >= Size)
        {
            throw new Exception("Position is out of range");
        }

        if (pos == Size - 1)
        {
            Pop_Back();
        }

        for (int i = pos + 1; i < Size; i++)
        {
            values[i - 1] = values[i];
        }

        Size -= 1;

    }

    public void Shrint_TO_Fit()
    {
        T[] newvalues = new T[Size];
        values = newvalues;
        Capacity = Size;
    }

    public void Resize(T val, int count)
    {
        T[]? newvalues = null;
        if (count < 0)
        {
            throw new Exception("Count is less than 0");
        }

        if (count < Size)
        {
            Size = count;
        }

        if (count + Size > Capacity)
        {
            newvalues = new T[(Capacity + (count - (Capacity - Size))) * 2];
            Capacity = Capacity + (count - (Capacity - Size)) * 2;
            Array.Copy(values, newvalues, Size);
            values = newvalues;
        }

        for (int i = Size; i < Size + count; ++i)
        {
            values[i] = val;
        }

        Size += count;
    }

    public void Clear()
    {
        Capacity = 0;
        Size = 0;
        values = new T[0];
    }

}