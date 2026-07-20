using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.HashingOrArrays
{
    public class WallsAndGates_CSharp_Bespoke_286 : IWallsAndGates_286
    {
        // time complexity: O(k * m * n) where k = number of gates — DFS per gate may revisit cells
        // space complexity: O(m * n)
        public void WallsAndGates(int[][] rooms)
        {
            int i = 0;
            int j = 0;
            
            while (true)
            {
                var nextIJ = FindNextGate(rooms, i, j);
                if (nextIJ == null) break;                

                i = nextIJ.Value.i;
                j = nextIJ.Value.j;

                var currentDistance = 0;

                // right
                    markAdjacentRooms(rooms, i + 1, j, currentDistance + 1);

                // left
                    markAdjacentRooms(rooms, i - 1, j, currentDistance + 1);

                // down
                    markAdjacentRooms(rooms, i, j + 1, currentDistance + 1);

                // up
                    markAdjacentRooms(rooms, i, j - 1, currentDistance + 1);

                int nextI = i + 1;
                int nextJ = j;

                if (nextI == rooms.Length)
                {
                    nextI = 0;
                    nextJ = j + 1;
                }

                i = nextI;
                j = nextJ;
            }
        }

        private void markAdjacentRooms(int[][] rooms, int i, int j, int currentDistance)
        {
            if (i < 0 || j < 0) return;
            if (i == rooms.Length || j == rooms[0].Length) return;

            if (rooms[i][j] == WALL) return;
            if (rooms[i][j] == GATE) return;
            if (rooms[i][j] != INF && rooms[i][j] <= currentDistance) return;

            rooms[i][j] = currentDistance;

            // right
                markAdjacentRooms(rooms, i + 1, j, currentDistance + 1);
            
            // left
                markAdjacentRooms(rooms, i - 1, j, currentDistance + 1);
            
            // down
                markAdjacentRooms(rooms, i, j + 1, currentDistance + 1);
            
            // up
                markAdjacentRooms(rooms, i, j - 1, currentDistance + 1);
        }

        private (int i, int j)? FindNextGate(int[][] rooms, int i, int j)
        {
            while (true)
            {
                if (i == rooms.Length) break;
                if (j == rooms[0].Length) break;

                if (rooms[i][j] == GATE) return (i, j);

                int nextI = i + 1;
                int nextJ = j;

                if (nextI == rooms.Length)
                {
                    nextI = 0;
                    nextJ = j + 1;
                }

                i = nextI;
                j = nextJ;
            }
            return null;
        }


        private const int INF = int.MaxValue;
        private const int WALL = -1;
        private const int GATE = 0;


    }
}
