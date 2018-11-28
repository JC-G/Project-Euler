Module Module1
    Dim Total As Integer = 999
    Public Sub writelist(L As List(Of Integer))
        Dim T As Integer = 0
        For Each P As Integer In L
            Console.Write(P)
            T += P
        Next
        Console.WriteLine(" TOTAL: " & T)
    End Sub
    Public Sub FindSets(L As List(Of Integer), PartialSums As SortedSet(Of Integer))

        If L.Count = 7 Then
            Dim T As Integer = 0
            For Each I As Integer In L
                T += I
            Next
            If T < Total Then
                Total = T
                writelist(L)
            End If
            Return
        End If

        Dim lastEl As Integer = 1
        If L.Count > 0 Then
            lastEl = L.Last
        End If

        For z As Integer = lastEl To 99 '
            'perform partial sum check - handles subset sum problem
            Dim newPS As SortedSet(Of Integer) = New SortedSet(Of Integer)(PartialSums.AsEnumerable)
            Dim canDo As Boolean = True
            For Each S As Integer In PartialSums
                If PartialSums.Contains(S + z) Then
                    canDo = False
                    Exit For
                Else
                    newPS.Add(S + z)
                End If
            Next
            If Not canDo Then
                Continue For
            End If
            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)


            L3.Add(z)
            'now find a solution to rule 2
            'if the largest 2 set is greater than the smallest 3 set then exit
            'if the largest n set is greater than the smallest (n+1) set then exit
            Dim lowerTotal As Integer = 0
            Dim upperTotal As Integer = 0
            For n As Integer = 0 To L3.Count - 1
                lowerTotal += L3(n)
                If upperTotal >= lowerTotal Then
                    canDo = False
                    Exit For
                End If
                upperTotal += L3(L3.Count - 1 - n)
            Next

            If Not canDo Then
                Continue For
            End If

            'For n As Integer = 1 To L.Count - 1
            'find the smallest
            'compare to previous largest
            'else find new largest

            'Next










            FindSets(L3, newPS)

        Next

    End Sub
    Sub Main()
        Dim ps As SortedSet(Of Integer) = New SortedSet(Of Integer)
        ps.Add(0)
        FindSets(New List(Of Integer), ps)
        Console.ReadLine()
    End Sub

End Module
