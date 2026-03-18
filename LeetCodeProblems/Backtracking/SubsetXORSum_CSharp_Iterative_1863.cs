using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetXORSum_CSharp_Iterative_1863 : ISubsetXORSum_1863
    {
        public int SubsetXORSum(int[] nums)
        {
            var stack = new Stack<(int i, int total)>();
            var sumOfXors = 0;
            stack.Push((0, 0));

            while (stack.Count > 0)
            {
                (int i, int total) = stack.Pop();

                if (i == nums.Length)
                {
                    sumOfXors += total;
                    continue;
                }

                stack.Push((i + 1, total ^ nums[i]));
                stack.Push((i + 1, total));
            }

            return sumOfXors;
        }
    }
}
