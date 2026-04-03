using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class CombinationSum2_BacktrackingOptimal_CSharp_40 : ICombinationSumII_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);

            recurse(candidates, target, 0, new List<int>(), 0, result);

            return result;
        }

        public void recurse(int[] candidates, int target, int index, List<int> currentSubset, int current, List<IList<int>> result)
        {
            if (current == target)
            {
                result.Add(currentSubset.ToList());
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                if (i > index && candidates[i] == candidates[i - 1]) continue;
                if (current + candidates[i] > target) break;
                currentSubset.Add(candidates[i]);
                recurse(candidates, target, i + 1, currentSubset, current + candidates[i], result);
                currentSubset.RemoveAt(currentSubset.Count - 1);
            }

        }
    }
}
