Imports System.Windows.Markup
Imports LeetCodeProblems.Interfaces.Medium

Namespace Stack
    Public Class MinStackVBSolution_155
        Implements IMinStack_155

        Private _minValues As New List(Of Integer)
        Private _values As New List(Of Integer)

        Public Sub Pop() Implements IMinStack_155.Pop
            _values.RemoveAt(_values.Count - 1)
            _minValues.RemoveAt(_minValues.Count - 1)
        End Sub

        Private Function IsEmpty() As Boolean
            Return 0 = _values.Count
        End Function

        Public Sub Push(val As Integer) Implements IMinStack_155.Push
            Dim minValue As Integer
            If Not IsEmpty() Then
                Dim previousMinValue = _minValues(_minValues.Count - 1)
                minValue = Math.Min(previousMinValue, val)
            Else
                minValue = val
            End If


            _values.Add(val)
            _minValues.Add(minValue)
        End Sub

        Public Function GetMin() As Integer Implements IMinStack_155.GetMin
            Return _minValues.Last()
        End Function

        Public Function Top() As Integer Implements IMinStack_155.Top
            If IsEmpty() Then
                Return -1
            End If
            Return _values(_values.Count - 1)
        End Function
    End Class
End Namespace
