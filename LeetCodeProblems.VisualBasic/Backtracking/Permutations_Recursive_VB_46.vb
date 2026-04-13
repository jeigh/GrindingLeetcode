Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Permutations_Recursive_VB_46
        Implements IPermutations_46

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutations_46.Permute
            Dim outerResults As New List(Of IList(Of Integer))()

            If (nums.Length = 0) Then
                outerResults.Add(New List(Of Integer)())
                Return outerResults
            End If

            Dim currentValue = nums(0)
            Dim innerResult = Permute(nums.Skip(1).ToArray())

            InsertAndAppend(currentValue, innerResult, outerResults)
            Return outerResults
        End Function

        Private Sub InsertAndAppend(currentValue As Integer, sourceCollection As IList(Of IList(Of Integer)), targetCollection As List(Of IList(Of Integer)))
            For Each innerResultItem In sourceCollection
                For i = 0 To innerResultItem.Count
                    Dim copied = innerResultItem.ToList()
                    copied.Insert(i, currentValue)
                    targetCollection.Add(copied)
                Next
            Next
        End Sub
    End Class

End Namespace
