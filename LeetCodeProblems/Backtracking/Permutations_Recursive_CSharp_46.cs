using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class Permutations_Recursive_CSharp_46 : IPermutations_46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();            
            
            if (nums.Length == 0)  
            {
                result.Add(new List<int>());  
                return result; 
            }

            var nestedResult = Permute(nums[1..]);
            var currentValue = nums[0];
            foreach (var nestedResultItem in nestedResult)
            {
                for (int i = 0; i < nestedResultItem.Count + 1; i++)
                {
                    var copied = nestedResultItem.ToList();
                    copied.Insert(i, currentValue);
                    result.Add(copied);
                }
            }           

            return result;
        }
    }
}
