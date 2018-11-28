Module Module1
    Dim fn As Integer
    Dim fn1 As Integer = 1
    Dim fn2 As Integer = 1
    Dim n As Integer = 2
    Dim modulus As Integer = 1000000000
    Dim phi As Double = (1 + Math.Sqrt(5)) / 2
    Sub Main()
        Dim found As Boolean = False
        While Not found
            n += 1
            fn = (fn1 + fn2) Mod modulus
            fn2 = fn1
            fn1 = fn
            Dim fns As String = fn.ToString
            If fns.Distinct.Count = 9 And Not fns.Contains("0") Then
                Console.WriteLine(n)
                Dim res As Double = 1 / Math.Sqrt(5)
                For x As Integer = 1 To n
                    res *= phi
                    If res > modulus Then
                        res /= 10
                    End If
                Next
                Dim fnf As String = res.ToString.Substring(0, 9)
                If fnf.Distinct.Count = 9 And Not fns.Contains("0") Then
                    Console.WriteLine(res.ToString)
                    Console.ReadLine()

                End If




            End If

        End While
    End Sub

End Module
