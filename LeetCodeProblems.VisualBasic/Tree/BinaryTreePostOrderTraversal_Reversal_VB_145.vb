Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved on 2025-12-17
Public Class BinaryTreePostOrderTraversal_Reversal_VB_145
    Implements IBinaryTreePostOrderTraversal_145

    Public Function PostOrderTraversal(root As TreeNode) As IList(Of Integer) Implements IBinaryTreePostOrderTraversal_145.PostOrderTraversal
        Dim result = New List(Of Integer)()
        Dim current = root
        Dim stack As New Stack(Of TreeNode)

        While (current IsNot Nothing OrElse stack.Count > 0)
            While (current IsNot Nothing)
                result.Add(current.val)
                stack.Push(current)
                current = current.right
            End While

            current = stack.Pop().left
        End While

        result.Reverse()
        Return result
    End Function
End Class
