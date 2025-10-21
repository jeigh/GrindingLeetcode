namespace LeetCodeProblems.HashingOrArrays
{
    public class MyHashSetSolution_705
    {
        public class MyHashSet
        {

            private LinkedList<int>[] _buckets = new LinkedList<int>[1000];

            public MyHashSet() 
            {
                for (int i = 0; i < 1000; i++)
                {
                    _buckets[i] = new LinkedList<int>();
                }
            }

            public void Add(int key)
            {
                var hash = Hash(key);
                var list = GetBucket(hash);
                if (!list.Contains(key)) list.AddLast(key);
            }

            public void Remove(int key)
            {
                var hash = Hash(key);
                var list = GetBucket(hash);
                list.Remove(key);
            }

            public bool Contains(int key)
            {
                var hash = Hash(key);
                var list = GetBucket(hash);

                return list.Contains(key);
            }

            private LinkedList<int> GetBucket(int hash)
            {
                return _buckets[hash];
            }

            private int Hash(int key)
            {
                return key % 1000;
            }
        }
    }
}
