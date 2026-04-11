using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Permutations_BacktrackingOptimized_CSharp_46 : IPermutations_46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            backtrack(new List<int>(), nums, new bool[nums.Length], result);
            return result;
        }

        public void backtrack(List<int> perm, int[] nums, bool[] pick, List<IList<int>> result )
        {
            if (perm.Count == nums.Length)
            {
                result.Add(perm.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!pick[i])
                {
                    perm.Add(nums[i]);
                    pick[i] = true;
                    backtrack(perm, nums, pick, result);
                    perm.RemoveAt(perm.Count - 1);
                    pick[i] = false;
                }
            }
        }
    }
}
