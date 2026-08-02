Imports LeetCodeProblems.Interfaces.Medium

Namespace HashingOrArrays
    Public Class CourseSchedule_DFS_VB_207
        Implements ICourseSchedule_207


        Public Function CanFinish(numCourses As Integer, prerequisites As Integer()()) As Boolean Implements ICourseSchedule_207.CanFinish
            Dim visited = New List(Of Integer)()
            Dim visiting = New List(Of Integer)()
            Dim adjacencies = New List(Of List(Of Integer))()

            For i = 0 To numCourses - 1
                Dim newList = New List(Of Integer)()
                adjacencies.Add(newList)
            Next

            For Each item In prerequisites
                Dim depender = item(0)
                Dim dependee = item(1)

                adjacencies(depender).Add(dependee)
            Next

            For i = 0 To numCourses
                If Not recurse(visited, visiting, adjacencies, course:=i) Then Return False
            Next

            Return True
        End Function

        Private Function recurse(visited As List(Of Integer), visiting As List(Of Integer), adjacencies As List(Of List(Of Integer)), course As Integer) As Boolean

            If visiting.Contains(course) Then Return False
            If visited.Contains(course) Then Return True

            visiting.Add(course)
            For Each item In adjacencies(course)
                If Not recurse(visited, visiting, adjacencies, item) Then Return False
            Next

            visiting.Remove(course)
            visited.Add(course)

            Return True
        End Function
    End Class
End Namespace
