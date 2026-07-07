using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class MatchsticksToSquare_BacktrackingII_CSharp_473 : IMatchsticksToSquare_473
    {
        public bool Makesquare(int[] matchsticks)
        {
            var used = new bool[matchsticks.Length];
            var sum = matchsticks.Sum();
            if (sum % 4 != 0 && matchsticks.Length > 0) return false;
            
            var sideLength = sum / 4;
            return recurse(matchsticks, used, sideLength, 4, 0, 0);
        }

        private bool recurse(int[] matchsticks, bool[] used, int sideLength, int sidesRemaining, int currentSideSum, int startIndex)
        {
            if (sidesRemaining == 0) return true;
            if (currentSideSum == sideLength) return recurse(matchsticks, used, sideLength, sidesRemaining - 1, 0, 0);

            for (int i = startIndex; i < matchsticks.Length; i++)
            {
                if (used[i] || currentSideSum + matchsticks[i] > sideLength) continue;

                used[i] = true;
                if (recurse(matchsticks, used, sideLength, sidesRemaining, currentSideSum + matchsticks[i], i + 1)) return true;
                used[i] = false;
            }

            return false;
        }
    }
}
