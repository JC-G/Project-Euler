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
    Dim cache(1000000) As Integer
    Sub Main()
        Dim maxChainSize As Integer = 0
        Dim minElement As Integer = 1000001
        For x As Integer = 1 To 1000000
            Dim n As Integer = x
            Dim n0 As Integer = n
            Dim L As List(Of Integer) = New List(Of Integer)
            L.Add(n)
            Dim chainSize As Integer = 1
            While True
                n0 = n
                n = d(n)
                If n > 1000000 Then
                    Exit While
                End If
                If cache(n) > 0 Then
                    chainSize = cache(n)
                    Exit While
                End If
                If n = n0 Then
                    Exit While
                End If
                If L.Contains(n) Then
                    chainSize = L.Count - L.IndexOf(n)
                    Exit While
                End If
                L.Add(n)
            End While
            For Each I As Integer In L
                cache(I) = chainSize
            Next
            If chainSize > maxChainSize Then
                maxChainSize = chainSize
                Dim thisMin As Integer = 1000001
                For z As Integer = L.Count - chainSize To L.Count - 1
                    thisMin = Math.Min(thisMin, L(z))
                Next
                minElement = thisMin
            End If
        Next
        Console.WriteLine(minElement)
        Console.ReadLine()




    End Sub

End Module
