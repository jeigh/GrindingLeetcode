Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class PalindromePartitioning_Backtracking_VB_131
        Implements IPalindromePartitioning_131

        Public Function Partition(s As String) As IList(Of IList(Of String)) Implements IPalindromePartitioning_131.Partition
            Dim result = New List(Of IList(Of String))
            recurse(s, 0, New List(Of String), result)
            Return result
        End Function

        Public Sub recurse(s As String, startOffset As Integer, current As List(Of String), result As List(Of IList(Of String)))
            If s.Length = startOffset Then
                result.Add(current.ToList())
                Return
            End If

            For endOffset = startOffset To s.Length - 1
                recurseIfPalindrome(s, startOffset, current, result, endOffset)
            Next
        End Sub

        Private Sub recurseIfPalindrome(s As String, startOffset As Integer, current As List(Of String), result As List(Of IList(Of String)), endOffset As Integer)
            If isPalindrome(s, startOffset, endOffset) Then
                Dim substr = s.Substring(startOffset, endOffset - startOffset + 1)

                current.Add(substr)
                recurse(s, endOffset + 1, current, result)
                current.RemoveAt(current.Count() - 1)
            End If
        End Sub

        Private Function isPalindrome(s As String, startOffset As Integer, endOffset As Integer) As Boolean
            If startOffset >= endOffset Then Return True
            If s(startOffset) = s(endOffset) Then Return isPalindrome(s, startOffset + 1, endOffset - 1)
            Return False
        End Function
    End Class

End Namespace
