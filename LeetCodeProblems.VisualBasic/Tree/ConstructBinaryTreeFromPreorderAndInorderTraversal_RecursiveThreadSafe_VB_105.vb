Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

' solved 2026-02-07
Public Class ConstructBinaryTreeFromPreorderAndInorderTraversal_RecursiveThreadSafe_VB_105
    Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105

    Public Function BuildTree(preorder() As Integer, inorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105.BuildTree
        Return BuildTree(preorder, inorder, 0, preorder.Length, 0, inorder.Length)
    End Function

    Public Function BuildTree(preorder() As Integer, inorder() As Integer, preStart As index, preEnd As index, inStart As index, inEnd As index) As TreeNode
        If preStart >= preEnd Then Return Nothing
        If inStart >= inEnd Then Return Nothing

        If preEnd > preorder.Length Then Return Nothing
        If inEnd > inorder.Length Then Return Nothing

        Dim currentValue = preorder(preStart)
        Dim inIndex = DetermineInorderIndex(inorder, inStart, inEnd, currentValue)
        Dim leftSize = inIndex - inStart

        Dim leftPreStart = preStart + 1
        Dim leftPreEnd = preStart + 1 + leftSize
        Dim leftInStart = inStart
        Dim leftInEnd = inIndex

        Dim rightPreStart = preStart + 1 + leftSize
        Dim rightPreEnd = preEnd
        Dim rightInStart = inIndex + 1
        Dim rightInEnd = inEnd

        Dim left = BuildTree(preorder, inorder, leftPreStart, leftPreEnd, leftInStart, leftInEnd)
        Dim right = BuildTree(preorder, inorder, rightPreStart, rightPreEnd, rightInStart, rightInEnd)

        Return New TreeNode(currentValue, left, right)
    End Function

    Private Function DetermineInorderIndex(inorder() As Integer, inStart As Integer, inEnd As Integer, currentValue As Integer) As Object
        For i = inStart To inEnd - 1
            If inorder(i) = currentValue Then Return i
        Next
        Throw New Exception("you have an off by 1 error somewhere")
    End Function
End Class

