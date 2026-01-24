Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class DeleteNodeInABST_DirectSuccessorPromotion_VB_450
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

        ' if key == root.val
        If root.right Is Nothing Then Return root.left
        If root.left Is Nothing Then Return root.right

        ' Find the inorder successor (leftmost node in right subtree)
        Dim successor = root.right

        ' If the immediate right child has no left child, it's the successor
        If successor.left Is Nothing Then
            successor.left = root.left  ' Attach left subtree to successor
            Return successor
        End If

        ' Otherwise, find the leftmost node in right subtree
        Dim parent = successor
        While successor.left IsNot Nothing
            parent = successor
            successor = successor.left
        End While

        ' Remove successor from its current position
        parent.left = successor.right  ' Successor's right child takes its place

        ' Place successor in root's position
        successor.left = root.left
        successor.right = root.right

        Return successor
    End Function
End Class

