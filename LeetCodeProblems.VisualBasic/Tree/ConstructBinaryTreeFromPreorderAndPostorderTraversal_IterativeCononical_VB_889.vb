Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared
Imports index = System.Int32

Public Class ConstructBinaryTreeFromPreorderAndPostorderTraversal_IterativeCononical_VB_889
    Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889

    Public Function ConstructFromPrePost(preorder() As Integer, postorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndPostorderTraversal_889.ConstructFromPrePost
        Dim postorderIndices = CreateIndices(postorder)
        Dim stack As New Stack(Of (parent As TreeNode, preStart As index, preEnd As index, postStart As index, postEnd As index, isRight As Boolean))(preorder.Length)
        stack.Push((Nothing, 0, preorder.Length, 0, postorder.Length, True))
        Dim root As TreeNode = Nothing
        While stack.Count > 0
            Dim sf = stack.Pop()

            If sf.preStart >= sf.preEnd Then Continue While
            If sf.postStart >= sf.postEnd Then Continue While

            Dim currentValue = preorder(sf.preStart)
            Dim node = New TreeNode(currentValue)

            If sf.parent Is Nothing Then
                root = node
            ElseIf sf.isRight Then
                sf.parent.right = node
            Else
                sf.parent.left = node
            End If

            If sf.preStart = sf.preEnd - 1 Then Continue While
            Dim postIndexOfNext As index = getPostIndexOfNext(preorder, postorderIndices, sf.preStart)
            Dim leftSize = postIndexOfNext - sf.postStart + 1

            Dim leftPreStart = sf.preStart + 1
            Dim leftPreEnd = sf.preStart + leftSize + 1
            Dim rightPreStart = sf.preStart + leftSize + 1
            Dim rightPreEnd = sf.preEnd

            Dim leftPostStart = sf.postStart
            Dim leftPostEnd = postIndexOfNext + 1
            Dim rightPostStart = postIndexOfNext + 1
            Dim rightPostEnd = sf.postEnd - 1

            stack.Push((node, leftPreStart, leftPreEnd, leftPostStart, leftPostEnd, False))
            stack.Push((node, rightPreStart, rightPreEnd, rightPostStart, rightPostEnd, True))
        End While
        Return root
    End Function

    Private Function getPostIndexOfNext(preorder() As Integer, postorderIndices As Dictionary(Of Integer, Integer), preStart As index) As Integer
        Dim nextValue = preorder(preStart + 1)
        Return postorderIndices(nextValue)
    End Function

    Public Function CreateIndices(collection() As Integer) As Dictionary(Of Integer, index)
        Dim ret = New Dictionary(Of Integer, index)
        For i = 0 To collection.Length - 1
            ret(collection(i)) = i
        Next
        Return ret
    End Function
End Class

