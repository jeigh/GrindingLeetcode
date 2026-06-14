Imports System.Runtime.CompilerServices
Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class WordSearch_Backtracking_VB_79
        Implements IWordSearch_79

        Public Function Exist(board As Char()(), word As String) As Boolean Implements IWordSearch_79.Exist
            Dim hashSet As New HashSet(Of (x As Integer, y As Integer))()
            For i = 0 To board.Length
                For j = 0 To board(0).Length
                    If recurse(board, word, 0, hashSet, i, j) Then
                        Return True
                    End If
                Next
            Next
            Return False
        End Function

        Public Function recurse(board As Char()(), word As String, i As Integer, hashSet As HashSet(Of (Integer, Integer)), x As Integer, y As Integer) As Boolean
            If i = word.Length Then
                Return True
            End If

            If _
                x = -1 OrElse
                y = -1 OrElse
                x = board.Length OrElse
                y = board(0).Length OrElse
                board(x)(y) <> word(i) OrElse
                hashSet.Contains((x, y)) Then

                Return False
            End If


            hashSet.Add((x, y))
            Return _
                recurse(board, word, i + 1, hashSet, x + 1, y) OrElse
                recurse(board, word, i + 1, hashSet, x - 1, y) OrElse
                recurse(board, word, i + 1, hashSet, x, y + 1) OrElse
                recurse(board, word, i + 1, hashSet, x, y - 1)
            hashSet.Remove((x, y))

        End Function

    End Class

End Namespace

