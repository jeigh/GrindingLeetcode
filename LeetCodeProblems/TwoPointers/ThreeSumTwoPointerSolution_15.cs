namespace LeetCodeProblems.TwoPointers
{
    public class ThreeSumTwoPointerSolution_15
    {
        // I had to review other's solutions before I really understood what was going on here.
        // time complexity O(n^2) where n is the length of the array
        // space complexity O(m) where m is the number lists to be returned

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var returnable = new List<IList<int>>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var left = i + 1;
                var right = nums.Length - 1;
                while (left < right)
                {
                    var sum = nums[left] + nums[right] + nums[i];
                    if (sum < 0) left++;
                    else if (sum > 0) right--;
                    else
                    {
                        var item = new List<int>
                        {
                            nums[i],
                            nums[left],
                            nums[right]
                        };

                        returnable.Add(item);
                        left++;
                        while (left < right && nums[left] == nums[left - 1]) left++;
                    }
                }
            }
            return returnable;
        }

    }
}
