Module Module1

    Sub Main()
        Dim input As Long = 600851475143
        While input <> 1
            Dim divider As Integer = 2

            While input Mod divider <> 0
                divider += 1
            End While
            input /= divider
            Console.WriteLine(divider)
        End While
        Console.ReadLine()



    End Sub

End Module
