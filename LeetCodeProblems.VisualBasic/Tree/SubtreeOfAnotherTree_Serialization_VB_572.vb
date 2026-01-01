Imports System.Text
Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class SubtreeOfAnotherTree_Serialization_VB_572
    Implements ISubtreeOfAnotherTree_572

    Public Function IsSubtree(root As TreeNode, subroot As TreeNode) As Boolean Implements ISubtreeOfAnotherTree_572.IsSubtree
        If subroot Is Nothing Then Return True
        If root Is Nothing And subroot IsNot Nothing Then Return False
        If Serialize(root).Contains(Serialize(subroot)) Then Return True
        Return False
    End Function

    Private Function Serialize(root As TreeNode) As String
        If root Is Nothing Then Return "$#"
        Return $"${root.val}{Serialize(root.left)}${Serialize(root.right)}"
    End Function
End Class

