Module Module1
    Public Function getPrimeFactorization(x As Integer) As List(Of Integer)
        Dim r As List(Of Integer) = New List(Of Integer)
        Dim isPrime = True
        Dim total As Integer = x
        While Not total = 1
            For iter As Integer = 2 To Math.Ceiling(x / 2)
                If total Mod iter = 0 Then
                    isPrime = False
                    r.Add(iter)
                    total /= iter
                    Exit For
                End If
            Next
            If isPrime Then
                r.Add(x)
                Return r
            End If
        End While
        Return r
    End Function
    Sub Main()
        Dim found As Boolean = False
        Dim N As Integer = 2
        Dim count As Integer = 0
        While Not found
            If getPrimeFactorization(N).Distinct.Count = 4 Then
                count += 1
            Else
                count = 0
            End If


            If count = 4 Then
                found = True
            Else

                N += 1
            End If
        End While
        Console.WriteLine(N - 3)
        Console.ReadLine()
    End Sub

End Module
