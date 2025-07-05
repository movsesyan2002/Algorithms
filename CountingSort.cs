class CS
{
    public static int[] CointingSort(int[] nums)
    {

        int min = nums[0];

        int max = nums[0];


        for (int i = 1; i < nums.Length; ++i)
        {
            if (nums[i] > max)
            {
                max = nums[i];
            }

            if (nums[i] < min)
            {
                min = nums[i];
            }
        }


        int[] countofelems = new int[max - min + 1];


        for (int i = 0; i < nums.Length; i++)
        {
            countofelems[nums[i] - min]++;
        }


        int[] prefixSum = new int[countofelems.Length];

        prefixSum[0] = countofelems[0];


        for (int i = 1; i < countofelems.Length; ++i)
        {
            prefixSum[i] = countofelems[i] + prefixSum[i - 1];
        }


        int[] result = new int[nums.Length];


        for (int i = nums.Length - 1; i >= 0; --i)
        {
            result[prefixSum[nums[i] - min] - 1] = nums[i];
            --prefixSum[nums[i] - min];
        }

        return result;
    }
}