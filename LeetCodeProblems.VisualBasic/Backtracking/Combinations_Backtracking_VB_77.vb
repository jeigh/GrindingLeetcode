Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Combinations_Backtracking_VB_77
        Implements ICombinations_77

        Public Function Combine(n As Integer, k As Integer) As IList(Of IList(Of Integer)) Implements ICombinations_77.Combine
            Dim result = New List(Of IList(Of Integer))()

            backtrack(n, k, 1, New List(Of Integer), result)

            Return result
        End Function

        Private Sub backtrack(n As Integer, k As Integer, currentValue As Integer, currentList As List(Of Integer), result As IList(Of IList(Of Integer)))
            If currentList.Count = k Then
                result.Add(currentList.ToList())
                Return
            End If

            If currentValue > n Then Return

            currentList.Add(currentValue)
            backtrack(n, k, currentValue + 1, currentList, result)
            currentList.RemoveAt(currentList.Count - 1)

            backtrack(n, k, currentValue + 1, currentList, result)
        End Sub
    End Class

End Namespace

