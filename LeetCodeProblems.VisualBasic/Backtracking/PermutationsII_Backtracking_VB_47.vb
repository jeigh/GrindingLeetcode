Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class PermutationsII_Backtracking_VB_47
        Implements IPermutationsII_47

        Private _result As New List(Of IList(Of Integer))
        Private _currentList As New List(Of Integer)

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutationsII_47.Permute
            Dim pick(nums.Length - 1) As Boolean

            Array.Sort(nums)
            Recurse(nums, pick, New Text.StringBuilder())

            Return _result
        End Function

        Private Sub Recurse(nums As Integer(), ByRef pick As Boolean(), stringKey As System.Text.StringBuilder)

            If _currentList.Count = nums.Length Then
                _result.Add(_currentList.ToList())
                Return
            End If

            For i = 0 To nums.Length - 1
                If i > 0 AndAlso nums(i) = nums(i - 1) AndAlso Not pick(i - 1) Then Continue For
                If pick(i) Then Continue For

                _currentList.Add(nums(i))
                pick(i) = True
                Recurse(nums, pick, stringKey)
                _currentList.RemoveAt(_currentList.Count - 1)
                pick(i) = False
            Next
        End Sub

    End Class
End Namespace
