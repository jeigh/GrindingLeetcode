namespace LeetCodeProblems.BinarySearch
{
    public class CapacityToShipPackagesWithinDDaysSoluition_1011
    {
        public int ShipWithinDays(int[] weights, int days)
        {
            var left = weights.Max();
            var right = weights.Sum();
            var capacity = 0;
            var returnable = right;

            while (left <= right)
            {
                capacity = left + (right - left) / 2;
                var shipCount = GetShipCount(weights, capacity);

                if (shipCount <= days) 
                {
                    returnable = capacity;
                    right = capacity - 1;
                }
                if (shipCount > days) left = capacity + 1;

            }
            return returnable;
        }

        public int GetShipCount(int[] weights, int capacity)
        {
            int shipsNeeded = 1; 
            int currentLoad = 0; 

            foreach (int weight in weights)
            {
                if (weight > capacity) return int.MaxValue;
                
                if (currentLoad + weight > capacity)
                {
                    shipsNeeded++;
                    currentLoad = weight; // Start loading new ship
                }
                else
                {
                    currentLoad += weight;
                }
            }

            return shipsNeeded;
        }
    }
}
