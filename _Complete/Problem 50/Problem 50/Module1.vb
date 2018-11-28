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
        Dim target As Integer = 1000000
        Dim primes As SortedSet(Of Integer) = PrimeSieve(target)
        Dim maxlength As Integer = 0
        Dim bestPrime As Integer = 0
        For startIndex As Integer = 0 To primes.Count - 2
            If startIndex Mod 100 = 0 Then
                Console.WriteLine(startIndex & "/" & primes.Count)
            End If
            'we know that it must be greater than 64 (10k case) therefore if primes(startindex) > target/64 then just stop
            If primes(startIndex) > target / 64 Then
                Exit For
            End If


            'sum all of these ,if less then do maxlength and recordprime

            Dim total As Integer = 0
            Dim index As Integer = 0
            Dim length As Integer = 0
            While total < target
                length += 1
                total += primes(index + startIndex)
                If length > maxlength AndAlso primes.Contains(total) Then
                    maxlength = length
                    bestPrime = total
                End If
                index += 1
            End While
        Next
        Console.WriteLine(bestPrime & " " & maxlength)
        Console.ReadLine()


    End Sub

End Module
