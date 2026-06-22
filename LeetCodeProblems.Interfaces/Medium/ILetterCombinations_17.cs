namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// LeetCode Problem 17: Letter Combinations of a Phone Number
    ///
    /// Given a string containing digits from 2-9, return all possible letter
    /// combinations that the number could represent, in any order.
    /// Return an empty list if the input is empty.
    ///
    /// Phone mapping: 2→abc, 3→def, 4→ghi, 5→jkl, 6→mno, 7→pqrs, 8→tuv, 9→wxyz
    /// </summary>
    public interface ILetterCombinations_17
    {
        IList<string> LetterCombinations(string digits);
    }
}
