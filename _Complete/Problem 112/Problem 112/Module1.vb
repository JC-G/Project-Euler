Module Module1

    Sub Main()
        Console.WriteLine("0" < "2")
        Dim T As Integer = 0
        Dim X As Integer = 0
        While True
            X += 1

            If isBouncy(X) Then T += 1
            If 99 * X = 100 * T Then
                Console.WriteLine(X)
                Exit While
            End If
        End While

        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

    Function isBouncy(x As Integer) As Boolean
        Dim S As String = x.ToString
        Dim inc As Boolean = True
        Dim dec As Boolean = True
        For i As Integer = 0 To S.Count - 2
            If S(i) < S(i + 1) Then
                dec = False
            End If
            If S(i) > S(i + 1) Then
                inc = False
            End If

        Next
        Return (Not inc) And (Not dec)
    End Function

End Module
