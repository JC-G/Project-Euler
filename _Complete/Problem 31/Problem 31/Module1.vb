Module Module1
    Dim allowedSet As List(Of Integer) = New List(Of Integer)({200, 100, 50, 20, 10, 5, 2, 1})
    'introduce a rule, can only pick coins in decreasing order
    Function waysToMake(x As Integer, max As Integer) As Integer
        Dim T As Integer = 0
        If x < allowedSet.Min Then
            Return 1
        End If
        For Each I As Integer In allowedSet
            If x >= I And max >= I Then
                T += waysToMake(x - I, I)
            End If
        Next
        Return T
    End Function
    Sub main()
        Console.WriteLine(waysToMake(200, allowedSet.Max))
        Console.ReadLine()
    End Sub
End Module
