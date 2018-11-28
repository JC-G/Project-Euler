Module Module1
    '*/+-
    '123456789
    Dim bestValue As Integer = 0
    Dim bestConsec As Integer = 0
    Dim dict As SortedDictionary(Of Integer, SortedSet(Of Integer)) = New SortedDictionary(Of Integer, SortedSet(Of Integer))
    Dim digitSetSet As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Public Sub RecursionTest(L As List(Of Integer))

        If L.Count = 4 Then
            For Each P As Integer In L
                'Console.Write(P & ",")
            Next
            'Console.WriteLine()
            digitSetSet.Add(L)
            Return
        End If
        Dim last As Integer = 0
        If L.Count <> 0 Then
            last = L.Last
        End If

        For z As Integer = last + 1 To 9

            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

            L3.Add(z)
            RecursionTest(L3)
        Next

    End Sub

    Public Sub RecursionTest2(L As List(Of Integer), usable As List(Of Integer), T As Double, key As Integer)

        If L.Count = 4 Then
            If T < 1 Then
                Return
            End If
            If isInt(T) Then
                If Not dict.ContainsKey(key) Then
                    dict(key) = New SortedSet(Of Integer)
                End If

                If Not dict(key).Contains(T) Then
                    dict(key).Add(T)


                End If
            End If
            Return

        End If

        For Each z As Integer In usable
            Dim usable2 As List(Of Integer) = New List(Of Integer)(usable.AsEnumerable)
            usable2.Remove(z)



            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

            L3.Add(z)
            If L.Count = 0 Then
                RecursionTest2(L3, usable2, z, key)
            Else
                RecursionTest2(L3, usable2, T + z, key)
                RecursionTest2(L3, usable2, T - z, key)
                RecursionTest2(L3, usable2, z - T, key)

                RecursionTest2(L3, usable2, T * z, key)
                RecursionTest2(L3, usable2, T / z, key)
                RecursionTest2(L3, usable2, z / T, key)


            End If
        Next

    End Sub
    Function isInt(D As Double) As Boolean
        Dim eps As Double = 0.00001
        If Math.Abs(D - Math.Round(D)) < eps Then
            Return True
        End If
        Return False 'no consec -1 0 1
    End Function
    Sub Main()
        RecursionTest(New List(Of Integer))
        Console.WriteLine(digitSetSet.Count)
        For Each digitSet As List(Of Integer) In digitSetSet
            Dim key As Integer = 1000 * digitSet(0) + 100 * digitSet(1) + 10 * digitSet(2) + digitSet(3)
            RecursionTest2(New List(Of Integer), digitSet, 0, key)
        Next
        Console.WriteLine(dict.Count)
        For Each S As KeyValuePair(Of Integer, SortedSet(Of Integer)) In dict
            Dim i As Integer = 0

            While S.Value(i) = i + 1
                Console.Write(S.Value(i) & ",")
                i += 1
            End While
            Console.WriteLine()

            If i > bestConsec Then
                bestConsec = i
                bestValue = S.Key
            End If

        Next
        Console.WriteLine(bestValue & ":" & bestConsec)
        For Each I As Integer In dict(1258)
            Console.Write(I & ",")
        Next
        'for each set do the thing
        Console.ReadLine()
    End Sub

End Module
