Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

' solved 2026-01-19
Public Class RecoverBinarySearchTree_Iterative_VB_99
    Implements IRecoverBinarySearchTree_99

    Public Sub RecoverTree(root As TreeNode) Implements IRecoverBinarySearchTree_99.RecoverTree
        Dim stack = New Stack(Of TreeNode)
        Dim current = root
        Dim previous As TreeNode = Nothing
        Dim first As TreeNode = Nothing
        Dim last As TreeNode = Nothing

        While (current IsNot Nothing OrElse stack.Count > 0)
            While (current IsNot Nothing)
                stack.Push(current)
                current = current.left
            End While

            current = stack.Pop()

            If (previous IsNot Nothing AndAlso previous.val > current.val) Then
                If (first Is Nothing) Then
                    first = previous
                    last = current
                Else
                    last = current
                    Exit While
                End If
            End If

            previous = current
            current = current.right
        End While

        Swap(first, last)
    End Sub

    Private Sub Swap(first As TreeNode, last As TreeNode)
        Dim temp = first.val
        first.val = last.val
        last.val = temp
    End Sub
End Class

