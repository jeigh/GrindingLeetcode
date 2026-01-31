Imports LeetCodeProblems.Interfaces
Imports LeetCodeProblems.Interfaces.Medium

Public Class ConstructQuadTree_Iterative_VB_427
    Implements IConstructQuadTree_427

    Public Function Construct(grid As Integer()()) As QuadNode Implements IConstructQuadTree_427.Construct
        Dim stack = New Stack(Of (node As QuadNode, regionSize As Integer, rowStart As Integer, colStart As Integer))
        Dim returnable = New QuadNode()


        stack.Push((returnable, grid.Length, 0, 0))

        While stack.Count > 0
            Dim popped = stack.Pop()

            If IsUniform(grid, popped.regionSize, popped.rowStart, popped.colStart) Then
                popped.node.isLeaf = True
                popped.node.val = 1 = grid(popped.rowStart)(popped.colStart)
            Else
                Dim half = popped.regionSize \ 2

                popped.node.isLeaf = False
                popped.node.topLeft = New QuadNode()
                popped.node.topRight = New QuadNode()
                popped.node.bottomLeft = New QuadNode()
                popped.node.bottomRight = New QuadNode()

                stack.Push((popped.node.topLeft, half, popped.rowStart, popped.colStart))
                stack.Push((popped.node.topRight, half, popped.rowStart, popped.colStart + half))
                stack.Push((popped.node.bottomLeft, half, popped.rowStart + half, popped.colStart))
                stack.Push((popped.node.bottomRight, half, popped.rowStart + half, popped.colStart + half))
            End If
        End While

        Return returnable
    End Function

    Public Function IsUniform(grid As Integer()(), regionSize As Integer, rowStart As Integer, colStart As Integer) As Boolean
        Dim testVal = grid(rowStart)(colStart)
        For i = 0 To regionSize - 1
            For j = 0 To regionSize - 1
                If testVal <> grid(rowStart + i)(colStart + j) Then Return False
            Next
        Next
        Return True
    End Function
End Class

