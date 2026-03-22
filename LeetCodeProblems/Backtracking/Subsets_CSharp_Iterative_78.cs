using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Subsets_CSharp_Iterative_78 : ISubsets_78
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            var stack = new Stack<(int i, List<int> currentSubset)>();
            stack.Push((0, new List<int>()));

            while (stack.Count > 0)
            {
                (int i, List<int> currentSubset) = stack.Pop();

                if (i >= nums.Length)
                {
                    res.Add(currentSubset);
                    continue;
                }

                stack.Push((i + 1, currentSubset));
                stack.Push((i + 1, [.. currentSubset, nums[i]]));
            }            

            return res;
        }
    }


}
