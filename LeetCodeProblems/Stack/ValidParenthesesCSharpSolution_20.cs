using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems
{
    public class ValidParenthesesCSharpSolution_20 : IValidParentheses_20
    {
        // time commplexity: O(n), space complexity: O(n)
        public bool IsValid(string s)
        {
            var parentheses = new Stack<char>();

            foreach (char c in s)
            {
                char popped = '\n';
                switch (c)
                { 
                    case '(':
                    case '{':
                    case '[':
                        parentheses.Push(c);
                        break;
                    case ']':
                        if (!parentheses.TryPop(out popped) || popped != '[')
                            return false;
                        break;
                    case '}':
                        if (!parentheses.TryPop(out popped) || popped != '{')
                            return false;
                        break;
                    case ')':
                        if (!parentheses.TryPop(out popped) || popped != '(')
                            return false;
                        break;
                    default:
                        break;                        
                }
            }
            if (parentheses.Count > 0) return false;
            return true;
        }
    }
}
