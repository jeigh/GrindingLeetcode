Imports LeetCodeProblems.Interfaces.Medium

Namespace SlidingWindow
    Public Class PermutationInStringSlidingWindowVB_567
        Implements IPermutationInString_567



        Public Function CheckInclusion(s1 As String, s2 As String) As Boolean Implements IPermutationInString_567.CheckInclusion
            If s2.Length < s1.Length Then Return False

            Dim s1Count As New Dictionary(Of Integer, Integer)()
            Dim s2Count As New Dictionary(Of Integer, Integer)()

            InitCounts(s1Count, s2Count)

            For i = 0 To s1.Length - 1
                SetCounts(s1, s1Count, i)
                SetCounts(s2, s2Count, i)
            Next

            Dim matches = InitMatches(s1Count, s2Count)

            Dim l = 0
            For r = s1.Length To s2.Length - 1
                If 26 = matches Then Return True

                AddRightChar(s1Count, s2Count, matches, s2, s2(r))
                RemoveLeftChar(s1Count, s2Count, matches, s2, s2(l))

                l += 1
            Next

            If 26 = matches Then Return True
            Return False
        End Function

        Private Shared Sub InitCounts(ByRef s1Count As Dictionary(Of Integer, Integer), ByRef s2Count As Dictionary(Of Integer, Integer))
            For i As Integer = 0 To 25
                s1Count(i) = 0
                s2Count(i) = 0
            Next
        End Sub

        Private Sub RemoveLeftChar(
            s1Count As Dictionary(Of Integer, Integer),
            s2Count As Dictionary(Of Integer, Integer),
            ByRef matches As Integer,
            s As String,
            removable As Char)

            Dim encoded = EncodeChar(removable)

            s2Count(encoded) -= 1

            Dim stringsAreNowEqual As Boolean = s2Count(encoded) = s1Count(encoded)
            Dim removedCharCausedStringsToBeUnequal As Boolean = s1Count(encoded) = s2Count(encoded) + 1

            If stringsAreNowEqual Then
                matches += 1
            ElseIf removedCharCausedStringsToBeUnequal Then
                matches -= 1
            End If
        End Sub

        Private Sub AddRightChar(
            s1Count As Dictionary(Of Integer, Integer),
            s2Count As Dictionary(Of Integer, Integer),
            ByRef matches As Integer,
            s As String,
            addable As Char)

            Dim encoded = EncodeChar(addable)

            s2Count(encoded) += 1

            Dim stringsAreNowIdentical As Boolean = s2Count(encoded) = s1Count(encoded)
            Dim addedCharCausedStringsToBeUnequal As Boolean = s1Count(encoded) = s2Count(encoded) - 1

            If stringsAreNowIdentical Then
                matches += 1
            ElseIf addedCharCausedStringsToBeUnequal Then
                matches -= 1
            End If
        End Sub

        Private Function InitMatches(s1Count As Dictionary(Of Integer, Integer), s2Count As Dictionary(Of Integer, Integer)) As Integer
            Dim matches = 0

            For i = 0 To 25
                If s1Count(i) = s2Count(i) Then matches += 1
            Next

            Return matches
        End Function

        Private Sub SetCounts(paramStr As String, hashSet As Dictionary(Of Integer, Integer), charOffset As Integer)
            Dim currentChar = paramStr(charOffset)
            Dim encoded As Integer = EncodeChar(currentChar)
            hashSet(encoded) = hashSet(encoded) + 1
        End Sub

        Private Shared Function EncodeChar(currentChar As Char) As Integer
            Return Asc(currentChar) - Asc("a")
        End Function

    End Class



End Namespace

