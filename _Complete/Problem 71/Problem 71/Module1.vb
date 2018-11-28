Module Module1
    'we know it is between 2/5 and 3/7
    'for d = 2 to 1000000
    'for n = \frac{300000}{700001}*d to 3/7*d ceil to floor
    'if d mod n = 0 then discard since d|n so not reduced
    'put in sorted dictionary of (double,numerator)
    'pick the last
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

        Dim Dict As SortedDictionary(Of Double, Integer) = New SortedDictionary(Of Double, Integer)
        For d As Integer = 2 To 1000000
            If d Mod 10000 = 0 Then Console.WriteLine(d)
            'Console.WriteLine(d)
            Dim lower As Double = 30000.0 / 70001.0
            Dim upper As Double = 3.0 / 7.0
            For n As Integer = Math.Ceiling(lower * d) To Math.Floor(upper * d)
                If gcd(n, d) <> 1 Then
                    Continue For

                Else
                    Dict.Add(n / d, n)
                End If
            Next
        Next
        Console.WriteLine("Done")
        Dict.Remove(Dict.Last.Key) 'remove 3/7
        Console.WriteLine(Dict.Last.Value)
        Console.ReadLine()

    End Sub

End Module
