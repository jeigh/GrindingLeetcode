Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Namespace HashingOrArrays
    Public Class CloneGraph_VB_133
        Implements ICloneGraph_133

        ' time complexity: O(n + e) where n = nodes, e = edges
        ' space complexity: O(n)
        Public Function CloneGraph(node As GraphNode) As GraphNode Implements ICloneGraph_133.CloneGraph
            Dim hashMap As New Dictionary(Of GraphNode, GraphNode)()

            Return Recurse(node, hashMap)
        End Function


        Private Function Recurse(node As GraphNode, hashMap As Dictionary(Of GraphNode, GraphNode)) As GraphNode
            If node Is Nothing Then Return Nothing

            Dim clonedNode As New GraphNode()
            If Not hashMap.TryGetValue(node, clonedNode) Then
                clonedNode = New GraphNode()
                clonedNode.val = node.val
                hashMap.Add(node, clonedNode)

                For Each neighbor In node.neighbors
                    Dim addable = Recurse(neighbor, hashMap)
                    clonedNode.neighbors.Add(addable)
                Next
            End If

            Return clonedNode
        End Function




    End Class
End Namespace
