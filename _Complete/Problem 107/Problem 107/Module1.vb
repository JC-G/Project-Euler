Module Module1
    Dim network(39, 39) As Integer
    Dim arcMax As Integer = 39
    Dim arcCount As Integer = 0
    Dim total As Integer = 0
    Dim skipRows As List(Of Integer) = New List(Of Integer)
    Dim useCols As List(Of Integer) = New List(Of Integer)
    Sub Main()
        useCols.Add(0)
        skipRows.Add(0)
        Dim fileText As String = My.Computer.FileSystem.ReadAllText("p107_network.txt")
        Dim y As Integer = -1
        For Each line As String In fileText.Replace(vbCr, "").Split(vbLf)

            y += 1
            If y < 40 Then
                Dim x As Integer = -1
                For Each entry As String In line.Split(",")
                    x += 1
                    If entry = "-" Then
                        Continue For
                    End If
                    network(x, y) = Convert.ToInt32(entry)
                Next

            End If
        Next
        Dim treeTotal As Integer = 0
        While arcCount < arcMax

            Dim min As Integer = 999999
            Dim bestx As Integer = 0
            Dim besty As Integer = 0
            For Each x As Integer In useCols
                For y2 As Integer = 0 To 39
                    If skipRows.Contains(y2) Then
                        Continue For
                    End If
                    If network(x, y2) <= 0 Then
                        Continue For
                    End If
                    If network(x, y2) < min Then
                        min = network(x, y2)
                        bestx = x
                        besty = y2
                    End If
                Next
            Next
            If min = 999999 Then
                Exit While
            End If
            treeTotal += min
            Console.WriteLine(min & " " & bestx & " " & besty)
            useCols.Add(besty)
            skipRows.Add(besty)
            arcCount += 1
        End While
        Dim netTotal As Integer = 0
        For x As Integer = 0 To 39
            For y2 As Integer = 0 To x
                netTotal += network(x, y2)

            Next
        Next

        Console.WriteLine(netTotal - treeTotal)
        Console.ReadLine()

    End Sub

End Module
