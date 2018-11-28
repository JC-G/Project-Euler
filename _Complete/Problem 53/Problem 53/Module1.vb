Module Module1
    Function factorial(x As Integer) As Double
        If x = 0 Then Return 1
        Dim D As Double = 1
        For t As Integer = 1 To x
            D *= t
        Next
        Return D
    End Function
    Sub Main()
        Dim total As Integer = 0
        For n As Integer = 1 To 100
            For r As Integer = 0 To n
                If factorial(n) / (factorial(r) * factorial(n - r)) > 1000000 Then
                    total += 1
                End If


            Next
        Next
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub

End Module
