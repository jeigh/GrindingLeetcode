using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.BruteForce
{
    public class FindKClosestElementsBruteForce_658 : IFindKClosestElements_658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var queue = new PriorityQueue<int, double>();

            foreach(int i in arr)
            {
                queue.Enqueue(i, orderHack(x, i));
            }

            var returnable = new List<int>();
            for (int i = 0; i < k; i++)
            {
                returnable.Add(queue.Dequeue());
            }

            returnable.Sort();

            return returnable;
        }

        public double orderHack(int x, int i)
        {
            double retval = Math.Abs(x - i);
            if (i > x) retval = retval + 0.1;
            return retval;
        }
    }
}
