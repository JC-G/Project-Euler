Module Module1

    Sub Main()
        Dim digits As Long = 0
        Dim modulus As Long = 10000000000
        For x As Integer = 1 To 1000
            Dim part As Long = 1
            For y As Integer = 1 To x
                part = (part * x) Mod modulus
            Next
            digits = (digits + part) Mod modulus
        Next
        Console.WriteLine(digits)
        Console.ReadLine()
    End Sub

End Module
