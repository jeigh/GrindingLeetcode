Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class Combinations_Iterative_VB_77
        Implements ICombinations_77

        Private Enum stackPhase
            firstVisit
            backtrack
        End Enum

        Public Function Combine(n As Integer, k As Integer) As IList(Of IList(Of Integer)) Implements ICombinations_77.Combine
            Dim result As New List(Of IList(Of Integer))()
            Dim currentList As New List(Of Integer)()
            Dim stack As New Stack(Of (currentValue As Integer, phase As stackPhase))()
            stack.Push((1, stackPhase.firstVisit))

            While stack.Count > 0
                Dim sf = stack.Pop()
                If sf.phase = stackPhase.backtrack Then
                    currentList.RemoveAt(currentList.Count - 1)
                    If sf.currentValue + 1 <= n OrElse currentList.Count = k Then
                        stack.Push((sf.currentValue + 1, stackPhase.firstVisit))
                    End If
                    Continue While
                End If

                If currentList.Count = k Then
                    result.Add(currentList.ToList())
                    Continue While
                End If

                If sf.currentValue > n Then Continue While

                stack.Push((sf.currentValue, stackPhase.backtrack))
                currentList.Add(sf.currentValue)
                stack.Push((sf.currentValue + 1, stackPhase.firstVisit))
            End While

            Return result
        End Function
    End Class

End Namespace

