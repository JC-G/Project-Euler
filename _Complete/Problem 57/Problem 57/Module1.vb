Module Module1

    Sub Main()
        Dim total As Integer = 0
        Dim a As Numerics.BigInteger = 1
        Dim b As Numerics.BigInteger = 2
        For x As Integer = 1 To 1000
            Dim newB As Numerics.BigInteger = 2 * b + a
            Dim newA As Numerics.BigInteger = b
            a = newA
            b = newB
            If (3 * b + a).ToString.Length > (2 * b + a).ToString.Length Then
                total += 1
            End If
        Next
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub

End Module
