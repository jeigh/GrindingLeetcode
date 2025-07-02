using System.Text;

namespace LeetCodeProblems
{
    public class GenerateParenthesisSolution
    {
        public List<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            string stringStack = string.Empty;
            
            Recurse(0, 0, result, n, stringStack);
            return result;
        }

        public void Recurse(int open, int closed, List<string> result, int maxNumberOfOpenParen, string stringStack)
        {
            if (open == closed && open == maxNumberOfOpenParen) 
            { 
                result.Add(stringStack); 
                return;
            }


            if (open < maxNumberOfOpenParen)
                Recurse(open + 1, closed, result, maxNumberOfOpenParen, stringStack + "(");
                

            if (closed < open)
                Recurse(open, closed + 1, result, maxNumberOfOpenParen, stringStack + ")");
        }
    }
}
