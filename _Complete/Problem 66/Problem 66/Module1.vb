Module Module1
    'pell equation- convergent of continued fraction that satisfies p/q = x/y for x*x-d*y*y=1
    'http://mathworld.wolfram.com/Convergent.html use the recurrence for this
    'use the algorithm from continued fraction test (p64) to get convergent list- use mod for repeating if needed
    'biginteger IS necessary cause the numbers get stupid at 109 and 61

    Function GetEq(x As Numerics.BigInteger, y As Numerics.BigInteger, D As Integer) As Numerics.BigInteger
        Return x * x - D * y * y
    End Function
    Sub Main()
        Dim maxX As Numerics.BigInteger = 0
        Dim maxD As Integer = 0
        For x As Integer = 1 To 1000
            If Math.Pow(Math.Floor(Math.Sqrt(x)), 2) = x Then
                Continue For
            End If
            Dim CF As List(Of Integer) = GetRootFraction(x)
            Dim AL As List(Of Numerics.BigInteger) = New List(Of Numerics.BigInteger)
            Dim BL As List(Of Numerics.BigInteger) = New List(Of Numerics.BigInteger)
            AL.Add(1)
            BL.Add(0)
            AL.Add(GetNth(0, CF))
            BL.Add(1)
            Dim n As Integer = 0

            While GetEq(AL.Last, BL.Last, x) <> 1
                n += 1
                AL.Add(GetNth(n, CF) * AL.Last + AL(AL.Count - 2))
                BL.Add(GetNth(n, CF) * BL.Last + BL(BL.Count - 2))
            End While
            If AL.Last > maxX Then

                maxX = AL.Last
                maxD = x
            End If
        Next
        Console.WriteLine(maxX.ToString)
        Console.WriteLine(maxD)
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
