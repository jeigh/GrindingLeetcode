namespace LeetCodeProblems.HashingOrArrays
{
    public class MajorityElementSolution_169
    {
        // neetcode calls this the boyer-moore voting algorithm
        public int MajorityElement(int[] nums)
        {
            int returnable = nums[0];
            var returnableCount = 0;

            foreach(int x in nums)
            {
                if (returnable == x)
                {
                    returnableCount++;
                }
                else
                {
                    if (returnableCount > 0) returnableCount--;
                    else 
                    { 
                        returnable = x; 
                        returnableCount++; 
                    }                   
                }
            }

            return returnable;
        }
    }
}
