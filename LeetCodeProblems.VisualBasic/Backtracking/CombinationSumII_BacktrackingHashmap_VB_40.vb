Imports System.Threading
Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSumII_BacktrackingHashmap_VB_40
        Implements ICombinationSumII_40

        Public Function CombinationSum2(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSumII_40.CombinationSum2
            Array.Sort(candidates)
            Dim result = New List(Of IList(Of Integer))()
            Dim counts As New Dictionary(Of Integer, Integer)()
            Dim unique = New List(Of Integer)

            For Each candidate In candidates
                If counts.ContainsKey(candidate) Then
                    counts(candidate) += 1
                Else
                    counts(candidate) = 1
                    unique.Add(candidate)
                End If
            Next

            recurse(target, 0, New List(Of Integer)(), counts, result, unique)
            Return result
        End Function

        Private Sub recurse(target As Integer,
                            i As Integer,
                            currentList As List(Of Integer),
                            counts As Dictionary(Of Integer, Integer),
                            result As List(Of IList(Of Integer)),
                            unique As List(Of Integer))

            If target = 0 Then
                result.Add(currentList.ToList())
                Return
            End If

            If 0 > target OrElse i >= unique.Count Then Return

            Dim currentValue = unique(i)
            If counts(currentValue) > 0 Then
                currentList.Add(currentValue)
                counts(currentValue) -= 1
                target -= currentValue

                recurse(target, i, currentList, counts, result, unique)

                target += currentValue
                counts(currentValue) += 1
                currentList.RemoveAt(currentList.Count - 1)
            End If

            recurse(target, i + 1, currentList, counts, result, unique)
        End Sub
    End Class

End Namespace

