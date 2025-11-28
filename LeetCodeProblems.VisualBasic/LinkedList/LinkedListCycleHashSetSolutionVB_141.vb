Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Namespace LinkedList
    Public Class LinkedListCycleHashSetSolutionVB_141
        Implements ILinkedListCycle_141

        Private _hashset As New HashSet(Of ListNode)()

        Public Function HasCycle(head As ListNode) As Boolean Implements ILinkedListCycle_141.HasCycle
            Dim current As ListNode = head

            While current IsNot Nothing

                If _hashset.Contains(current) Then Return True
                _hashset.Add(current)

                current = current.next
            End While

            Return False
        End Function
    End Class
End Namespace
