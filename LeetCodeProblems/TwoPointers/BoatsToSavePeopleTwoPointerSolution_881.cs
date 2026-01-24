namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// You are given an array people where people[i] is the weight of the ith person, and an infinite number of boats where each boat can carry a maximum weight of limit. Each boat carries at most two people at the same time, provided the sum of the weight of those people is at most limit.
    ///
    /// Return the minimum number of boats to carry every given person.
    /// </summary>
    public class BoatsToSavePeopleTwoPointerSolution_881
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);

            var boats = 0;
            var left = 0;
            var right = people.Length - 1;
            var end = people.Length - 1;

            while(left <= right)
            {
                if (left == right) 
                { 
                    boats++; 
                    break; 
                }
                else if (people[left] + people[right] <= limit)
                {
                    boats++;
                    left++;
                    right--;
                }
                else
                {
                    right--;
                    boats++;
                }
            }           

            return boats;
        }
    }
}
