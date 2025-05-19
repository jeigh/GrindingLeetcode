using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LeetCodeProblems.AnagramGroups
{


    public class GroupAnagramsSolution
    {
        // this is the solution that I came up with on my own;  its also very similar to the solution given in Neetcode
        // time complexity: O(n * k log k), where n is the number of strings and k is the average length of the strings.
        // space complexity:  O(n * k)

        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var groups = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                var sortedString = new string(chars);
                if (groups.ContainsKey(sortedString))
                    groups[sortedString].Add(str);
                else
                    groups.Add(sortedString, new List<string>() { str });
            }
            var result = new List<List<string>>();
            foreach (List<string> values in groups.Values)
            {
                result.Add(values);
            }
            return result;
        }
    }
}
