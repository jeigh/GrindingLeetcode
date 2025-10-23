using System.ComponentModel.DataAnnotations;

namespace LeetCodeProblems.Hashing
{
    public class ConcatenationOfArraySolution_1929
    {
        public int[] GetConcatenation(int[] nums)
        {
            var returnable = new List<int>(nums.Count() * 2);

            foreach (var item in nums)
            {
                returnable.Add(item);
            }
            foreach (var item in nums)
            {
                returnable.Add(item);
            }
            return returnable.ToArray();
        }
    }
}
