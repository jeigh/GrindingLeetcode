Imports LeetCodeProblems.Interfaces.Medium

Namespace Graph
    Public Class GraphValidTree_Solution_VB_261
        Implements IGraphValidTree_261

        Public Function ValidTree(n As Integer, edges As Integer()()) As Boolean Implements IGraphValidTree_261.ValidTree
            If (edges.Count <> n - 1) Then Return False

            Dim edgesOf As New List(Of List(Of Integer))()
            For i = 0 To n - 1
                edgesOf.Add(New List(Of Integer)())
            Next
            Dim visited As New List(Of Integer)()

            For Each item In edges
                edgesOf(item(0)).Add(item(1))
                edgesOf(item(1)).Add(item(0))
            Next

            Dim stack As New Stack(Of (current As Integer, parent As Integer))
            stack.Push((0, -1))

            While (stack.Count > 0)
                Dim popped = stack.Pop()
                If (visited.Contains(popped.current)) Then Exit While

                visited.Add(popped.current)
                For Each item In edgesOf(popped.current)
                    If (item = popped.parent) Then Continue For
                    stack.Push((item, popped.current))
                Next

            End While

            Return n = visited.Count()
        End Function
    End Class
End Namespace
