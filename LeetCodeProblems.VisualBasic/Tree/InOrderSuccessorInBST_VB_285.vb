Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class InOrderSuccessorInBST_VB_285
    Implements IInorderSuccessorInBST_285

    Public Function InorderSuccessor(root As TreeNode, p As TreeNode) As TreeNode Implements IInorderSuccessorInBST_285.InorderSuccessor
        If p Is Nothing Then Return Nothing
        If p.right Is Nothing AndAlso root Is Nothing Then Return Nothing

        Dim successor As TreeNode = Nothing
        Dim current = root

        If p.right Is Nothing Then
            While Not ReferenceEquals(current, p)
                If p.val < current.val Then
                    successor = current
                    current = current.left
                Else
                    current = current.right
                End If
            End While
        Else
            successor = p.right
            While successor.left IsNot Nothing
                successor = successor.left
            End While
        End If

        Return successor
    End Function
End Class

