using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new ReversePolishNotationSolution();


            string[] tokens = ["2", "1", "+", "3", "*"];




            var result = unit.EvalRPN(tokens);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
