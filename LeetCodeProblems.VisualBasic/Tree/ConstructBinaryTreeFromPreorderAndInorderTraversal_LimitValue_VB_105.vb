Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndInorderTraversal_LimitValue_VB_105
    Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105

    ' solved 2026-02-07
    Public Function BuildTree(preorder() As Integer, inorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105.BuildTree
        Dim limitValue As Int64 = Int64.MaxValue
        Dim inIndex = 0
        Dim preIndex = 0

        Return BuildTree(preorder, inorder, limitValue, preIndex, inIndex)
    End Function

    Public Function BuildTree(preorder() As Integer, inorder() As Integer, limitValue As Int64, ByRef preIndex As index, ByRef inIndex As index) As TreeNode
        If preIndex >= preorder.Length Then Return Nothing
        If inIndex >= preorder.Length Then Return Nothing

        If inorder(inIndex) = limitValue Then
            inIndex += 1
            Return Nothing
        End If

        Dim currentValue = preorder(preIndex)
        preIndex += 1

        Dim left = BuildTree(preorder, inorder, currentValue, preIndex, inIndex)
        Dim right = BuildTree(preorder, inorder, limitValue, preIndex, inIndex)

        Return New TreeNode(currentValue, left, right)
    End Function


End Class

