using System.Xml.Linq;

namespace LeetCodeProblems.OptimizedSolutions
{
    public class TopKFrequentOptimized
    {
        // This is the solution provided by NeetCode
        // Time Complexity: O(n + u log u + k), which simplifies to O(n log n) in the worst case when all elements are unique.
        // Space Complexity: O(u + k), where u is the number of unique elements and k is the number of top frequent elements to return.

        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (count.ContainsKey(num)) count[num]++;
                else count[num] = 1;
            }

            List<int[]> arr = count.Select(entry => new int[] { entry.Value, entry.Key }).ToList();
            arr.Sort((a, b) => b[0].CompareTo(a[0]));

            int[] res = new int[k];
            for (int i = 0; i < k; i++)
            {
                res[i] = arr[i][1];
            }
            return res;
        }
    }
}
