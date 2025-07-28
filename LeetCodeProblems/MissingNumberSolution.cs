namespace LeetCodeProblems
{
    public class MissingNumberSolution
    {
        // time: O(1), space: O(1)
        public int MissingNumber(int[] nums)
        {
            var n = nums.Length;
            int fullSum = n * (n + 1) / 2;
            var partialSum = nums.Sum();
            return fullSum - partialSum;
        }
    }
}
