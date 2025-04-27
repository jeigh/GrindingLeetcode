namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class TwoSumSolution
    {
        public class Solution
        {
            public int[] TwoSumOptimized(int[] nums, int target)
            {
                Dictionary<int, int> addends = new();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (addends.ContainsKey(nums[i]))
                    {
                        return [addends[nums[i]], i];
                    }
                    addends[target - nums[i]] = i;
                }
                return [-1, -1];
            }

            public int[] TwoSumUnoptimized(int[] nums, int target)
            {
                int firstIndex = 0;
                foreach (int firstAddend in nums)
                {
                    int secondIndex = 0;
                    foreach (int secondAddend in nums)
                    {
                        if (firstIndex == secondIndex) continue;
                        if (firstAddend + secondAddend == target) return [secondIndex, firstIndex];


                        secondIndex += 1;
                    }

                    firstIndex += 1;
                }
                return [-1, -1];
            }
        }
    }
