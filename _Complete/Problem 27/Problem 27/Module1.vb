Module Module1
    Function isPrime(x As Integer) As Boolean
        If x < 0 Then Return False
        For y As Integer = 2 To Math.Sqrt(x)
            If x Mod y = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Sub Main()
        Dim maxTotal As Integer = 0
        Dim bestA As Integer = 0
        Dim bestB As Integer = 0
        For a As Integer = -999 To 999
            For b As Integer = -1000 To 1000
                Dim n As Integer = 0
                While isPrime(n * n + a * n + b)
                    n += 1
                End While
                If n > maxTotal Then
                    maxTotal = n
                    bestA = a
                    bestB = b
                End If

            Next
        Next
        Console.WriteLine(bestA)
        Console.WriteLine(bestB)
        Console.WriteLine(bestA * bestB)
        Console.WriteLine(maxTotal)
        Console.ReadLine()


    End Sub

End Module
