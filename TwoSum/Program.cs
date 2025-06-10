using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new LongestRepeatingCharacterReplacementSolution();

            var s = "ABAB";
            var k = 2;
            var result = unit.CharacterReplacementSlidingWindow(s, k);
            
            
            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
