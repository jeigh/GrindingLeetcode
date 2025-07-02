using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    // first attempt
    // time complexity: O(n)
    // space complexity: O(1)

    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int minHeight = Math.Min(height[left], height[right]);
                int area = minHeight * (right - left);
                if (area > maxArea) maxArea = area;
                if (height[left] > height[right]) right--;
                else left++;
            }
            return maxArea;
        }
    }
}
