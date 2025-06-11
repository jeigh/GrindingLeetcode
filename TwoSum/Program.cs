using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new PermutationInString();

            var s2 = "dcda";
            var s1 = "adc";
            var result = unit.CheckInclusionSlidingWindow(s1, s2);
            
            
            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
