Module Module1
    Function DigitSum(x As Numerics.BigInteger) As Integer
        Dim T As Integer = 0
        For Each C As Char In x.ToString
            T += Convert.ToInt32(C) - 48
        Next
        Return T
    End Function
    Sub Main()
        Dim max As Integer = 0
        For a As Integer = 1 To 100
            For b As Integer = 1 To 100
                Dim L As Numerics.BigInteger = Numerics.BigInteger.Pow(a, b)
                If max < DigitSum(L) Then
                    max = DigitSum(L)
                End If
            Next
        Next
        Console.WriteLine(max)
        Console.ReadLine()
    End Sub

End Module
