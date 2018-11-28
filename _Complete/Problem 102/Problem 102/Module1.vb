Module Module1

    Sub Main()
        Dim T As Integer = 0
        Dim f As String = My.Computer.FileSystem.ReadAllText("p102_triangles.txt")
        For Each L As String In f.Replace(vbCr, "").Split(vbLf)

            Dim numbers As String() = L.Split(",")
            If Not numbers.Count = 6 Then Continue For
            Dim A As Double = numbers(2) - numbers(0)
            Dim B As Double = numbers(3) - numbers(1)
            Dim C As Double = numbers(4) - numbers(0)
            Dim D As Double = numbers(5) - numbers(1)
            Dim X As Double = -numbers(0)
            Dim Y As Double = -numbers(1)
            Dim det As Double = A * D - B * C
            Dim Xn As Double = (D * X - C * Y) / det
            Dim Yn As Double = (A * Y - B * X) / det
            If Xn > 0 And Yn > 0 And Xn + Yn < 1 Then
                Console.WriteLine("Y")
                T += 1
            Else
                Console.WriteLine("N")
            End If
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
