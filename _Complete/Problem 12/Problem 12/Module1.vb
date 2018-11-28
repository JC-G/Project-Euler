Module Module1

    Sub Main()
        Dim target As Integer = 500
        Dim T As Integer = 1
        Dim x As Integer = 0
        While T <= target
            x += 1
            T = getFactorCount(getPrimeFactorization(triangular(x)))

            'Console.WriteLine(T)
        End While
        'Dim D As Dictionary(Of Integer, Integer) = getPrimeFactorization(triangular(x))

        Console.WriteLine(triangular(x))



        Console.Read()
    End Sub

    Function getPrimeFactorization(x As Integer) As Dictionary(Of Integer, Integer) 'p,c
        Dim D As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)
        Dim T As Integer = x
        While Not T = 1
            For i As Integer = 2 To x
                If T Mod i = 0 Then
                    T /= i
                    If Not D.ContainsKey(i) Then
                        D(i) = 1
                    Else
                        D(i) += 1
                    End If

                    Exit For
                End If
            Next
        End While
        Return D
    End Function

    Function getFactorCount(D As Dictionary(Of Integer, Integer)) As Integer
        Dim T As Integer = 1
        For Each K As KeyValuePair(Of Integer, Integer) In D
            T *= (1 + K.Value)
        Next
        Return T
    End Function

    Function triangular(x As Integer)
        Return (x * (x + 1)) / 2
    End Function

End Module
