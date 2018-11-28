Module Module1

    Sub Main()
        'go up to 999
        Dim result As Integer = 0 'max 999999999 < 2B
        For x As Integer = 1 To 9999
            'compile a string and check for duplicates
            Dim numStr As String = ""
            Dim multiplier As Integer = 1
            While numStr.Length < 9
                numStr += (multiplier * x).ToString

                multiplier += 1
            End While
            'check that numstr has no duplicates
            If numStr.Distinct.Count = numStr.Length And Not numStr.Contains(0) Then
                Console.WriteLine(x & " " & numStr)

            End If
        Next
        Console.ReadLine()

    End Sub

End Module
