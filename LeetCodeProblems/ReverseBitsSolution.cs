namespace LeetCodeProblems
{
    public class ReverseBitsSolution
    {
        // space: O(1) time: O(1)
        public uint ReverseBits(uint n)
        {
            uint result = 0;
            
            for(int i = 0; i < 32; i++)
            {
                result = (result << 1) | (1 & n);

                n >>= 1;
            }
            return result;
        }
    }
}
