Imports LeetCodeProblems.Interfaces.Medium

Namespace Graph
    Public Class GraphValidTree_Solution_NoLoop_VB_261
        Implements IGraphValidTree_261

        Public Function ValidTree(n As Integer, edges As Integer()()) As Boolean Implements IGraphValidTree_261.ValidTree
            If (edges.Length <> n - 1) Then Return False

            Dim visited = New HashSet(Of Integer)()

            Dim edgesById(n - 1) As List(Of Integer)
            For i = 0 To n - 1 Step 1
                edgesById(i) = New List(Of Integer)()
            Next

            For Each edge In edges
                edgesById(edge(0)).Add(edge(1))
                edgesById(edge(1)).Add(edge(0))
            Next

            Dim stack = New Stack(Of (child As Integer, parent As Integer, edgeOffset As Integer))()

            stack.Push((0, -1, 0))

            While (stack.Count > 0)
                Dim popped = stack.Pop()
                visited.Add(popped.child)

                If (popped.edgeOffset = edgesById(popped.child).Count()) Then Continue While


                Dim edge = edgesById(popped.child)(popped.edgeOffset)

                'explore
                stack.Push((popped.child, popped.parent, popped.edgeOffset + 1))

                If (edge = popped.parent) Then Continue While
                If (visited.Contains(edge)) Then Return False

                ' descend
                stack.Push((edge, popped.child, 0))
            End While

            Return visited.Count = n

        End Function
    End Class
End Namespace
