
Module Module1

    Sub Main()


        Console.WriteLine(27 * Math.Log(64) = 81 * Math.Log(4))
        Dim lim As Integer = 100
        Dim L As SortedSet(Of Numerics.BigInteger) = New SortedSet(Of Numerics.BigInteger)
        For a As Integer = 2 To lim
            For b As Integer = 2 To lim
                Dim x As Numerics.BigInteger = Numerics.BigInteger.Pow(a, b)
                If Not L.Contains(x) Then
                    L.Add(x)
                    'Console.WriteLine(a & " " & b & " " & x & " " & L.Count)
                End If
            Next
        Next
        Console.WriteLine(L.Count)
        Console.ReadLine()
    End Sub

End Module
