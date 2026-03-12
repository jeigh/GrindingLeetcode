Imports LeetCodeProblems.Interfaces.Medium

Public Class TaskScheduler_TwoQueues_VB_621
    Implements ITaskScheduler_621

    Private Function CreateCounts(tasks() As Char) As Integer()
        Dim ret(25) As Integer

        For Each task In tasks
            Dim index = Asc(task) - Asc("A")
            ret(index) += 1
        Next

        Return ret
    End Function

    Public Function LeastInterval(tasks() As Char, n As Integer) As Integer Implements ITaskScheduler_621.LeastInterval
        Dim counts = CreateCounts(tasks)
        Dim maxHeap = CreateMaxHeapFrom(counts)

        Dim time As Integer = 0
        Dim queue As New Queue(Of (count As Integer, nextTick As Integer))()
        While maxHeap.Count > 0 OrElse Queue.Count > 0
            Tick(time, queue, maxHeap, n)
        End While

        Return time
    End Function

    Private Function CreateMaxHeapFrom(counts() As Integer) As PriorityQueue(Of Integer, Integer)
        Dim maxHeap As New PriorityQueue(Of Integer, Integer)()
        For i = 0 To counts.Length - 1
            If counts(i) > 0 Then
                maxHeap.Enqueue(counts(i), -counts(i))
            End If
        Next

        Return maxHeap
    End Function

    Private Sub Tick(
        ByRef time As Integer,
        queue As Queue(Of (count As Integer, nextTick As Integer)),
        maxHeap As PriorityQueue(Of Integer, Integer),
        cooldownInterval As Integer)

        If (queue.Count > 0 AndAlso time >= queue.Peek().nextTick) Then
            Dim temp = queue.Dequeue()
            maxHeap.Enqueue(temp.count, -temp.count)
        End If
        If (maxHeap.Count > 0) Then
            Dim newCount = maxHeap.Dequeue() - 1
            If (newCount > 0) Then
                Dim nextAvailableTick = time + cooldownInterval + 1
                queue.Enqueue((newCount, nextAvailableTick))
            End If
        End If
        time += 1
    End Sub
End Class
