namespace LeetCodeProblems.BinarySearch
{
    public class SqrtSolution_69
    {
        public int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 1 || x == 2 || x == 3) return 1;
            

            int low = 0;
            int high = x;
            int mid = low + (high - low) / 2;
            var result = -1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                long testValue = mid * (long)mid;

                if (testValue == x) 
                    return mid;

                if (testValue > x)
                    high = mid - 1;

                if (testValue <= x)
                {
                    result = Math.Max(mid, result);
                    low = mid + 1;
                }
            }
            return result;
        }
    }
}
