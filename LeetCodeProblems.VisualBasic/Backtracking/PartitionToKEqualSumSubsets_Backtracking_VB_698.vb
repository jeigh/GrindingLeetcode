Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class PartitionToKEqualSumSubsets_Backtracking_VB_698
        Implements IPartitionToKEqualSumSubsets_698

        Public Function CanPartitionKSubsets(nums As Integer(), k As Integer) As Boolean Implements IPartitionToKEqualSumSubsets_698.CanPartitionKSubsets
            Dim sum As Integer = nums.Sum()
            If (sum Mod k <> 0) Then Return False
            Dim partitionSize As Integer = sum / k

            Return recurse(nums, partitionSize, k, 0, 0, New Integer(k - 1) {})
        End Function

        Public Function recurse(nums As Integer(), partitionSize As Integer, partitionCount As Integer, partitionIndex As Integer, numsIndex As Integer, partitions As Integer()) As Boolean
            If (numsIndex = nums.Length) Then
                For Each partitionItem In partitions
                    If (partitionItem <> partitionSize) Then Return False
                Next
                Return True
            End If
            If (partitionIndex = partitionCount) Then Return False


            partitions(partitionIndex) += nums(numsIndex)
            If (partitions(partitionIndex) <= partitionSize AndAlso recurse(nums, partitionSize, partitionCount, 0, numsIndex + 1, partitions)) Then Return True
            partitions(partitionIndex) -= nums(numsIndex)

            Return recurse(nums, partitionSize, partitionCount, partitionIndex + 1, numsIndex, partitions)
        End Function

    End Class

End Namespace
