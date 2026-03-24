using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class CombinationSum_Iterative_CSharp_39 : ICombinationSum_39
    {
        

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var stack = new Stack<(int leftPointer, int runningTotal, List<int> current)>();
            stack.Push((0, 0, new List<int>()));

            while (stack.TryPop(out var sf))
            {
                if (sf.runningTotal == target)
                {
                    result.Add(sf.current);
                    continue;
                }

                if (sf.leftPointer >= candidates.Length || sf.runningTotal > target) continue;

                stack.Push((sf.leftPointer + 1, sf.runningTotal, sf.current));

                var next = new List<int>(sf.current) { candidates[sf.leftPointer] };
                stack.Push((sf.leftPointer, sf.runningTotal + candidates[sf.leftPointer], next));
            }

            return result;
        }
    }
}
