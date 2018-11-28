Module Module1
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
    Function GetStringValue(s As String)
        Dim T As Integer = -48 * s.Count
        For Each c As Char In s
            T += Convert.ToInt32(c)
        Next
        Return T
    End Function
    Sub Main()
        Dim max As Long = 0
        Dim L As List(Of String) = LexoPerm("123456789:") ': is ten because it is the value of 10
        Console.WriteLine("DONE LP" & L.Count)
        For Each S As String In L
            Dim V As Integer = -1 'unset value
            Dim allowable As Boolean = True
            For x As Integer = 0 To 4
                Dim testString As String = S(x) + S(x + 5)
                If x = 4 Then
                    testString += S(5)
                Else
                    testString += S(x + 6)
                End If
                If V = -1 Then
                    V = GetStringValue(testString)
                Else
                    If GetStringValue(testString) <> V Then
                        allowable = False
                        Exit For
                    End If
                End If


            Next
            If allowable Then
                Console.WriteLine(S)
                'start with the lowest outer number rather than any
                Dim minOuter As Integer = 999
                Dim outerStart As Integer = 0
                For x As Integer = 0 To 4
                    If GetStringValue(S(x)) < minOuter Then
                        outerStart = x
                        minOuter = GetStringValue(S(x))
                    End If
                Next
                Dim finalS As String = ""
                For x As Integer = 0 To 4
                    Dim xT As Integer = (x + outerStart) Mod 5
                    finalS += S(xT) + S(xT + 5)
                    If xT = 4 Then
                        finalS += S(5)
                    Else
                        finalS += S(xT + 6)
                    End If
                Next
                finalS = finalS.Replace(":", "10")
                If finalS.Length = 16 Then
                    If Convert.ToInt64(finalS) > max Then
                        max = Convert.ToInt64(finalS)
                    End If

                End If
            End If
        Next
        Console.WriteLine(max)
        Console.ReadLine()
    End Sub

End Module
