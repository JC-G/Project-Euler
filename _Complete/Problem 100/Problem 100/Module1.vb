Module Module1

    Sub Main()
        'lol could have just done this https://oeis.org/A029549
        'rather than the rabbit hole of pell equations ect
        Dim found As Boolean = False
        Dim lim As Numerics.BigInteger = New Numerics.BigInteger(1000000000000)
        Dim p As Numerics.BigInteger = 1
        Dim v As Numerics.BigInteger = 1
        Dim pn As Numerics.BigInteger = p
        Dim vn As Numerics.BigInteger = v
        While Not found
            p = pn
            v = vn
            pn = p + 2 * v
            vn = p + v
            Dim T1 As Numerics.BigInteger = vn * (pn + vn)
            Dim T2 As Numerics.BigInteger = (pn + vn) * (pn + vn) - vn * vn
            If T1 > lim Or T2 > lim Then
                Dim N As Numerics.BigInteger = (pn + vn) * (pn + vn) + vn * vn
                Console.WriteLine("A= " & ((1 + N) / 2).ToString)
                Console.ReadLine()
            End If






        End While

        Console.ReadLine()
    End Sub

End Module
