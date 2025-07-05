namespace LeetCodeProblems
{
    public class LastStoneWeightSolution
    {
        // time complexity: O(n log n),  space complexity: O(n)
        private PriorityQueue<int, int> _weights = new PriorityQueue<int, int>();

        public int LastStoneWeight(int[] stones)
        {
            foreach (int stone in stones) 
                _weights.Enqueue(stone, -stone);

            while (_weights.Count > 1)
            {
                var y = _weights.Dequeue();
                var x = _weights.Dequeue();                

                if (x == y) continue;
                var newVal = y - x;
                if (x < y) _weights.Enqueue(newVal, -newVal);
            }

            if (_weights.Count == 1) 
                return _weights.Dequeue();

            return 0;
        }
    }
}
