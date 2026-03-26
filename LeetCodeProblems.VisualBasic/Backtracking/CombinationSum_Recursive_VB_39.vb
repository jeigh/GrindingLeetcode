Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class CombinationSum_Recursive_VB_39
        Implements ICombinationSum_39

        Public Function CombinationSum(candidates() As Integer, target As Integer) As IList(Of IList(Of Integer)) Implements ICombinationSum_39.CombinationSum
            Dim response As New List(Of IList(Of Integer))()
            Dim currentList = New List(Of Integer)()

            CombinationSum(candidates, 0, currentList, 0, target, response)

            Return response
        End Function

        Public Sub CombinationSum(
            candidates() As Integer,
            leftPointer As Integer,
            currentList As List(Of Integer),
            currentListSum As Integer,
            target As Integer,
            response As IList(Of IList(Of Integer)))

            If (currentListSum = target) Then
                response.Add(currentList.ToList())
                Return
            End If

            If (leftPointer >= candidates.Length OrElse currentListSum > target) Then
                Return
            End If

            currentList.Add(candidates(leftPointer))
            currentListSum += candidates(leftPointer)
            CombinationSum(candidates, leftPointer, currentList, currentListSum, target, response)

            currentList.RemoveAt(currentList.Count - 1)
            currentListSum -= candidates(leftPointer)
            CombinationSum(candidates, leftPointer + 1, currentList, currentListSum, target, response)
        End Sub
    End Class

End Namespace

