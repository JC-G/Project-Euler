Module Module1

    Dim S As List(Of SortedSet(Of Integer)) = New List(Of SortedSet(Of Integer))
    Public Function concat(x As Long, y As Long) As Long
        Dim c As Long = y
        While c > 0
            x *= 10
            c \= 10
        End While
        Return x + y
    End Function

    Sub TryHead(head As Integer, used As Boolean(), L As List(Of Integer))
        If L.Count = 6 Then
            If L.First \ 100 = L.Last Mod 100 Then
                Console.Beep()
                Dim total As Integer = 0
                For Each I As Integer In L
                    Console.Write(I & ",")
                    total += I
                Next
                Console.WriteLine(total)
                'Console.ReadLine()
            End If
        End If

        For tail As Integer = 10 To 99
            For t As Integer = 0 To 5
                If Not used(t) AndAlso S(t).Contains(concat(head, tail)) AndAlso Not L.Contains(concat(head, tail)) Then
                    Dim used2(5) As Boolean
                    Array.Copy(used, used2, used.Count)
                    Dim L2 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)
                    L2.Add(concat(head, tail))
                    used2(t) = True
                    TryHead(tail, used2, L2)
                End If
            Next
        Next


    End Sub
    Sub Main()
        Dim L As List(Of Integer) = New List(Of Integer) 'where the cyclic numbers will be stored
        For x As Integer = 3 To 8
            S.Add(New SortedSet(Of Integer))
        Next
        Dim it As Integer = 1
        While (it * (it + 1)) / 2 < 10000
            S(0).Add((it * (it + 1)) / 2)
            S(1).Add(it * it)
            S(2).Add((it * (3 * it - 1)) / 2)
            S(3).Add(it * (2 * it - 1))
            S(4).Add((it * (5 * it - 3)) / 2)
            S(5).Add(it * (3 * it - 2))


            it += 1
        End While
        Console.WriteLine("All numbers generated")
        Dim used() As Boolean = {False, False, False, False, False, False}
        For startingHead As Integer = 10 To 99
            L.Clear()
            used = {False, False, False, False, False, False}
            'for each level where correct, update used and list and reset counter to 10, if you get to 6 then print else go back to other counter
            TryHead(startingHead, used, L)





        Next

        Console.ReadLine()
    End Sub

End Module
