using System.Security.Cryptography.X509Certificates;

namespace LeetCodeProblems.HashingOrArrays
{
    public class MyHashMapSolution_706
    {
        public class ListNode
        {
            public int Key = -1;
            public int Val = -1;
            public ListNode? Next;

            public ListNode(int key = -1, int val = -1, ListNode? next = null)
            {
                Key = key;
                Val = val;
                Next = next;
            }
        }

        public class MyHashMap
        {
            private ListNode[] _map;

            public MyHashMap()
            {
                _map = new ListNode[1000];

                for (int i = 0; i < _map.Length; i++)
                {
                    _map[i] = new ListNode();
                }
            }

            private int Hash(int key)
            {
                return key % _map.Length;
            }

            public void Put(int key, int value)
            {
                ListNode cur = _map[Hash(key)];
                while (cur.Next != null)
                {
                    if (cur.Next.Key == key)
                    {
                        cur.Next.Val = value;
                        return;
                    }
                    cur = cur.Next;
                }
                cur.Next = new ListNode(key, value);
            }

            public int Get(int key)
            {
                int hashedKey = Hash(key);
                ListNode? cur = _map[hashedKey].Next;

                while (cur != null)
                {
                    if (cur.Key == key)
                    {
                        return cur.Val;
                    }
                    cur = cur.Next;
                }
                return -1;
            }

            public void Remove(int key)
            {
                ListNode cur = _map[Hash(key)];
                while (cur.Next != null)
                {
                    if (cur.Next.Key == key)
                    {
                        cur.Next = cur.Next.Next;
                        return;
                    }
                    cur = cur.Next;
                }
            }

        }
    }
}
