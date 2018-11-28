Module Module1


    Dim PFDict As SortedDictionary(Of Integer, List(Of Integer)) = New SortedDictionary(Of Integer, List(Of Integer))
    Public Function getPrimeFactorization(x As Integer) As List(Of Integer)

        Dim r As List(Of Integer) = New List(Of Integer)
        Dim isPrime = True
        Dim total As Integer = x
        While Not total = 1
            If PFDict.ContainsKey(total) Then

                r = New List(Of Integer)(r.Union(PFDict(total)).Distinct)
                PFDict.Add(x, r)
                Return r

            End If

            For iter As Integer = 2 To Math.Ceiling(x / 2)
                If total Mod iter = 0 Then
                    isPrime = False
                    If Not r.Contains(iter) Then
                        r.Add(iter)

                    End If
                    total /= iter
                    Exit For
                End If
            Next
            If isPrime Then
                r.Add(x)
                Exit While
            End If
        End While
        PFDict.Add(x, r)
        Return r
    End Function
    Sub Main()
        Dim maxVal As Double = 0
        Dim bestN As Integer = 0
        For n As Integer = 2 To 1000000

            'Console.WriteLine(n)
            Dim P As Double = n
            For Each Prime As Integer In getPrimeFactorization(n)
                P *= (1 - 1 / Prime)
            Next
            Dim val As Double = n / P
            If val > maxVal Then
                maxVal = val
                bestN = n
            End If
        Next
        Console.WriteLine(bestN)
        Console.WriteLine(maxVal)
        Console.ReadLine()
    End Sub

End Module
