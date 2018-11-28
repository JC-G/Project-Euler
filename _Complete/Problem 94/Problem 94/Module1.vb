Module Module1

    Private Function SqrtN(ByVal N As Long) As Long
        If N < 2 << 50 Then
            Return Math.Floor(Math.Sqrt(N))
        End If
        Dim num As Long = N
        If (0 = N) Then Return 0
        N /= 2

        Dim n1 As Long = N / 2 + num / (2 * N)
        Dim n0 As Long = N

        While True
            If n0 = n1 Then Return n1
            n0 = n1
            n1 = n0 / 2 + num / (2 * n0)

        End While
        Return n1

    End Function
    Public Function isSquare(x As Long) As Boolean
        Dim x0 As Long = x
        'If Not (x Mod 10 = 0 Or x Mod 10 = 4 Or x Mod 10 = 6) Then
        '    Return False
        'End If
        ''A Perfect Square always have digital summation of one of these numbers ( 1, 4, 7, 9),
        'If x = 7 Then Return False
        'While x > 10
        '    Dim x2 As Long = x
        '    x = 0
        '    While x2 > 0
        '        x += x2 Mod 10
        '        x2 \= 10

        '    End While

        'End While
        'If Not (x = 1 Or x = 4 Or x = 7 Or x = 9) Then
        '    Return False
        'End If

        Dim falseRoot As Long = Math.Round(Math.Sqrt(x0))
        If x0 >= 2 ^ 52 Then
            While falseRoot * falseRoot < x0
                falseRoot += 1
            End While
            While falseRoot * falseRoot > x0
                falseRoot -= 1
            End While

        End If

        Return falseRoot * falseRoot = x0
        'Dim actualRoot As Long = SqrtN(x0)

    End Function
    Sub Main()

        Console.ReadLine()
        Dim T As Long = 0
        For x As Long = 3 To 333333333 Step 2
            If x Mod 1000000 = 1 Then
                Console.WriteLine(x)
            End If
            Dim r1 As Long = x * (3 * x + 2) - 1
            Dim r2 As Long = x * (3 * x - 2) - 1
            If isSquare(r1) Then
                'If Math.Sqrt(r1) * (x - 1) Mod 4 = 0 Then
                Console.WriteLine(x & " " & x & " " & x - 1)
                T += 3 * x - 1
                'End If


            End If

            If isSquare(r2) Then
                'If Math.Sqrt(r2) * (x + 1) Mod 4 = 0 Then
                Console.WriteLine(x & " " & x & " " & x + 1)


                T += 3 * x + 1
                'End If
            End If
        Next

        Console.Beep()
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
