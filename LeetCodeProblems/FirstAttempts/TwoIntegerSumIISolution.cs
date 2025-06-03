namespace LeetCodeProblems.FirstAttempts
{
    public class TwoIntegerSumIISolution
    {
        // this was my solution after reading the hints.
        // space complexity: O(n)
        // time complexity:  O(1)

        public int[] TwoSum(int[] numbers, int target)
        {
            int l = 0;
            int r = numbers.Length - 1;

            while (l < r)
            {
                if (numbers[l] + numbers[r] == target) return [l + 1, r + 1];
                if (numbers[l] + numbers[r] > target)
                {
                    r--;
                    continue;
                }
                if (numbers[l] + numbers[r] < target) 
                {
                    l++;
                    continue;
                }                
            }

            return [-1, -1];
        }
    }
}
