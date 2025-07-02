namespace LeetCodeProblems
{
    public class DailyTemperaturesSolution
    {
        // i recognized this as a monotonic decreasing stack problem from the outset.
        // space complexity: O(n)
        // time complexity: O(n)
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];

            var monotonicDecreasingStack = new Stack<int>();

            for(int i = 0; i < temperatures.Length; i++)
            {
                var temp = temperatures[i];
                if (monotonicDecreasingStack.Count == 0) 
                    monotonicDecreasingStack.Push(i);
                else
                {
                    
                    
                    while (
                        monotonicDecreasingStack.TryPeek(out int peeked)  && 
                        temp > temperatures[peeked])
                    {
                        var offset = monotonicDecreasingStack.Pop();
                        result[offset] = i - offset;
                    }
                    monotonicDecreasingStack.Push(i);
                }
            }
            return result;
        }
    }
}
