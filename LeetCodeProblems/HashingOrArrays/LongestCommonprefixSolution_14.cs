namespace LeetCodeProblems.HashingOrArrays
{
    public class LongestCommonprefixSolution_14
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || strs[0].Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var charOffset = 0;

            while (true)  // for each string
            {
                char theChar = strs[0][charOffset];
                for (int stringOffset = 0; stringOffset < strs.Length; stringOffset++)  // for each char
                {
                    if ( strs[stringOffset].Length <= charOffset || strs[stringOffset][charOffset] != theChar) 
                        return sb.ToString();
                    
                }
                sb.Append(theChar);
                charOffset++;
                if (strs[0].Length <= charOffset) return sb.ToString();
            }
        }
    }
}
