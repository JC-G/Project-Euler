Module Module1
    'includes system.numerics reference

    Sub Main()
        Dim n As Numerics.BigInteger = New Numerics.BigInteger(1)
        For x As Integer = 1 To 1000
            n = n * 2

        Next

        Dim s As String = n.ToString()
        Dim T As Integer = 0
        For Each c As String In s
            T += Convert.ToInt32(c)
        Next
        Console.WriteLine(T)
        Console.Read()
    End Sub

End Module
