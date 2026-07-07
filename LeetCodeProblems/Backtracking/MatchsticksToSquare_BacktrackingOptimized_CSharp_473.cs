using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class MatchsticksToSquare_BacktrackingOptimized_CSharp_473 : IMatchsticksToSquare_473
    {
        public bool Makesquare(int[] matchsticks)
        {
            int sum = matchsticks.Sum();
            if (sum % 4 != 0) return false;
            var sideLength = sum / 4;
            int[] sides = new int[4];
            Array.Sort(matchsticks, (a, b) => b.CompareTo(a));
            return recurse(matchsticks, 0, 0, sideLength, sides);
        }

        public bool recurse(int[] matchsticks, int matchIndex, int sideIndex, int sideLength, int[] sides)
        {
            if (matchIndex == matchsticks.Length) return true;
            if (sideIndex == 4) return false;

            if (sides[sideIndex] + matchsticks[matchIndex] <= sideLength)
            {
                sides[sideIndex] += matchsticks[matchIndex];
                if (recurse(matchsticks, matchIndex + 1, 0, sideLength, sides)) return true;
                sides[sideIndex] -= matchsticks[matchIndex];
            }
            if (sides[sideIndex] == 0) return false;

            return recurse(matchsticks, matchIndex, sideIndex + 1, sideLength, sides);
        }
    }
}
