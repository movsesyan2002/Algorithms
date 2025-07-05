class MS
{
    public static void MergeSort(int[] array, int left, int right)
    {

        if (left >= right)
        {
            return;
        }

        int mid = left + (right - left) / 2;

        MergeSort(array, left, mid);
        MergeSort(array, mid + 1, right);
        Merge(array, left, mid, right);

    }

    public static void Merge(int[] array, int left, int mid, int right)
    {

        int l1 = left;
        int r1 = mid;

        int l2 = mid + 1;
        int r2 = right;

        int[] ints = new int[right - left + 1];
        int i = 0;

        while (l1 <= r1 && l2 <= r2)
        {

            if (array[l1] <= array[l2])
            {
                ints[i++] = array[l1++];
            }

            else
            {
                ints[i++] = array[l2++];
            }

        }

        while (l1 <= r1)
        {
            ints[i++] = array[l1++];
        }

        while (l2 <= r2)
        {
            ints[i++] = array[l2++];
        }

        for (int j = 0; j < ints.Length; j++)
        {
            array[left++] = ints[j];
        }

    }

    public static int Search(int[] nums, int target)
    {

        int left = 0;
        int right = nums.Length - 1;
        int mid;


        while (left <= right)
        {

            mid = left + (right - left) / 2;

            if (nums[left] == target)
            {
                return left;
            }

            else if (nums[right] == target)
            {
                return right;
            }

            else if (nums[mid] == target)
            {
                return mid;
            }

            else if (nums[left] > target)
            {
                left = mid + 1;
            }

            else
            {
                right = mid - 1;
            }

        }

        return -1;
        
    }
}
