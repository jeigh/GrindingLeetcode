using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.Stack
{
    public class CarFleetCSharp_853 : ICarFleet_853
    {
        // I used some oop on this one.   
        // time complexity: O(n log n)
        // space complexity: O(n)
        public class car 
        {
            public car(int position, int speed)
            {
                this.position = position;
                this.speed = speed;
            }

            public int position { get; set; }
            public int speed { get; set; }
            public float TimeToFinishAlone(int target) 
            {
                float returnable = (float)(target - position) / speed;
                return returnable;
            }

        }
        
        public int CarFleet(int target, int[] position, int[] speed)
        {
            List<car> vehicles = ConstructVehiclesList(position, speed);
            var theStack = new Stack<float>();

            foreach (var vehicle in vehicles)
            {
                var timeOfCurrentCar = vehicle.TimeToFinishAlone(target);
                if (!theStack.TryPeek(out float timeOfCarInFrontOfThisOne) || timeOfCurrentCar > timeOfCarInFrontOfThisOne)
                {
                    theStack.Push(timeOfCurrentCar);
                }                    
            }

            return theStack.Count;
        }


        private List<car> ConstructVehiclesList(int[] position, int[] speed)
        {
            var vehicles = new List<car>();
            for (int i = 0; i < position.Length; i++)
            {
                vehicles.Add(new car(position[i], speed[i]));
            }
            return vehicles.OrderByDescending(v => v.position).ToList();
        }
    }
}
