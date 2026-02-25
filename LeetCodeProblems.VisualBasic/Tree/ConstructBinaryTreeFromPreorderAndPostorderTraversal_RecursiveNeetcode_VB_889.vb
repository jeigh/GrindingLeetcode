Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveNeetcode_VB_889
    Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889

    Public Function ConstructFromPrePost(preorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889.ConstructFromPrePost
        Dim postIndices = CreateIndices(postorder)

        Return buildTree(preorder, postIndices, 0, postorder.Length, 0)
    End Function

    Private Function buildTree(preorder() As Integer, postIndices As Dictionary(Of Integer, index), preStart As Integer, preEnd As Integer, postStart As Integer) As TreeNode
        If preStart >= preEnd Then Return Nothing

        Dim currentValue = preorder(preStart)

        Dim left As TreeNode = Nothing
        Dim right As TreeNode = Nothing

        If preStart <> preEnd - 1 Then
            Dim nextVal = preorder(preStart + 1)
            Dim postIndexOfNext = postIndices(nextVal)
            Dim leftSize = postIndexOfNext - postStart + 1

            left = buildTree(preorder, postIndices, preStart + 1, preStart + leftSize + 1, postStart)
            right = buildTree(preorder, postIndices, preStart + leftSize + 1, preEnd, postIndexOfNext + 1)
        End If

        Return New TreeNode(currentValue, left, right)
    End Function

    Public Function CreateIndices(collection() As Integer) As Dictionary(Of Integer, index)
        Dim ret = New Dictionary(Of Integer, index)
        For i = 0 To collection.Length - 1
            ret(collection(i)) = i
        Next
        Return ret
    End Function

End Class

