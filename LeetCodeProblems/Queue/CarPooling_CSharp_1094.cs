using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Queue
{
    public class CarPooling_CSharp_1094 : ICarPooling_1094
    {

        const int numPassengers = 0;
        const int from = 1;
        const int to = 2;

        public bool CarPooling(int[][] trips, int capacity)
        {
            var dropOffQueue = new PriorityQueue<int[], int>();

            var pickupQueue = new PriorityQueue<int[], int>();
            foreach (int[] queueItem in trips)
            {
                if (queueItem[numPassengers] > capacity) return false;
                if (queueItem[to] > queueItem[from]) pickupQueue.Enqueue(queueItem, queueItem[from]);
            }

            var distance = 0;
            int seatsInUse = 0;
            while (pickupQueue.Count > 0)
            {
                // this ordering assumes that the peeps will get off the bus before new peeps try to get on..
                // which is the obviously right thing to do, but i've also ridden on the subway before.  ;-)

                if (dropOffQueue.Count > 0 && dropOffQueue.Peek()[to] == distance)
                {
                    var dequeued = dropOffQueue.Dequeue();
                    seatsInUse -= dequeued[numPassengers];
                }
                if (pickupQueue.Count > 0 && pickupQueue.Peek()[from] == distance)
                {
                    var dequeued = pickupQueue.Dequeue();
                    if (dequeued[numPassengers] + seatsInUse > capacity) return false;
                    seatsInUse += dequeued[numPassengers];
                    dropOffQueue.Enqueue(dequeued, dequeued[to]);
                }                
                distance++;
            }

            return true;
        }
    }
}
