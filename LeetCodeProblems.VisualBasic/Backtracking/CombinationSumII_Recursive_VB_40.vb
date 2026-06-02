Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSumII_Recursive_VB_40
        Implements ICombinationSumII_40

        Public Function CombinationSum2(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSumII_40.CombinationSum2
            Dim result = New List(Of IList(Of Integer))()
            Array.Sort(candidates)

            recurse(candidates, target, 0, New List(Of Integer), result)

            Return result
        End Function

        Public Sub recurse(candidates() As Integer, target As Integer, i As Integer, currentList As List(Of Integer), result As List(Of IList(Of Integer)))
            If currentList.Sum() = target Then
                result.Add(currentList.ToList())
                Return
            End If
            If i = candidates.Length OrElse currentList.Sum() > target Then Return

            currentList.Add(candidates(i))
            recurse(candidates, target, i + 1, currentList, result)
            currentList.RemoveAt(currentList.Count() - 1)

            While i + 1 < candidates.Length AndAlso candidates(i) = candidates(i + 1)
                i += 1
            End While

            recurse(candidates, target, i + 1, currentList, result)
        End Sub



    End Class

End Namespace

