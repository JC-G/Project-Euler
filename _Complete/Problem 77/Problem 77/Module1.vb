Module Module1
    Dim result As Integer = 0
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

    Public Sub RecursionTest(target As Integer, goodPrimes As SortedSet(Of Integer), Optional currentSum As Integer = 0, Optional lastTerm As Integer = -1)
        If lastTerm = -1 Then
            lastTerm = target - 1
        End If
        If currentSum = target Then
            result += 1

            'For Each P As Integer In L
            'Console.Write(P & ",")
            'Next
            'Console.WriteLine()
            Return
        End If

        'Console.WriteLine(goodPrimes2.Count)

        For Each P As Integer In goodPrimes
            If P > lastTerm Then
                Exit For
            End If
            If currentSum + P > target Then
                Exit For
            End If

            RecursionTest(target, goodPrimes, currentSum + P, P)
        Next

    End Sub
    Sub Main()
        For T As Integer = 1 To 100
            result = 0
            RecursionTest(T, PrimeSieve(T))
            If result > 5000 Then
                Console.WriteLine(T)
                Console.Beep()
                Console.ReadLine()
            End If
        Next
    End Sub

End Module
