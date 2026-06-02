using LeetCodeProblems.Interfaces.Medium;
using System.Security.Cryptography.X509Certificates;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class CombinationSum2_Recursive_Backtracking_CSharp_40 : ICombinationSumII_40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            Array.Sort(candidates);
            recurse(candidates, target, 0, new List<int>(), result);

            return result;
        }

        public void recurse(int[] candidates, int target, int i, List<int> currentList, List<IList<int>> result)
        {

            if (currentList.Sum() == target)
            {
                result.Add(currentList.ToList());
                return;
            }
            if (currentList.Sum() > target || i == candidates.Length) return;

            currentList.Add(candidates[i]);
            recurse(candidates, target, i + 1, currentList, result);
            currentList.RemoveAt(currentList.Count - 1);

            while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) i += 1;
            recurse(candidates, target, i + 1, currentList, result);
        }
    }
}
