namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// Given an array of positive integers nums and a positive integer target, 
    /// return the minimal length of a subarray whose sum is greater than or equal to target. 
    /// If there is no such subarray, return 0 instead.
    /// </summary>
    public interface IMinimumSizeSubarraySum_209
    {
        public int MinSubArrayLen(int target, int[] nums);
    }
}
