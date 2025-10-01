namespace LeetCodeProblems.BinarySearch
{
    public class SearchIn2DMatrixSolution_74
    {
        
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return false;

            var left = 0;
            var right = matrix.Length - 1;
            var mid = 0;
            var targetRow = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (matrix[mid][0] == target) 
                    return true;
                
                if (matrix[mid][0] > target)
                    right = mid - 1;                 

                if (matrix[mid][0] < target)
                {
                    left = mid + 1;
                    targetRow = mid;
                }
            }

            left = 0;
            right = matrix[0].Length - 1;
            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (matrix[targetRow][mid] == target) return true;

                if (matrix[targetRow][mid] > target) right = mid - 1;
                if (matrix[targetRow][mid] < target) left = mid + 1;
            }
            return false;
        }
    }
}
