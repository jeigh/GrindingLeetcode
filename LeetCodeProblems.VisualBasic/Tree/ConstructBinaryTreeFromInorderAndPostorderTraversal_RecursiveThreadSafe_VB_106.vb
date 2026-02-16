Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromInorderAndPostorderTraversal_RecursiveThreadSafe_VB_106
    Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106

    Public Function BuildTree(inorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromInOrderAndPostOrderTraversal_106.BuildTree
        Return BuildTree(inorder, postorder, 0, postorder.Length, 0, inorder.Length)
    End Function

    Public Function BuildTree(inorder() As Integer, postorder() As Integer, postStart As index, postEnd As index, inStart As index, inEnd As index) As TreeNode
        If inStart >= inEnd Then Return Nothing
        If postStart >= postEnd Then Return Nothing


        Dim currentValue = postorder(postEnd - 1)
        Dim inIndex = GetIndex(inorder, inStart, inEnd, currentValue)
        Dim leftSize = inIndex - inStart

        Dim leftInStart As index = inStart
        Dim leftInEnd As index = inIndex
        Dim rightInStart As index = inIndex + 1
        Dim rightInEnd As index = inEnd

        Dim leftPostStart As index = postStart
        Dim leftPostEnd As index = postStart + leftSize
        Dim rightPostStart As index = postStart + leftSize
        Dim rightPostEnd As index = postEnd - 1

        Dim right As TreeNode = BuildTree(inorder, postorder, rightPostStart, rightPostEnd, rightInStart, rightInEnd)
        Dim left As TreeNode = BuildTree(inorder, postorder, leftPostStart, leftPostEnd, leftInStart, leftInEnd)

        Return New TreeNode(currentValue, left, right)
    End Function

    Private Function GetIndex(inorder() As Integer, inStart As Integer, inEnd As Integer, currentValue As Integer) As Object
        For i = inStart To inEnd
            If inorder(i) = currentValue Then Return i
        Next
        Throw New Exception("off by 1")
    End Function
End Class

