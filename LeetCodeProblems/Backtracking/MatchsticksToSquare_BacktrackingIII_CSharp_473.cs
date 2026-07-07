using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class MatchsticksToSquare_BacktrackingIII_CSharp_473 : IMatchsticksToSquare_473
    {
        public bool Makesquare(int[] matchsticks)
        {
            var sum = matchsticks.Sum();
            if (sum % 4 != 0) return false;
            var sideLength = sum / 4;
            int matchIndex = 0;
            int sideIndex = 0;
            int[] sides = new int[4];

            return recurse(matchsticks, sideLength, matchIndex, sideIndex, sides);
        }

        private bool recurse(int[] matchsticks, int sideLength, int matchIndex, int sideIndex, int[] sides)
        {
            if (matchIndex == matchsticks.Length) return sides[0] == sides[1] && sides[1] == sides[2] && sides[2] == sides[3];
            if (sideIndex == 4) return false;

            sides[sideIndex] += matchsticks[matchIndex];
            if (sides[sideIndex] <= sideLength && recurse(matchsticks, sideLength, matchIndex + 1, 0, sides)) return true;
            sides[sideIndex] -= matchsticks[matchIndex];

            return recurse(matchsticks, sideLength, matchIndex, sideIndex + 1, sides);
        }
    }
}
