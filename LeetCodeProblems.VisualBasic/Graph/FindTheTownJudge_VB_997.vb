Imports LeetCodeProblems.Interfaces.Easy

Namespace Graph
    Public Class FindTheTownJudge_VB_997
        Implements IFindTheTownJudge_997

        ' this one is more terse than the C# one

        Public Function FindJudge(n As Integer, trust As Integer()()) As Integer Implements IFindTheTownJudge_997.FindJudge
            Dim given(n) As Integer
            Dim received(n) As Integer

            For Each pair In trust
                given(pair(0)) += 1
                received(pair(1)) += 1
            Next

            For i = 1 To n
                If given(i) = 0 AndAlso received(i) = n - 1 Then Return i
            Next

            Return -1
        End Function

    End Class
End Namespace
