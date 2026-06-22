Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class LetterCombinations_Backtracking_VB_17
        Implements ILetterCombinations_17

        Private _twos = New List(Of Char)() From {"a", "b", "c"}
        Private _threes = New List(Of Char)() From {"d", "e", "f"}
        Private _fours = New List(Of Char)() From {"g", "h", "i"}
        Private _fives = New List(Of Char)() From {"j", "k", "l"}
        Private _sixes = New List(Of Char)() From {"m", "n", "o"}
        Private _sevens = New List(Of Char)() From {"p", "q", "r", "s"}
        Private _eights = New List(Of Char)() From {"t", "u", "v"}
        Private _nines = New List(Of Char)() From {"w", "x", "y", "z"}

        Public Function LetterCombinations(digits As String) As IList(Of String) Implements ILetterCombinations_17.LetterCombinations
            Dim result = New List(Of String)()
            If digits.Count = 0 Then
                Return result
            End If
            recurse(digits, 0, New List(Of Char), result)

            Return result
        End Function

        Private Sub recurse(digits As String, i As Integer, currentList As List(Of Char), result As List(Of String))
            If i = digits.Count() Then
                result.Add(New String(currentList.ToArray()))
                Return
            End If

            Dim chars = _twos

            Select Case digits(i)
                Case "2"
                    chars = _twos
                Case "3"
                    chars = _threes
                Case "4"
                    chars = _fours
                Case "5"
                    chars = _fives
                Case "6"
                    chars = _sixes
                Case "7"
                    chars = _sevens
                Case "8"
                    chars = _eights
                Case "9"
                    chars = _nines
                Case Else
                    Throw New NotImplementedException("unsupported character")
            End Select

            For Each c In chars
                currentList.Add(c)
                recurse(digits, i + 1, currentList, result)
                currentList.RemoveAt(currentList.Count - 1)
            Next
        End Sub

    End Class

End Namespace
