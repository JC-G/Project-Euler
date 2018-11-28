Module Module1
    Function DigitSum(x As String)
        Dim T As Integer = -48 * x.Count
        For Each C As Char In x
            T += Convert.ToInt32(C)
        Next
        Return T
    End Function
    Function GetEConvergent(x As Integer)
        If x = 1 Then Return 2
        If x Mod 3 = 0 Then Return 2 * x / 3
        Return 1
    End Function
    Sub Main()
        Dim L(100) As Integer
        For x As Integer = 1 To 100
            L(x) = GetEConvergent(x)
        Next
        Dim P As Numerics.BigInteger = 1
        Dim Q As Numerics.BigInteger = L(100)
        For x As Integer = 99 To 1 Step -1
            Dim NP As Numerics.BigInteger = Q
            Dim NQ As Numerics.BigInteger = L(x) * Q + P
            P = NP
            Q = NQ
        Next
        Console.WriteLine(DigitSum(Q.ToString))
        Console.ReadLine()
    End Sub

End Module
