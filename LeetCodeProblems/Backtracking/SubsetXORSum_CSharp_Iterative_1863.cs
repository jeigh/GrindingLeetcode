using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetXORSum_CSharp_Iterative_1863 : ISubsetXORSum_1863
    {
        public int SubsetXORSum(int[] nums)
        {
            var stack = new Stack<(int, List<int>)>();
            
            stack.Push((0, new List<int>()));
            
            var xors = new List<int>();

            while (stack.Count > 0)
            {
                (int i, List<int> currentList) = stack.Pop();

                if (i != nums.Length)
                {
                    currentList.Add(nums[i]);
                    stack.Push((i + 1, currentList.ToList()));
                    currentList.RemoveAt(currentList.Count - 1);

                    stack.Push((i + 1, currentList.ToList()));
                    continue;
                }

                int xor = 0;
                foreach (var v in currentList) xor ^= v;
                xors.Add(xor);
            }

            return xors.Sum();
        }
    }
}
