using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Combinations_Backtracking_CSharp_77 : ICombinations_77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            backtrack(n, k, 1, new List<int>(), result);
            return result;
        }

        public void backtrack(int n, int k, int i, IList<int> currentList, IList<IList<int>> result)
        {
            if (i > n )
            {
                if (currentList.Count == k) result.Add(currentList.ToList());
                return;
            }

            if (currentList.Count > n) return;

            currentList.Add(i);
            backtrack(n, k, i + 1, currentList, result);
            currentList.RemoveAt(currentList.Count - 1);
            
            backtrack(n, k, i + 1, currentList, result);
        }
    }
}
