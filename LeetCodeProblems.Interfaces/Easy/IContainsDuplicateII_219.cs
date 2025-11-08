using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    /// </summary>
    public interface IContainsDuplicateII_219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k);
    }
}
