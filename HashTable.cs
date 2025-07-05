using System.Linq.Expressions;
using Microsoft.VisualBasic;

class MyHashTable
{
    private const double _loadFactor = 0.75;
    private int _elementCount;
    private int _slotCount = 3;

    private LinkedList<KeyValuePair<object, object>>[] _slots;

    public MyHashTable()
    {
        _slots = new LinkedList<KeyValuePair<object, object>>[_slotCount];
        for (int i = 0; i < _slotCount; ++i)
        {
            _slots[i] = new();
        }
    }

    public object? this[object Key]
    {
        get
        {
            return Search(Key);
        }

        set
        {
            int index = IndexOfSlot(Key);

            var node = _slots[index].First;

            while (node != null)
            {
                if (node.Value.Key == Key)
                {
                    node.Value = new KeyValuePair<object, object>(Key, value);
                    break;
                }
                node = node.Next;
            }
            

        }
    }

    public void Add(object Key, object Value)
    {

        if (Search(Key) != null)
        {
            Console.WriteLine("Key just exist");
            return;
        }

        KeyValuePair<object, object> pair = new KeyValuePair<object, object>(Key, Value);
        int index = IndexOfSlot(pair.Key);

        _slots[index].AddFirst(pair);
        _elementCount++;

        if (GetLoadFactor() > _loadFactor)
        {
            Rehashing();
        }

        return;
    }

    public object? Search(object Key)
    {
        if (_elementCount == 0)
        {
            return null;
        }

        int index = IndexOfSlot(Key);

       
        foreach (var item in _slots[index])
        {
            if (item.Key == Key)
            {
                return item.Value;
            }
        }
        

        return null;
    }

    public bool Erase(object Key)
    {
        
        
            int index = IndexOfSlot(Key);
            
            foreach (var item in _slots[index])
            {
                if (item.Key == Key)
                {
                    _slots[index].Remove(item);
                    --_elementCount;
                    return true;
                }
            }

        return false;
    }


    private int NextPrime(int number)
    {
        int n = number + 1;
        if (n <= 2)
            return 2;

        while (!IsPrime(n))
            n++;

        return n;
    }


    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int boundary = (int)Math.Sqrt(number);

        for (int i = 3; i <= boundary; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }


    private void Rehashing()
    {
        int oldslot = _slotCount;
        _slotCount = NextPrime(_slotCount * 2);
        var _newslots = new LinkedList<KeyValuePair<object, object>>[_slotCount];
        for (int i = 0; i < _slotCount; ++i){_newslots[i] = new();}
        
        for (int i = 0; i < oldslot; ++i)
        {
            foreach (var item in _slots[i])
            {
                int hashIndex = IndexOfSlot(item.Key);
                _newslots[hashIndex].AddFirst(item);
            }
        }

        _slots = _newslots;
        return;
    }


    private int IndexOfSlot(object Key)
    {
        int hash = Key.GetHashCode();
        return Math.Abs(hash) % _slotCount;
    }


    private double GetLoadFactor()
    {
        return (double)_elementCount / _slotCount;
    }
    
}