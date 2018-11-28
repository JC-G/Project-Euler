Module Module1

    Dim kLim As Integer = 12000
    Dim A(kLim) As Integer
    Public Sub BuildList(L As List(Of Integer), k As Integer, Sum As Integer, Product As Integer)
        'exit conditions
        If L.Count > 1 + Math.Log(k, 2) Or Product > 2 * k Or Product > Sum + k - L.Count Then
            Return 'doesnt work
        End If

        If Product = Sum + k - L.Count Then
            'this is ok
            If A(k) = 0 Then
                A(k) = Product
            Else
                A(k) = Math.Min(A(k), Product)
            End If
            Return
        End If



        Dim lastTerm As Integer = 2
        If L.Count <> 0 Then
            lastTerm = L.Last
        End If
        For z As Integer = lastTerm To (2 * k) / Product

            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

            L3.Add(z)

            BuildList(L3, k, Sum + z, Product * z)
        Next

    End Sub
    Sub Main()
        'how about that one recursive algorithm?
        'If (x1, . . . , xn) ∈ A(n), n > 2, then x1 + · · · + xn <= 2n
        For k As Integer = kLim To 2 Step -1
            Console.WriteLine(k)
            Dim L As List(Of Integer) = New List(Of Integer)
            BuildList(L, k, 0, 1)
            'N = list count
            'store product and sum
        Next
        Console.ReadLine()
        Dim T As Integer = 0
        For Each I As Integer In A.Distinct
            Console.Write(I & ",")
            T += I
        Next
        Console.WriteLine("Total: " & T)
        Console.ReadLine()
    End Sub

End Module
