Module Module1
    Dim Ls As List(Of String) = New List(Of String)
    Sub Main()
        Dim f As String = My.Computer.FileSystem.ReadAllText("79.txt")

        For Each L As String In f.Replace(vbLf, "").Split(vbCr + vbLf)
            If Not Ls.Contains(L) Then
                Ls.Add(L)

            End If
        Next
        For Each S As String In Ls
            'Console.WriteLine(S)
        Next
        'count unique characters
        Dim s2 As String = f.Replace(vbLf, "").Replace(vbCr, "")
        Dim count As Integer = 0
        While s2.Length > 0
            Console.Write(s2(0) & ",")
            count += 1
            s2 = s2.Replace(s2(0), "")
        End While
        Console.WriteLine()
        Console.WriteLine("UNIQUE:" & count)
        Console.WriteLine("COUNT: " & Ls.Count)
        Console.ReadLine()
    End Sub

End Module
