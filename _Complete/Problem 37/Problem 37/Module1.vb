Module Module1
    'start with the assumption all less than 1M
    Public Function PrimeSieve(x As Integer) As SortedSet(Of Integer) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Integer) = New SortedSet(Of Integer)
        For t As Integer = 2 To x
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

    Function makeInteger(L As List(Of Integer)) 'perhaps a string is not the best way to do this
        Dim S As String = ""
        For Each digit As Integer In L
            S += digit.ToString
        Next
        Return Convert.ToInt32(S)
    End Function

    Function getDigits(x As Integer) As List(Of Integer)
        Dim workingValue As Integer = x
        Dim digits As List(Of Integer) = New List(Of Integer)
        While workingValue > 0
            digits.Add(workingValue Mod 10)
            workingValue \= 10
        End While
        digits.Reverse()
        Return digits
    End Function

    Sub Main()
        Dim S As SortedSet(Of Integer) = PrimeSieve(999999)
        Dim T As Integer = 0
        For Each prime As Integer In S
            If prime < 10 Then
                Continue For
            End If
            Dim isTrunc As Boolean = True
            'test left truncate
            Dim baseDigits As List(Of Integer) = getDigits(prime)

            For x As Integer = 0 To baseDigits.Count - 2
                baseDigits.RemoveAt(0)
                If Not S.Contains(makeInteger(baseDigits)) Then
                    isTrunc = False
                    Exit For
                End If
            Next
            If isTrunc Then
                'now right trunc
                baseDigits = getDigits(prime)
                For x As Integer = 0 To baseDigits.Count - 2
                    baseDigits.RemoveAt(baseDigits.Count - 1)
                    If Not S.Contains(makeInteger(baseDigits)) Then
                        isTrunc = False
                        Exit For
                    End If

                Next
            End If
            If isTrunc Then
                Console.WriteLine(prime)
                T += prime
            End If

        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
