Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved 2025-12-19
Public Class MaxDepthOfBinaryTree_Recursive_VB_104
    Implements IMaxDepthOfBinaryTree_104

    Public Function MaxDepth(root As TreeNode) As Integer Implements IMaxDepthOfBinaryTree_104.MaxDepth
        If root Is Nothing Then Return 0

        Dim leftMaxDepth = MaxDepth(root.left)
        Dim rightMaxDepth = MaxDepth(root.right)

        Return Math.Max(rightMaxDepth, leftMaxDepth) + 1
    End Function
End Class

