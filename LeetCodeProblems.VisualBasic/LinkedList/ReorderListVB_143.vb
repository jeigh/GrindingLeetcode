Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class ReorderListVB_143
    Implements IReorderList_143

    Public Sub ReorderList(head As ListNode) Implements IReorderList_143.ReorderList
        If (head?.next Is Nothing) Then Return

        Dim head2 = SplitList(head)
        head2 = Reverse(head2)
        ZipperMerge(head, head2)
    End Sub

    Private Sub ZipperMerge(head1 As ListNode, head2 As ListNode)
        Dim node1 = head1
        Dim node2 = head2

        While node1 IsNot Nothing AndAlso node2 IsNot Nothing
            Dim node1next = node1.next
            Dim node2next = node2.next

            node1.next = node2
            node2.next = node1next

            node1 = node1next
            node2 = node2next
        End While
    End Sub

    Private Function Reverse(head As ListNode) As ListNode
        Dim first As ListNode = Nothing
        Dim second As ListNode = head

        While second IsNot Nothing
            Dim secondNext = second.next

            second.next = first

            first = second
            second = secondNext
        End While

        Return first
    End Function

    Private Function SplitList(head As ListNode) As ListNode
        Dim fast = head
        Dim slow = head

        While fast?.next?.next IsNot Nothing
            fast = fast?.next?.next
            slow = slow.next
        End While

        Dim newHead = slow.next
        slow.next = Nothing
        Return newHead

    End Function
End Class
