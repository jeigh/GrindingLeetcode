Imports LeetCodeProblems.Interfaces.Easy

Public Class LastStoneWeight_VB_1046
    Implements ILastStoneWeight_1046

    Public Function LastStoneWeight(stones() As Integer) As Integer Implements ILastStoneWeight_1046.LastStoneWeight
        Dim queue As New PriorityQueue(Of Integer, Integer)(stones.Length)

        For Each item In stones
            queue.Enqueue(item, -item)
        Next

        While queue.Count > 1
            Dim difference = queue.Dequeue - queue.Dequeue
            If difference > 0 Then queue.Enqueue(difference, -difference)
        End While

        If queue.Count = 1 Then Return queue.Dequeue()
        Return 0
    End Function
End Class
