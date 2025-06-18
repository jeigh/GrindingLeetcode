namespace LeetCodeProblems.FirstAttempts
{
    public class MinimumWindowSubstring
    {
        // this method works, but doesn't satisfy the time complexity requirements
        // time complexity: O(n*m) where n is the length of s, and m is the number of unique characters in t
        // the strech goal was to have it complete in O(m+n), not O(m*n)  
        // space complexity: O(m)
        public string MinWindowBespokeSolution(string s, string t)
        {
            if (s.Length < t.Length) return "";

            var targetHashmap = InitializeHashmapFromString(t);
            var windowHashmap = InitializeWindowHashmap(targetHashmap);

            var tLength = t.Length;
            var returnableSubstring = string.Empty;
            
            var left = 0;
            var currentWindowLength = 0;
            var currentSubstring = s.Substring(left, currentWindowLength);

            // expand the window to the right until the criteria is satisfied
            // then contract the window by incrementing left until the criteria is no longer satisfied
            // repeat until we're out of characters
            do
            { 
                while (left + currentWindowLength < s.Length && !SatisfiesCriteria(windowHashmap, targetHashmap))
                {
                    currentWindowLength++;
                    currentSubstring = s.Substring(left, currentWindowLength);
                    var newChar = currentSubstring.ToCharArray().Last();
                    if (targetHashmap.ContainsKey(newChar)) 
                        windowHashmap[newChar]++;
                }

                while (SatisfiesCriteria(windowHashmap, targetHashmap))
                {
                    if (currentWindowLength < returnableSubstring.Length || returnableSubstring == string.Empty)
                        returnableSubstring = s.Substring(left, currentWindowLength);

                    var takeThisOut = s[left];
                    left++;
                    currentWindowLength--;
                    if (targetHashmap.ContainsKey(takeThisOut)) 
                        windowHashmap[takeThisOut]--;
                    
                    currentSubstring = s.Substring(left, currentWindowLength);
                }                
            } while (!(left + currentWindowLength >= s.Length));

            return returnableSubstring;

        }

        private bool SatisfiesCriteria(Dictionary<char, int> challenge, Dictionary<char, int> criteria)
        {
            foreach (KeyValuePair<char, int> kvp in criteria)
            {
                if (challenge[kvp.Key] < criteria[kvp.Key]) return false;
            }
            return true;
        }

        private Dictionary<char, int> InitializeHashmapFromString(string source)
        {
            var dict = new Dictionary<char, int>();
            foreach (char c in source)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
            return dict;
        }

        public Dictionary<char, int> InitializeWindowHashmap(Dictionary<char, int> sourceHashmap)
        {
            var targetHashmap = new Dictionary<char, int>();
            foreach (char key in sourceHashmap.Keys)
            {
                targetHashmap.Add(key, 0);
            }
            return targetHashmap;
        }



    }
}
