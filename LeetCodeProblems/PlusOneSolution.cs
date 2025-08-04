namespace LeetCodeProblems
{
    // time complexity: O(n);  space complexity O(1)
    public class PlusOneSolution
    {
        public int[] PlusOne(int[] digits)
        {
            var reversedReturnable = new List<int>();
            var toCarry = 1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int rawAfterCarry = digits[i] + toCarry;

                if (rawAfterCarry == 10)
                {
                    reversedReturnable.Add(0);
                    toCarry = 1;
                }
                if (rawAfterCarry < 10)
                {
                    reversedReturnable.Add(rawAfterCarry);
                    toCarry = 0;
                }                
            }
            
            if (toCarry > 0) 
                reversedReturnable.Add(toCarry);

            reversedReturnable.Reverse();
            return reversedReturnable.ToArray();
        }
    }
}
