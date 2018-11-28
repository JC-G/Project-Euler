Module Module1
    Dim Phi As Double = 1.6180339887498949
    'nlog(phi)-0.5log(5) >= 1000
    Sub Main()
        Dim n As Integer = 1
        While n * Math.Log10(Phi) - 0.5 * Math.Log10(5) < 999
            Console.WriteLine(n * Math.Log10(Phi) - 0.5 * Math.Log10(5))
            n += 1
        End While
        Console.WriteLine(n)
        Console.ReadLine()
    End Sub

End Module
