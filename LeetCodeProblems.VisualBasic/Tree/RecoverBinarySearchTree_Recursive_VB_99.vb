Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

' solved 2026-01-19
Public Class RecoverBinarySearchTree_Recursive_VB_99
    Implements IRecoverBinarySearchTree_99

    Public Sub RecoverTree(root As TreeNode) Implements IRecoverBinarySearchTree_99.RecoverTree
        If root Is Nothing Then Return

        Dim first As TreeNode = Nothing
        Dim last As TreeNode = Nothing
        Dim previous As TreeNode = Nothing

        InOrder(root, first, last, previous)

        Swap(first, last)
    End Sub

    Public Sub InOrder(node As TreeNode, ByRef first As TreeNode, ByRef last As TreeNode, ByRef previous As TreeNode)
        If node Is Nothing Then Return
        InOrder(node.left, first, last, previous)

        If previous IsNot Nothing AndAlso previous.val > node.val Then
            If first Is Nothing Then
                first = previous
                last = node
            Else
                last = node
            End If
        End If
        previous = node

        InOrder(node.right, first, last, previous)
    End Sub

    Public Sub Swap(first As TreeNode, last As TreeNode)
        Dim temp = first.val
        first.val = last.val
        last.val = temp
    End Sub

End Class

