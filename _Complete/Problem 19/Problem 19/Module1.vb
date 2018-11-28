Module Module1

    Sub Main()
        Dim T As Integer = 0
        For year As Integer = 1901 To 2000
            For month As Integer = 1 To 12
                Dim d As DateTime = New Date(year, month, 1)
                If d.DayOfWeek = DayOfWeek.Sunday Then
                    T += 1
                End If
            Next
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
