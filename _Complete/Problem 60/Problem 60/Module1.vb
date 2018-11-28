Module Module1
    Dim primes As SortedSet(Of Long)
    Dim largePrimes As SortedSet(Of Long)
    Public Function isPrime(x As Long) As Boolean
        If x < 2 Then Return False
        Dim root As Long = Math.Floor(Math.Sqrt(x))
        For t As Long = 2 To root
            If x Mod t = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Function concat(x As Long, y As Long) As Long
        Dim c As Long = y
        While c > 0
            x *= 10
            c \= 10
        End While
        Return x + y
    End Function
    Public Function PrimalTest(x As Long) As Boolean
        Return primes.Contains(x) OrElse largePrimes.Contains(x) OrElse isPrime(x)
    End Function
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
    Public Sub AddToSet([set] As SortedSet(Of Long), x As Long)
        'Console.Write(x & ",")
        [set].Add(x)
    End Sub
    Public Function IsGoodPair(x As Long, y As Long)
        Return PrimalTest(concat(x, y)) AndAlso PrimalTest(concat(y, x))
    End Function
    Public Function FitsInSet(x As Long, s As SortedSet(Of Long))
        If s.Count = 0 Then Return True

        For Each I As Long In s
            If Not IsGoodPair(x, I) Then
                Return False
            End If
        Next
        Return True
    End Function
    Sub Main()
        primes = PrimeSieve(20000) 'hope is enough
        largePrimes = PrimeSieve(100000)
        Dim indices() As Integer = {0, 1, 2, 3, 4}
        Dim indexBuffer() As Integer = {0, 0, 0, 0, 0}
        Dim currentLevel As Integer = 0
        Console.WriteLine("Primes Generated")
        Dim TheSet As SortedSet(Of Long) = New SortedSet(Of Long)

        For I1 As Integer = 0 To primes.Count - 5
            TheSet.Clear()
            Console.WriteLine()

            If FitsInSet(primes(I1), TheSet) Then
                AddToSet(TheSet, primes(I1))
                For I2 As Integer = I1 + 1 To primes.Count - 4

                    If FitsInSet(primes(I2), TheSet) Then
                        AddToSet(TheSet, primes(I2))
                        For I3 As Integer = I2 + 1 To primes.Count - 3

                            If FitsInSet(primes(I3), TheSet) Then
                                AddToSet(TheSet, primes(I3))
                                For I4 As Integer = I3 + 1 To primes.Count - 2

                                    If FitsInSet(primes(I4), TheSet) Then
                                        AddToSet(TheSet, primes(I4))

                                        For I5 As Integer = I4 + 1 To primes.Count - 1

                                            If FitsInSet(primes(I5), TheSet) Then
                                                AddToSet(TheSet, primes(I5))

                                                If TheSet.Count = 5 Then
                                                    Console.Beep(500, 10)
                                                    Console.WriteLine("Found")
                                                    Dim total2 As Integer = 0
                                                    For Each item As Long In TheSet
                                                        Console.Write(item & ",")
                                                        total2 += item
                                                    Next
                                                    Console.WriteLine(total2)
                                                    Console.ReadLine()
                                                End If
                                            End If
                                        Next
                                        TheSet.Remove(TheSet.Last)
                                    End If

                                Next
                                TheSet.Remove(TheSet.Last)
                            End If


                        Next
                        TheSet.Remove(TheSet.Last)
                    End If

                Next
                TheSet.Remove(TheSet.Last)
            End If

        Next


        Console.Beep()
        Console.Beep()
        Console.Beep()

        Console.ReadLine()
    End Sub

End Module
