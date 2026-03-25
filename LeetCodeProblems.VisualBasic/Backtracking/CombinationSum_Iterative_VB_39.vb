Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSum_Iterative_VB_39
        Implements ICombinationSum_39

        Public Function CombinationSum(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSum_39.CombinationSum
            Dim result As New List(Of IList(Of Integer))()
            Dim stack = New Stack(Of (Integer, List(Of Integer), Integer))()
            stack.Push((0, New List(Of Integer), 0))

            While stack.Count > 0
                Dim sf As (i As Integer, currentList As List(Of Integer), currentListSum As Integer) = stack.Pop()

                If (sf.i >= candidates.Length OrElse sf.currentListSum > target) Then Continue While
                If (sf.currentListSum = target) Then
                    result.Add(sf.currentList.ToList())
                    Continue While
                End If

                sf.currentListSum += candidates(sf.i)
                sf.currentList.Add(candidates(sf.i))
                stack.Push((sf.i, sf.currentList.ToList(), sf.currentListSum))

                sf.currentListSum -= candidates(sf.i)
                sf.currentList.RemoveAt(sf.currentList.Count - 1)
                stack.Push((sf.i + 1, sf.currentList.ToList(), sf.currentListSum))
            End While

            Return result
        End Function
    End Class

End Namespace

