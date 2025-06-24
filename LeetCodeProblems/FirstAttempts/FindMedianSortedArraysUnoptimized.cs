using LeetCodeProblems.Shared;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace LeetCodeProblems.FirstAttempts
{

    public class FindMedianSortedArraysUnoptimized 
    {
        // leetcode stats: 15.4% in runtime, 6.02% in memory

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var combined = nums1.Concat(nums2).OrderBy(x => x).ToList();
            double returnable = 0;
            if (combined.Count % 2 == 0) 
            { 
                var upperIndex = combined.Count / 2;
                var lowerIndex = upperIndex - 1;

                var upperValue = combined[upperIndex];
                var lowerValue = combined[lowerIndex];

                returnable = (double)(upperValue + (double)lowerValue) / 2;
                
            }
            else
                returnable = combined[combined.Count / 2];
            return returnable;
        }

        // this runs in the top 100% on leetcode
        // sadly I couldn't come up with this solution myself -- I had to use github copilot
        // I did refactor it for readability


        public double FindMedianSortedArraysOptimized(int[] shorter, int[] longer)
        {

            if (shorter.Length > longer.Length) return FindMedianSortedArraysOptimized(longer, shorter);

            int shorterLength = shorter.Length;
            int longerLength = longer.Length;

            int low = 0,
                high = shorterLength;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = (shorterLength + longerLength + 1) / 2 - partitionX;

                int maxX = GetMax(shorter, partitionX);
                int minX = GetMin(shorter, shorterLength, partitionX);
                int maxY = GetMax(longer, partitionY);
                int minY = GetMin(longer, longerLength, partitionY);

                if (maxX <= minY && maxY <= minX)
                {
                    if ((shorterLength + longerLength) % 2 == 0) return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
                    else return Math.Max(maxX, maxY);
                }
                else if (maxX > minY) high = partitionX - 1;
                else low = partitionX + 1;
            }

            throw new InvalidOperationException("Input arrays are not sorted.");
        }

        private int GetMin(int[] theIntegers, int val, int partition)
        {
            int returnable;

            if (partition == val) returnable = int.MaxValue;
            else returnable = theIntegers[partition];
            return returnable;
        }

        private int GetMax(int[] theIntegers, int partition)
        {
            int returnable;
            if (partition == 0) returnable = int.MinValue;
            else returnable = theIntegers[partition - 1];
            return returnable;
        }

    }
}