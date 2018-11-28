Module Module1
    Function f(x As Long) As Long
        Dim r As Long = 0
        For t As Long = 0 To 10
            r += (-x) ^ t
        Next
        Return r
    End Function

    Function c(x As Long, p As Long, k As Long) As Long
        Dim D As Double = 1
        For n As Long = 1 To p - 1
            D *= (x - n) / (p - n)
        Next
        For n As Long = p + 1 To k
            D *= (x - n) / (p - n)
        Next
        Return Math.Round(D)
    End Function
    Function L(x, k) As Long
        Dim S As Long = 0
        For p As Long = 1 To k
            S += f(p) * c(x, p, k)
        Next
        Return S
    End Function
    Sub Main()
        Dim T As Long = 0
        For N As Long = 1 To 10
            T += L(N + 1, N)
        Next
        Console.WriteLine(T)
        Console.ReadLine()

        'there exists a unique polynomial of degree n-1 through n points
        'find this polynomial for n = 0 to 10 then find the first term it fails
        'done in desmos lol
    End Sub

End Module
