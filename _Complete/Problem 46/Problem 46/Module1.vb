Module Module1
    Public Function PrimeSieve(x As Integer) As SortedSet(Of Integer) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Integer) = New SortedSet(Of Integer)
        For t As Integer = 2 To x
            L.Add(t)
        Next
        For testValue As Integer = 2 To Math.Floor(Math.Sqrt(x))
            For testNumber As Integer = 2 * testValue To x Step testValue
                If L.Contains(testNumber) Then
                    L.Remove(testNumber)
                End If
            Next
        Next
        Return L
    End Function

    Sub Main()
        Dim primeList As SortedSet(Of Integer) = PrimeSieve(1000000) 'generate a lot of primes
        Dim found As Boolean = False
        Dim N As Integer = 1
        While Not found
            N += 2
            If primeList.Contains(N) Then
                Continue While
            End If
            'check squares up to N with primes up to N-2S
            For S As Integer = 1 To Math.Floor(Math.Sqrt(N))
                If primeList.Contains(N - 2 * S * S) Then
                    Continue While
                End If
            Next
            found = True
        End While
        Console.WriteLine(N)
        Console.ReadLine()
    End Sub

End Module
