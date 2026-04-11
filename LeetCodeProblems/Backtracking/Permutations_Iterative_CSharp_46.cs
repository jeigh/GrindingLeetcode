using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{

    public class Permutations_Iterative_CSharp_46 : IPermutations_46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var outerResult = new List<IList<int>>([new List<int>()]);

            foreach(var n in nums)
            {
                var innerResult = new List<IList<int>>();
                foreach (IList<int> outerResultItem in outerResult)
                {
                    for (int i = 0; i < outerResultItem.Count + 1; i++)
                    {
                        List<int> copiedOuterResultItem = outerResultItem.ToList();
                        copiedOuterResultItem.Insert(i, n);
                        innerResult.Add(copiedOuterResultItem);
                    }
                }
                outerResult = innerResult;
            }

            return outerResult;
        }
    }
}
