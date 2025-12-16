Imports LeetCodeProblems.Interfaces.Easy
Imports LeetCodeProblems.Shared

Public Class BinaryTreeInOrderTraversal_Recursive_VB_94
    Implements IBinaryTreeInorderTraversal_94

    Public Function InorderTraversal(root As TreeNode) As IList(Of Integer) Implements IBinaryTreeInorderTraversal_94.InorderTraversal
        If root Is Nothing Then Return New List(Of Integer)()

        Dim returnable As List(Of Integer) = InorderTraversal(root.left)
        returnable.Add(root.val)
        returnable.AddRange(InorderTraversal(root.right))

        Return returnable
    End Function
End Class

