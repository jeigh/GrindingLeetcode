Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSumII_Recursive_VB_40
        Implements ICombinationSumII_40

        Public Function CombinationSum2(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSumII_40.CombinationSum2
            Dim result = New List(Of IList(Of Integer))()
            Array.Sort(candidates)

            Recurse(candidates, target, 0, New List(Of Integer)(), 0, result)
            Return result
        End Function

        Public Sub Recurse(candidates() As Integer, target As Integer, i As Integer, currentList As IList(Of Integer), currentListSum As Integer, result As IList(Of IList(Of Integer)))

            If (currentListSum = target) Then
                result.Add(currentList.ToList())
                Return
            End If

            If (i >= candidates.Length OrElse currentListSum > target) Then Return

            Dim currentElementValue = candidates(i)

            currentList.Add(currentElementValue)
            currentListSum += currentElementValue
            Recurse(candidates, target, i + 1, currentList, currentListSum, result)

            currentList.RemoveAt(currentList.Count - 1)
            currentListSum -= currentElementValue

            While (i + 1 < candidates.Length AndAlso currentElementValue = candidates(i + 1))
                i += 1
            End While
            Recurse(candidates, target, i + 1, currentList, currentListSum, result)
        End Sub
    End Class

End Namespace

