Module Module1
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
    Function makeInteger(L As List(Of Integer)) 'perhaps a string is not the best way to do this
        Dim S As String = ""
        For Each digit As Integer In L
            S += digit.ToString
        Next
        Return Convert.ToInt32(S)
    End Function
    Function getRotations(x As Integer) As List(Of Integer)
        Dim digits As List(Of Integer) = getDigits(x)
        Dim L As List(Of Integer) = New List(Of Integer)
        L.Add(x)
        For rotation As Integer = 1 To digits.Count - 1
            Dim tmpItem = digits(0)
            digits.RemoveAt(0)
            digits.Add(tmpItem)
            L.Add(makeInteger(digits))
        Next

        Return L
    End Function

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
    Sub Main()

        Dim count As Integer = 0
        Dim allPrimes As SortedSet(Of Integer) = PrimeSieve(999999)
        For Each P As Integer In allPrimes
            'is it circular
            If P < 10 Then
                count += 1 'yes
                Continue For
            End If
            Dim rotations As List(Of Integer) = getRotations(P)
            Dim isCircular As Boolean = True
            For Each rotation As Integer In rotations
                If Not allPrimes.Contains(rotation) Then
                    isCircular = False
                    Exit For
                End If

            Next

            If isCircular Then
                count += 1
            End If


        Next
        Console.WriteLine(count)

        Console.ReadLine()

    End Sub

End Module
