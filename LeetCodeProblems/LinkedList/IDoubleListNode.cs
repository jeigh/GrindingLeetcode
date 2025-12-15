namespace LeetCodeProblems.CSharp.LinkedList
{
    public interface IDoubleListNode
    {
        DoubleListNode Next { get; }
        DoubleListNode Prev { get; }
        int Value { get; set; }

        void SetNext(DoubleListNode? nextNode);
        void SetPrev(DoubleListNode? prevNode);
    }
}