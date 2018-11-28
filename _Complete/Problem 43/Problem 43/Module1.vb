Module Module1
    Dim checkArray() As Integer = {2, 3, 5, 7, 11, 13, 17}
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
    Function isOK(S As String) As Boolean
        If S(0) = "0" Then
            Return False
        End If
        For x As Integer = 0 To 6
            If Convert.ToInt32(S.Substring(x + 1, 3)) Mod checkArray(x) <> 0 Then
                Return False
                Exit For
            End If
        Next
        Return True
    End Function
    Sub Main()
        Console.WriteLine(isOK("1406357289"))
        Dim L As List(Of String) = LexoPerm("0123456789")
        Dim count As Long = 0
        For Each S As String In L
            'if the first digit of S = 0 then fix it


            If isOK(S) Then
                count += Convert.ToInt64(S)
            End If


        Next
        Console.WriteLine(count)
        Console.ReadLine()
    End Sub

End Module
