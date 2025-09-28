namespace LeetCodeProblems.BinarySearch
{
    public class FindSmallestLetterGreaterThanTargetSolution_744
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            var left = 0;
            var right = letters.Length - 1;
            var mid = 0;
            var result = -1;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (letters[mid] > target)
                {
                    result = mid;
                    right = mid - 1;
                }

                if (letters[mid] <= target) left = mid + 1;
            }

            return result == -1 ? letters[0] : letters[result];
        }
    }
}
