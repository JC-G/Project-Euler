Module Module1
    Dim units() As String = New String() {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"}
    Dim tens() As String = New String() {"", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"}
    Sub Main()
        Dim T As Integer = 0
        For x As Integer = 1 To 1000
            Dim L As Integer = 0
            If 10 < (x Mod 100) And (x Mod 100) < 20 Then
                L += units(x Mod 100).Length 'fix teens
            Else
                L += units(x Mod 10).Length + tens((x \ 10) Mod 10).Length
            End If

            If x > 99 Then
                L += units(x \ 100).Length + "hundred".Length()
                If x Mod 100 <> 0 Then
                    L += "and".Length()
                End If
            End If


            If x = 1000 Then
                L = "onethousand".Length()
            End If

            T += L
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
