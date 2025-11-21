using LeetCodeProblems.Interfaces.Medium;
using System.Text;

namespace LeetCodeProblems.CSharp.Stack
{
    public class SimplifyPathCSharpStackSolution_71 : ISimplifyPath_71
    {
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new();
            string currentFileName = string.Empty;
            foreach (char pathChar in path)
            {
                switch (pathChar)
                {
                    case '/':
                        if (stack.Count == 0 && currentFileName.Length == 0) continue;
                        if (currentFileName.Length > 0)
                            ProcessFile(stack, ref currentFileName);
                        break;

                    default:
                        currentFileName += pathChar;
                        break;
                }
            }
            if (currentFileName.Length > 0)
                ProcessFile(stack, ref currentFileName);

            return AssembleResponseStringInLinearTime(stack);
        }

        private string AssembleResponseStringInLinearTime(Stack<string> stack)
        {
            if (stack.Count == 0) return "/";

            var parts = stack.ToArray();
            Array.Reverse(parts);
            var result = new StringBuilder();
            foreach (var part in parts)
            {
                result.Append('/');
                result.Append(part);
            }
            return result.ToString();
        }

        // My original solution used this method to assemble the string, until I realized that
        // it essentially made the solution an O(n^2) solution because of the inserts.
        // the corrected solution above is more efficient -- I'm leaving this here for reference on what **not** to do
        private string AssembleResponseStringInQuadraticTime(Stack<string> stack)
        {
            var stringBuilder = new System.Text.StringBuilder();

            if (stack.Count == 0) return "/";

            while (stack.Count > 0)
            {
                stringBuilder.Insert(0, stack.Pop());
                stringBuilder.Insert(0, '/');
            }

            return stringBuilder.ToString();
        }

        private void ProcessFile(Stack<string> stack, ref string currentFileName)
        {
            switch (currentFileName)
            {
                case ".":
                    currentFileName = string.Empty;
                    break;
                case "..":
                    if (stack.Count > 0) stack.Pop();
                    currentFileName = string.Empty;
                    break;
                default:
                    stack.Push(currentFileName);
                    currentFileName = string.Empty;
                    break;
            }
        }
    }
}
