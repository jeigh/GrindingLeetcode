Imports LeetCodeProblems.Interfaces.Medium

Namespace Graph
    Public Class CourseScheduleIV_Solution_VB_1462
        Implements ICourseScheduleIV_1462

        Public Function CheckIfPrerequisite(numCourses As Integer, prerequisites As Integer()(), queries As Integer()()) As IList(Of Boolean) Implements ICourseScheduleIV_1462.CheckIfPrerequisite
            Dim transativeDependencies As New List(Of HashSet(Of Integer))
            Dim directDependencies As New List(Of HashSet(Of Integer))()

            For i = 0 To numCourses - 1
                transativeDependencies.Add(New HashSet(Of Integer)())
                directDependencies.Add(New HashSet(Of Integer)())
            Next

            For Each item In prerequisites
                Dim course = item(1)
                Dim prerequisite = item(0)

                directDependencies(course).Add(prerequisite)
            Next

            Dim visited = New List(Of Integer)()
            For i = 0 To numCourses - 1
                HydrateTransitiveDependencies(directDependencies, transativeDependencies, visited, i)
            Next

            Dim result = New List(Of Boolean)()
            For Each item In queries
                result.Add(transativeDependencies(item(1)).Contains(item(0)))
            Next
            Return result
        End Function

        Private Sub HydrateTransitiveDependencies(directDependencies As List(Of HashSet(Of Integer)), transativeDependencies As List(Of HashSet(Of Integer)), visited As List(Of Integer), i As Integer)
            If visited.Contains(i) Then Return
            visited.Add(i)

            transativeDependencies(i).UnionWith(directDependencies(i))
            For Each item In directDependencies(i)

                HydrateTransitiveDependencies(directDependencies, transativeDependencies, visited, item)
                transativeDependencies(i).UnionWith(transativeDependencies(item))
            Next



        End Sub
    End Class
End Namespace
