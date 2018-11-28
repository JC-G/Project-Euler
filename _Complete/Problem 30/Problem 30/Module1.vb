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
    Function getDigitPowerSum(x As Integer, P As Integer) As Integer
        Dim T As Integer = 0
        For Each digit As Integer In getDigits(x)
            T += Math.Pow(digit, P)
        Next
        Return T
    End Function
    Sub Main()
        Dim T As Integer = 0
        For x As Integer = 2 To 999999
            If getDigitPowerSum(x, 5) = x Then
                T += x
            End If
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
