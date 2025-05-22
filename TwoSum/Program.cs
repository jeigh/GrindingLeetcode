using LeetCodeProblems.AddTwo;
using LeetCodeProblems.AnagramGroups;
using LeetCodeProblems.IsValidSudoku;
using LeetCodeProblems.MedianOfTwoSortedArrays;
using LeetCodeProblems.ProductExceptSelf;
using LeetCodeProblems.ValidAnagram;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] board = [
                ['1', '2', '.', '.', '3', '.', '.', '.', '.'],
                ['4', '.', '.', '5', '.', '.', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '.', '3'],
                ['5', '.', '.', '.', '6', '.', '.', '.', '4'],
                ['.', '.', '.', '8', '.', '3', '.', '.', '5'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '.', '.', '.', '.', '.', '2', '.', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '8'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9']
            ];

            var unit = new IsValidSudokuSolution();
            unit.IsValidSudoku(board);


            Console.WriteLine("debugger");

        }
    }
}
