Imports LeetCodeProblems.Interfaces.Medium

Namespace Stack


    Public Class EvaluateReversePolishNotationVB_150
        Implements IEvaluateReversePolishNotationCSharp_150

        Private _stack As New Stack(Of Integer)


        Public Function EvalRPN(tokens() As String) As Integer Implements IEvaluateReversePolishNotationCSharp_150.EvalRPN
            For Each token In tokens
                Select Case token
                    Case "+"
                        Dim first = _stack.Pop()
                        Dim second = _stack.Pop()
                        Dim pushable = second + first
                        _stack.Push(pushable)
                    Case "-"
                        Dim first = _stack.Pop()
                        Dim second = _stack.Pop()
                        Dim pushable = second - first
                        _stack.Push(pushable)
                    Case "*"
                        Dim first = _stack.Pop()
                        Dim second = _stack.Pop()
                        Dim pushable = second * first
                        _stack.Push(pushable)
                    Case "/"
                        Dim first = _stack.Pop()
                        Dim second = _stack.Pop()
                        Dim pushable As Integer = second \ first  '' this is a quirk in vb that integer division is not the default behavior of /
                        _stack.Push(pushable)
                    Case Else
                        Dim pushable = Integer.Parse(token)
                        _stack.Push(pushable)
                End Select
            Next
            Return _stack.Pop()
        End Function
    End Class

End Namespace
