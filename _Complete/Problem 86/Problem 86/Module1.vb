



Module Module1
    Structure vec2
        Public a As Long
        Public b As Long
        Sub New(_a As Long, _b As Long)
            a = _a
            b = _b
        End Sub
        Sub write()
            Console.WriteLine("A: " & a & " B: " & b & " C: " & Math.Sqrt(a * a + b * b))
        End Sub
    End Structure
    Dim LIM As Long = 100000
    Dim triplelist As SortedSet(Of Long) = New SortedSet(Of Long)
    Function getHash(a As Long, b As Long) As Long
        Return LIM * a + b
    End Function
    Function getPair(H As Long) As vec2
        Return New vec2(H \ LIM, H Mod LIM)
    End Function

    Sub Main()
        'ASSUMPTION THAT A NUMBER CAN ONLY BE THE SMALLEST IN A TRIPLE ONCE??? possibly wrong
        'THE ASSUMPTION IS WRONG- RESORT TO HASHES AND LIST OF DOUBLES
        'counter 872, 1635 or 95046

        For u As Long = 1 To Math.Sqrt(LIM) 'Math.Sqrt(LIM) 'from cplx
            For v As Integer = 1 To u
                Dim x As Integer = u * u - v * v
                Dim y As Integer = 2 * u * v
                If x < 1 Or y < 1 Then
                    Continue For
                End If
                Dim ci As Integer = u * u + v * v
                Dim c As Integer = ci
                Dim a As Integer = Math.Min(x, y)
                Dim b As Integer = Math.Max(x, y)
                Dim mul As Integer = 1
                While c <= LIM
                    Dim triple As Long = getHash(mul * a, mul * b)
                    If Not triplelist.Contains(triple) Then
                        triplelist.Add(triple)
                    End If

                    c += ci
                    mul += 1

                End While
            Next
        Next
        Console.WriteLine("Triple Count: " & triplelist.Count)
        Dim M As Integer = 0
        Dim T As Integer = 0


        While T <= 1000000
            M += 1
            If M Mod 100 = 0 Then
                Console.WriteLine("M= " & M)

            End If
            For Each N As Long In triplelist
                Dim triple As vec2 = getPair(N)
                'we are counting too many for example (k,2m-k) could get counted 
                Dim other As Integer = 0
                If triple.a = M And triple.b <= 2 * M Then
                    other = triple.b
                End If
                If triple.b = M And triple.a <= 2 * M Then
                    other = triple.a
                End If
                If other <= M Then
                    T += other \ 2
                Else
                    For x = 1 To other \ 2
                        If other - x > M Then
                            Continue For
                        Else
                            T += 1
                        End If
                    Next
                End If
            Next

        End While
        Console.WriteLine("M= " & M & " T= " & T)

            'first generate triples
            'on an m increase, for C = m,
            'check all triples where m = a or b, then add floor(other/2)
            'this works since  it will have been done before if a or b as C is less than M
            ' check that b <= 2m since A+B <= 2m
            'the easiest way to do this is just a for loop i think
            Console.ReadLine()
    End Sub

End Module
