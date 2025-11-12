Imports LeetCodeProblems.Interfaces.Medium

Namespace SlidingWindow

    Public Class LongestSubstringWithoutRepeatingCharactersVB_3
        Implements ILongestSubstringWithoutRepeatingCharacters_3

        Public Function LengthOfLongestSubstring(s As String) As Integer Implements ILongestSubstringWithoutRepeatingCharacters_3.LengthOfLongestSubstring
            Dim hashSet As New HashSet(Of Char)
            Dim retval = 0
            Dim left = 0



            For i = 0 To s.Length - 1
                While hashSet.Contains(s(i))
                    hashSet.Remove(s(left))
                    left = left + 1
                End While

                hashSet.Add(s(i))
                retval = Math.Max(retval, hashSet.Count)
            Next

            Return retval
        End Function
    End Class



End Namespace

