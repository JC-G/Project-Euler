Module Module1
    Function Totient(x As Integer) As Integer
        Dim D As Double = x
        Dim tmp As Integer = x
        For iter As Integer = 2 To tmp
            Dim canDivide As Boolean = False
            While tmp Mod iter = 0
                canDivide = True
                tmp \= iter
            End While
            If canDivide Then
                D *= (1 - 1 / iter)

            End If
            If tmp = 1 Then Exit For
        Next
        Return Math.Round(D)
    End Function
    'sum of totient from 2 to 1000000
    Sub Main()
        Dim T As Long = 0
        For x As Integer = 2 To 1000000
            T += Totient(x)
        Next
        Console.WriteLine(T)
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
