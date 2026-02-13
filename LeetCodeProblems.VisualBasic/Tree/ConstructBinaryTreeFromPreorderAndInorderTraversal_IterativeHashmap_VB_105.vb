Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class ConstructBinaryTreeFromPreorderAndInorderTraversal_IterativeHashmap_VB_105
    Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105

    ' this class exists simply to remind me that i'm dealing with an index and not a raw value
    ' if space was an issue, I'd remove it;  but in the meantime it adds readability
    Private Class index
        Public index As Integer
        Private _nextIndex As index

        Public Sub New(index As Integer)
            Me.index = index
        End Sub

        Public Function nextIndex() As index
            If _nextIndex Is Nothing Then _nextIndex = New index(Me.index + 1)
            Return _nextIndex
        End Function
    End Class

    Public Function BuildTree(preorder() As Integer, inorder() As Integer) As TreeNode Implements IConstructBinaryTreeFromPreorderAndInorderTraversal_105.BuildTree
        If preorder.Length = 0 Then Return Nothing

        Dim inorderIndices = GenerateInorderIndices(inorder)
        Dim stack = New Stack(Of (parent As TreeNode, inorderLeft As index, inorderRight As index, isRight As Boolean))()
        Dim preorderIndex = New index(0)

        stack.Push((Nothing, New index(0), New index(preorder.Length - 1), True))
        Dim root As TreeNode = Nothing

        While stack.Count > 0
            Dim p = stack.Pop()

            If p.inorderLeft.index > p.inorderRight.index Then Continue While

            Dim currentValue = preorder(preorderIndex.index)
            preorderIndex = preorderIndex.nextIndex()
            Dim node = New TreeNode(currentValue)

            If p.parent Is Nothing Then
                root = node
            ElseIf p.isRight Then
                p.parent.right = node
            Else
                p.parent.left = node
            End If

            Dim inorderIndex = inorderIndices(currentValue)

            If inorderIndex.index < p.inorderRight.index Then
                stack.Push((node, New index(inorderIndex.index + 1), p.inorderRight, True))
            End If

            If p.inorderLeft.index < inorderIndex.index Then
                stack.Push((node, p.inorderLeft, New index(inorderIndex.index - 1), False))
            End If
        End While

        Return root
    End Function

    Private Function GenerateInorderIndices(inorder() As Integer) As Dictionary(Of Integer, index)
        Dim inorderIndices = New Dictionary(Of Integer, index)(inorder.Length)

        For i = 0 To inorder.Length - 1
            inorderIndices(inorder(i)) = New index(i)
        Next

        Return inorderIndices
    End Function
End Class

