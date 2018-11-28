Module Module1
    'n=7 by trial/error
    Function LexoPerm(S As String, Optional H As String = "") As List(Of String)
        Dim L As List(Of String) = New List(Of String)
        If S.Length = 1 Then
            L.Add(H + S)
            Return L
        End If
        For x As Integer = 0 To S.Length - 1
            Dim s2 As String = S.Remove(x, 1)
            L.AddRange(LexoPerm(s2, H + S(x)).AsEnumerable)
        Next
        Return L
    End Function
    Public Function IsPrime(x As Integer) As Boolean
        If x < 2 Then Return False
        Dim root As Integer = Math.Floor(Math.Sqrt(x))
        For t As Integer = 2 To root
            If x Mod t = 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Sub Main()

        For Each x As Integer In LexoPerm(7654321)
            If IsPrime(x) Then
                Console.WriteLine(x)
            End If
        Next
        Console.WriteLine("DONE")
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
