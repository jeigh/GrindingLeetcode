Imports System.ComponentModel.DataAnnotations
Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Permutations_BacktrackingOptimized_VB_46
        Implements IPermutations_46

        Private _result As List(Of IList(Of Integer))
        Private _currentList As List(Of Integer)

        Public Function Permute(nums As Integer()) As IList(Of IList(Of Integer)) Implements IPermutations_46.Permute
            _result = New List(Of IList(Of Integer))
            _currentList = New List(Of Integer)()
            Dim pick(nums.Length - 1) As Boolean

            recurse(nums, pick)

            Return _result
        End Function

        Public Sub recurse(nums As Integer(), ByRef pick As Boolean())
            If _currentList.Count() = nums.Length Then
                _result.Add(_currentList.ToList())
                Return
            End If

            For i As Integer = 0 To nums.Length - 1 Step 1
                If Not pick(i) Then
                    pick(i) = True
                    _currentList.Add(nums(i))
                    recurse(nums, pick)
                    _currentList.RemoveAt(_currentList.Count - 1)
                    pick(i) = False
                End If
            Next
        End Sub



    End Class

End Namespace
