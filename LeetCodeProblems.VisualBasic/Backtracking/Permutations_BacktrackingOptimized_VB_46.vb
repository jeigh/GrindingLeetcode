Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Permutations_BacktrackingOptimized_VB_46
        Implements IPermutations_46

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutations_46.Permute
            Dim result As New List(Of IList(Of Integer))
            Dim pick(nums.Length) As Boolean

            BackTrack(New List(Of Integer)(), nums, pick, result)

            Return result
        End Function

        Public Sub BackTrack(currentList As List(Of Integer), nums() As Integer, pick() As Boolean, result As List(Of IList(Of Integer)))
            If (currentList.Count = nums.Length) Then
                result.Add(currentList.ToList())
                Return
            End If

            For i = 0 To nums.Length - 1
                If (Not pick(i)) Then
                    currentList.Add(nums(i))
                    pick(i) = True
                    BackTrack(currentList, nums, pick, result)
                    pick(i) = False
                    currentList.RemoveAt(currentList.Count - 1)
                End If
            Next

        End Sub


    End Class

End Namespace
