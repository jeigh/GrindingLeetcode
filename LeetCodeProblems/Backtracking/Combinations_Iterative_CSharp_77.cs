using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    // Iterative backtracking using an explicit stack instead of recursion.
    public class Combinations_Iterative_CSharp_77 : ICombinations_77
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();
            var stack = new Stack<(int, List<int>)>();
            stack.Push((1, new List<int>()));

            while (stack.Count > 0)
            {
                (int currentValue, List<int> currentList) = stack.Pop();
                
                if (currentList.Count == k)
                {
                    result.Add(currentList.ToList());
                    continue;
                }
                if (currentValue > n) continue;
                
                currentList.Add(currentValue);
                stack.Push((currentValue + 1, currentList.ToList()));
                currentList.RemoveAt(currentList.Count - 1);

                stack.Push((currentValue + 1, currentList.ToList()));
            }

            return result;
        }
    }
}
