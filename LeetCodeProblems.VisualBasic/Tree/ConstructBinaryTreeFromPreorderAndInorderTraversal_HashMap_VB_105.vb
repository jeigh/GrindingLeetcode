Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndInorderTraversal_HashMap_VB_105
    Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105

    Public Function BuildTree(preorder() As Integer, inorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105.BuildTree
        Dim hashMap = GenerateHashmap(inorder)
        Dim preorderIndex = 0

        Return BuildSubtree(preorder, hashMap, 0, inorder.Length - 1, preorderIndex)
    End Function

    Private Function BuildSubtree(preorder() As Integer, hashmap As Dictionary(Of Integer, index), inorderLeft As index, inorderRight As index, ByRef preorderIndex As index) As TreeNode
        If inorderLeft > inorderRight Then Return Nothing
        Dim currentValue = preorder(preorderIndex)
        preorderIndex = preorderIndex + 1

        Dim midIndex = hashmap(currentValue)

        Dim left = BuildSubtree(preorder, hashmap, inorderLeft, midIndex - 1, preorderIndex)
        Dim right = BuildSubtree(preorder, hashmap, midIndex - 1, inorderRight, preorderIndex)

        Return New TreeNode(currentValue, left, right)
    End Function

    Private Function GenerateHashmap(inorder() As Integer) As Dictionary(Of Integer, index)
        Dim hashmap As New Dictionary(Of Integer, index)(inorder.Length)

        For i = 0 To inorder.Length - 1
            Dim value = inorder(i)
            hashmap(value) = i
        Next

        Return hashmap
    End Function
End Class

