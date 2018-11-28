Module Module1
    Public Function factorial(x As Integer) As Integer
        If x <= 0 Then Return 1
        Dim T As Integer = 1
        For z As Integer = 1 To x
            T *= z
        Next
        Return T
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
    Sub Main()
        Dim F(10) As Integer
        Dim StopTerms() As Integer = {1, 2, 145, 1454, 45361, 45362}
        For x As Integer = 0 To 10
            F(x) = factorial(x)

        Next
        Dim count As Integer = 0
        For x As Integer = 1 To 999999
            Dim TermCount As Integer = 1
            Dim Term As Integer = x

            While True
                If StopTerms.Contains(Term) Then
                    Exit While
                End If
                Dim D As List(Of Integer) = getDigits(Term)
                Dim Total As Integer = 0
                For Each digit As Integer In D
                    Total += F(digit)
                Next
                If Term = Total Then
                    Exit While
                End If
                Term = Total
                TermCount += 1

            End While
            If TermCount = 60 Then
                count += 1
            End If
            'Console.WriteLine(x & ":" & TermCount)
        Next
        Console.Beep()
        Console.WriteLine(count)
        Console.ReadLine()
    End Sub

End Module
