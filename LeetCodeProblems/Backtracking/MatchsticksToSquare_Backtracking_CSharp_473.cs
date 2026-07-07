using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{


    public class MatchsticksToSquare_Backtracking_CSharp_473 : IMatchsticksToSquare_473
    {
        public bool Makesquare(int[] matchsticks)
        {
            var sum = matchsticks.Sum();
            if (sum % 4 != 0) return false;
            var targetSideLength = sum / 4;

            return recurse(matchsticks, new int[4], 0, targetSideLength);
        }

        public bool recurse(int[] matchsticks, int[] sides, int matchIndex, int targetSideLength)
        {
            if (matchIndex == matchsticks.Length) return sides[0] == sides[1] && sides[1] == sides[2] && sides[2] == sides[3];

            for(int sideIndex = 0; sideIndex < 4; sideIndex++)
            {
                sides[sideIndex] += matchsticks[matchIndex];
                if (sides[sideIndex] <= targetSideLength && recurse(matchsticks, sides, matchIndex + 1, targetSideLength)) return true;
                sides[sideIndex] -= matchsticks[matchIndex];
            }
            return false;
        }
    }
}
