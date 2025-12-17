Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class BinaryTreeInOrderTraversal_Stack_VB_94
    Implements IBinaryTreeInorderTraversal_94

    Public Function InorderTraversal(root As TreeNode) As IList(Of Integer) Implements IBinaryTreeInorderTraversal_94.InorderTraversal
        Dim returnable = New List(Of Integer)
        Dim current = root
        Dim stack = New Stack(Of TreeNode)

        While (current IsNot Nothing OrElse stack.Any())
            While (current IsNot Nothing)
                stack.Push(current)
                current = current.left
            End While
            current = stack.Pop()
            returnable.Add(current.val)
            current = current.right
        End While

        Return returnable
    End Function
End Class

