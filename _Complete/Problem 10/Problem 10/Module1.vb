Module Module1
    Dim target As Integer = 2000000
    Sub Main()
        Dim total As Long = 0
        For x As Integer = 1 To target
            If isPrime(x) Then
                total += x
            End If
        Next
        Console.WriteLine(total)
        Console.Read()
    End Sub
    Function isPrime(x As Integer) As Boolean
        If x = 1 Then Return False
        For i As Integer = 2 To Math.Sqrt(x)
            If x Mod i = 0 Then Return False
        Next
        Return True

    End Function

End Module
