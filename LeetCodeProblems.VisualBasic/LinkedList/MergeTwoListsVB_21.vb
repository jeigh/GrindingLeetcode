Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class MergeTwoListsVB_21
        Implements IMergeTwoLists_21

        Public Function MergeTwoLists(list1 As ListNode, list2 As ListNode) As ListNode Implements IMergeTwoLists_21.MergeTwoLists
            If list1 Is Nothing Then Return list2
            If list2 Is Nothing Then Return list1

            Dim overhead As New ListNode(0)
            Dim tail As ListNode = overhead

            While list1 IsNot Nothing AndAlso list2 IsNot Nothing
                If list1.val <= list2.val Then
                    tail.next = list1
                    list1 = list1.next
                Else
                    tail.next = list2
                    list2 = list2.next
                End If
                tail = tail.next
            End While

            If list1 IsNot Nothing Then
                tail.next = list1
            Else
                tail.next = list2
            End If

            Return overhead.next
        End Function
    End Class
End Namespace
