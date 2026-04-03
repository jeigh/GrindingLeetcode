Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSumII_RecursiveOptimized_VB_40
        Implements ICombinationSumII_40

        Public Function CombinationSum2(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSumII_40.CombinationSum2
            Array.Sort(candidates)
            Dim result As New List(Of IList(Of Integer))()
            backtrack(candidates, target, 0, New List(Of Integer), 0, result)

            Return result
        End Function

        Private Sub backtrack(candidates() As Integer, target As Integer, startPtr As Integer, currentList As List(Of Integer), currentListSum As Integer, result As IList(Of IList(Of Integer)))
            If (currentListSum = target) Then
                result.Add(currentList.ToList())
                Return
            End If

            For index = startPtr To candidates.Length - 1
                If (index > startPtr AndAlso candidates(index) = candidates(index - 1)) Then Continue For
                Dim currentValue = candidates(index)
                If (currentListSum + currentValue > target) Then Exit For

                currentList.Add(currentValue)
                backtrack(candidates, target, index + 1, currentList, currentListSum + currentValue, result)
                currentList.RemoveAt(currentList.Count - 1)
            Next
        End Sub
    End Class

End Namespace

