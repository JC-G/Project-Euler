Module Module1
    Function gcd(a As Integer, b As Integer) As Integer
        While b > 0
            Dim Na = b
            Dim Nb = a Mod b
            a = Na
            b = Nb

        End While
        Return a
    End Function
    Sub Main()
        Dim T As Integer = 0
        For d As Integer = 2 To 12000
            For n As Integer = Math.Ceiling(d / 3) To Math.Floor(d / 2)
                If gcd(n, d) = 1 Then
                    If Not (n = 1 And (d = 2 Or d = 3)) Then

                        T += 1
                    End If
                End If
            Next
        Next
        Console.WriteLine(T) '1/2 is in there
        Console.ReadLine()
    End Sub

End Module
