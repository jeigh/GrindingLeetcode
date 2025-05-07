using LeetCodeProblems.AddTwo;
using LeetCodeProblems.MedianOfTwoSortedArrays;
using LeetCodeProblems.ValidAnagram;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new FindMedianSortedArraysOptimized();

            var unit = new ValidAnagram();

            var result = unit.IsAnagram("jar", "jam");

            Console.WriteLine("debugger");

        }
    }
}
