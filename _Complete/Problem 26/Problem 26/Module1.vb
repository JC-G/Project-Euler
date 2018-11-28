Module Module1
    'https://en.wikipedia.org/wiki/Repeating_decimal
    'the period of a prime power:
    'period(p^n)=p^(n-1)period(p) unless p^n divides 10^(p-1)-1, then period(p^n)=period(p)
    'period of product of prime powers(1/p^n*q^m) = lcm(period(p^m),period(q^m))
    'period of number not coprime to 10- divide by 2 or 5 until it is coprime then continue
    'period of reciprocal of prime = ord-p(10)

    'The length of the repetend (period of the repeating decimal segment) of 1/p is equal to the order of 10 modulo p.



    'For denominator q, the period length is the smallest k such that q divides 10^k-1. E.g. for 41, the period length is 5 because 41 divides 99999.
    'if q divides 10^k-1 then 10^k-1 mod q = 0 hence 10^k mod q = 1
    Function period(x As Integer) As Integer
        While x Mod 5 = 0
            x /= 5
        End While
        While x Mod 2 = 0
            x /= 2
        End While
        If x = 1 Then Return 0

        'find largest k such that 10^k mod q = 1
        Dim k As Integer = 1 'we need to start with 0
        Dim M As Integer = 1
        Do
            M = (M * 10) Mod x
            k += 1
        Loop While M <> 1
        Return k - 1


    End Function
    Sub Main()
        Dim maxP As Integer = 0
        Dim d As Integer = 0
        For x As Integer = 1 To 999
            If period(x) > maxP Then
                maxP = period(x)
                d = x
                Console.WriteLine(d & " Has Period " & maxP)
            End If


        Next
        Console.ReadLine()
    End Sub

End Module
