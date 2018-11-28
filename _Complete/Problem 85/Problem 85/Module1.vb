Module Module1
    'number of rectangles in mxn = m(m+1)n(n+1)/4
    Sub Main()
        Dim absD As Integer = 9999999
        Dim upperBound As Integer = 9999999
        Dim lim As Integer = 8000000
        Dim bestarea As Integer = 0
        For m As Long = 1 To lim
            Dim k As Long = lim / (m * (m + 1))
            Dim nLim As Integer = (-1 + Math.Sqrt(1 + k * k)) / 2
            For n As Integer = m To 2 + nLim 'add a couple more for safety
                Dim rect4 As Integer = m * n * (m + 1) * (n + 1)
                If rect4 > upperBound Then
                    Exit For
                End If

                If Math.Abs(lim - rect4) < absD Then
                    If rect4 < upperBound And rect4 > lim Then
                        upperBound = rect4
                    End If
                    absD = Math.Abs(lim - rect4)
                    bestarea = m * n
                    Console.WriteLine(absD & " : " & bestarea)
                    'Console.Beep()
                End If
            Next
        Next
        Console.ReadLine()
    End Sub

End Module
