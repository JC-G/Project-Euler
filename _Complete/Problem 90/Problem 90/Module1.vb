Module Module1
    Dim DiceList As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Public Sub RecursionTest(L As List(Of Integer))

        If L.Count = 6 Then
            For Each P As Integer In L
                Console.Write(P & ",")
            Next
            Console.WriteLine()
            DiceList.Add(L)
            Return
        End If
        Dim lastItem As Integer = -1
        If L.Count <> 0 Then
            lastItem = L.Last
        End If
        For z As Integer = lastItem + 1 To 9

            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

            L3.Add(z)
            RecursionTest(L3)
        Next

    End Sub
    Sub Main()
        RecursionTest(New List(Of Integer))
        'now we have all the dice
        Dim count As Integer = 0
        For d1i As Integer = 0 To DiceList.Count - 1
            For d2i As Integer = d1i To DiceList.Count - 1
                Dim d1 As List(Of Integer) = DiceList(d1i)
                Dim d2 As List(Of Integer) = DiceList(d2i)

                If Not ((d1.Contains(0) And d2.Contains(1)) Or (d2.Contains(0) And d1.Contains(1))) Then
                    Continue For
                End If
                If Not ((d1.Contains(0) And d2.Contains(4)) Or (d2.Contains(0) And d1.Contains(4))) Then
                    Continue For
                End If
                If Not ((d1.Contains(2) And d2.Contains(5)) Or (d2.Contains(2) And d1.Contains(5))) Then
                    Continue For
                End If
                If Not ((d1.Contains(8) And d2.Contains(1)) Or (d2.Contains(8) And d1.Contains(1))) Then
                    Continue For
                End If


                If Not ((d1.Contains(0) And d2.Contains(9)) Or (d2.Contains(0) And d1.Contains(9))) Then

                    If Not ((d1.Contains(0) And d2.Contains(6)) Or (d2.Contains(0) And d1.Contains(6))) Then
                        Continue For
                    End If
                End If
                If Not ((d1.Contains(1) And d2.Contains(9)) Or (d2.Contains(1) And d1.Contains(9))) Then

                    If Not ((d1.Contains(1) And d2.Contains(6)) Or (d2.Contains(1) And d1.Contains(6))) Then
                        Continue For
                    End If
                End If
                If Not ((d1.Contains(3) And d2.Contains(9)) Or (d2.Contains(3) And d1.Contains(9))) Then

                    If Not ((d1.Contains(3) And d2.Contains(6)) Or (d2.Contains(3) And d1.Contains(6))) Then
                        Continue For
                    End If
                End If
                If Not ((d1.Contains(4) And d2.Contains(9)) Or (d2.Contains(4) And d1.Contains(9))) Then

                    If Not ((d1.Contains(4) And d2.Contains(6)) Or (d2.Contains(4) And d1.Contains(6))) Then
                        Continue For
                    End If
                End If
                count += 1
            Next
        Next
        Console.WriteLine(DiceList.Count)
        Console.WriteLine(count)
        Console.ReadLine()
    End Sub

End Module
