namespace LeetCodeProblems.FirstAttempts
{
    public class LargestRectangleAreaSolution
    {
        public int LargestRectangleArea(int[] heights)
        {
            var monotonicIncreasingStack = new Stack<(int index, int height)>();
            int maxArea = 0;

            int start = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                start = i;
                while (monotonicIncreasingStack.TryPeek(out (int index, int height) peeked) && heights[i] < peeked.height)
                {
                    var popped = monotonicIncreasingStack.Pop();
                    start = popped.index;

                    var currentArea = popped.height * (i - start);
                    maxArea = Math.Max(maxArea, currentArea);

                }
                monotonicIncreasingStack.Push((start, heights[i]));
            }

            foreach((int index, int height) item in monotonicIncreasingStack)
            {
                maxArea = Math.Max(maxArea, item.height * (heights.Length - item.index));
            }
            return maxArea;
        }
    }
}

