Imports System.ComponentModel.DataAnnotations
Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class RemoveNthNodeFromEndOfListVB_19
        Implements IRemoveNthNodeFromEndOfList_19

        Public Function RemoveNthFromEnd(head As ListNode, n As Integer) As ListNode Implements IRemoveNthNodeFromEndOfList_19.RemoveNthFromEnd
            If head Is Nothing Then Return Nothing

            Dim dummy As New ListNode(0, head)
            Dim prev = dummy
            Dim eol = Traverse(n, prev)

            While eol IsNot Nothing
                eol = eol.next
                prev = prev.next
            End While

            RemoveNextNodeFromList(prev)

            Return dummy.next
        End Function

        Private Sub RemoveNextNodeFromList(prev As ListNode)
            If prev Is Nothing Then Throw New ArgumentException("prev cannot be null.")
            If prev.next Is Nothing Then Return
            prev.next = prev.next.next
        End Sub



        Private Shared Function Traverse(n As Integer, fast As ListNode) As ListNode
            For i = 0 To n
                If fast Is Nothing Then Throw New ArgumentException("n must not be larger than the length of the list.")

                fast = fast.next
            Next

            Return fast
        End Function
    End Class
End Namespace
