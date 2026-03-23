Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Subsets_VB_ForLoop_78
        Implements ISubsets_78

        Public Function Subsets(nums() As Integer) As IList(Of IList(Of Integer)) Implements ISubsets_78.Subsets
            Dim response = New List(Of IList(Of Integer))()
            response.Add(New List(Of Integer)())
            For Each num In nums
                Dim originalResponseCount = response.Count
                For i = 0 To originalResponseCount - 1
                    Dim clone = response(i).ToList()
                    clone.Add(num)
                    response.Add(clone.ToList())
                Next
            Next
            Return response
        End Function
    End Class

End Namespace

