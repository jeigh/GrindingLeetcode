Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class MiddleOfLinkedListVB_876
        Implements IMiddleOfLinkedList_876

        Public Function MiddleNode(head As ListNode) As ListNode Implements IMiddleOfLinkedList_876.MiddleNode
            Dim fast = head
            Dim slow = head

            While fast?.next IsNot Nothing
                fast = fast?.next?.next
                slow = slow.next
            End While

            Return slow
        End Function
    End Class
End Namespace
