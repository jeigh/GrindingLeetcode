Imports System.ComponentModel.DataAnnotations
Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class SubtreeOfAnotherTree_DFS_VB_572
    Implements ISubtreeOfAnotherTree_572

    Public Function IsSubtree(root As TreeNode, subroot As TreeNode) As Boolean Implements ISubtreeOfAnotherTree_572.IsSubtree
        If subroot Is Nothing Then Return True
        If root Is Nothing Then Return False

        If IsSameTree(root, subroot) Then Return True

        If IsSubtree(root.left, subroot) Then Return True
        If IsSubtree(root.right, subroot) Then Return True
        Return False
    End Function

    Private Function IsSameTree(p As TreeNode, q As TreeNode) As Boolean
        If p Is Nothing AndAlso q Is Nothing Then Return True
        If p Is Nothing OrElse q Is Nothing Then Return False

        If p.val <> q.val Then Return False
        Return IsSameTree(p.left, q.left) AndAlso IsSameTree(p.right, q.right)
    End Function




End Class

