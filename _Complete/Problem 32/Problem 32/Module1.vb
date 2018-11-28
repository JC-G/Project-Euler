Module Module1
    Function getProperDivisors(x As Integer) As List(Of Integer) 'MODIFIED TO ONLY DO HALF OF THEM!!!!
        Dim L As List(Of Integer) = New List(Of Integer)
        For t As Integer = 1 To Math.Floor(Math.Sqrt(x))
            If x Mod t = 0 Then
                L.Add(t)
                'If x / t <> t And t <> 1 Then
                '    L.Add(x / t)

                'End If
            End If
        Next
        Return L
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
    Function ContainsDuplicates(Of T)(x As List(Of T))
        Return x.Distinct.Count <> x.Count
    End Function

    Sub Main()
        Dim addedNumbers As SortedSet(Of Integer) = New SortedSet(Of Integer)

        Dim T As Integer = 0
        For x As Integer = 1000 To 9999

            Dim usedDigits As List(Of Integer) = getDigits(x)
            If ContainsDuplicates(usedDigits) Or usedDigits.Contains(0) Then
                Continue For
            End If

            ' does this number have 2 factors with 5 digits total?
            Dim divisors As List(Of Integer) = getProperDivisors(x)
            For Each D As Integer In divisors
                usedDigits = getDigits(x)
                usedDigits.AddRange(getDigits(D).AsEnumerable)
                usedDigits.AddRange(getDigits(x / D).AsEnumerable)
                If Not ContainsDuplicates(usedDigits) And Not usedDigits.Contains(0) And usedDigits.Count = 9 Then

                    Console.WriteLine(x & " " & D & " " & x / D)
                    T += x
                    Exit For
                End If
            Next





        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
