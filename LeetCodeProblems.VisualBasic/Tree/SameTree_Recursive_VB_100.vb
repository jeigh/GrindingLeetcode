Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

' solved 2025-12-26
Public Class SameTree_Recursive_VB_100
    Implements ISameTree_100
    Public Function IsSameTree(p As TreeNode, q As TreeNode) As Boolean Implements ISameTree_100.IsSameTree
        If p Is Nothing AndAlso q Is Nothing Then Return True
        If p Is Nothing OrElse q Is Nothing Then Return False

        If p.val <> q.val Then Return False

        If Not IsSameTree(p.left, q.left) Then Return False
        If Not IsSameTree(p.right, q.right) Then Return False

        Return True
    End Function
End Class

