Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.[Shared]

Public Class BinarySearchTreeIterator_InOrderSuccessor_VB_173
    Implements IBinarySearchTreeIterator_173

    Private _sentinalNode As TreeNode
    Private _rootNode As TreeNode
    Private _currentNode As TreeNode
    Private _maxNode As TreeNode

    Public Sub New(rootNode As TreeNode)
        If rootNode IsNot Nothing Then
            _rootNode = rootNode
            _currentNode = _rootNode
            While (_currentNode.left IsNot Nothing)
                _currentNode = _currentNode.left
            End While
            _sentinalNode = New TreeNode(Integer.MinValue, Nothing, _currentNode)
            _currentNode = _sentinalNode

            _maxNode = _rootNode
            While _maxNode.right IsNot Nothing
                _maxNode = _maxNode.right
            End While
        End If
    End Sub

    Public Function [Next]() As Integer Implements IBinarySearchTreeIterator_173.Next
        If Not HasNext() Then Return Nothing

        If _currentNode.right IsNot Nothing Then
            _currentNode = _currentNode.right
            While _currentNode.left IsNot Nothing
                _currentNode = _currentNode.left
            End While
        Else
            Dim previousValue = _currentNode.val
            Dim reTraversed = _rootNode
            While previousValue <> reTraversed.val
                If previousValue > reTraversed.val Then
                    reTraversed = reTraversed.right
                Else
                    _currentNode = reTraversed
                    reTraversed = reTraversed.left
                End If
            End While
        End If

        Return _currentNode.val
    End Function

    Public Function HasNext() As Boolean Implements IBinarySearchTreeIterator_173.HasNext
        If _rootNode Is Nothing Then Return False
        If _currentNode.val <> _maxNode.val Then Return True
        Return False
    End Function
End Class

