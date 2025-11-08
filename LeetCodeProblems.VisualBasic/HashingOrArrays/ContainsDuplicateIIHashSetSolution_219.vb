Imports LeetCodeProblems.Interfaces.Easy

Namespace HashingOrArrays
    Public Class ContainsDuplicateIIHashSetSolution_219
        Implements IContainsDuplicateII_219


        ''' <summary>
        ''' this uses a hashmap like the C# implementation, 
        ''' but instead of treating i as the right boundary, 
        ''' it assumes i is the left boundary and i+k is the right boundary
        ''' </summary>
        ''' <returns></returns>
        Public Function ContainsNearbyDuplicate(nums() As Integer, k As Integer) As Boolean Implements IContainsDuplicateII_219.ContainsNearbyDuplicate
            If (nums.Length = 0 OrElse k = 0) Then Return False

            Dim hashMap As New HashSet(Of Integer)()

            For i = 0 To Math.Min(k - 1, nums.Length - 1)
                If hashMap.Contains(nums(i)) Then Return True

                hashMap.Add(nums(i))
            Next

            For i = 0 To nums.Length - 1 - k

                Dim targetOffset = i + k
                If hashMap.Contains(nums(targetOffset)) Then Return True
                hashMap.Remove(nums(i))
                hashMap.Add(nums(targetOffset))
            Next

            Return False
        End Function
    End Class

End Namespace

