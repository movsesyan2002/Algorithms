using System.Globalization;

class Quick
{
    // public static void QuickSort(int[] nums, int left, int right) // Right and Random
    // {
    //     if (left >= right)
    //     {
    //         return;
    //     }

    //     int partitonIndex = Partition(nums, left, right);
    //     QuickSort(nums, left, partitonIndex - 1);
    //     QuickSort(nums, partitonIndex + 1, right);

    // }

    // public static int Partition(int[] nums, int left, int right)
    // {

    // Random random= new Random();
    // int id = random.Next(left, right);
    // (nums[right], nums[id]) = (nums[id], nums[right]);

    //     int pivot = nums[right];

    // int i = left;
    // int j = right - 1;

    //     while (i <= j) // 2 8 7 1 3 5 6 4
    //     {
    //         while (i <= j && nums[i] <= pivot){i++;}

    //         while (i <= j && nums[j] > pivot){--j;}

    //         if (i < j)
    //         {
    //             int tmp = nums[i];
    //             nums[i] = nums[j];
    //             nums[j] = tmp;
    //         }

    //     }

    //     int swapper = nums[i];
    //     nums[i] = nums[right];
    //     nums[right] = swapper;

    //     return i;
    // }

    // public static void QuickSort(int[] nums, int left, int right)
    // {
    //     if (left >= right)
    //     {
    //         return;
    //     }

    //     int partitonIndex = Partition(nums, left, right);
    //     QuickSort(nums, left, partitonIndex - 1);
    //     QuickSort(nums, partitonIndex + 1, right);
    // }

    // public static int Partition(int[] nums, int left, int right) // left Pivot
    // {
    //     int pivot = nums[left];
    //     int i = left + 1;
    //     int j = right;

    //     while (i <= j)
    //     {
    //         while (i <= j && nums[i] <= pivot) { ++i; }
    //         while (i <= j && nums[j] > pivot) { --j; }

    //         if (i < j)
    //         {
    //             int tmp = nums[i];
    //             nums[i] = nums[j];
    //             nums[j] = tmp;
    //         }
    //     }

    //     int temp = nums[j];
    //     nums[j] = nums[left];
    //     nums[left] = temp;

    //     return j;
    // }

    public static void QuickSort(int[] nums, int left, int right) // Median of three
    {
        if (left >= right)
        {
            return;
        }

        int partitonIndex = Partition(nums, left, right);
        QuickSort(nums, left, partitonIndex - 1);
        QuickSort(nums, partitonIndex + 1, right);

    }

    public static int Partition(int[] nums, int left, int right)
    {
        int mid = left + (right - left) / 2;

        if (nums[mid] < nums[left])
        {
            (nums[mid], nums[left]) = (nums[left], nums[mid]);
        }

        if (nums[mid] > nums[right])
        {
            (nums[mid], nums[right]) = (nums[right], nums[mid]);
        }

        if (nums[left] > nums[mid])
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }

        (nums[mid], nums[right]) = (nums[right], nums[mid]);

        int j = right - 1;
        int i = left;
        int pivot = nums[right];

        while (i <= j)
        {
            while (i <= j && nums[i] <= pivot) { ++i; }
            while (i <= j && nums[j] > pivot) { --j; }

            if (i < j)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
        }

        (nums[i], nums[right]) = (nums[right], nums[i]);

        return i;
    }

}