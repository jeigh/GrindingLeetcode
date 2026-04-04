using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{

    public class Combinations_BacktrackingWithForLoop_CSharp_77 : ICombinations_77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();

            backtrack(1, k, new List<int>(), result, n);

            return result;
        }

        private void backtrack(int start, int k, List<int> currentList, List<IList<int>> result, int n)
        {
            if (currentList.Count == k)
            {
                result.Add(currentList.ToList());
                return;
            }

            for (int i = start; i <= n; i++)
            {
                currentList.Add(i);
                backtrack(i + 1, k, currentList, result, n);
                currentList.RemoveAt(currentList.Count - 1);
            }            
        }
    }
}
