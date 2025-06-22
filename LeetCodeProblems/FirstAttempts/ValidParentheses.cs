using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.FirstAttempts
{
    public class ValidParentheses
    {
        // this was an easy one.
        // time commplexity: O(n)
        // space complexity: O(n)
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
