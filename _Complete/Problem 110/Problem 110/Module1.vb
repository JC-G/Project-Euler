Module Module1
    Dim s As Long = 4000000
    Dim bestValue As Long = Long.MaxValue
    Dim primes As SortedSet(Of Long)

    Public Sub main()
        primes = PrimeSieve(300)
        RecursionTest(New List(Of Long))
        Console.WriteLine("DONE")
        Console.ReadLine()
    End Sub


    Public Function PrimeSieve(x As Long) As SortedSet(Of Long) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Long) = New SortedSet(Of Long)
        For t As Long = 2 To x
            L.Add(t)
        Next
        For testValue As Long = 2 To Math.Floor(Math.Sqrt(x))
            For testNumber As Long = 2 * testValue To x Step testValue
                If L.Contains(testNumber) Then
                    L.Remove(testNumber)
                End If
            Next
        Next
        Return L
    End Function

    Public Sub RecursionTest(L As List(Of Long), Optional pow As Long = 1, Optional val As Long = 1)

        If pow > 1 + 2 * s Then
            If val < bestValue Then
                bestValue = val
                For Each P As Long In L
                    Console.Write(P & ",")
                Next
                Console.WriteLine(val)
                Console.WriteLine()
            End If
            Return
        End If

        Dim max As Long = s
        If L.Count > 0 Then max = L.Last

        For z As Long = 1 To max

            Dim L3 As List(Of Long) = New List(Of Long)(L.AsEnumerable)
            Dim val2 As Long = 1
            Try
                val2 = val * (primes(L.Count) ^ z)
            Catch ex As OverflowException
                Console.WriteLine("FAIL")
                'Console.ReadLine()

                val2 = Long.MaxValue
            End Try
            If val2 >= bestValue Then
                Return
            End If
            L3.Add(z)
            RecursionTest(L3, pow * (2 * z + 1), val2)

        Next

    End Sub

End Module
