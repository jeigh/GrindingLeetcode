namespace LeetCodeProblems.Interfaces.Easy
{
    /// <summary>
    /// LeetCode Problem 997: Find the Town Judge
    ///
    /// Among n people labeled 1..n, find the one person who trusts nobody
    /// and is trusted by everybody else. Return their label, or -1 if no such
    /// person exists.
    /// trust[i] = [a, b] means person a trusts person b.
    /// </summary>
    public interface IFindTheTownJudge_997
    {
        int FindJudge(int n, int[][] trust);
    }
}
