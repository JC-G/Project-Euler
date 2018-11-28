Module Module1

    Sub Main()
        Dim T As Numerics.BigInteger = Numerics.BigInteger.Parse("1")
        For x As Integer = 1 To 100
            T *= x

        Next
        Dim S As String = T.ToString
        Dim N As Integer = 0
        For Each C As String In S
            N += Convert.ToInt32(C)
        Next
        Console.WriteLine(N)
        Console.ReadLine()
    End Sub

End Module
