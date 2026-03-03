using LeetCodeProblems.Interfaces.Medium;
using System.Collections.Generic;

namespace LeetCodeProblems.CSharp.Queue
{
    public class KthClosestPointsToOrigin_CSharp_973 : IKthClosestPointsToOrigin_973
    {
        public int[][] KClosest(int[][] points, int k)
        {
            var queue = new PriorityQueue<int[], double>();
            foreach (var point in points)
            {
                var x = point[0];
                var y = point[1];

                var magnitude = Math.Sqrt(x * x + y * y);

                queue.Enqueue(point, -magnitude);
            }
            while (queue.Count > k) queue.Dequeue();
            return queue.UnorderedItems.Select(x => x.Element).ToArray();
        }
    }
}
