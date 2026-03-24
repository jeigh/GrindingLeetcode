using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{

    public class CombinationSum_Recursive_CSharp_39 : ICombinationSum_39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            recurse(candidates, 0, new List<int>(), 0, result, target);

            return result;
        }

        private void recurse(int[] candidates, int leftPointer, List<int> current, int total, List<IList<int>> result, int target) 
        { 
            if (total == target)
            {
                result.Add(current.ToList());
                return;
            }

            if (leftPointer >= candidates.Length || total > target) return;

            current.Add(candidates[leftPointer]);
            recurse(candidates, leftPointer, current, total + candidates[leftPointer], result, target);

            current.RemoveAt(current.Count - 1);
            recurse(candidates, leftPointer + 1, current, total, result, target);
        }
    }
}
