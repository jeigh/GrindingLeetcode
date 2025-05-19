using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TopKFrequent
{

    public class TopKFrequentUnoptimizedSolution
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
    }
}
