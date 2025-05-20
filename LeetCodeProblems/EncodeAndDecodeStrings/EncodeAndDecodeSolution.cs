using System.Text;

public class EncodeAndDecodeSolution
{

    // this was my hand-crafted solution.
    // Time complexity for encode is O(n) where n is the total number of characters.
    // Time complexity for decode is O(s) where s is the length of the string.

    // space complexity for encode is O(n) where n is the total number of characters.
    // space complexity for decode is O(s) where s is the length of the string.


    char delimiter = (char)0;
    char surrogateEmptyString = (char)1;


    public string Encode(IList<string> strs)
    {                
        if (strs.Count == 0) return null;
        
        var sb = new StringBuilder();
        for (int i = 0; i < strs.Count; i++)
        {
            if (strs[i] == string.Empty)
                sb.Append(surrogateEmptyString);
            else
                sb.Append(strs[i]);

            if (i != strs.Count - 1)
                sb.Append(delimiter);
        }
        
        return sb.ToString();
    }

    public List<string> Decode(string s)
    {
        if (s == null) return new List<string>();

        var result = s.Split((char)0, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < result.Length; i++)
        {
            string item = result[i];
            if (item == surrogateEmptyString.ToString()) result[i] = string.Empty;
        }
        return result.ToList();
    }
}