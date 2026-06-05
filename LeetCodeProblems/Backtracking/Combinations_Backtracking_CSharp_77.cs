using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Combinations_Backtracking_CSharp_77 : ICombinations_77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();

            if (k == 0) return result;

            Recurse(n, k, 1, new List<int>(), result);

            return result;            
        }

        private void Recurse(int maxNum, int combinationSize, int i, List<int> current, List<IList<int>> result)
        {

            if (current.Count == combinationSize)
            {
                result.Add(current.ToList());
                return;
            }
            if (i > maxNum) return;

            current.Add(i); 
            Recurse(maxNum, combinationSize, i + 1, current, result);
            current.RemoveAt(current.Count - 1);

            Recurse(maxNum, combinationSize, i + 1, current, result);            
        }
    }
}
