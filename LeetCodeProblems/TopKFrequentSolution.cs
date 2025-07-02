using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{

    public class TopKFrequentSolution
    {
        // this was my first attempt without looking at the solution
        // time complexity: O(n + u log u), which simplifies to O(n log n) in the worst case when all elements are unique.
        // space complexity: O(u+k), where u is the number of unique elements in the input array.

        public int[] TopKFrequent(int[] nums, int k)
        {
            var hist = Histogramize(nums);
            List<KeyValuePair<int, int>> sortedHist = hist.OrderByDescending(x => x.Value).ToList();

            return (from abc in sortedHist select abc.Key).Take(k).ToArray();
        }

        private Dictionary<int, int> Histogramize(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num)) dict[num]++;
                else dict.Add(num, 1);
            }

            return dict;
        }

        // This is the solution provided by NeetCode
        // Time Complexity: O(n + u log u + k), which simplifies to O(n log n) in the worst case when all elements are unique.
        // Space Complexity: O(u + k), where u is the number of unique elements and k is the number of top frequent elements to return.

        public int[] TopKFrequentOptimized(int[] nums, int k)
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
