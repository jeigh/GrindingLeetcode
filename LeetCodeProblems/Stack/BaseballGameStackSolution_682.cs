using LeetCodeProblems.Interfaces.Easy;
using System.Numerics;

namespace LeetCodeProblems.CSharp.Stack
{
    public class BaseballGameStackSolution_682 : IBaseballGame_682
    {
        public int CalPoints(string[] operations)
        {
            var scores =  new Stack<int>();

            foreach(var operation in operations)
            {
                switch(operation)
                {
                    case "+":
                        var a = scores.Pop();
                        var b = scores.Peek();
                                                
                        scores.Push(a);
                        scores.Push(a+b);

                        break;
                    case "C":
                        scores.TryPop(out int c);
                        break;

                    case "D":
                        var d = scores.Peek();                        
                        scores.Push(d * 2);
                        break;

                    default:
                        var value = Int32.Parse(operation);
                        scores.Push(value);
                        break;
                }
            }

            var retval = 0;
            while (scores.Count > 0)
            {
                retval += scores.Pop();
            }
            return retval;
        }
    }
}
