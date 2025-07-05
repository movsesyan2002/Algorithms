using System.Collections;

class SLL<T> : IEnumerable<Node<T>> where T : IComparable
{
    Node<T>? dummy;
    public int Size { get; private set; }

    //Parameter less constructor
    public SLL()
    {
        dummy = new Node<T>();
        Size = 0;
    }

    //Parametrized constructor
    public SLL(IEnumerable<T> values)
    {
        if (values == null)
        {
            Console.WriteLine("You past null value");
            return;
        }

        dummy = new Node<T>();
        Size = 0;
        Node<T> tmp = dummy;

        foreach (var item in values)
        {
            tmp.Next = new Node<T>(item);
            tmp = tmp.Next;
            Size++;
        }

    }

    //Enumerator
    public IEnumerator GetEnumerator()
    {
        return this.GetEnumerator();
    }

    //Generic Enumerator
    IEnumerator<Node<T>> IEnumerable<Node<T>>.GetEnumerator()
    {
        if (dummy.Next == null)
        {
            yield break;
        }

        else
        {
            Node<T>? tmp = dummy.Next;

            while (tmp != null)
            {
                yield return tmp;
                tmp = tmp.Next;
            }
        }
    }

    public void Push_Back(T val)
    {

        Node<T> tmp = dummy;
        while (tmp.Next != null)
        {
            tmp = tmp.Next;
        }
        Node<T> node = new Node<T>(val);
        tmp.Next = node;
        Size++;
    }

    public void Pop_Back()
    {
        if (Size == 0)
        {
            Console.WriteLine("There is not element");
            return;
        }


        Node<T> tmp = dummy;
        while (tmp?.Next?.Next != null)
        {
            tmp = tmp.Next;
        }

        tmp.Next = null;
        Size--;

    }

    public void Push_Front(T val)
    {
        if (Size == 0)
        {
            dummy.Next = new Node<T>(val);
            Size++;
            return;
        }

        Node<T> node = new Node<T>(val);
        node.Next = dummy.Next;
        dummy.Next = node;
        Size++;
    }

    public void Pop_Front()
    {
        if (Size == 0)
        {
            Console.WriteLine("List is already empty");
            return;
        }
        dummy.Next = dummy.Next?.Next;
        Size--;
    }

    public void Insert(int pos, T val)
    {
        if (pos >= Size)
        {
            Console.WriteLine($"Can't adding element Count of elems is {Size}");
            return;
        }

        if (pos < 0)
        {
            Console.WriteLine("Position is less than 0");
            return;
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

        Node<T> tmp = dummy.Next;

        while ((--pos) > 0)
        {
            tmp = tmp.Next;
        }

        Node<T> tmp2 = tmp.Next;
        tmp.Next = new Node<T>(val);
        tmp.Next.Next = tmp2;

        Size++;

    }

    public void Erase(int pos)
    {
        if (pos >= Size)
        {
            Console.WriteLine($"Can't erasing element Count of elems is {Size}");
            return;
        }

        if (pos < 0)
        {
            Console.WriteLine("Position is less than 0");
            return;
        }

        if (pos == 0)
        {
            Pop_Front();
            return;
        }

        else if (pos == Size - 1)
        {
            Pop_Back();
            return;
        }

        else
        {
            Node<T>? tmp = dummy.Next;

            while ((--pos) > 0)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;

            return;
        }

    }

    public void Empty()
    {
        dummy.Next = null;
        Size = 0;
    }

    public T GetMidElem()
    {
        if (dummy.Next == null)
        {
            return default(T);
        }

        if (Size == 1)
        {
            return dummy.Next.Val;
        }

        Node<T>? slow = dummy.Next;
        Node<T>? fast = dummy.Next;

        if (Size % 2 == 0)
        {
            fast = slow.Next;
        }

        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return slow.Val;
    }

    public bool HasCycle()
    {
        if (dummy == null || dummy.Next == null)
        {
            Console.WriteLine("There is not elements");
            return false;
        }

        Node<T>? slow = dummy.Next;
        Node<T>? fast = dummy.Next;

        while (fast != null && fast.Next != null)
        {
            if (fast == slow)
            {
                return true;
            }
            slow = slow?.Next;
            fast = fast.Next.Next;
        }

        return false;
    }

    public T CycleFirsElem()
    {
        if (dummy == null || dummy.Next == null)
        {
            Console.WriteLine("There is not elements");
            return default(T);
        }

        Node<T>? slow = dummy.Next;
        Node<T>? fast = dummy.Next;


        while (fast != null && fast.Next != null)
        {
            slow = slow?.Next;
            fast = fast.Next.Next;

            if (fast == slow)
            {
                break;
            }

        }

        if (fast == null || fast.Next == null)
        {
            Console.WriteLine("This List not cycled");
            return default(T);
        }

        Node<T> tmp = dummy.Next;

        while (slow != tmp)
        {
            slow = slow.Next;
            tmp = tmp.Next;
        }

        return slow.Val;
    }


    public Node<T> Merge(Node<T> list1, Node<T> list2)
    {
        Node<T> dummy = new Node<T>();
        Node<T> tmp = dummy; ;
        while (list1 != null && list2 != null)
        {
            if (list1.Val.CompareTo(list2.Val) < 0)
            {
                tmp.Next = list1;
            }

            if (list1.Val.CompareTo(list2.Val) > 0)
            {
                tmp.Next = list2;
            }

            tmp = tmp.Next;
        }

        return dummy.Next;
    }

    public Node<T> MergeSort(Node<T> head)
    {
        if (head == null || head.Next == null)
        {
            return head;
        }

        Node<T> prev = head;
        Node<T>? slow = head.Next;
        Node<T>? fast = head.Next.Next;

        while (fast != null && fast.Next != null)
        {
            prev = slow;
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        prev.Next = null;

        Node<T> left = MergeSort(head);
        Node<T> right = MergeSort(slow);

        return Merge(left, right);
    }

    public Node<T> ReverseList(Node<T> head) {

        if (head == null || head.Next == null) {
            return head;
        }

        Node<T> dummy = ReverseList(head.Next);

        head.Next.Next = head;
        head.Next = null;

        return dummy;
        
    }
}

class Node<T>
{
    public T? Val { get; set; } 
    public Node<T>? Next { get; set; }

    public Node(T? val = default(T), Node<T>? next = null)
    {
        this.Val = val;
        this.Next = next;
    }

 
}