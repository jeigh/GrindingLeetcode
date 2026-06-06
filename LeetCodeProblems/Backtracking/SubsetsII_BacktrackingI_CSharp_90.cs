using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetsII_BacktrackingI_CSharp_90 : ISubsetsII_90
    {
        // time complexity: O(n * 2^n)
        // space complexity: O(n)
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>();

            Array.Sort(nums);

            recurse(nums, 0, new List<int>(), result);

            return result;
        }

        private void recurse(int[] nums, int i, List<int> currentList, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(currentList.ToList());
                return;
            }

            currentList.Add(nums[i]);
            recurse(nums, i + 1, currentList, result);
            currentList.RemoveAt(currentList.Count - 1);

            while (i + 1 < nums.Length && nums[i + 1] == nums[i]) i++;

            recurse(nums, i + 1, currentList, result);
            
        }
    }
}
