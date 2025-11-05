using System.ComponentModel;
using static LeetCodeProblems.CarFleetSolution;
using static System.Formats.Asn1.AsnWriter;

namespace LeetCodeProblems.CSharp.TwoPointers
{
    /// <summary>
    /// You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
    /// 
    /// Find two lines that together with the x-axis form a container, such that the container contains the most water.
    /// 
    /// Return the maximum amount of water a container can store.
    /// 
    /// Notice that you may not slant the container.
    /// </summary>
    public class ContainerWithMostWaterTwoPointersSolution_11
    {
        // first attempt
        // time complexity: O(n)
        // space complexity: O(1)
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
