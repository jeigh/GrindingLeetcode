Imports LeetCodeProblems.Interfaces.Easy

Namespace Backtracking
    Public Class SubsetXorSum_Recursive_VB_1863
        Implements ISubsetXORSum_1863

        Public Function SubsetXORSum(nums() As Integer) As Integer Implements ISubsetXORSum_1863.SubsetXORSum
            Return SubsetXORSum(nums, 0, 0)
        End Function

        Public Function SubsetXORSum(nums() As Integer, i As Integer, runningTotal As Integer) As Integer
            If i >= nums.Length Then Return runningTotal

            Dim withCurrent = SubsetXORSum(nums, i + 1, runningTotal Xor nums(i))
            Dim withoutCurrent = SubsetXORSum(nums, i + 1, runningTotal)
            Return withCurrent + withoutCurrent
        End Function
    End Class

End Namespace

