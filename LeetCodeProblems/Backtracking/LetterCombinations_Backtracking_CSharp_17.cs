using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class LetterCombinations_Backtracking_CSharp_17 : ILetterCombinations_17
    {
        private char[] _twos = ['a', 'b', 'c'];
        private char[] _threes = ['d', 'e', 'f'];
        private char[] _fours = ['g', 'h', 'i'];
        private char[] _fives = ['j', 'k', 'l'];
        private char[] _sixes = ['m', 'n', 'o'];
        private char[] _sevens = ['p', 'q', 'r', 's'];
        private char[] _eights = ['t', 'u', 'v'];
        private char[] _nines = ['w', 'x', 'y', 'z'];



        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (digits.Count() == 0) return result;
            recurse(digits, 0, new List<char>(), result);
            return result;
        }

        private void recurse(string digits, int i, List<char> currentList, List<string> result)
        {
            if (i == digits.Length)
            {
                result.Add(new string(currentList.ToArray()));
                return;
            }

            char[] pool = _twos;
            switch(digits[i])
            {
                case '2':
                    break;
                case '3':
                    pool = _threes;
                    break;

                case '4':
                    pool = _fours;
                    break;

                case '5':
                    pool = _fives;
                    break;

                case '6':
                    pool = _sixes;
                    break;

                case '7':
                    pool = _sevens;
                    break;

                case '8':
                    pool = _eights;
                    break;

                case '9':
                    pool = _nines;
                    break;

                default:
                    throw new NotImplementedException("Scenario is for 2 to 9 inclusive");

            }

            foreach(char c in pool)
            {
                currentList.Add(c);
                recurse(digits, i + 1, currentList, result);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
