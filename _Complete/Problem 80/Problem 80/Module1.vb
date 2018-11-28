Module Module1
    'https://stackoverflow.com/questions/3432412/calculate-square-root-of-a-biginteger-system-numerics-biginteger
    Function isRoot(x As Numerics.BigInteger, r As Numerics.BigInteger)
        Dim LB As Numerics.BigInteger = r * r
        Dim UB As Numerics.BigInteger = (r + 1) * (r + 1)
        Return LB <= x And x < UB

    End Function
    Function Sqrt(x As Numerics.BigInteger) As Numerics.BigInteger
        If x = 0 Then Return 0
        Dim bitLn As Integer = Math.Ceiling(Numerics.BigInteger.Log(x, 2))
        Dim root As Numerics.BigInteger = 1 << (bitLn / 2)
        While Not isRoot(x, root)
            root += x / root
            root /= 2
        End While
        Return root

    End Function
    Function DigitSum(x As String)
        Dim T As Integer = -48 * x.Count
        For Each C As Char In x
            T += Convert.ToInt32(C)
        Next
        Return T
    End Function
    Sub Main()
        Dim T As Integer = 0
        For x As Integer = 1 To 100
            If Math.Pow(Math.Floor(Math.Sqrt(x)), 2) = x Then
                Continue For

            End If

            Dim N As Numerics.BigInteger = x * Numerics.BigInteger.Pow(10, 200)
            Dim S As String = Sqrt(N).ToString
            If S.Length > 100 Then
                S = S.Remove(100)
            End If
            T += DigitSum(S)
        Next


        Console.WriteLine(T)
        Console.ReadLine()
        'Sqrt(N)
    End Sub

End Module
