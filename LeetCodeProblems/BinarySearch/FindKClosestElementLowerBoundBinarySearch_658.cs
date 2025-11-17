using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.BinarySearch
{

    public class FindKClosestElementLowerBoundBinarySearch_658 : IFindKClosestElements_658
    {
        // time complexity: O(log(n-k));  space complexity: O(k)
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var left = 0;
            var right = arr.Length - k;
            var windowStart = 0;

            while (left < right)
            {
                windowStart = left + (right - left) / 2;

                if (x - arr[windowStart] > arr[windowStart + k] - x)
                    left = windowStart + 1;
                else
                    right = windowStart;
            }
            return arr[left..(left + k)];
        }
    }
}
