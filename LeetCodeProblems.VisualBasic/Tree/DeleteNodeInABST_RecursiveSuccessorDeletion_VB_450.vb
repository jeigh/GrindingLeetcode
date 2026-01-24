Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class DeleteNodeInABST_RecursiveSuccessorDeletion_VB_450
    Implements IDeleteNodeInABST_450

    Public Function DeleteNode(root As TreeNode, key As Integer) As TreeNode Implements IDeleteNodeInABST_450.DeleteNode
        If root Is Nothing Then Return Nothing

        If key > root.val Then
            root.right = DeleteNode(root.right, key)
            Return root
        End If

        If key < root.val Then
            root.left = DeleteNode(root.left, key)
            Return root
        End If

        If root.left Is Nothing Then Return root.right
        If root.right Is Nothing Then Return root.left

        Dim successor = root.right
        While successor.left IsNot Nothing
            successor = successor.left
        End While

        root.val = successor.val
        root.right = DeleteNode(root.right, successor.val)

        Return root
    End Function
End Class

