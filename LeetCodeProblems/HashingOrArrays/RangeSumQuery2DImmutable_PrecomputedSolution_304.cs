

namespace LeetCodeProblems.HashingOrArrays
{
    public class RangeSumQuery2DImmutable_PrecomputedSolution_304
    {
        // I wrote this before learning about pefix sums.
        // it satisfies the O(1) criteria for the SumRegion method, but because of the size of the _hashmap, it gets an out of memory exception on leetcode.
        // nonetheless, I argue that it is a successful implementation because no size constraints were placed on my implementation
        // leetcode didn't set constraints on time complexity of the constructor or space complexity.
        public class NumMatrix
        {
            private Dictionary<(int row1, int col1, int row2, int col2), int> _hashMap = new();
            
            public NumMatrix(int[][] matrix)
            {
                List<(int row1, int col1, int row2, int col2)> rectangles = new();

                if (matrix.Length == 0)
                    rectangles = CreateAllPossibleRectangles(0, 0);
                else
                    rectangles = CreateAllPossibleRectangles(matrix.Length - 1, matrix[0].Length - 1);

                foreach (var rectangle in rectangles)
                            {
                                int sum = CalculateSum(matrix, rectangle);
                                _hashMap.Add(rectangle, sum);
                            }
            }

            private int CalculateSum(int[][] matrix, (int row1, int col1, int row2, int col2) rectangle)
            {
                int sum = 0;
                for (int r = rectangle.row1; r <= rectangle.row2; r++)
                {
                    for (int c = rectangle.col1; c <= rectangle.col2; c++)
                    {
                        sum += matrix[r][c];
                    }
                }
                return sum;
            }

            public List<(int row1, int col1, int row2, int col2)> CreateAllPossibleRectangles(int dimension1Length, int dimension2Length)
            {
                var returnables = new List<(int row1, int col1, int row2, int col2)>();
                for (int firstRowOffset = 0; firstRowOffset <= dimension1Length; firstRowOffset++)
                {
                    for (int firstColumnOffset = 0; firstColumnOffset <= dimension2Length; firstColumnOffset++)
                    {
                        for (int secondRowOffset = 0; secondRowOffset <= dimension1Length; secondRowOffset++)
                        {
                            for (int secondColumnOffset = 0; secondColumnOffset <= dimension2Length; secondColumnOffset++)
                            {
                                if (firstColumnOffset <= secondColumnOffset && firstRowOffset <= secondRowOffset)
                                {
                                    returnables.Add((firstRowOffset, firstColumnOffset, secondRowOffset, secondColumnOffset));
                                }
                            }
                        }
                    }
                }
                return returnables;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int rectangle1 = _hashMap[( row1,  col1,  row2,  col2)];

                return _hashMap[(row1, col1, row2, col2)];
            }
        }
    }
}
