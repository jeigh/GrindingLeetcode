Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class AddTwoNumbersVB_2
        Implements IAddTwoNumbers_2

        Public Function AddTwoNumbers(l1 As ListNode, l2 As ListNode) As ListNode Implements IAddTwoNumbers_2.AddTwoNumbers
            Dim overhead = New ListNode()
            Dim current = overhead
            Dim carry As Integer = 0

            While l1 IsNot Nothing OrElse l2 IsNot Nothing OrElse carry > 0
                Dim val1 = If(l1 IsNot Nothing, l1.val, 0)
                Dim val2 = If(l2 IsNot Nothing, l2.val, 0)

                Dim sum = val1 + val2 + carry
                carry = sum \ 10

                current.next = New ListNode(sum Mod 10)
                current = current.next

                If l1 IsNot Nothing Then l1 = l1.next
                If l2 IsNot Nothing Then l2 = l2.next
            End While

            Return overhead.next
        End Function
    End Class
End Namespace
