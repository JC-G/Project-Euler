Module Module1

    Sub Main()

        Dim total As Integer = 0
        For x As Integer = 1 To 10000 - 1
            Dim iterationCount As Integer = 0
            Dim L As Numerics.BigInteger = x
            Do
                iterationCount += 1
                L += Numerics.BigInteger.Parse(StrReverse(L.ToString))
                If iterationCount >= 50 Then
                    total += 1
                    Exit Do
                End If

            Loop While L.ToString <> StrReverse(L.ToString)
            Console.WriteLine(iterationCount)

        Next
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub

End Module
