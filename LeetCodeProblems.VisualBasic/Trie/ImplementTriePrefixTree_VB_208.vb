Imports System.Security.Cryptography.X509Certificates
Imports LeetCodeProblems.Interfaces.Medium

Namespace Trie
    Public Class ImplementTriePrefixTree_VB_208
        Implements IImplementTriePrefixTree_208

        Public Class TrieNode
            Public Nodes As New Dictionary(Of Char, TrieNode)
        End Class

        Private Const EOW = ControlChars.NullChar
        Private _root = New TrieNode()

        Public Sub Insert(word As String) Implements IImplementTriePrefixTree_208.Insert

            Dim current As TrieNode = _root

            Dim nextNode As New TrieNode
            For Each c As Char In word
                If Not current.Nodes.TryGetValue(c, nextNode) Then
                    nextNode = New TrieNode()
                    current.Nodes.Add(c, nextNode)
                End If
                current = nextNode
            Next

            Dim lastNode As New TrieNode()
            If Not current.Nodes.TryGetValue(EOW, lastNode) Then
                current.Nodes.Add(EOW, lastNode)
            End If
        End Sub

        Public Function Search(word As String) As Boolean Implements IImplementTriePrefixTree_208.Search
            Dim current As TrieNode = _root
            Dim nextNode As New TrieNode()
            For Each c As Char In word
                If Not current.Nodes.TryGetValue(c, nextNode) Then
                    Return False
                End If
                current = nextNode
            Next

            If Not current.Nodes.ContainsKey(EOW) Then Return False
            Return True
        End Function

        Public Function StartsWith(prefix As String) As Boolean Implements IImplementTriePrefixTree_208.StartsWith
            Dim current As TrieNode = _root
            Dim nextNode As New TrieNode()
            For Each c As Char In prefix
                If Not current.Nodes.TryGetValue(c, nextNode) Then
                    Return False
                End If
                current = nextNode
            Next
            Return True
        End Function

    End Class

End Namespace
