namespace LeetCodeProblems
{
    public class IsValidSudokuSolution
    {
        // this was my hand-crafted solution before reading about any optimization techniques.

        public bool IsValidSudoku(char[][] board)
        {
            char[] testable;

            for (int i=0; i < 9; i++)
            {
                testable = board[i];
                if (HasDuplicates(testable)) return false;
            }

            char[][] transposed = Transpose(board);
            for (int i = 0; i < 9; i++)
            {
                testable = transposed[i];
                if (HasDuplicates(testable)) return false;
            }

            for(int i=0;i < 3; i++)
            {
                var firstDimensionOffset = i * 3;
                testable = FlattenThreeByThree(board, firstDimensionOffset, 0);
                if (HasDuplicates(testable)) return false;

                testable = FlattenThreeByThree(board, firstDimensionOffset, 3);
                if (HasDuplicates(testable)) return false;

                testable = FlattenThreeByThree(board, firstDimensionOffset, 6);
                if (HasDuplicates(testable)) return false;
            }

            return true;
        }

        public char[] FlattenThreeByThree(char[][] source, int firstDimensionOffset, int secondDimensionOffset)
        {
            var returnable = new List<char>();
            for (int row = firstDimensionOffset; row < firstDimensionOffset + 3; row++)
            {
                for (int col = secondDimensionOffset; col < secondDimensionOffset + 3; col++)
                {
                    returnable.Add(source[row][col]);
                }
            }
            return returnable.ToArray();
        }

        public char[][] Transpose(char[][] original)
        {
            int rows = original.Length;
            int cols = original[0].Length;
            char[][] transposed = new char[cols][];
            for (int i = 0; i < cols; i++)
            {
                transposed[i] = new char[rows];
                for (int j = 0; j < rows; j++)
                {
                    transposed[i][j] = original[j][i];
                }
            }
            return transposed;
        }

        public bool HasDuplicates(char[] flattened)
        {
            var seen = new HashSet<char>();
            foreach (var item in flattened)
            {
                if (item == '.') continue;
                if (seen.Contains(item)) return true;
                seen.Add(item);
            }
            return false;
        }


    }
}
