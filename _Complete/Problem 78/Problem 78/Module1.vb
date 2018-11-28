Module Module1
    'try just mod 1000000 to begin with
    Dim PCache As SortedDictionary(Of Long, Long) = New SortedDictionary(Of Long, Long)
    Function P(n As Long) As Long
        If n = 0 Then Return 1
        If n < 0 Then
            'Console.WriteLine("ERROR: " & n)
            Return 0
        End If
        If PCache.ContainsKey(n) Then Return PCache(n)
        Dim T As Long = 0
        For k As Long = 1 To n
            Dim inv As Long = Math.Pow((-1), (k + 1))
            Dim p1 As Long = P(n - ((k * (3 * k - 1)) / 2))
            Dim p2 As Long = P(n - ((k * (3 * k + 1)) / 2))
            If p1 = 0 And p2 = 0 Then Exit For 'added after completion, removes lots of redundant cases
            'Console.WriteLine(p1 & " " & p2)
            T += inv * (p1 + p2)
            T = T Mod 1000000
        Next
        PCache.Add(n, T)
        Return T
    End Function
    Sub Main()

        For k As Integer = 1 To 100000
            If k Mod 10000 = 0 Then
                Console.WriteLine(k)
            End If
            'Console.WriteLine("K: " & k)
            If P(k) = 0 Then
                Console.WriteLine(k)
                Console.Beep()
            End If
        Next
        'Console.WriteLine(P(100))
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
