Imports System.Text
Imports LeetCodeProblems.Interfaces.Medium

Public Class LongestHappyString_VB_1405
    Implements ILongestHappyString_1405

    Public Function LongestDiverseString(a As Integer, b As Integer, c As Integer) As String Implements ILongestHappyString_1405.LongestDiverseString
        Dim sb As New StringBuilder()

        Dim queue As PriorityQueue(Of Char, (firstBy As Integer, thenBy As Integer)) = CreateQueue(a, b, c)

        Dim ultimateChar As Char? = Nothing
        Dim penultimateChar As Char? = Nothing

        Dim element As Char
        Dim priority As (firstBy As Integer, thenBy As Integer)

        Dim tick = 0
        While queue.TryDequeue(element, priority)
            If penultimateChar.HasValue AndAlso penultimateChar = element AndAlso ultimateChar = element Then
                Dim element2 As Char
                Dim priority2 As (firstBy As Integer, thenBy As Integer)

                If Not queue.TryDequeue(element2, priority2) Then Return sb.ToString()
                sb.Append(element2)
                If priority2.firstBy < -1 Then queue.Enqueue(element2, (priority2.firstBy + 1, tick + 3))
                queue.Enqueue(element, priority)
                penultimateChar = ultimateChar
                ultimateChar = element2
            Else
                sb.Append(element)
                If priority.firstBy < -1 Then queue.Enqueue(element, (priority.firstBy + 1, tick + 3))
                penultimateChar = ultimateChar
                ultimateChar = element
            End If
            tick += 1
        End While

        Return sb.ToString()
    End Function

    Private Shared Function CreateQueue(a As Integer, b As Integer, c As Integer) As PriorityQueue(Of Char, (firstBy As Integer, thenBy As Integer))
        Dim queue = New PriorityQueue(Of Char, (firstBy As Integer, thenBy As Integer))()
        If (a > 0) Then queue.Enqueue("a", (-a, -3))
        If (b > 0) Then queue.Enqueue("b", (-b, -3))
        If (c > 0) Then queue.Enqueue("c", (-c, -3))
        Return queue
    End Function
End Class
