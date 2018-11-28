Module Module1
    Dim bTab(100, 100) As Long

    Function B(n As Long, k As Long) As Long
        If bTab(n, k) <> 0 Then
            Return bTab(n, k)
        End If
        If n = 1 Then
            Return k

        End If
        If k = 1 Then
            Return 1

        End If

        Dim S As Long = 0
        For j = 1 To k
            S += B(n - 1, j)
        Next

        If bTab(n, k) = 0 Then
            bTab(n, k) = S
        End If
        Return S
    End Function

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
    Function Inc(n As Integer) As Long
        If n = 1 Then
            Return 9
        End If
        Dim T As Long = 0
        For k = 1 To 9
            T += B(n - 1, k)
        Next
        Return T + Inc(n - 1)
    End Function
    Function Dec(n As Integer) As Long

        If n = 1 Then
            Return 9
        End If
        Dim T As Long = 0
        For k = 2 To 10
            T += B(n - 1, k)
        Next
        Return T + Dec(n - 1)
    End Function

    Function Tot(n As Integer) As Long
        Return Inc(n) + Dec(n) - 9 * n
    End Function
    Sub Main()
        Dim T As Long = 0
        Dim k As Integer = 100
        Console.WriteLine(Tot(k))
        Console.ReadLine()
    End Sub

End Module
