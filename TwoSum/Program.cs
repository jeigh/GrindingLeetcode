using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new TrappingRainWater();
            List<int> input = [4, 2, 0, 3, 2, 5];
            var result = unit.Trap(input.ToArray());
            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
