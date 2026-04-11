
using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Permutations_LinqQuery_CSharp_46 : IPermutations_46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var perms = new List<IList<int>> { new List<int>() };

            foreach (int num in nums)
            {
                perms = 
                    (
                        from perm in perms
                        from i in Enumerable.Range(0, perm.Count + 1)
                        let copy = perm.ToList()
                        select InsertAndReturn(copy, i, num)
                    ).ToList();
            }

            return perms;
        }

        private IList<int> InsertAndReturn(List<int> list, int index, int value)
        {
            list.Insert(index, value);
            return list;
        }
    }
}
