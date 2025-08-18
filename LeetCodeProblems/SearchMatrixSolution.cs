using System.Data.SqlTypes;

namespace LeetCodeProblems
{
    //time: O(m+n) where m and n are the number of rows and cols respectively
    //space: O(1) 
    public class SearchMatrixSolution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            if (rows == 0) return false;
            int cols = matrix[0].Length;
            if (cols == 0) return false;

            // Start from top-right corner
            int row = 0;
            int col = cols - 1;

            while (row < rows && col >= 0)
            {
                if (matrix[row][col] == target)
                    return true;
                else if (matrix[row][col] > target)
                    col--; // Move left
                else
                    row++; // Move down
            }

            return false;
        }
    }
}
