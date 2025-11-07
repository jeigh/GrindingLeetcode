namespace LeetCodeProblems.CSharp.SlidingWindow
{
    public class PermutationInStringSlidingWindowSolution_567
    {
        // this is the pseudo-optimized solution o(n) time complexity and O(1) space complexity
        // most online examples make the count arrays start at 'a', and then subtract from 'a' throughout the logic
        // but I feel that doing so, while making it slightly less storage intense, limits readability.
        // this solution seams to be a reasonable comprimise between the two
        public bool CheckInclusionSlidingWindow(string s1, string s2)
        {
            var indexDomainSize = 26 + 'a';
            if (s1.Length > s2.Length) return false;

            int[] s1Count = new int[indexDomainSize];
            int[] s2Count = new int[indexDomainSize];

            for (int i = 0; i < s1.Length; i++)
            {
                char index = s1[i];
                s1Count[index]++;

                index = s2[i]; 
                s2Count[index]++;
            }

            Func<int, bool> MeetsIncrementCriteria = 
                i => s1Count[i] == s2Count[i];

            int matches = 0;
            for (int i = 0; i < 26; i++)
            {
                if (MeetsIncrementCriteria(i)) matches++;
            }

            int windowStart = 0;
            for (int windowEnd = s1.Length; windowEnd < s2.Length; windowEnd++)
            {
                if (matches == 26) return true;

                int index = s2[windowEnd];
                s2Count[index]++;

                if (MeetsIncrementCriteria(index)) matches++;
                else if (s1Count[index] + 1 == s2Count[index]) matches--;                

                index = s2[windowStart];
                s2Count[index]--;
                
                if (MeetsIncrementCriteria(index)) matches++;
                else if (s1Count[index] - 1 == s2Count[index]) matches--;
                
                windowStart++;
            }

            return matches == 26;
        }


    }
}
