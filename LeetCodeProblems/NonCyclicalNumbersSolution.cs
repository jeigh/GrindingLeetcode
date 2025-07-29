namespace LeetCodeProblems
{
    public class NonCyclicalNumbersSolution
    {
        //time: O(n), space: O(1)

        private Dictionary<int, int> _powers;

        public NonCyclicalNumbersSolution()
        {
             _powers = new Dictionary<int, int>
             {
                 { 0, 0 },
                 { 1, 1 },
                 { 2, 4 },
                 { 3, 9 },
                 { 4, 16 },
                 { 5, 25 },
                 { 6, 36 },
                 { 7, 49 },
                 { 8, 64 },
                 { 9, 81 }
             };
        }

        private int CalculateSumOfSquares(int n)
        {
            char[] digits = n.ToString().ToCharArray();
            int theSum = 0;
            foreach (char digit in digits)
            {
                int integerValue = int.Parse(digit.ToString());
                theSum += _powers[integerValue];
            }
            return theSum;
        }

        private HashSet<int> _hashSet = new HashSet<int>();

        public bool IsHappy(int n)
        {
            if (n == 1) return true;
            int sumOfSquares = CalculateSumOfSquares(n);
            if (_hashSet.Contains(sumOfSquares)) return false;
            _hashSet.Add(sumOfSquares);
            return IsHappy(sumOfSquares);
        }
    }
}
