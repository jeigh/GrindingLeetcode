Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class ReverseLinkedListVB_206
        Implements IReverseLinkedList_206

        Public Function ReverseList(head As ListNode) As ListNode Implements IReverseLinkedList_206.ReverseList
            If head Is Nothing Then Return Nothing

            Dim prev As ListNode = Nothing
            Dim current As ListNode = head

            While current IsNot Nothing
                Dim nextTemp As ListNode = current.next

                current.next = prev
                prev = current

                current = nextTemp
            End While

            Return prev
        End Function
    End Class
End Namespace
