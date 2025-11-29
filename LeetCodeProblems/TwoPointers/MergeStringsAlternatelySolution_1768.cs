namespace LeetCodeProblems.TwoPointers
{
    public class MergeStringsAlternatelySolution_1768
    {
        public string MergeAlternately(string word1, string word2)
        {
            var word1Index = 0;
            var word2Index = 0;

            var result = new System.Text.StringBuilder("");

            while (word1Index < word1.Length && word2Index < word2.Length)
            {
                result.Append(word1[word1Index]);
                word1Index++;

                result.Append(word2[word2Index]);
                word2Index++;
            }

            if (word1.Length > word2.Length) 
            {
                // finish word1
                while (word1Index <= word1.Length - 1)
                {
                    result.Append(word1[word1Index]);
                    word1Index++;

                }
            }

            if (word2.Length > word1.Length)
            {
                while (word2Index <= word2.Length - 1)
                {
                    result.Append(word2[word2Index]);
                    word2Index++;

                }

             }

            return result.ToString();
        }
    }
}
