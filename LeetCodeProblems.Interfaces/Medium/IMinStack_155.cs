using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeProblems.Interfaces.Medium
{
    /// <summary>
    /// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
    /// 
    /// Implement the MinStack class:
    /// 
    /// MinStack() initializes the stack object.
    /// void push(int val) pushes the element val onto the stack.
    /// void pop() removes the element on the top of the stack.
    /// int top() gets the top element of the stack.
    /// int getMin() retrieves the minimum element in the stack.
    /// You must implement a solution with O(1) time complexity for each function.
    /// </summary>
    public interface IMinStack_155
    {
        int GetMin();
        void Pop();
        void Push(int val);
        int Top();
    }
}