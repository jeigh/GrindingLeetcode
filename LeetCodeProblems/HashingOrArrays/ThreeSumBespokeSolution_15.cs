using System.Linq;

namespace LeetCodeProblems
{
    /// <summary>
    /// Given an integer array nums, return all the triplets[nums[i], nums[j], nums[k]] 
    /// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    /// Notice that the solution set must not contain duplicate triplets.
    /// </summary>
    public class ThreeSumBespokeSolution_15
    {
        // I started down the non-ideal solution to this problem and ended up with more code than I needed.
        // I ended up taking several hours to correct the mistakes that I made in my first attempt.
        // Despite being bespoke, it does satisfy the time complexity requirement though.
        // Time complexity: O(n^2), Space Complexity: O(n^2)
        private List<(int, int)> TwoSum(int[] originalNums, int targetOffset)
        {
            var returnable = new List<(int, int)>();
            int targetValue = -originalNums[targetOffset];

            var complementValueToIndex = new Dictionary<int, int>();
            for (int i = targetOffset + 1; i < originalNums.Length; i++)
            {
                var currentValue = originalNums[i];
                
                if (complementValueToIndex.ContainsKey(currentValue))
                {
                    var originalValue = originalNums[complementValueToIndex[currentValue]];
                    returnable.Add((originalValue, currentValue));
                    
                    i = JumpToNextDistinctValue(originalNums, i);
                }
                else
                {
                    complementValueToIndex.TryAdd(targetValue - currentValue, i);
                }
            }

            return returnable;
        }

        private int JumpToNextDistinctValue(int[] originalNums, int i)
        {
            while (i < originalNums.Length - 1 && originalNums[i] == originalNums[i + 1]) 
                i++;
            
            return i;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var valueTupleResults = new HashSet<(int, int, int)>();
            
            for(int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                List<(int, int)>? results = TwoSum(nums, i)?.ToList();
                if (results == null)
                    continue;  
                else
                {
                    var prependable = nums[i];
                    var prepended = Prepend(nums[i], results);

                    foreach(var abc in prepended)
                    {
                        if (!valueTupleResults.Contains(abc))
                            valueTupleResults.Add(abc);
                    }
                }
            }
            return Convert(valueTupleResults);
        }

        private List<(int, int, int)> Prepend(int firstValue, List<(int, int)> results)
        {
            var returnable = new List<(int, int, int)>();
            foreach ((int, int) item in results)
            {
                var triplet = new[] { firstValue, item.Item1, item.Item2 };
                Array.Sort(triplet);
                returnable.Add((triplet[0], triplet[1], triplet[2]));
            }
            return returnable;
        }

        private IList<IList<int>> Convert(HashSet<(int, int, int)> convertable)
        {
            var converted = new List<IList<int>>();
            foreach(var item in convertable)
            {
                IList<int> innerConverted = [item.Item1, item.Item2, item.Item3];

                converted.Add(innerConverted);
            }
            return converted;
        }
    }
}
