Module Module1
    Function LexoPerm(S As String, Optional H As String = "") As List(Of String)
        Dim L As List(Of String) = New List(Of String)
        If S.Length = 1 Then
            L.Add(H + S)
            Return L
        End If
        For x As Integer = 0 To S.Length - 1
            Dim s2 As String = S.Remove(x, 1)
            L.AddRange(LexoPerm(s2, H + S(x)).AsEnumerable)
        Next
        Return L
    End Function
    Public Function PrimeSieve(x As Integer, Optional from As Integer = 2) As SortedSet(Of Integer) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Integer) = New SortedSet(Of Integer)
        For t As Integer = from To x
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
        Dim L As SortedSet(Of Integer) = PrimeSieve(9999, 1000)
        'maximum jump = (9999-P)/2
        For Each P As Integer In L
            For J As Integer = 2 To (9999 - P) / 2
                If L.Contains(P + J) AndAlso L.Contains(P + 2 * J) Then
                    'do the permutations bit
                    Dim S As String = P.ToString
                    Dim perm As List(Of String) = LexoPerm(S)
                    If perm.Contains(P + J) And perm.Contains(P + 2 * J) Then
                        Console.WriteLine(P & P + J & P + 2 * J)
                    End If



                End If
            Next
        Next
        Console.ReadLine()
    End Sub

End Module
