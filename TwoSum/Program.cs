using LeetCodeProblems.FirstAttempts;

namespace TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var unit = new CarFleetSolution();


            var target = 12;
            int[] position = [10, 8, 0, 5, 3];
            int[] speed = [2, 4, 1, 1, 3];

            target = 10;
            position = [6, 8];
            speed = [3, 2];




            var result = unit.CarFleet(target, position, speed);



            Console.WriteLine(result);

            Console.WriteLine("debugger");

        }
    }
}
