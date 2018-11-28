Module Module1

    Sub Main()
        Dim tot As Integer = 0
        For i = 1 To 999
            If i Mod 5 = 0 Or i Mod 3 = 0 Then
                tot += i
            End If
        Next
        Console.WriteLine(tot)
        Console.ReadLine()
    End Sub

End Module
