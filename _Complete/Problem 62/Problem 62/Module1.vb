Module Module1
    Function StrSort(x As String)
        Dim A As Char() = x.ToCharArray
        Array.Sort(A)
        Return New String(A)
    End Function
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
    Sub Main()
        Dim sortedCubes As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Dim firsts As Dictionary(Of String, Long) = New Dictionary(Of String, Long)
        For x As Long = 1 To 100000
            Dim I As Long = x * x * x

            Dim sortedString = StrSort(I)
            If Not sortedCubes.ContainsKey(sortedString) Then
                firsts.Add(sortedString, I)
                sortedCubes.Add(sortedString, 1)
            Else
                sortedCubes(sortedString) += 1
            End If

        Next
        For Each I As KeyValuePair(Of String, Integer) In sortedCubes
            If I.Value = 5 Then
                Console.WriteLine(firsts(I.Key))

            End If

        Next
        Console.ReadLine()
    End Sub

End Module
