Module Module1

    Sub Main()
        Dim T As Integer = 0
        For x As Integer = 1 To 999999 Step 2 'no even numbers (leading 0)

            Dim asString As String = x.ToString
            If asString = StrReverse(asString) Then
                Dim binString = Convert.ToString(x, 2)
                If binString = StrReverse(binString) Then
                    T += x
                End If
            End If
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
