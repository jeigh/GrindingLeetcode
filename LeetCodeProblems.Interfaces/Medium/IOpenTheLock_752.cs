namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 752: Open the Lock
    ///
    /// A lock has 4 circular dials each numbered 0–9. Starting at "0000",
    /// each turn rotates one dial one slot forward or backward (wrapping 9↔0).
    /// Given a list of deadend codes (reaching one permanently locks the device)
    /// and a target code, return the minimum number of turns to reach the target,
    /// or -1 if impossible.
    /// </summary>
    public interface IOpenTheLock_752
    {
        int OpenLock(string[] deadends, string target);
    }
}
