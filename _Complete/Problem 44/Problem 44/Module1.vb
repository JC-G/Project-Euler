Module Module1
    Function isPentagonal(x As Integer) As Boolean
        'solve the quadratic
        Dim n As Integer = Math.Round(1 / 6 + Math.Sqrt(2 * x / 3 + 1 / 36))
        Return x = n / 2 * (3 * n - 1)
    End Function
    Function getPentagonal(x As Integer) As Integer
        Return x / 2 * (3 * x - 1)
    End Function
    Sub Main()
        Dim k As Integer = 10000
        For a As Integer = 2 To k
            For b As Integer = 1 To a - 1
                Dim pa As Integer = getPentagonal(a)
                Dim pb As Integer = getPentagonal(b)
                If isPentagonal(pa + pb) And isPentagonal(pa - pb) Then
                    Console.WriteLine(a & " " & b)
                    Console.WriteLine(pa - pb)
                End If
            Next
        Next


        Console.ReadLine()
    End Sub

End Module
