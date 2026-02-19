Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveHashmap_VB_106
    Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106

    Public Function BuildTree(inorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106.BuildTree
        Dim inorderIndices = CreateIndicesHashmap(inorder)
        Dim postIndex As index = postorder.Length

        Return BuildTree(postorder, inorderIndices, postIndex, 0, inorder.Length)
    End Function

    Private Function BuildTree(postorder() As Integer, inorderIndices As Dictionary(Of Integer, index), ByRef postIndex As Integer, inStart As index, inEnd As index) As TreeNode
        If postIndex < 1 Then Return Nothing
        If inStart >= inEnd Then Return Nothing

        postIndex -= 1
        Dim currentValue = postorder(postIndex)
        Dim inIndex = inorderIndices(currentValue)

        Dim right As TreeNode = BuildTree(postorder, inorderIndices, postIndex, inIndex + 1, inEnd)
        Dim left As TreeNode = BuildTree(postorder, inorderIndices, postIndex, inStart, inIndex)

        Return New TreeNode(currentValue, left, right)
    End Function

    Private Function CreateIndicesHashmap(inorder() As Integer) As Dictionary(Of Integer, index)
        Dim retval = New Dictionary(Of Integer, index)()
        For i = 0 To inorder.Length - 1
            retval(inorder(i)) = i
        Next
        Return retval
    End Function
End Class

