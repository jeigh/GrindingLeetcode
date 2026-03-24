Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Subsets_VB_Recursive_78
        Implements ISubsets_78

        Public Function Subsets(nums() As Integer) As IList(Of IList(Of Integer)) Implements ISubsets_78.Subsets
            Dim result = New List(Of IList(Of Integer))()
            Dim currentSubset = New List(Of Integer)()
            recurse(nums, 0, result, currentSubset)

            Return result
        End Function

        Public Sub recurse(nums() As Integer, i As Integer, results As IList(Of IList(Of Integer)), currentSubset As List(Of Integer))
            If i >= nums.Length Then
                results.Add(currentSubset.ToList())
                Return
            End If

            currentSubset.Add(nums(i))
            recurse(nums, i + 1, results, currentSubset)

            currentSubset.RemoveAt(currentSubset.Count - 1)
            recurse(nums, i + 1, results, currentSubset)
        End Sub
    End Class

End Namespace

