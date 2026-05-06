using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class SubsetsII_Iterative_CSharp_90 : ISubsetsII_90
    {
        // time complexity: O(n * 2^n)
        // space complexity: O(n * 2^n)
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>> {new List<int>()};
            Array.Sort(nums);
            int lastBatchSize = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                bool skipThisElement = i > 0 && nums[i] == nums[i-1];
                int startIndex = skipThisElement ? result.Count - lastBatchSize : 0;
                int newBatchSize = 0;
                int endIndex = result.Count;
                for (int j = startIndex; j < endIndex; j++)
                {
                    var copy = result[j].ToList();
                    copy.Add(nums[i]);
                    result.Add(copy);

                    newBatchSize++;
                }
                lastBatchSize = newBatchSize;
            }

            return result;
        }
    }
}
