Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

' solved 2026-01-20
Public Class BinaryTreeRightSideView_IterativeInOrder_VB_199
    Implements IBinaryTreeRightSideView_199

    Public Function RightSideView(root As TreeNode) As List(Of Integer) Implements IBinaryTreeRightSideView_199.RightSideView
        Dim response = New List(Of Integer)
        Dim stack = New Stack(Of (current As TreeNode, depth As Integer))
        Dim current As TreeNode = root
        Dim depth = 0

        While current IsNot Nothing OrElse stack.Count > 0
            While current IsNot Nothing
                stack.Push((current, depth))
                current = current.left
                depth += 1
            End While

            Dim popped = stack.Pop()
            depth = popped.depth
            current = popped.current

            While response.Count < depth + 1
                response.Add(current.val)
            End While
            response(depth) = current.val

            current = current.right
            depth += 1
        End While



        Return response
    End Function
End Class

