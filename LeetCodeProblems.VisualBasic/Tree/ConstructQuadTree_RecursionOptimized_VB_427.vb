Imports LeetCodeProblems.Interfaces
Imports LeetCodeProblems.Interfaces.Medium

Public Class ConstructQuadTree_RecursionOptimized_VB_427
    Implements IConstructQuadTree_427

    Private _trueNode As New QuadNode(True, True)
    Private _falseNode As New QuadNode(False, True)

    Public Function Construct(grid As Integer()()) As QuadNode Implements IConstructQuadTree_427.Construct
        Return Recurse(grid, grid.Length, 0, 0)
    End Function


    Public Function Recurse(grid As Integer()(), regionSize As Integer, rowStart As Integer, colStart As Integer) As QuadNode
        If regionSize = 1 Then
            If grid(rowStart)(colStart) = 1 Then
                Return _trueNode
            Else
                Return _falseNode
            End If
        End If

        Dim half = regionSize \ 2
        Dim returnable As New QuadNode()
        With returnable

            .topLeft = Recurse(grid, half, rowStart, colStart)
            .topRight = Recurse(grid, half, rowStart, colStart + half)
            .bottomLeft = Recurse(grid, half, rowStart + half, colStart)
            .bottomRight = Recurse(grid, half, rowStart + half, colStart + half)


            If _
                .topLeft.isLeaf AndAlso .topRight.isLeaf AndAlso
                .bottomLeft.isLeaf AndAlso .bottomRight.isLeaf AndAlso
                .topLeft.val = .topRight.val AndAlso
                .topLeft.val = .bottomLeft.val AndAlso
                .bottomLeft.val = .bottomRight.val Then

                Return .topLeft

            End If
        End With
        returnable.isLeaf = False

        Return returnable
    End Function


End Class

