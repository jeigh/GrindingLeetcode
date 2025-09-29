namespace LeetCodeProblems.BinarySearch
{
    public class ValidPerfectSquare_367
    {
        public bool IsPerfectSquare(int num)
        {
            HashSet<int> trivialSquares = [0, 1];
            if (trivialSquares.Contains(num)) return true;
            
            var left = 0;
            var right = Math.Min(46341, num/2);  
            int mid = 0;

            while (left <= right)
            {
                mid = left + (right - left) / 2;
                long targetSquare = mid * mid;
                
                if (targetSquare == num) 
                    return true;
                
                if (num > targetSquare) 
                    left = mid + 1;
                
                if (num < targetSquare) 
                    right = mid - 1;
            }

            return false;
        }
    }
}
