Imports System.Text
Imports LeetCodeProblems.Interfaces.Medium

Namespace HashingOrArrays
    Public Class OpenTheLock_VB_752
        Implements IOpenTheLock_752

        Private START = "0000"

        ' time complexity: O(10^4 * 4 * 2) = O(1) — bounded by fixed state space of 10,000 combinations
        ' space complexity: O(10^4) = O(1) — visited set bounded by same fixed state space
        Public Function OpenLock(deadends As String(), target As String) As Integer Implements IOpenTheLock_752.OpenLock
            If deadends.Contains(target) OrElse deadends.Contains(START) Then Return -1

            Dim hashSet = New HashSet(Of String)()
            For Each item In deadends
                hashSet.Add(item)
            Next

            Dim queue As New Queue(Of (currentValue As String, currentDistance As Integer))()

            queue.Enqueue((START, 0))
            hashSet.Add(START)

            While queue.Count > 0
                Dim queueItem = queue.Dequeue()

                If target = queueItem.currentValue Then Return queueItem.currentDistance

                Dim edges = GetEdges(queueItem.currentValue, hashSet)
                For Each edge In edges
                    queue.Enqueue((edge, queueItem.currentDistance + 1))
                Next
            End While

            Return -1
        End Function

        Public Function GetEdges(currentItem As String, hashSet As HashSet(Of String)) As List(Of String)
            Dim returnable = New List(Of String)()
            For i = 0 To 3
                Dim digit As Char = currentItem(i)

                Dim plusOne = (Integer.Parse(digit) + 1) Mod 10
                IncludeInResult(plusOne, hashSet, i, currentItem, returnable)

                Dim minusOne = (Integer.Parse(digit) - 1 + 10) Mod 10
                IncludeInResult(minusOne, hashSet, i, currentItem, returnable)
            Next

            Return returnable
        End Function

        Private Sub IncludeInResult(plusOne As Integer, hashSet As HashSet(Of String), i As Integer, currentItem As String, returnable As List(Of String))
            Dim chars = currentItem.ToCharArray()
            chars(i) = Chr(plusOne + AscW("0"c))
            Dim temp = New String(chars)
            If Not hashSet.Contains(temp) Then
                returnable.Add(temp)
                hashSet.Add(temp)
            End If
        End Sub
    End Class
End Namespace
