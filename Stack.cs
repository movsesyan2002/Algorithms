using System.Collections;
using System.Collections.Generic;
using System.Xml;

class Stack<T> : IEnumerable<T>
{
    private Vector<T> vector;

    public int Size { get { return vector.Size; } }

    public IEnumerator GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = Size - 1; i >= 0; --i)
        {
            yield return vector[i];
        }
    }

    public void Push(T value)
    {
        vector.Push_Back(value);
    }

    public void Pop()
    {
        vector.Pop_Back();
    }

    public T Top()
    {
        T val = vector[vector.Size - 1];
        vector.Pop_Back();
        return val;
    }

    public void Empty()
    {
        vector.Clear();
    }
}