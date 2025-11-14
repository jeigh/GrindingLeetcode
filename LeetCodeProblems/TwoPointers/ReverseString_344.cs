namespace LeetCodeProblems.TwoPointers
{
    public class ReverseString_344
    {
        public void ReverseString(char[] s)
        {
            if (s == null || s.Length == 0) return;
            var left = 0;
            var right = s.Length - 1;

            while (left<right)
            {
                swap(s, left, right);
                left++;
                right--;
            }
        }

        public void swap(char[] s, int left, int right)
        {
            var temp = s[left];
            s[left] = s[right];
            s[right] = temp;
        }
    }
}
