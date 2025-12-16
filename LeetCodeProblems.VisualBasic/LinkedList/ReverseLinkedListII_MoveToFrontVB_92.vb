Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class ReverseLinkedListII_MoveToFrontVB_92
        Implements IReverseLinkedListII_92

        Public Function ReverseBetween(head As ListNode, left As Integer, right As Integer) As ListNode Implements IReverseLinkedListII_92.ReverseBetween

            Dim dummyForHead As New ListNode(0, head)
            Dim leftBoundary = dummyForHead

            For index = 1 To left - 1
                leftBoundary = leftBoundary.next
            Next

            Dim anchor = leftBoundary.next

            For index = left To right - 1
                Dim nextNode = anchor.next

                anchor.next = anchor.next.next
                nextNode.next = leftBoundary.next
                leftBoundary.next = nextNode
            Next

            Return dummyForHead.next
        End Function
    End Class
End Namespace
