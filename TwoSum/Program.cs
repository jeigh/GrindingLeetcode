using LeetCodeProblems.AddTwo;
using LeetCodeProblems.AnagramGroups;
using LeetCodeProblems.MedianOfTwoSortedArrays;
using LeetCodeProblems.ValidAnagram;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var unit = new GroupAnagramsSolution();

            var result = unit.GroupAnagrams(new string[] { "act", "pots", "tops", "cat", "stop", "hat" });

            Console.WriteLine("debugger");

        }
    }
}
