Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

' solved 2025-12-29
Public Class LowestCommonAncestorOfBinarySearchTree_Recursion_VB_235
    Implements ILowestCommonAncestorOfBinarySearchTree_235

    Public Function LowestCommonAncestor(root As TreeNode, p As TreeNode, q As TreeNode) As TreeNode Implements ILowestCommonAncestorOfBinarySearchTree_235.LowestCommonAncestor
        If root Is Nothing OrElse p Is Nothing OrElse q Is Nothing Then Return Nothing

        Dim bigger = If(p.val > q.val, p, q)
        Dim smaller = If(q.val > p.val, p, q)

        If (bigger.val < root.val) Then Return LowestCommonAncestor(root.left, bigger, smaller)
        If (smaller.val > root.val) Then Return LowestCommonAncestor(root.right, bigger, smaller)
        Return root
    End Function
End Class

