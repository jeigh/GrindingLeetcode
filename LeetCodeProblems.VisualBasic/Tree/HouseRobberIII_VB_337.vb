Imports LeetCodeProblems.Interfaces.Medium
Imports LeetCodeProblems.Shared

Public Class HouseRobberIII_VB_337
    Implements IHouseRobberIII_337

    Public Function Rob(root As TreeNode) As Integer Implements IHouseRobberIII_337.Rob
        Dim results = RobSubTree(root)

        Return Math.Max(results.withRoot, results.withoutRoot)
    End Function

    Public Function RobSubTree(node As TreeNode) As (withRoot As Integer, withoutRoot As Integer)
        If node Is Nothing Then Return (0, 0)

        Dim left = RobSubTree(node.left)
        Dim right = RobSubTree(node.right)

        Dim withoutNode As Integer = Math.Max(left.withRoot, left.withoutRoot) + Math.Max(right.withRoot, right.withoutRoot)

        Dim withNode As Integer = node.val + left.withoutRoot + right.withoutRoot

        Return (withNode, withoutNode)
    End Function

End Class

