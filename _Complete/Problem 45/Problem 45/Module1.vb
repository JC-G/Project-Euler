Module Module1
    Function isPentagonal(x As Long) As Boolean
        'solve the quadratic
        Dim n As Long = Math.Round(1 / 6 + Math.Sqrt(2 * x / 3 + 1 / 36))
        Return x = n / 2 * (3 * n - 1)
    End Function
    Public Function isTriangular(x As Long) As Boolean
        Dim r As Long = Math.Floor(Math.Sqrt(2 * x))
        Return 2 * x = r * (r + 1)
    End Function
    Sub Main()
        Dim x As Integer = 1
        Dim found As Boolean = False
        While Not found
            x += 1
            Dim hex As Integer = x * (2 * x - 1)
            If isTriangular(hex) And isPentagonal(hex) Then
                Console.WriteLine(hex)
            End If
        End While
    End Sub

End Module
