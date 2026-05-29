using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{

    public class CombinationSum_Recursive_CSharp_39 : ICombinationSum_39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            recurse(candidates, 0, target, new List<int>(), result);

            return result;
        }

        public void recurse(int[] candidates, int i, int target, List<int> currentList, List<IList<int>> result)
        {

            if (currentList.Sum() == target && i == candidates.Length)
            {
                result.Add(currentList.ToList());
                return;
            }

            if (currentList.Sum() > target || i == candidates.Length) return;

            currentList.Add(candidates[i]);
            recurse(candidates, i, target, currentList, result);
            currentList.RemoveAt(currentList.Count - 1);

            recurse(candidates, i + 1, target, currentList, result);
        }

    }
}
