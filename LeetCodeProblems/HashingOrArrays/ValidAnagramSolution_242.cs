namespace LeetCodeProblems.HashingOrArrays
{
    public class ValidAnagramSolution_242
    {      
        public bool IsAnagram(string s, string t)
        {
            int[] s_chars = NewMethod(s);
            int[] t_chars = NewMethod(t);

            for (int i = 0; i < s_chars.Length; i++)
            {
                if (s_chars[i] != t_chars[i]) return false;
            }
            return true;
        }

        private static int[] NewMethod(string str)
        {
            int[] str_chars = new int[26];
            for (int i = 0; i < str.Length; i++)
            {
                var offset = str[i] - 'a';
                str_chars[offset]++;
            }

            return str_chars;
        }
    }
}
