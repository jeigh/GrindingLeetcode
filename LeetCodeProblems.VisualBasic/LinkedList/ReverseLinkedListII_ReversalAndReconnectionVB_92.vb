Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Namespace LinkedList

    Public Class ReverseLinkedListII_ReversalAndReconnectionVB_92
        Implements IReverseLinkedListII_92

        Public Function ReverseBetween(head As ListNode, left As Integer, right As Integer) As ListNode Implements IReverseLinkedListII_92.ReverseBetween
            Dim dummy = New ListNode(0, head)
            Dim leftNode = dummy
            Dim currentNode = dummy.next

            For i = 1 To left - 1
                leftNode = currentNode
                currentNode = currentNode.next
            Next

            Dim firstNodeOfReversalSegment = currentNode

            Dim prev As ListNode = Nothing

            For i = 0 To right - left
                Dim temp = currentNode.next

                currentNode.next = prev
                prev = currentNode
                currentNode = temp
            Next

            firstNodeOfReversalSegment.next = currentNode
            leftNode.next = prev

            Return dummy.next
        End Function

    End Class
End Namespace
