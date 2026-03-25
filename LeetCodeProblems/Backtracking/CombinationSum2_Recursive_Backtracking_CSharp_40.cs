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
            CombinationSum2(candidates, 0, target, result, new List<int>(), 0);

            return result;
        }

        public void CombinationSum2(int[] candidates, int i, int target, IList<IList<int>> result, List<int> currentList, int currentListSum)
        {
            if (currentListSum == target)
            {
                result.Add(currentList.ToArray());
                return;
            }

            if (currentListSum > target || i >= candidates.Length) return;

            currentList.Add(candidates[i]);
            currentListSum += candidates[i];
            CombinationSum2(candidates, i + 1, target, result, currentList, currentListSum);

            currentList.RemoveAt(currentList.Count - 1);
            currentListSum -= candidates[i];

            while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) i += 1;
            CombinationSum2(candidates, i + 1, target, result, currentList, currentListSum);
        }
    }
}
