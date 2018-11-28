Module Module1
    Dim target As Integer = 5
    Dim result As Integer = 0

    Dim L As List(Of Integer) = New List(Of Integer)


    Public Sub RecursionTest(Optional currentSum As Integer = 0, Optional lastTerm As Integer = -1)
        Dim max As Integer
        If lastTerm = -1 Then
            max = target - 1
        Else
            max = lastTerm
        End If
        If currentSum = target Then
            result += 1
            'For Each P As Integer In L
            'Console.Write(P & ",")
            'Next
            'Console.WriteLine()
            Return
        End If

        For z As Integer = 1 To max
            If currentSum + z > target Then
                Continue For
            End If

            RecursionTest(currentSum + z, z)
        Next

    End Sub


    Sub Main()
        target = 100
        RecursionTest()
        Console.Beep()
        Console.WriteLine(result)
        Console.ReadLine()
    End Sub

End Module
