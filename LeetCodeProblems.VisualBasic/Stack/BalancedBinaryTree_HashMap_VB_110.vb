Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class BalancedBinaryTree_HashMap_VB_110
    Implements IBalancedBinaryTree_110

    Public Function IsBalanced(root As TreeNode) As Boolean Implements IBalancedBinaryTree_110.IsBalanced
        If (root Is Nothing) Then Return True

        Dim stack As New Stack(Of TreeNode)()
        Dim hashMap As New Dictionary(Of TreeNode, Integer)()
        stack.Push(root)

        While (stack.Count > 0)
            Dim peeked = stack.Peek()

            If (peeked.left IsNot Nothing AndAlso Not hashMap.ContainsKey(peeked.left)) Then
                stack.Push(peeked.left)
            ElseIf (peeked.right IsNot Nothing AndAlso Not hashMap.ContainsKey(peeked.right)) Then
                stack.Push(peeked.right)
            Else
                stack.Pop()

                Dim leftDepth = 0
                Dim rightDepth = 0

                If peeked.right IsNot Nothing Then rightDepth = hashMap(peeked.right)
                If peeked.left IsNot Nothing Then leftDepth = hashMap(peeked.left)

                If Math.Abs(leftDepth - rightDepth) > 1 Then Return False

                hashMap(peeked) = Math.Max(leftDepth, rightDepth) + 1
                End If
        End While

        Return True
    End Function
End Class

