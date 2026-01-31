Imports LeetCodeProblems.Interfaces
Imports LeetCodeProblems.Interfaces.Medium

Public Class ConstructQuadTree_Recursion_VB_427
    Implements IConstructQuadTree_427

    Public Function Construct(grid As Integer()()) As QuadNode Implements IConstructQuadTree_427.Construct
        Return Recurse(New RecursionParams(grid, grid.Length, 0, 0))
    End Function

    Public Function Recurse(params As RecursionParams) As QuadNode
        Dim returnable = New QuadNode()

        If IsRegionUniform(params) Then
            returnable.isLeaf = True
            returnable.val = params.grid(params.rowStart)(params.colStart)
            Return returnable
        End If

        Dim half = params.regionSize \ 2

        returnable.topLeft = Recurse(New RecursionParams(params.grid, half, params.rowStart, params.colStart))
        returnable.topRight = Recurse(New RecursionParams(params.grid, half, params.rowStart, params.colStart + half))
        returnable.bottomLeft = Recurse(New RecursionParams(params.grid, half, params.rowStart + half, params.colStart))
        returnable.bottomRight = Recurse(New RecursionParams(params.grid, half, params.rowStart + half, params.colStart + half))

        returnable.isLeaf = False

        Return returnable
    End Function

    Private Function IsRegionUniform(params As RecursionParams) As Boolean
        Dim firstVal = params.grid(params.rowStart)(params.colStart)
        For i = 0 To params.regionSize - 1
            For j = 0 To params.regionSize - 1
                If firstVal <> params.grid(params.rowStart + i)(params.colStart + j) Then Return False
            Next
        Next
        Return True
    End Function

    Public Class RecursionParams
        Public grid As Integer()()
        Public regionSize As Integer
        Public rowStart As Integer
        Public colStart As Integer

        Public Sub New(grid As Integer()(), regionSize As Integer, rowStart As Integer, colStart As Integer)
            Me.grid = grid
            Me.regionSize = regionSize
            Me.rowStart = rowStart
            Me.colStart = colStart
        End Sub
    End Class
End Class

