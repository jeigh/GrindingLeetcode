namespace LeetCodeProblems
{
    public class CanAttendMeetingsSolution
    {
        public class Interval
        {
            public int start;
            public int end;

        }

        // space complexity: O(1)  ; time complexity O(n log n)
        public bool CanAttendMeetings(List<Interval> intervals)
        {
            intervals.Sort((a, b) => a.start.CompareTo(b.start));

            for (int i = 0; i < intervals.Count - 1; i++)
            {
                if (intervals[i + 1].start - intervals[i].end < 0) return false;
            }
            return true;
        }
    }
}
