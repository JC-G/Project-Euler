Module Module1

    Sub Main()
        Dim modulus As Long = 10000000000
        Dim P As Long = 1
        For x As Integer = 1 To 7830457
            P = (P * 2) Mod modulus
        Next
        P = (28433 * P) Mod modulus
        P = (P + 1) Mod modulus
        Console.WriteLine(P)
        Console.ReadLine()

    End Sub

End Module
