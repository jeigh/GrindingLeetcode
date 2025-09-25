namespace LeetCodeProblems.BinarySearch
{
    public class VersionControl
    {
        private readonly int _firstBadVersion;

        public VersionControl(int firstBadVersion)
        {
            _firstBadVersion = firstBadVersion;
        }

        protected bool IsBadVersion(int version)
        {
            if (version >= _firstBadVersion) return true;
            return false;
        }
    }

    public class FirstBadVersion_278 : VersionControl
    {
        public FirstBadVersion_278(int firstBadVersion) : base(firstBadVersion)
        {
        }

        public int FirstBadVersion(int n)
        {
            var left = 0;
            var right = n;
            var mid = 0;
            var result = right;

            while (left <= right)
            {
                var setLeftToNext = () => left = mid + 1;
                var setRightToPrev = () => right = mid - 1;

                mid = left + (right - left) / 2;


                if (IsBadVersion(mid))
                {
                    setRightToPrev();
                    result = Math.Min(result, mid);
                }

                else setLeftToNext();
            }

            return result;
        }
    }
}
