Module Module1

    Public Function PrimeSieve(x As Integer, Optional start As Integer = 2) As SortedSet(Of Integer) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Integer) = New SortedSet(Of Integer)
        For t As Integer = start To x
            L.Add(t)
        Next
        For testValue As Integer = 2 To Math.Floor(Math.Sqrt(x))
            For testNumber As Integer = 2 * testValue To x Step testValue
                If L.Contains(testNumber) Then
                    L.Remove(testNumber)
                End If
            Next
        Next
        Return L
    End Function
    Sub Main()
        Dim primes As SortedSet(Of Integer) = PrimeSieve(1000000) 'generate primes under 1M
        'Dim failed As SortedSet(Of Integer) = New SortedSet(Of Integer)
        Console.WriteLine(primes.Count)
        For Each p As Integer In primes
            Dim s As String = p.ToString
            Dim L As Integer = s.Length

            For x As Integer = 1 To (1 << L) - 1 'FOR EACH MASK

                Dim failureCount As Integer = 0
                Dim mask As String = Convert.ToString(x, 2)
                While mask.Length < L
                    mask = "0" + mask
                End While

                Dim res As Integer = 99999999
                Dim newString As String = ""
                For testDigit As Integer = 0 To 9
                    newString = ""
                    For c As Integer = 0 To L - 1
                        If mask(c) = "0" Then
                            newString += s(c)
                        Else
                            newString += testDigit.ToString
                        End If
                    Next

                    'Console.WriteLine(newString)
                    If newString(0) = "0" OrElse Not primes.Contains(Convert.ToInt32(newString)) Then
                        failureCount += 1
                        If failureCount > 2 Then
                            Exit For 'dont bother checking this mask-prime any more

                        End If
                    Else

                        res = Math.Min(res, Convert.ToInt32(newString))
                    End If

                Next
                If failureCount <= 2 Then
                    Console.WriteLine(res & " " & mask)
                    Console.ReadLine()
                End If
                'create the number
                'Console.WriteLine(mask)
            Next
        Next





        Console.WriteLine("DONE")
        Console.ReadLine()
    End Sub

End Module
