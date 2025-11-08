using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.HashingOrArrays
{
    public class ContainsDuplicateIIHashSetSolution_219 : IContainsDuplicateII_219
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0) return false;

            var hashSet = new HashSet<int>();

            for ( int i = 0; i < nums.Length; i++)
            {
                if (hashSet.Contains(nums[i])) return true;
                else hashSet.Add(nums[i]);
                if (i >= k) hashSet.Remove(nums[i-k]);
            }
            return false;
        }
    }
}
