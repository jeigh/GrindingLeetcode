Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved 2025-12-26
Public Class SameTree_Stack_VB_100
    Implements ISameTree_100

    Public Function IsSameTree(p As TreeNode, q As TreeNode) As Boolean Implements ISameTree_100.IsSameTree
        Dim stack As New Stack(Of (pNode As TreeNode, qNode As TreeNode))
        stack.Push((p, q))

        While stack.Count > 0
            Dim popped = stack.Pop()
            Dim qNode = popped.qNode
            Dim pNode = popped.pNode

            If pNode Is Nothing AndAlso qNode Is Nothing Then Continue While
            If pNode Is Nothing OrElse qNode Is Nothing Then Return False
            If pNode.val <> qNode.val Then Return False

            stack.Push((pNode.left, qNode.left))
            stack.Push((pNode.right, qNode.right))
        End While

        Return True
    End Function
End Class

