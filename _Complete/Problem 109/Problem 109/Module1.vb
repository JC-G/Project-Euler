Module Module1

    Sub Main()
        Dim scoreList As List(Of Integer) = New List(Of Integer)
        Dim finList As List(Of Integer) = New List(Of Integer)
        scoreList.Add(0)
        For x As Integer = 1 To 20
            scoreList.Add(x)
            scoreList.Add(2 * x)
            scoreList.Add(3 * x)
            finList.Add(2 * x)
        Next
        scoreList.Add(25)
        scoreList.Add(50)
        finList.Add(50)

        Dim total As Integer = 0

        For d1 As Integer = 0 To scoreList.Count - 1
            For d2 As Integer = d1 To scoreList.Count - 1
                For d3 As Integer = 0 To finList.Count - 1
                    Dim thisScore As Integer = scoreList(d1) + scoreList(d2) + finList(d3)
                    If thisScore < 100 Then
                        total += 1
                    End If
                Next
            Next
        Next
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub

End Module
