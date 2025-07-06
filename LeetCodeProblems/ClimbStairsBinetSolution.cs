namespace LeetCodeProblems
{

    public class ClimbStairsBinetSolution
    {
        // this is the math-solution to the problem, not a computer science solution.
        // explained fully in a numberphile video that I saw a few months earlier
        // https://www.youtube.com/watch?v=JBkmR3rzz5M
        // while this is an O(1) solution, it fails to beat leetcode solutions for small numbers
        // apparently binet's solution is also the closed solution for calculating fibbanocci numbers
        public int ClimbStairs(int n)
        {
            double squareRootOfFive = 2.2360679775;

            double first = (5 + squareRootOfFive) * 0.1;
            double third = (5 - squareRootOfFive) * 0.1;
            
            double second = Math.Pow((1+squareRootOfFive) * 0.5, n);
            double fourth = Math.Pow((1-squareRootOfFive) * 0.5, n);

            int retval = (int) Math.Round(first * second + third * fourth);
            return retval;
        }
    }
}
