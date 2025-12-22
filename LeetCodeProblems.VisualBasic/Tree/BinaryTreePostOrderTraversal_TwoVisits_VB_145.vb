Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved on 2025-12-17
Public Class BinaryTreePostOrderTraversal_TwoVisits_VB_145
    Implements IBinaryTreePostOrderTraversal_145

    Public Function PostOrderTraversal(root As TreeNode) As IList(Of Integer) Implements IBinaryTreePostOrderTraversal_145.PostOrderTraversal
        Dim stack = New Stack(Of (node As TreeNode, visited As Boolean))
        Dim result = New List(Of Integer)()
        stack.Push((root, False))

        While stack.Count > 0
            Dim popped = stack.Pop()
            If popped.node IsNot Nothing Then
                If popped.visited Then
                    result.Add(popped.node.val)
                Else
                    stack.Push((popped.node, True))
                    stack.Push((popped.node.right, False))
                    stack.Push((popped.node.left, False))
                End If
            End If
        End While

        Return result
    End Function
End Class

