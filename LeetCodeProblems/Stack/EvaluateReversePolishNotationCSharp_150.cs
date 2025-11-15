using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Stack
{
    public class EvaluateReversePolishNotationCSharp_150 : IEvaluateReversePolishNotationCSharp_150
    {
        // this one was fairly easy
        // space complexity: O(n)
        // time complexity: O(n)

        public int EvalRPN(string[] tokens)
        {
            Stack<int> theStack = new Stack<int>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int parsed))
                {
                    theStack.Push(parsed);
                }
                else
                {
                    int secondOperand = theStack.Pop();
                    int firstOperand = theStack.Pop();
                    int pushable = 0;

                    switch (token)
                    {
                        case "+":
                            pushable = firstOperand + secondOperand;
                            theStack.Push(pushable);
                            break;
                        case "-":
                            pushable = firstOperand - secondOperand;
                            theStack.Push(pushable);
                            break;
                        case "*":
                            pushable = firstOperand * secondOperand;
                            theStack.Push(pushable);
                            break;
                        case "/":
                            pushable = firstOperand / secondOperand;
                            theStack.Push(pushable);
                            break;
                    }
                }
            }

            return theStack.Peek();
        }
    }
}
