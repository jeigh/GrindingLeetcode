using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Graph
{

    public class WallsAndGates_CSharp_286 : IWallsAndGates_286
    {
        // time complexity: O(m * n)
        // space complexity: O(m * n)
        public void WallsAndGates(int[][] rooms)
        {
            var queue = new Queue<(int i, int j, int currentDistance)>();

            for (int i = 0; i < rooms.Length; i++)
            {
                for (int j = 0; j < rooms[i].Length; j++)
                {
                    if (rooms[i][j] == GATE) queue.Enqueue((i, j, 0));
                }
            }

            TraverseRooms(rooms, queue);
        }

        private void TraverseRooms(int[][] rooms, Queue<(int i, int j, int currentDistance)> queue)
        {
            while (queue.Count != 0)
            {
                (int i, int j, int currentDistance) = queue.Dequeue();

                if (i < 0) continue;
                if (j < 0) continue;
                if (i == rooms.Length) continue;
                if (j == rooms[0].Length) continue;
                if (rooms[i][j] == WALL) continue;

                if (currentDistance == 0 || rooms[i][j] == INF)
                {
                    if (currentDistance > 0)
                        rooms[i][j] = currentDistance;

                    queue.Enqueue((i + 1, j, currentDistance + 1));
                    queue.Enqueue((i - 1, j, currentDistance + 1));
                    queue.Enqueue((i, j + 1, currentDistance + 1));
                    queue.Enqueue((i, j - 1, currentDistance + 1));
                }
            }
        }

        private const int INF = int.MaxValue;
        private const int WALL = -1;
        private const int GATE = 0;
    }
}
