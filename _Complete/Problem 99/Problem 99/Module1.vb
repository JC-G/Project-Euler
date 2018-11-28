Module Module1

    Sub Main()
        Dim file As String = My.Computer.FileSystem.ReadAllText("p099_base_exp.txt")
        Dim max As Double = 0
        Dim maxLn As Integer = 0
        file.Replace(vbCr, "")
        Dim lines() As String = file.Split(vbLf)
        Dim idx As Integer = 1
        For Each line As String In lines
            Dim nos() As String = line.Split(",")
            Dim base As Double = Convert.ToDouble(nos(0))
            Dim exp As Double = Convert.ToDouble(nos(1))
            Dim log As Double = Math.Log(base) * exp
            If log > max Then
                max = log
                maxLn = idx
            End If
            idx += 1
        Next
        Console.WriteLine(maxLn)
        Console.ReadLine()

    End Sub

End Module
