namespace LeetCodeProblems.HashingOrArrays
{

    public class ContainsDuplicateSolution_217
    {
        // I generated this one on the first attempt.  Time: O(n) Space: O(n)
        private bool hasDuplicateBruteForce(int[] nums)
        {
            HashSet<int> founds = new HashSet<int>();

            foreach (int value in nums)
            {
                if (founds.Contains(value)) return true;
                founds.Add(value);
            }
            return false;
        }


        public bool hasDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

    }
}
