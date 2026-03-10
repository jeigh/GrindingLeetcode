Imports LeetCodeProblems.Interfaces.Medium
Public Class TaskScheduler_Greedy_VB_621
    Implements ITaskScheduler_621

    Public Function LeastInterval(tasks() As Char, n As Integer) As Integer Implements ITaskScheduler_621.LeastInterval
        Dim freqs = AggregateCounts(tasks)

        Dim pq = New PriorityQueue(Of Char, Integer)()
        For Each kvp In freqs
            pq.Enqueue(kvp.Key, -kvp.Value)
        Next
        Dim negativeCount As Integer
        Dim mostFrequent As Char

        pq.TryDequeue(mostFrequent, negativeCount)
        Dim mostFrequentCount = -negativeCount
        Dim idle As Integer = (mostFrequentCount - 1) * n

        While pq.Count > 0
            Dim task As Char
            pq.TryDequeue(task, negativeCount)
            Dim count = -negativeCount
            idle -= Math.Min(mostFrequentCount - 1, count)
            If (idle <= 0) Then Exit While
        End While

        Return Math.Max(0, idle) + tasks.Length
    End Function

    Private Function AggregateCounts(tasks() As Char) As Dictionary(Of Char, Integer)
        Dim ret = New Dictionary(Of Char, Integer)(26)

        For Each task As Char In tasks
            If ret.ContainsKey(task) Then
                ret(task) += 1
            Else
                ret(task) = 1
            End If
        Next

        Return ret
    End Function
End Class
