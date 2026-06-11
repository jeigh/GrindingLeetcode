Imports System.Text
Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class GenerateParentheses_Backtracking_VB_22
        Implements IGenerateParentheses_22

        Public Function GenerateParenthesis(n As Integer) As IList(Of String) Implements IGenerateParentheses_22.GenerateParenthesis

            Dim current As New StringBuilder()
            Dim result As New List(Of String)()

            recurse(n, 0, 0, current, result)

            Return result
        End Function

        Private Sub recurse(n As Integer, usedOpen As Integer, usedClosed As Integer, current As StringBuilder, result As List(Of String))
            If usedOpen = n AndAlso usedClosed = n Then
                result.Add(current.ToString())
                Return
            End If

            If usedOpen < n Then
                Dim len = current.Length
                current.Append("(")
                recurse(n, usedOpen + 1, usedClosed, current, result)
                current.Length = len
            End If

            If usedClosed < usedOpen Then
                Dim len = current.Length
                current.Append(")")
                recurse(n, usedOpen, usedClosed + 1, current, result)
                current.Length = len

            End If


        End Sub
    End Class

End Namespace

