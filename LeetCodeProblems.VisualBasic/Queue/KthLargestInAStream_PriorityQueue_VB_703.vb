Imports LeetCodeProblems.Interfaces.Easy

Public Class KthLargestInAStream_PriorityQueue_VB_703
    Implements IKthLargestElementInAStream_703

    Private _k As Integer
    Private _queue As PriorityQueue(Of Integer, Integer)

    Public Sub New(k As Integer, nums() As Integer)
        _k = k
        _queue = New PriorityQueue(Of Integer, Integer)()
        For Each num As Integer In nums
            Add(num)
        Next
    End Sub

    Public Function Add(val As Integer) As Integer Implements IKthLargestElementInAStream_703.Add
        If _queue.Count < _k OrElse val > _queue.Peek() Then
            _queue.Enqueue(val, val)
        End If
        If _queue.Count > _k Then
            _queue.Dequeue()
        End If

        Return _queue.Peek()
    End Function
End Class
