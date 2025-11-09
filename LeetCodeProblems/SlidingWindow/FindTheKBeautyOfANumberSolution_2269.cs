using LeetCodeProblems.Interfaces.Easy;

namespace LeetCodeProblems.CSharp.SlidingWindow
{
    public class FindTheKBeautyOfANumberSolution_2269 : IFindTheKBeautyOfANumber_2269
    {
        public int DivisorSubstrings(int num, int k)
        {
            char[] numChars = num.ToString().ToCharArray();
            var count = 0;

            var chars = new List<char>();
            for (int i = 0; i < k; i++)
            {
                chars.Add(numChars[i]);
            }


            for (int i = 0; i <= numChars.Length - k; i++)
            {
                string strval = new string(chars.ToArray());
                int currentNum = int.Parse(strval);

                if (IsDivisor(currentNum, num)) count++;

                
                if (numChars.Length - 1 >= i + k) 
                { 
                    chars.Add(numChars[i + k]);
                    chars.RemoveAt(0);
                }
            }
            return count;
        }


        private bool IsDivisor(int divisor, int dividend)
        {
            if (divisor == 0) return false;
            if (dividend % divisor == 0) return true;
            return false;
        }
    }
}
