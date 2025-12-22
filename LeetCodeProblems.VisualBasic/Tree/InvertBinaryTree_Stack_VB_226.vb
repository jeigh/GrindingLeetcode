Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class InvertBinaryTree_Stack_VB_226
    Implements IInvertBinaryTree_226

    ' solved on 2025-12-19
    Public Function InvertTree(root As TreeNode) As TreeNode Implements IInvertBinaryTree_226.InvertTree
        If root Is Nothing Then Return root
        Dim stack = New Stack(Of TreeNode)
        stack.Push(root)

        While stack.Count > 0
            Dim current = stack.Pop()

            If current.left IsNot Nothing Then stack.Push(current.left)
            If current.right IsNot Nothing Then stack.Push(current.right)

            If current.right IsNot Nothing OrElse current.left IsNot Nothing Then
                Dim temp = current.left
                current.left = current.right
                current.right = temp
            End If
        End While

        Return root
    End Function
End Class


