using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new DailyTemperaturesSolution();


            int[] temperatures = [30, 38, 30, 36, 35, 40, 28];




            var result = unit.DailyTemperatures(temperatures);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
