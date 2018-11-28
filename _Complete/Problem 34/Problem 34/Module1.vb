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
    Function Factorial(x) As Integer
        Dim Total As Integer = 1
        If x = 1 Or x = 0 Then
            Return 1 '0! is defined as 1
        End If
        For t As Integer = x To 1 Step -1
            Total *= t
        Next
        Return Total
    End Function
    Sub Main()
        Dim Total As Integer = 0
        For x As Integer = 3 To 2540160 'possibly reduce this a lot
            Dim digits As List(Of Integer) = getDigits(x)
            Dim T As Integer = 0
            For Each digit In digits
                T += Factorial(digit)
            Next
            If T = x Then
                Console.WriteLine(x)
                Total += T
            End If
        Next
        Console.WriteLine(Total)
        Console.ReadLine()
    End Sub

End Module
