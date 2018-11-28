Module Module1
    Dim target As Integer = 1000000
    Sub Main()
        Dim maxT As Integer = 0
        Dim res As Integer = 0
        For k As Integer = 1 To target
            Dim n As Long = k
            Dim T As Integer = 0
            While Not n = 1
                If n Mod 2 = 0 Then
                    n /= 2
                Else
                    n = 3 * n + 1
                End If
                T += 1
            End While
            If T > maxT Then
                maxT = T
                res = k
            End If
        Next
        Console.WriteLine(res)
        Console.Read()
    End Sub

End Module
