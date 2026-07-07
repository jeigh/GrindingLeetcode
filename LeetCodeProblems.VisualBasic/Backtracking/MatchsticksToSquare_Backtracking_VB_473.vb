Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class MatchsticksToSquare_Backtracking_VB_473
        Implements IMatchsticksToSquare_473

        ' time complexity: O(4^n)
        ' space complexity: O(n)
        Public Function Makesquare(matchsticks As Integer()) As Boolean Implements IMatchsticksToSquare_473.Makesquare
            Dim sides As Integer() = New Integer(3) {}
            Dim sum = matchsticks.Sum()
            If sum Mod 4 <> 0 Then Return False
            Dim sideLength = sum / 4

            Return recurse(matchsticks, sideLength, sides, 0)

        End Function

        Private Function recurse(matchsticks() As Integer, sideLength As Double, sides() As Integer, matchIndex As Integer) As Boolean
            If matchIndex = matchsticks.Length Then
                Return sides(0) = sides(1) AndAlso sides(1) = sides(2) AndAlso sides(2) = sides(3)
            End If

            For j = 0 To 3
                sides(j) += matchsticks(matchIndex)
                If sides(j) <= sideLength AndAlso recurse(matchsticks, sideLength, sides, matchIndex + 1) Then Return True
                sides(j) -= matchsticks(matchIndex)
            Next

            Return False
        End Function
    End Class

End Namespace
