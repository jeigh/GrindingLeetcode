Imports LeetCodeProblems.Interfaces.Easy

Namespace Backtracking
    Public Class SubsetXorSum_Recursive_VB_1863
        Implements ISubsetXORSum_1863

        Public Function SubsetXORSum(nums() As Integer) As Integer Implements ISubsetXORSum_1863.SubsetXORSum
            Dim xors As New List(Of Integer)()

            Recurse(nums, 0, 0, xors)

            Return xors.Sum()
        End Function

        Private Sub Recurse(nums() As Integer, i As Integer, xored As Integer, xors As List(Of Integer))
            If (i = nums.Length) Then
                xors.Add(xored)
                Return
            End If

            Recurse(nums, i + 1, xored Xor nums(i), xors)
            Recurse(nums, i + 1, xored, xors)
        End Sub

    End Class

End Namespace

