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

