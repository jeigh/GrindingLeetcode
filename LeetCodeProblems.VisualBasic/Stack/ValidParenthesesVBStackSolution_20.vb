Imports System.Security.Cryptography.X509Certificates
Imports LeetCodeProblems.Interfaces.Easy

Public Class ValidParenthesesVBStackSolution_20
    Implements IValidParentheses_20

    Public Function IsValid(s As String) As Boolean Implements IValidParentheses_20.IsValid

        Dim theStack = New Stack(Of Char)()

        For Each c In s.ToCharArray()
            Dim peeked As Char
            If theStack.TryPeek(peeked) Then
                Select Case c
                    Case "}"
                        If peeked <> "{" Then Return False
                        theStack.Pop()
                    Case "]"
                        If peeked <> "[" Then Return False
                        theStack.Pop()
                    Case ")"
                        If peeked <> "(" Then Return False
                        theStack.Pop()
                    Case Else
                        theStack.Push(c)
                End Select
            Else
                theStack.Push(c)
            End If

        Next
        If theStack.Count = 0 Then Return True
        Return False
    End Function


End Class
