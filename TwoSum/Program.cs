using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var nums = new int[] {2, 20, 4, 10, 3, 4, 5};
            var unit = new LargestConsecutiveUnoptimized();
            var result = unit.LongestConsecutive(nums);


            Console.WriteLine("debugger");

        }
    }
}
