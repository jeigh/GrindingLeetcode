Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class DiameterOfBinaryTree_Recursive_VB_543
    Implements IDiameterOfBinaryTree_543

    ' solved 2025-12-19
    Public Function DiameterOfBinaryTree(root As TreeNode) As Integer Implements IDiameterOfBinaryTree_543.DiameterOfBinaryTree
        Dim maxDiameter As Integer = 0
        MaxDepth(root, maxDiameter)
        Return maxDiameter
    End Function

    Private Function MaxDepth(node As TreeNode, ByRef diameter As Integer) As Integer
        If node Is Nothing Then Return 0

        Dim leftDepth = MaxDepth(node.left, diameter)
        Dim rightDepth = MaxDepth(node.right, diameter)

        ' depth calculation
        diameter = Math.Max(diameter, leftDepth + rightDepth)

        ' depth calculation
        Return 1 + Math.Max(leftDepth, rightDepth)
    End Function
End Class
