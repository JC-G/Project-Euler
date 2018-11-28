Module Module1
    'absolute shit doesnt really work - see problem 110
    Dim lim As Long = 4000000
    Dim powerLimit As Long = 50 'set a Power limit so the lists dont go on forever
    Dim n As Long
    Dim min As Long = Long.MaxValue
    Dim primes As SortedSet(Of Long)
    Dim expListList As List(Of List(Of Long)) = New List(Of List(Of Long))
    Sub Main()
        n = Math.Floor((Math.Sqrt(1 + 8 * lim) - 1) / 2)
        Console.WriteLine(n)
        Console.ReadLine()
        primes = PrimeSieve(1000) 'get a lot of primes
        FindPowers(New List(Of Long), 1, 0)
        Console.Beep()
        Console.ReadLine()
    End Sub
    Function getValue(L As List(Of Long)) As Long
        Dim T As Long = 1
        Try
            For x As Long = 0 To L.Count - 1
                T *= Math.Pow(primes(x), L(x))
                If T > min Then Exit For
            Next

        Catch ex As Exception
            T = Long.MaxValue
        End Try
        Return T
    End Function
    Public Sub FindPowers(L As List(Of Long), product As Long, sum As Long)
        If sum > 64 Then
            Return
        End If

        If product > n Then
            'For Each P As Long In L
            '    Console.Write(P & ",")
            'Next
            'Console.WriteLine()
            Dim v As Long = getValue(L)
            If v < min Then
                Dim divs As List(Of Long) = getProperDivisors(v)
                divs.Add(v)
                'divs.Sort()
                Dim total As Long = 0
                For x As Long = 0 To divs.Count - 1
                    For y As Long = x To divs.Count - 1
                        If gcd(divs(x), divs(y)) = 1 Then
                            total += 1
                        End If

                    Next
                Next
                'Console.WriteLine(total)
                If total > lim Then
                    min = v


                    Console.WriteLine()
                    Console.WriteLine(v)
                    Console.ReadLine()

                End If
                'cfp check here

            End If
            If v > min Then
                Return

            End If
        End If
        Dim last As Long = powerLimit
        If L.Count > 0 Then last = L.Last

        For z As Long = last To 1 Step -1

            Dim L3 As List(Of Long) = New List(Of Long)(L.AsEnumerable)

            L3.Add(z)
            FindPowers(L3, product * (z + 1), sum + (z + 1))
        Next

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



    Function getProperDivisors(x As Long) As List(Of Long)
        Dim L As List(Of Long) = New List(Of Long)
        For t As Long = 1 To Math.Floor(Math.Sqrt(x))
            If x Mod t = 0 Then
                L.Add(t)
                If x / t <> t And t <> 1 Then
                    L.Add(x / t)

                End If
            End If
        Next
        Return L
    End Function
    Function gcd(a As Long, b As Long) As Long
        While b > 0
            Dim Na = b
            Dim Nb = a Mod b
            a = Na
            b = Nb

        End While
        Return a
    End Function
End Module
