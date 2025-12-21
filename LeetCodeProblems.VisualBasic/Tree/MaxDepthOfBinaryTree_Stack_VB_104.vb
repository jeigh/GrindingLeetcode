Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved 2025-12-19
Public Class MaxDepthOfBinaryTree_Stack_VB_104
    Implements IMaxDepthOfBinaryTree_104

    Public Function MaxDepth(root As TreeNode) As Integer Implements IMaxDepthOfBinaryTree_104.MaxDepth
        If root Is Nothing Then Return 0
        Dim stack As New Stack(Of (node As TreeNode, parentDepth As Integer))
        Dim result As Integer = 0
        stack.Push((root, 0))

        While (stack.Count > 0)
            Dim popped = stack.Pop()
            Dim currentDepth = popped.parentDepth + 1
            result = Math.Max(result, currentDepth)

            If (popped.node.left IsNot Nothing) Then stack.Push((popped.node.left, currentDepth))
            If (popped.node.right IsNot Nothing) Then stack.Push((popped.node.right, currentDepth))
        End While

        Return result
    End Function
End Class

