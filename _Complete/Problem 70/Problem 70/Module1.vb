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
    Function StrSort(x As String)
        Dim A As Char() = x.ToCharArray
        Array.Sort(A)
        Return New String(A)
    End Function
    Sub Main()

        'too many things
        'it is NOT a prime since T(p) = p-1 and p-1 is never a permutation of p
        'in order to maximise PROD(1-1/p) for distinct prime factors, it should have a low amount of large prime factors - what if it was a square number? perhaps exactly 2 factors?
        'WHAT IF WE START FROM THE PRIME FACTORS
        'using double precision, calculate 1-1/p for all primes under L (L < 30k for now, can increase)
        'find a number such that - not necessarily all distinct factors yet (need to prove)
        'product of distinct (p-1) and remainder duplicate factors(p) is a permutation of itself
        'perhaps start with all numbers with 2 prime factors, and calculate (p-1)(q-1) and show that it is a permutation of itself
        'then find PROD(1-1/p) for it

        Dim Primes As SortedSet(Of Integer) = PrimeSieve(30000)
        Console.WriteLine("Prime Count: " & Primes.Count)
        Dim max As Double = 0
        Dim optimal As Integer = 0
        For p1i As Integer = 0 To Primes.Count - 1
            Console.WriteLine(p1i & "/" & Primes.Count - 1)
            For p2i As Integer = p1i To Primes.Count - 1
                Dim testNumber As Integer = Primes(p1i) * Primes(p2i)
                If testNumber > 10000000 Then
                    Exit For
                End If
                Dim test2number As Integer = (Primes(p1i) - 1) * (Primes(p2i) - 1)
                If StrSort(test2number) = StrSort(testNumber) Then
                    Console.WriteLine(testNumber)
                    'we have passed the first test
                    If max < test2number / testNumber Then
                        Console.WriteLine("New Optimal found")
                        max = test2number / testNumber
                        optimal = testNumber
                    End If

                End If
            Next
        Next
        Console.WriteLine("Actual Optimal: " & optimal)
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
