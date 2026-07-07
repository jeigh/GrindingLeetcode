Imports LeetCodeProblems.Interfaces.Medium

Namespace Backtracking
    Public Class MatchsticksToSquare_BacktrackingIII_VB_473
        Implements IMatchsticksToSquare_473

        Public Function Makesquare(matchsticks() As Integer) As Boolean Implements IMatchsticksToSquare_473.Makesquare
            Dim sides(4) As Integer

            Dim sum = matchsticks.Sum()
            If sum Mod 4 <> 0 Then Return False
            Dim sideLength = sum / 4

            Return Recurse(matchsticks, sideLength, sides, 0, 0)
        End Function

        Private Function Recurse(matchsticks() As Integer, sideLength As Double, sides() As Integer, matchIndex As Integer, sideIndex As Integer) As Boolean
            If matchIndex = matchsticks.Length Then Return sides(0) = sides(1) AndAlso sides(1) = sides(2) AndAlso sides(2) = sides(3)
            If sideIndex = 4 Then Return False

            sides(sideIndex) += matchsticks(matchIndex)
            If sides(sideIndex) <= sideLength AndAlso Recurse(matchsticks, sideLength, sides, matchIndex + 1, 0) Then Return True
            sides(sideIndex) -= matchsticks(matchIndex)

            Return Recurse(matchsticks, sideLength, sides, matchIndex, sideIndex + 1)
        End Function
    End Class

End Namespace
