Imports System.Text
Imports LeetCodeProblems.Interfaces.Medium

Public Class TaskScheduler_Math_VB_621
    Implements ITaskScheduler_621

    Public Function LeastInterval(tasks() As Char, n As Integer) As Integer Implements ITaskScheduler_621.LeastInterval
        Dim aggregates = GetAggregates(tasks)

        Dim result As Integer = ((aggregates.maxCount - 1) * (n + 1)) + aggregates.groupSize

        Return Math.Max(tasks.Count, result)
    End Function

    Public Function GetAggregates(tasks() As Char) As (maxCount As Integer, groupSize As Integer)
        Dim hashmap = New Dictionary(Of Char, Integer)()

        For Each task As Char In tasks
            If hashmap.ContainsKey(task) Then
                hashmap(task) += 1
            Else
                hashmap(task) = 1
            End If
        Next

        Dim maxCount As Integer = 0
        Dim groupSize As Integer = 0

        For Each count As Integer In hashmap.Values
            If count > maxCount Then
                maxCount = count
                groupSize = 1
            ElseIf count = maxCount Then
                groupSize += 1
            End If
        Next

        Return (maxCount, groupSize)
    End Function
End Class
