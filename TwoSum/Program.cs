using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new MinimumWindowSubstring();

            var s = "ab";
            var t = "a";
            var result = unit.MinWindowOptimized(s, t);
            
            
            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
