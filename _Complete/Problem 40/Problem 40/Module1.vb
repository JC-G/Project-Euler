Module Module1

    Sub Main()
        'd1 and d10 are both 1
        Dim done As Boolean = False
        Dim result As Integer = 1
        Dim current As Integer = 1
        Dim digitbase As Integer = 0
        Dim currentsearch As Integer = 1
        While Not done
            digitbase += current.ToString.Length

            If digitbase >= currentsearch Then
                Dim div As Integer = Math.Pow(10, digitbase - currentsearch)
                currentsearch *= 10
                If currentsearch = 10000000 Then
                    done = True
                End If
                Dim workingvalue As Integer = current
                Dim character As String = ((current \ div) Mod 10).ToString
                Console.WriteLine("Found character:" & character)
                result *= character
            End If
            'generate the digits
            current += 1
        End While
        Console.WriteLine(result)
        Console.ReadLine()
    End Sub

End Module
