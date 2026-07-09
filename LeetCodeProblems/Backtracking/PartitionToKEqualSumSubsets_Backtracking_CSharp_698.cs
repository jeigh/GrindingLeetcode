using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class PartitionToKEqualSumSubsets_Backtracking_CSharp_698 : IPartitionToKEqualSumSubsets_698
    {

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            var sum = nums.Sum();
            if (sum % k != 0) return false;
            var partitionSize = sum / k;

            return recurse(nums, partitionCount: k, partitionSize, numsIndex: 0, partitionIndex: 0, partitions: new int[k]);
        }

        private bool recurse(int[] nums, int partitionCount, int partitionSize, int numsIndex, int partitionIndex, int[] partitions)
        {
            if (numsIndex == nums.Length)
            {
                foreach( var partitionItem in partitions )
                {
                    if (partitionItem != partitionSize) return false;
                }

                return true;
            }
            
            if (partitionIndex == partitions.Length) return false;

            
            partitions[partitionIndex] += nums[numsIndex];
            if (partitions[partitionIndex] <= partitionSize && recurse(nums, partitionCount, partitionSize, numsIndex + 1, 0, partitions)) return true;
            partitions[partitionIndex] -= nums[numsIndex];

            return recurse(nums, partitionCount, partitionSize, numsIndex, partitionIndex + 1, partitions);
        }


    }
}
