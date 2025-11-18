Imports LeetCodeProblems.Interfaces.Medium

Public Class DailyTemperaturesVBSolution_739
    Implements IDailyTemperatures_739

    Public Function DailyTemperatures(temperatures() As Integer) As Integer() Implements IDailyTemperatures_739.DailyTemperatures
        Dim result(temperatures.Length - 1) As Integer
        Dim indexStack As New Stack(Of Integer)()

        For currentIndex = 0 To temperatures.Length - 1
            If indexStack.Count = 0 Then
                indexStack.Push(currentIndex)
                Continue For
            End If

            While indexStack.Count > 0 AndAlso temperatures(currentIndex) > temperatures(indexStack.Peek())
                Dim poppedIndex = indexStack.Pop()
                result(poppedIndex) = currentIndex - poppedIndex
            End While

            indexStack.Push(currentIndex)
        Next

        Return result
    End Function
End Class
