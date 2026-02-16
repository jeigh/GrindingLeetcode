Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveLimit_VB_106
    Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106

    Public Function BuildTree(inorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106.BuildTree
        Return BuildTree(inorder, postorder, Int64.MaxValue, postorder.Length - 1, inorder.Length - 1)
    End Function

    Public Function BuildTree(inorder() As Integer, postorder() As Integer, limitValue As System.Int64, ByRef postIndex As index, ByRef inIndex As index) As TreeNode
        If postIndex < 0 Then Return Nothing
        If inIndex < 0 Then Return Nothing

        If inorder(inIndex) = limitValue Then
            inIndex -= 1
            Return Nothing
        End If

        Dim currentValue = postorder(postIndex)
        postIndex -= 1

        Dim right As TreeNode = BuildTree(inorder, postorder, currentValue, postIndex, inIndex)
        Dim left As TreeNode = BuildTree(inorder, postorder, limitValue, postIndex, inIndex)

        Return New TreeNode(currentValue, left, right)
    End Function




End Class

