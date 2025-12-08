using LeetCodeProblems.Interfaces.Medium;

namespace LeetCodeProblems.CSharp.LinkedList
{
    public class FindTheDuplicateNumberUsingLinkedListCSharp_287 : IFindTheDuplicateNumber_287
    {
        // I wrote it like this to highlight why this problem is placed in the linkedList category
        // though the instantiation of multiple SimulatedLinkedList objects does slightly reduce the performance
        //
        // In practice, if readability was more important, I would recommend going the sort-first or hashset approaches, which 
        // would deteriorate the time complexity and space complexity respectively.   The below approach, while clearly
        // emphasizing the LinkedList categorization, is an awkward compromise that only beats out 33% on Leetcode.
        //
        // A slightly more efficient approach would be to scrap the simulatedLinkedList class
        // and supply the member functions inline so that the SimulatedLinkedList classes never get instantianted.
        public int FindDuplicate(int[] nums)
        {
            var firstIntersectionNode = AdvanceTortoiseAndHareToIntersection(nums);
            var secondIntersectionNode = AdvanceTwoTortoisesToIntersection(nums, firstIntersectionNode);
            return secondIntersectionNode._value;
        }

        private SimulatedListNode AdvanceTortoiseAndHareToIntersection(int[] nums)
        {
            var hare = new SimulatedListNode(nums, 0);
            var tortoise = new SimulatedListNode(nums, 0);

            tortoise = tortoise.Next;
            hare = hare.Next.Next;

            while (tortoise._value != hare._value)
            {
                tortoise = tortoise.Next;
                hare = hare.Next.Next;
            }

            return hare;
        }

        private SimulatedListNode AdvanceTwoTortoisesToIntersection(int[] nums, SimulatedListNode tortoise1)
        {
            var tortoise2 = new SimulatedListNode(nums, 0);
            while (tortoise2._value != tortoise1._value)
            {
                tortoise2 = tortoise2.Next;
                tortoise1 = tortoise1.Next;
            }

            return tortoise2;
        }

        public class SimulatedListNode
        {
            private SimulatedListNode? _next;
            public SimulatedListNode Next { 
                get 
                {
                    if (_next == null) _next = new SimulatedListNode(_array, _value);
                    return _next;
                } 
            }

            public readonly int _value;            
            private readonly int[] _array;            

            public SimulatedListNode(int[] array, int index)
            {
                _array = array;
                _value = array[index];
            }
        }
    }
}
