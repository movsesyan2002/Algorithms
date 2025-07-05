using System.Collections;
using System.Net;

class DLL<T> : IEnumerable<DNode<T>> where T : IComparable
{
    DNode<T>? first;
    DNode<T>? last;
    public int Size { get; private set; }

    public DLL()
    {
        first = new DNode<T>();
        last = new DNode<T>();

        first.Next = last;
        last.Prev = first;
        Size = 0;
    }


    public DLL(IEnumerable<T> values)
    {
        first = new DNode<T>();
        last = new DNode<T>();
        DNode<T> tmp = first;
        Size = 0;

        foreach (var item in values)
        {

            tmp.Next = new DNode<T>(item);

            if (Size == 0)
            {
                tmp.Next.Prev = null;
                Size++;
                continue;
            }

            tmp.Next.Prev = tmp;
            tmp = tmp.Next;
            Size++;
        }

        last.Prev = tmp;
    }




    public IEnumerator GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator<DNode<T>> IEnumerable<DNode<T>>.GetEnumerator()
    {
        if (first.Next == null)
        {
            yield break;
        }

        DNode<T>? tmp = first.Next;

        while (tmp != null)
        {
            yield return tmp;
            tmp = tmp.Next;
        }

    }

    public void Push_Front(T val)
    {
        DNode<T> tmpfirst = first;
        DNode<T> tmplast = last;

        DNode<T> dNode = new DNode<T>(val);

        if (Size == 0)
        {
            first.Next = dNode;
            last.Prev = dNode;
            Size++;
            return;
        }

        dNode.Next = tmpfirst.Next;
        tmpfirst.Next.Prev = dNode;
        tmpfirst.Next = dNode;
        Size++;

        return;
    }

    public void Push_Back(T val)
    {
        if (Size == 0)
        {
            Push_Front(val);
            return;
        }

        DNode<T> node = new DNode<T>(val);

        node.Prev = last.Prev;
        last.Prev.Next = node;
        last.Prev = node;
        Size++;
    }


    public void Pop_Front()
    {

        if (Size == 1)
        {
            first.Next = last;
            last.Prev = first;
            Size--;
            return;
        }

        first.Next = first.Next.Next;
        first.Next.Prev = null;
        Size--;

        return;
    }

    public void Pop_Back()
    {
        if (Size == 1)
        {
            Pop_Front();
            return;
        }

        last.Prev = last.Prev.Prev;
        last.Prev.Next = null;
        --Size;

        return;
    }

    public void Insert(T val, int pos)
    {

        if (pos < 0)
        {
            Console.WriteLine("Position less than 0");
            return;
        }

        if (pos >= Size)
        {
            Console.WriteLine("Position is big than size");
        }

        if (pos == 0)
        {
            Push_Front(val);
            return;
        }

        if (pos == Size - 1)
        {
            Push_Back(val);
            return;
        }

        DNode<T> node = new DNode<T>(val);
        DNode<T> tmp = first.Next;

        while ((--pos) > 0)
        {
            tmp = tmp.Next;
        }

        node.Next = tmp.Next;
        tmp.Next.Prev = node;
        tmp.Next = node;
        node.Prev = tmp;

        return;
    }

    public void Erase(int pos)
    {
        if (pos < 0)
        {
            Console.WriteLine("Position less than 0");
            return;
        }

        if (pos >= Size)
        {
            Console.WriteLine("Position is big than size");
        }

        if (pos == 0)
        {
            Pop_Front();
            return;
        }

        if (pos == Size - 1)
        {
            Pop_Back();
            return;
        }

        DNode<T> tmp = first.Next;

        while ((--pos) > 0)
        {
            tmp = tmp.Next;
        }

        tmp.Next = tmp.Next.Next;
        tmp.Next.Prev = tmp;

        return;
    }

    public void Empty()
    {
        first.Next = last;
        last.Prev = first;
        Size = 0;
    }

    public T GetMidElem()
    {
        if (Size == 0)
        {
            Console.WriteLine("List is empty");
            return default(T);
        }

        if (Size == 1)
        {
            return first.Next.Val;
        }

        DNode<T> slow = first.Next;
        DNode<T> fast = first.Next;

        while (fast != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow.Val;
    }

    public bool HasCycle()
    {
        if (Size == 0)
        {
            Console.WriteLine("List is empty");
            return false;
        }

        if (Size == 1)
        {
            return false;
        }

        DNode<T> slow = first.Next;
        DNode<T> fast = first.Next;

        while (fast != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }


    public T CycleFirstElem()
    {
        if (Size == 0)
        {
            Console.WriteLine("List is empty");
            return default(T);
        }

        if (Size == 1)
        {
            Console.WriteLine($"List's size is 1");
            return default(T);
        }

        DNode<T> head = first.Next;
        DNode<T> slow = first.Next;
        DNode<T> fast = first.Next;

        while (fast != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;

            if (slow == fast)
            {
                break;
            }
        }

        if (fast != null && fast.Next.Next != null)
        {
            Console.WriteLine("List is not cycled");
            return default(T);
        }

        while (slow != head)
        {

            slow = slow.Next;
            head = head.Next;

        }

        return head.Val;
    }
}

class DNode<T>
{
    public T? Val { get; set; }
    public DNode<T>? Next { get; set; }
    public DNode<T>? Prev { get; set; }

    public DNode(T? val = default(T), DNode<T>? next = null, DNode<T>? prev = null)
    {
        this.Val = val;
        this.Next = next;
        this.Prev = prev;
    }


}