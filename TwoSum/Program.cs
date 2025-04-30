using LeetCodeProblems.AddTwo;
using LeetCodeProblems.MedianOfTwoSortedArrays;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solution = new FindMedianSortedArraysOptimized();

            var result = solution.FindMedianSortedArrays(
                [1, 3, 9, 12, 40, 50, 81, 91], 
                [2, 7, 10, 22, 47, 82]);


            Console.WriteLine("debugger");

        }
    }
}
