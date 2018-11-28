Module Module1

    Sub Main()
        Dim Total As Integer = 0
        Dim sets As String = My.Computer.FileSystem.ReadAllText("p105_sets.txt")
        For Each line As String In sets.Replace(vbCr, "").Split(vbLf)

            Dim thisSet As SortedSet(Of Integer) = New SortedSet(Of Integer)
            For Each I As String In line.Split(",")
                thisSet.Add(Convert.ToInt32(I))
            Next
            'verify rule 2 first using upper and lower sums
            Dim canDo As Boolean = True
            Dim lowerTotal As Integer = 0
            Dim upperTotal As Integer = 0
            For n As Integer = 0 To thisSet.Count - 1
                lowerTotal += thisSet(n)
                If upperTotal >= lowerTotal Then
                    canDo = False
                    Exit For
                End If
                upperTotal += thisSet(thisSet.Count - 1 - n)
            Next

            If Not canDo Then Continue For

            'Now verify rule 1
            Dim PS As List(Of Integer) = New List(Of Integer)
            PS.Add(0)
            Dim PS2 As List(Of Integer) = New List(Of Integer)
            For Each I As Integer In thisSet

                For Each I2 As Integer In PS
                    If PS.Contains(I + I2) Then
                        canDo = False
                        Exit For
                    Else
                        PS2.Add(I + I2)
                    End If
                Next
                If canDo = False Then Exit For
                For Each I2 As Integer In PS2
                    PS.Add(I2)
                Next
            Next

            If canDo = False Then Continue For

            For Each I As Integer In thisSet
                Total += I
            Next
        Next
        Console.WriteLine(Total)
        Console.ReadLine()

    End Sub

End Module
