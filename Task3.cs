using System.Dynamic;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Text;

public class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {

        Dictionary<int, int> keyvalue = new Dictionary<int, int>();

        int[] arr = new int[2]; //2, 7, 11, 15 target = 9
        for (int i = 0; i < nums.Length; i++)
        {
            if (keyvalue.ContainsKey(target - nums[i]) == false)
            {
                try
                {
                    keyvalue.Add(nums[i], i);
                }
                catch
                {

                    continue;
                }
            }

            else if (keyvalue.ContainsKey(target - nums[i]) == true)
            {
                arr[0] = keyvalue[target - nums[i]];
                arr[1] = i;
                break;
            }
        }
        return arr;
    }


    public static int BinarySearchL(int[] nums, int target) // LOWER BOUND
    {
        int left = 0;
        int right = nums.Length;
        int mid = 0;
        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (nums[mid] >= target)
            {
                right = mid ;
            }

            else
            {
                left = mid + 1;
            }
        }


        return left;

    }

    public static int BinarySearchU(int[] nums, int target) // UPPER BOUND
    {
        int left = 0;
        int right = nums.Length ;
        int mid = 0;


        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (nums[mid] <= target)
            {
                left = mid + 1;
            }

            else
            {
                right = mid;
            }
        }


        return right;

    }

        public static bool BinarySearch(int[] nums, int target, int start, int end)
        {
            int mid = start + (end - start) / 2;

            if (start > end)
            {
                return false;
            }

            if (nums[mid] == target)
            {
                return true;
            }

            else if (nums[mid] > target)
            {
                return BinarySearch(nums, target, 0, mid - 1);
            }

            else
            {
                return BinarySearch(nums, target, mid + 1, end);
            }


        }
    public static int FindKthPositive(int[] arr, int k)
    {
        int x = int.MinValue;
        int[] nums = new int[arr[arr.Length - 1] + 1];
        for (int i = 0; i < arr.Length; ++i)
        {
            nums[arr[i]]++;
        }



        List<int> notinarray = new();
        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] == 0)
            {
                notinarray.Add(i);
            }
        }


        return notinarray[k];
    }



}



using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        // MyHashTable table = new MyHashTable();

        // // Add entries
        // table.Add("apple", 1);
        // table.Add("banana", 2);
        // table.Add("cherry", 3);

        // // Access values using indexer
        // Console.WriteLine($"apple => {table["apple"]}");   // Output: 1
        // Console.WriteLine($"banana => {table["banana"]}"); // Output: 2

        // // Modify value
        // table["banana"] = 5;
        // Console.WriteLine($"banana (modified) => {table["banana"]}"); // Output: 5

        // // Search for a key
        // object? result = table.Search("cherry");
        // Console.WriteLine(result != null ? $"Found: cherry => {result}" : "Not found");

        // // Try to add duplicate key
        // table.Add("apple", 10); // Should print "Key just exist"

        // // Remove a key
        // table.Erase("apple");
        // Console.WriteLine($"apple after erase => {table["apple"]}"); // Output: null

        // // Try to erase a non-existent key
        // table.Erase("pineapple"); // Should print "The key not found"

        // int[] input = { 20, 5, 15, 22, 10 };
        // BinaryHeap heap = new BinaryHeap(input);

        // Console.WriteLine("Initial Max-Heap:");
        // heap.PrintHeap();

        // Console.WriteLine($"\nTop Element: {heap.Top()}");

        // Console.WriteLine("\nPushing 30...");
        // heap.Push(30);
        // heap.PrintHeap();

        // Console.WriteLine("\nPushing 8...");
        // heap.Push(8);
        // heap.PrintHeap();

        // Console.WriteLine($"\nTop Element after pushes: {heap.Top()}");

        // Console.WriteLine("\nPopping top element...");
        // heap.Pop();
        // heap.PrintHeap();

        // Console.WriteLine("\nPopping top element again...");
        // heap.Pop();
        // heap.PrintHeap();
        // Console.WriteLine();

        // HP.HeapSort(input);
        // foreach (var item in input)
        // {
        //     Console.Write($"{item} ");
        // }

        // int[] ints = new int[] { 1, 2, 3, 4 };
        // PriorityQueue<int, int> priorityQueue = new();
        // Hashtable hashtable = new Hashtable();

        BinarySearchTree bst = new BinarySearchTree();

        // Insert test values
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(3);
        bst.Insert(7);
        bst.Insert(12);
        bst.Insert(18);

        Console.WriteLine("In-Order Display of Tree:");
        bst.Display(); // Should print sorted order: 3 5 7 10 12 15 18

        Console.WriteLine("\nSearch Tests:");
        int[] testValues = { 7, 15, 3, 1, 20, 12, 10 };
        foreach (int val in testValues)
        {
            bool found = bst.Search(val);
            Console.WriteLine($"Search({val}) -> {found}");
        }


    }
}




   

