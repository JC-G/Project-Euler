Module Module1
    Public Function isPrime(x As Integer) As Boolean
        If x < 2 Then Return False
        Dim root As Integer = Math.Floor(Math.Sqrt(x))
        For t As Integer = 2 To root
            If x Mod t = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Sub Main()
        Dim Total As Integer = 1
        Dim Prime As Integer = 0
        Dim SqSz As Integer = 1
        Do
            SqSz += 2
            For x As Integer = 0 To 3
                If isPrime(SqSz * SqSz - x * SqSz + x) Then
                    Prime += 1
                End If
                Total += 1
            Next
        Loop While Prime / Total >= 0.1
        Console.WriteLine(SqSz)
        Console.ReadLine()
    End Sub

End Module
