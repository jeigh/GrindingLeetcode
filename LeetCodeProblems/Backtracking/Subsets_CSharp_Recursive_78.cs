using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Subsets_CSharp_Recursive_78 : ISubsets_78
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var results = new List<IList<int>>();
            var subset = new List<int>();

            Subsets(nums, 0, results, subset);
            return results;
        }

        public void Subsets(int[] nums, int i, IList<IList<int>> result, List<int> currentSubset)
        {
            if (i >= nums.Length) 
            { 
                result.Add(currentSubset.ToList());
                return; 
            }

            currentSubset.Add(nums[i]);
            Subsets(nums, i + 1, result, currentSubset);

            currentSubset.RemoveAt(currentSubset.Count - 1);
            Subsets(nums, i + 1, result, currentSubset);
        }
    }


}
