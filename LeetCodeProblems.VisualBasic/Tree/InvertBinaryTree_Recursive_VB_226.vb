Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class InvertBinaryTree_Recursive_VB_226
    Implements IInvertBinaryTree_226

    ' solved on 2025-12-19
    Public Function InvertTree(root As TreeNode) As TreeNode Implements IInvertBinaryTree_226.InvertTree
        If root Is Nothing Then Return Nothing
        If (root.left Is Nothing AndAlso root.right Is Nothing) Then Return root

        Dim temp = root.left
        root.left = InvertTree(root.right)
        root.right = InvertTree(temp)

        Return root
    End Function
End Class


