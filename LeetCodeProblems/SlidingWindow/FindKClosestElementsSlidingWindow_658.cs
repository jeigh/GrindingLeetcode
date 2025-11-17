using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.SlidingWindow
{    
    public class FindKClosestElementsSlidingWindow_658 : IFindKClosestElements_658
    {
        // space complexity: O(k), time complexity O(n-k)
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (k >= arr.Length) return arr.ToList();

            var left = 0;
            var right = arr.Length - 1;

            while (right - left >= k)
            {
                int leftDistance = Math.Abs(arr[left] - x);
                int rightDistance = Math.Abs(arr[right] - x);

                if (leftDistance > rightDistance)
                    left++;
                else if (leftDistance < rightDistance)
                    right--;
                else
                    right--;
            }

            return arr[left..(right + 1)].ToList();
        }
    }
}
