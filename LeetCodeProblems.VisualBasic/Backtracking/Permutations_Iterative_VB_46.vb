Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Permutations_Iterative_VB_46
        Implements IPermutations_46

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutations_46.Permute
            Dim outerResult As New List(Of IList(Of Integer))()
            outerResult.Add(New List(Of Integer))

            For Each num In nums
                Dim innerResult As New List(Of IList(Of Integer))()
                InsertAndAppend(num, outerResult, innerResult)
                outerResult = innerResult
            Next

            Return outerResult
        End Function

        Private Sub InsertAndAppend(num As Integer, sourceCollection As List(Of IList(Of Integer)), targetCollection As List(Of IList(Of Integer)))
            For Each outerResultItem In sourceCollection
                For i = 0 To outerResultItem.Count
                    Dim copied = outerResultItem.ToList()
                    copied.Insert(i, num)
                    targetCollection.Add(copied)
                Next
            Next
        End Sub
    End Class

End Namespace
