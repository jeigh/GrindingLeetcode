using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new MaxSlidingWindowSolution();


            int[] nums = [1, 3, -1, -3, 5, 3, 6, 7];

            var k = 3;

            var result = unit.MaxSlidingWindowWithLinkedList(nums, k);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
