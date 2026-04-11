Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Permutations_LinqQuery_VB_46
        Implements IPermutations_46

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutations_46.Permute
            Dim returnable As New List(Of IList(Of Integer))()
            returnable.Add(New List(Of Integer)())

            For Each num In nums
                returnable = (From currentList In returnable
                              From i In Enumerable.Range(0, currentList.Count + 1)
                              Let copy = currentList.ToList()
                              Select InsertAndReturn(copy, i, num)).ToList()
            Next

            Return returnable
        End Function

        Private Function InsertAndReturn(list As List(Of Integer), index As Integer, value As Integer) As IList(Of Integer)
            list.Insert(index, value)
            Return list
        End Function

    End Class

End Namespace
