Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndPostorderTraversal_RecursiveHashmap_VB_889
    Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889

    Public Function ConstructFromPrePost(preorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889.ConstructFromPrePost
        Dim preorderIndices = CreateIndices(preorder)
        Dim postorderIndices = CreateIndices(postorder)
        Dim processedValues = New HashSet(Of Integer)(preorder.Length)
        Dim preorderIndex = 0

        Return BuildTree(preorder, postorder, preorderIndices, postorderIndices, preorderIndex, processedValues)
    End Function

    Public Function BuildTree(preorder() As Integer, postorder() As Integer, preorderIndices As Dictionary(Of Integer, index), postorderIndices As Dictionary(Of Integer, index), preorderIndex As index, processedValues As HashSet(Of Integer)) As TreeNode
        Dim currentValue = preorder(preorderIndex)
        If processedValues.Contains(currentValue) Then Return Nothing
        processedValues.Add(currentValue)

        Dim postorderIndex = postorderIndices(currentValue)

        Dim leftValue As Integer? = Nothing
        If preorderIndex + 1 < preorder.Length Then leftValue = preorder(preorderIndex + 1)

        Dim rightValue As Integer? = Nothing
        If postorderIndex > 0 AndAlso Not processedValues.Contains(postorder(postorderIndex - 1)) Then rightValue = postorder(postorderIndex - 1)

        Dim left As TreeNode = Nothing
        Dim right As TreeNode = Nothing

        If rightValue.HasValue AndAlso leftValue.HasValue AndAlso leftValue.Value <> rightValue.Value Then
            left = BuildTree(preorder, postorder, preorderIndices, postorderIndices, preorderIndex + 1, processedValues)

            preorderIndex = preorderIndices(rightValue.Value)

            right = BuildTree(preorder, postorder, preorderIndices, postorderIndices, preorderIndex, processedValues)
        ElseIf (rightValue.HasValue AndAlso leftValue = rightValue) Then
            left = BuildTree(preorder, postorder, preorderIndices, postorderIndices, preorderIndex + 1, processedValues)
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

