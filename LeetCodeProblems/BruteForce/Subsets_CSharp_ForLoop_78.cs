using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.BruteForce
{
    public class Subsets_CSharp_ForLoop_78 : ISubsets_78
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var res = new List<IList<int>>();
            res.Add(new List<int>());

            foreach (int num in nums)
            {
                int size = res.Count;
                for (int i = 0; i < size; i++) 
                    res.Add([.. res[i], num]);
            }

            return res;
        }
    }


}
