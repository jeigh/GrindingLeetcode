using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new SearchSolution();



            int[] nums = [-1, 0, 2, 4, 6, 8];
            var target = 4;



            var result = unit.Search(nums, target);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
