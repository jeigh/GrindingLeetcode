Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveCononical_VB_889
    Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889

    Public Function ConstructFromPrePost(preorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889.ConstructFromPrePost
        Dim hashMap = CreateIndices(postorder)
        Return BuildTree(preorder, postorder, hashMap, 0, preorder.Length, 0, postorder.Length)
    End Function

    Public Function BuildTree(preorder() As Integer, postorder() As Integer, postorderIndices As Dictionary(Of Integer, index), preStart As index, preEnd As index, postStart As index, postEnd As index) As TreeNode
        If preStart >= preEnd Then Return Nothing
        If postStart >= postEnd Then Return Nothing

        Dim currentValue = preorder(preStart)

        If preStart = preEnd - 1 Then Return New TreeNode(currentValue)

        Dim nextValue = preorder(preStart + 1)
        Dim postIndexOfNext = postorderIndices(nextValue)
        Dim size = postIndexOfNext - postStart + 1

        Dim leftPreStart = preStart + 1
        Dim leftPreEnd = preStart + size + 1
        Dim rightPreStart = preStart + size + 1
        Dim rightPreEnd = preEnd

        Dim leftPostStart = postStart
        Dim leftPostEnd = postIndexOfNext + 1
        Dim rightPostStart = postIndexOfNext + 1
        Dim rightPostEnd = postEnd - 1

        Dim left As TreeNode = BuildTree(preorder, postorder, postorderIndices, leftPreStart, leftPreEnd, leftPostStart, leftPostEnd)
        Dim right As TreeNode = BuildTree(preorder, postorder, postorderIndices, rightPreStart, rightPreEnd, rightPostStart, rightPostEnd)

        Return New TreeNode(currentValue, left, right)
    End Function

    Public Function CreateIndices(ary() As Integer) As Dictionary(Of Integer, index)
        Dim hashMap = New Dictionary(Of Integer, index)(ary.Length)
        For i = 0 To ary.Length - 1
            hashMap(ary(i)) = i
        Next
        Return hashMap
    End Function

End Class

