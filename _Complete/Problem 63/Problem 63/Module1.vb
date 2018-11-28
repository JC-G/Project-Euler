Module Module1

    Sub Main()
        Dim L As List(Of String) = New List(Of String)
        For b As Integer = 1 To 9
            For exp As Integer = 1 To 30
                Dim I As Numerics.BigInteger = Numerics.BigInteger.Pow(b, exp)
                If I.ToString.Count = exp Then
                    L.Add(I.ToString)
                End If

            Next
        Next
        Console.WriteLine(L.Distinct.Count)
        Console.ReadLine()
    End Sub

End Module
