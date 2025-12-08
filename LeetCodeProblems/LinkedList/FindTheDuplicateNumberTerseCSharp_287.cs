using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class FindTheDuplicateNumberTerseCSharp_287 : IFindTheDuplicateNumber_287
    {
        public int FindDuplicate(int[] nums)
        {
            int firstIntersectionIndex = AdvanceTortoiseAndHareToIntersection(nums);
            int secondIntersectionIndex = AdvanceTwoTortoisesToIntersection(nums, firstIntersectionIndex);
            return nums[secondIntersectionIndex];
        }

        private int AdvanceTwoTortoisesToIntersection(int[] nums, int firstTortoise)
        {
            var secondTortoise = 0;

            while (nums[firstTortoise] != nums[secondTortoise])
            {
                secondTortoise = nums[secondTortoise];
                firstTortoise = nums[firstTortoise];
            }

            return secondTortoise;
        }

        private int AdvanceTortoiseAndHareToIntersection(int[] nums)
        {
            var tortoise = 0;
            var hare = 0;

            tortoise = nums[tortoise];
            hare = nums[nums[hare]];

            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            }

            return tortoise;
        }
    }
}
