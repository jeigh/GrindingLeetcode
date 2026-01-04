Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class TwoSumIV_FlattenFirst_VB_653
    Implements ITwoSumIV_653

    Public Function FindTarget(root As TreeNode, k As Integer) As Boolean Implements ITwoSumIV_653.FindTarget
        If root Is Nothing Then Return False

        Dim list = CreateListFromTreeNode(root)

        Return DoTwoPointerAlgorithm(list, k)
    End Function

    Private Function DoTwoPointerAlgorithm(list As List(Of Integer), k As Integer) As Boolean
        Dim left = 0
        Dim right = list.Count - 1

        While right > left
            If list(left) + list(right) > k Then
                right = right - 1
            ElseIf list(left) + list(right) < k Then
                left = left + 1
            Else
                Return True
            End If

        End While

        Return False
    End Function

    Private Function CreateListFromTreeNode(root As TreeNode) As List(Of Integer)
        Dim returnable = New List(Of Integer)()
        Dim stack As New Stack(Of TreeNode)()
        Dim current As TreeNode = root

        While (current IsNot Nothing OrElse stack.Count > 0)
            While current IsNot Nothing
                stack.Push(current)
                current = current.left
            End While

            current = stack.Pop()
            returnable.Add(current.val)
            current = current.right
        End While

        Return returnable
    End Function
End Class

