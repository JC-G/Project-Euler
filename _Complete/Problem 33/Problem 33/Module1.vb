Module Module1

    Sub Main()
        For a As Integer = 1 To 9
            For b As Integer = 1 To 9
                For c As Integer = 1 To 9
                    If 9 * a * c + b * c - 10 * a * b = 0 And a <> b And a <> c And b <> c Then
                        Console.WriteLine(a & " " & b & " " & c)
                    End If
                Next
            Next
        Next
        Console.ReadLine()
    End Sub

End Module
