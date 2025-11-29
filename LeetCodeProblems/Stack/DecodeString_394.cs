using LeetCodeProblems.Interfaces.Medium;
using System.Numerics;
using System.Text;

namespace LeetCodeProblems.CSharp.Stack
{
    public class DecodeString_394 : IDecodeString_394
    {
        // this is the best solution on neetcode with some minor tweaks...
        // I changed the two stacks into just one stack<(int, string)> for clarity
        // and renamed some variables to make it more understandable

        // my default instinct was to parse this as count[segment], but when dealing with the stack
        // you parse it like segmentcount[;  they are paired together based on the depth, not based on 
        // the specific segment that gets duplicated count times.  this was
        // the biggest barrier to comprenhension for me.

        // practically, I think a recursive solution is more intelligible
        public  string DecodeString(string s)
        {
            var stack = new Stack<(int count, string segment)>();

            string activeSegment = "";
            int k = 0;

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    // think of this like "base 10 left bitshift"
                    k = k * 10 + (c - '0');
                }
                else if (c == '[')
                {
                    stack.Push((k, activeSegment));

                    activeSegment = "";
                    k = 0;
                }
                else if (c == ']')
                {
                    string encodedPart = activeSegment;
                    var context = stack.Pop();
                    activeSegment = ExpandAndConcatenate(encodedPart, context);
                }
                else
                {
                    activeSegment += c;
                }
            }

            return activeSegment;
        }

        private string ExpandAndConcatenate(string encodedPart, (int count, string parentSegment) context)
        {
            var sb = new StringBuilder(context.parentSegment.Length + encodedPart.Length * context.count);
            sb.Append(context.parentSegment);
            for (int i = 0; i < context.count; i++)
            {
                sb.Append(encodedPart);
            }
            return sb.ToString();
        }
    }
}
