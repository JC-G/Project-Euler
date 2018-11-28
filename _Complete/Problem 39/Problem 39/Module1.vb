Module Module1
    'first do math with a^2+b^2=c^2,a+b+c=n to eliminate c
    'a+b is always less than n
    Sub Main()
        Dim result As Integer = 0
        Dim maxTotal As Integer = 0
        For n As Integer = 1 To 1000
            Dim total As Integer = 0
            For a As Integer = 1 To n
                For b As Integer = 1 To a 'is this horrible? maybe
                    If 2 * a * b - 2 * a * n - 2 * b * n + n * n = 0 Then
                        Console.WriteLine(a & " " & b)
                        total += 1
                    End If
                Next
            Next
            If total > maxTotal Then
                Console.WriteLine(n)
                result = n
                maxTotal = total
            End If
        Next
        Console.WriteLine(result)
        Console.ReadLine()
    End Sub

End Module
