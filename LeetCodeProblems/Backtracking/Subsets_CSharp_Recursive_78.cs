using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Subsets_CSharp_Recursive_78 : ISubsets_78
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();

            recurse(nums, 0, new List<int>(), result);

            return result;
        }

        public void recurse(int[] nums, int i, List<int> currentList, List<IList<int>> result)
        {
            if (i != nums.Length)
            {
                currentList.Add(nums[i]);
                recurse(nums, i + 1, currentList, result);
                currentList.RemoveAt(currentList.Count - 1);

                recurse(nums, i + 1, currentList, result);
                return;
            }
            result.Add(currentList.ToList());
        }

    }


}
