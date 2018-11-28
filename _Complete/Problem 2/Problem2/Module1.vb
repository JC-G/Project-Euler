Module Module1

    Sub Main()
        Dim x1 = 1
        Dim x2 = 1
        Dim total As Integer = 0
        While x1 < 4000000 And x2 < 4000000
            Dim tmp = x2
            x2 += x1
            x1 = tmp
            If x2 Mod 2 = 0 Then
                total += x2
            End If
        End While
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub






End Module
