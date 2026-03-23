Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Subsets_VB_Iterative_78
        Implements ISubsets_78

        Public Function Subsets(nums() As Integer) As IList(Of IList(Of Integer)) Implements ISubsets_78.Subsets
            Dim stack As New Stack(Of (i As Integer, currentSubset As List(Of Integer)))
            Dim result As New List(Of IList(Of Integer))()
            stack.Push((0, New List(Of Integer)))

            While (stack.Count > 0)
                Dim popped = stack.Pop()

                If popped.i >= nums.Length Then
                    result.Add(popped.currentSubset)
                    Continue While
                End If


                stack.Push((popped.i + 1, popped.currentSubset))

                Dim withItem As New List(Of Integer)(popped.currentSubset)
                withItem.Add(nums(popped.i))

                stack.Push((popped.i + 1, withItem))
            End While

            Return result
        End Function
    End Class

End Namespace

