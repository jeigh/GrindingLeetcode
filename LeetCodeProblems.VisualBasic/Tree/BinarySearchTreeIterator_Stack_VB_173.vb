Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class BinarySearchTreeIterator_Stack_VB_173
    Implements IBinarySearchTreeIterator_173

    Private _stack As New Stack(Of TreeNode)

    Public Sub New(root As TreeNode)
        PushLeft(root)
    End Sub

    Public Sub PushLeft(node As TreeNode)
        While (node IsNot Nothing)
            _stack.Push(node)
            node = node.left
        End While
    End Sub

    Public Function [Next]() As Integer Implements IBinarySearchTreeIterator_173.Next
        Dim _current = _stack.Pop()
        PushLeft(_current.right)
        Return _current.val
    End Function

    Public Function HasNext() As Boolean Implements IBinarySearchTreeIterator_173.HasNext
        Return _stack.Count > 0
    End Function
End Class

