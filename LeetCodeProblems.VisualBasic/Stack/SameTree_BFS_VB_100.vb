Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved 2025-12-26
Public Class SameTree_BFS_VB_100
    Implements ISameTree_100

    Public Function IsSameTree(p As TreeNode, q As TreeNode) As Boolean Implements ISameTree_100.IsSameTree
        Dim queue = New Queue(Of (pNode As TreeNode, qNode As TreeNode))
        queue.Enqueue((p, q))

        While queue.Count > 0
            Dim nodes = queue.Dequeue()

            If nodes.qNode Is Nothing AndAlso nodes.pNode Is Nothing Then Continue While
            If nodes.qNode Is Nothing OrElse nodes.pNode Is Nothing Then Return False
            If nodes.qNode.val <> nodes.pNode.val Then Return False

            queue.Enqueue((nodes.pNode.left, nodes.qNode.left))
            queue.Enqueue((nodes.pNode.right, nodes.qNode.right))
        End While

        Return True
    End Function
End Class