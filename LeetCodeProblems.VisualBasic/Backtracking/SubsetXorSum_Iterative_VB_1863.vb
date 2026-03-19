Imports LeetCodeProblems.Interfaces.Easy

Namespace Backtracking
    Public Class SubsetXorSum_Iterative_VB_1863
        Implements ISubsetXORSum_1863

        Public Function SubsetXORSum(nums() As Integer) As Integer Implements ISubsetXORSum_1863.SubsetXORSum
            Dim stack = New Stack(Of (i As Integer, total As Integer))()
            stack.Push((0, 0))
            Dim ret = 0

            While (stack.Count > 0)
                Dim popped = stack.Pop()

                If (popped.i >= nums.Length) Then
                    ret += popped.total
                    Continue While
                End If

                stack.Push((popped.i + 1, popped.total))
                stack.Push((popped.i + 1, popped.total Xor nums(popped.i)))
            End While

            Return ret
        End Function
    End Class

End Namespace

