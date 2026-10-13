Imports LeetCodeProblems.Interfaces.Medium

Namespace Graph
    Public Class RedundantConnection_CycleDetection_Solution_VB_684
        Implements IRedundantConnection_684

        Public Function FindRedundantConnection(edges As Integer()()) As Integer() Implements IRedundantConnection_684.FindRedundantConnection
            Dim adjacencies As New List(Of List(Of Integer))()
            For i = 0 To edges.Count
                adjacencies.Add(New List(Of Integer)())
            Next

            For Each edge In edges
                Dim first = edge(0)
                Dim second = edge(1)

                adjacencies(first).Add(second)
                adjacencies(second).Add(first)

                Dim visited As New HashSet(Of Integer)()
                If (HasCycle(first, -1, visited, adjacencies)) Then Return New Integer() {first, second}
            Next

            Return New Integer() {0, 0}
        End Function

        Private Function HasCycle(node As Integer, parent As Integer, visited As HashSet(Of Integer), adjacencies As List(Of List(Of Integer))) As Boolean
            If (visited.Contains(node)) Then Return True
            visited.Add(node)

            For Each adjacency In adjacencies(node)
                If (adjacency = parent) Then Continue For
                If (HasCycle(adjacency, node, visited, adjacencies)) Then Return True
            Next
            Return False
        End Function

    End Class
End Namespace
