Imports LeetCodeProblems.Interfaces.Easy

Namespace Graph
    Public Class VerifyingAnAlienDictionary_VB_953
        Implements IVerifyingAnAlienDictionary_953

        Public Function IsAlienSorted(words As String(), order As String) As Boolean Implements IVerifyingAnAlienDictionary_953.IsAlienSorted
            Dim hashMap = CreateIndexHashmap(order)

            Dim previousWord = String.Empty

            For Each word In words
                If Not previousWord = String.Empty AndAlso Not isFirstBeforeLast(previousWord, word, hashMap) Then Return False
                previousWord = word
            Next
            Return True
        End Function


        Public Function isFirstBeforeLast(first As String, last As String, dictionary As Dictionary(Of Char, Integer)) As Boolean
            Dim index = 0

            While (True)
                If index = first.Length Then Return True
                If index = last.Length Then Return False
                If dictionary(first(index)) > dictionary(last(index)) Then Return False
                If dictionary(last(index)) > dictionary(first(index)) Then Return True
                index += 1
            End While

            Return True
        End Function





        Public Function CreateIndexHashmap(order As String) As Dictionary(Of Char, Integer)
            Dim returnable As New Dictionary(Of Char, Integer)()

            For i = 0 To order.Length - 1
                returnable(order(i)) = i
            Next

            Return returnable
        End Function


    End Class
End Namespace
