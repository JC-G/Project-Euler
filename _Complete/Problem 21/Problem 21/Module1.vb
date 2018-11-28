Module Module1


    Function listSum(L As List(Of Integer)) As Integer
        Dim T As Integer = 0
        For Each I As Integer In L
            T += I
        Next
        Return T
    End Function
    Function getProperDivisors(x As Integer) As List(Of Integer) 'find all combinations of prime factors
        Dim L As List(Of Integer) = New List(Of Integer)
        For t As Integer = 1 To Math.Floor(Math.Sqrt(x))
            If x Mod t = 0 Then
                L.Add(t)
                If x / t <> t And t <> 1 Then
                    L.Add(x / t)

                End If
            End If
        Next
        Return L
    End Function
    Function d(n As Integer)
        Return listSum(getProperDivisors(n))
    End Function
    Sub Main()
        Dim T As Integer
        Console.WriteLine(d(284))
        For x As Integer = 1 To 9999
            If d(d(x)) = x And x <> d(x) Then
                T += x
            End If
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
