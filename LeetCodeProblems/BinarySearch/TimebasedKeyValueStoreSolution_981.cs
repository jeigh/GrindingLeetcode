using System.Collections.Generic;

namespace LeetCodeProblems.BinarySearch
{
    public class TimebasedKeyValueStoreSolution_981
    {
        // despite this meeting the time complexity requirements,
        // this solution only ranks above ~10% others on leetcode
        // it was completely authored by me though -- no reference implementation was consulted
        public class TimeMap
        {
            private const string SURROGATE_NULL = "";
            Dictionary<string, List<(string value, int timestamp)>> _hashmap = new();

            public TimeMap() { }

            // o(n)
            public void Set(string key, string value, int timestamp)
            {
                if(_hashmap.TryGetValue(key, out var timestampedValues))
                {
                    timestampedValues.Add((value, timestamp));
                }
                else
                {
                    List<(string value, int timestamp)> addable = [(value, timestamp)];
                    _hashmap.Add(key, addable);
                }
            }

            // o(log n)
            public string Get(string key, int timestamp)
            {
                if (_hashmap.TryGetValue(key, out var timestampedValues))
                {
                    return DoBinarySearch(timestampedValues, timestamp);
                }
                return SURROGATE_NULL;
            }

            private string DoBinarySearch(List<(string value, int timestamp)> vals, int target)
            {
                var left = 0;
                var right = vals.Count() - 1;
                var mid = 0;
                var returnable = vals.Count();

                var moveRight = () => left = mid + 1;
                var moveLeft = () => right = mid - 1;

                while (left <= right)
                {
                    mid = left + (right - left) / 2;

                    if (vals[mid].timestamp == target) return vals[mid].value;

                    if (vals[mid].timestamp > target) 
                    { 
                        moveLeft();
                    }
                    if (vals[mid].timestamp < target) 
                    { 
                        returnable = mid;
                        moveRight();
                    }
                                        
                }
                if (returnable == vals.Count()) return "";
                return vals[returnable].value;
            }

            /**
             * Your TimeMap object will be instantiated and called as such:
             * TimeMap obj = new TimeMap();
             * obj.Set(key,value,timestamp);
             * string param_2 = obj.Get(key,timestamp);
             */

        }
    }
}
