using LeetCodeProblems.Interfaces.Medium;
using System.ComponentModel;
using System.Text;

namespace LeetCodeProblems.CSharp.Backtracking
{
    public class GenerateParentheses_Backtracking_CSharp_22 : IGenerateParentheses_22
    {

        public IList<string> GenerateParenthesis(int n)
        {
            int usedOpen = 0;
            int usedClosed = 0;

            StringBuilder current = new StringBuilder();
            List<string> result = new List<string>();

            recurse(n, usedOpen, usedClosed, current, result);

            return result;
        }

        private void recurse(int n, int usedOpen, int usedClosed, StringBuilder current, List<string> result)
        {
            if (usedOpen == n && usedClosed == n)
            {
                result.Add(current.ToString());
                return;
            }


            if (usedOpen < n)
            {
                var len = current.Length;
                current.Append('(');
                recurse(n, usedOpen + 1, usedClosed, current, result);
                current.Length = len;
            }

            if (usedClosed < usedOpen)
            {
                var len = current.Length;
                current.Append(')');
                recurse(n, usedOpen, usedClosed + 1, current, result);
                current.Length = len;
            }

        }
    }
}
