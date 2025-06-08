using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new LongestSubstringWithoutRepeats();
            string input = "abcabcbb";
            var result = unit.LengthOfLongestSubstringSlidingWindow(input);
            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
