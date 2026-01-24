Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class DeleteNodeInABST_LeftTreeDemotion_VB_450
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

        Dim leftTree = root.left
        Dim returnable As TreeNode = root.right

        DemoteLeftSubtree(root, leftTree)

        Return returnable
    End Function

    Public Sub DemoteLeftSubtree(deletable As TreeNode, successor As TreeNode)
        Dim attachPoint = deletable.right

        While attachPoint.left IsNot Nothing
            attachPoint = attachPoint.left
        End While

        attachPoint.left = successor
    End Sub


End Class

