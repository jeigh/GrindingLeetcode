using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetsII_Backtracking_CSharp_90 : ISubsetsII_90
    {
        // time complexity: O(n * 2^n)
        // space complexity: O(n)
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            Backtrack(nums, 0, new List<int>(), result);

            return result;
        }

        private void Backtrack(int[] nums, int i, List<int> currentSubset, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(currentSubset.ToList());
                return;
            }

            currentSubset.Add(nums[i]);
            Backtrack(nums, i+1, currentSubset, result);
            currentSubset.RemoveAt(currentSubset.Count - 1);

            while (i + 1 < nums.Length && nums[i] == nums[i+1]) i++;

            Backtrack(nums, i + 1, currentSubset, result);

        }

    }
}
