namespace LeetCodeProblems.TwoPointers
{
    public class MergeSortedArraySolution_88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var nums1Index = 0;
            var nums2Index = 0;
            var resultsIndex = 0;

            int[] nums1temp = new int[m];

            Array.Copy(nums1, nums1temp, m);

            while (nums1Index < m && nums2Index < n)
            {
                if (nums1temp[nums1Index] <= nums2[nums2Index])
                {
                    nums1[resultsIndex] = nums1temp[nums1Index];
                    nums1Index++;
                    resultsIndex++;
                    continue;
                }

                if (nums2[nums2Index] < nums1temp[nums1Index])
                {
                    nums1[resultsIndex] = nums2[nums2Index];
                    nums2Index++;
                    resultsIndex++;
                }
            }

            while (nums1Index < m)
            {
                nums1[resultsIndex] = nums1temp[nums1Index];
                resultsIndex++;
                nums1Index++;
            }

            while(nums2Index < n)
            {
                nums1[resultsIndex] = nums2[nums2Index];
                resultsIndex++;
                nums2Index++;
            }
        }
    }
}
