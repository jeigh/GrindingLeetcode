Imports System.Runtime.Intrinsics.X86
Imports LeetCodeProblems.Interfaces.Medium

Public Class CarFleetVB_853
    Implements ICarFleet_853

    Public Class car
        Public position As Integer
        Public speed As Integer
    End Class


    Public Function CarFleet(target As Integer, position() As Integer, speed() As Integer) As Integer Implements ICarFleet_853.CarFleet
        Dim myCars = New List(Of car)()

        For i = 0 To position.Length - 1
            myCars.Add(New car() With {.position = position(i), .speed = speed(i)})
        Next

        myCars = myCars.OrderByDescending(Function(c) c.position).ToList()

        Dim myStack = New Stack(Of Double)()

        For Each car In myCars
            Dim timeToTarget As Double = (target - car.position) / car.speed

            If myStack.Count > 0 Then
                If myStack.Peek() < timeToTarget Then
                    myStack.Push(timeToTarget)
                End If
            Else
                myStack.Push(timeToTarget)
            End If
        Next

        Return myStack.Count
    End Function
End Class

