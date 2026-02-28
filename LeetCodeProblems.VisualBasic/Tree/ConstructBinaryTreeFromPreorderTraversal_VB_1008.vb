Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderTraversal_VB_1008
    Implements IConstructBinarySearchTreeFromPreorderTraversal_1008

    Public Function BstFromPreorder(preorder() As Integer) As TreeNode Implements IConstructBinarySearchTreeFromPreorderTraversal_1008.BstFromPreorder
        Return BuildTree(preorder, 0, preorder.Length)
    End Function

    Private Function BuildTree(preorder() As Integer, preStart As index, preEnd As index) As TreeNode
        If preStart >= preEnd Then Return Nothing

        Dim currentValue = preorder(preStart)
        Dim node = New TreeNode(currentValue)
        Dim leftIndex = preStart + 1

        If leftIndex >= preorder.Length Then Return node

        Dim rightIndex As index = leftIndex
        While rightIndex < preorder.Length AndAlso preorder(rightIndex) < currentValue
            rightIndex += 1
        End While

        node.left = BuildTree(preorder, leftIndex, rightIndex)

        If rightIndex >= preorder.Length Then Return node

        node.right = BuildTree(preorder, rightIndex, preEnd)

        Return node
    End Function
End Class

