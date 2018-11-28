Module Module1

    Sub Main()
        Dim text As String = My.Computer.FileSystem.ReadAllText("p089_roman.txt")
        text.Replace(vbCr, "")
        Dim lines() As String = text.Split(vbLf)
        Dim total1 As Integer = 0
        Dim total2 As Integer = 0
        For Each line2 As String In lines
            Console.Write(line2 & ": ")
            Dim line = line2 & "E"
            total1 += line2.Count
            Dim number As Integer = 0
            'parse it
            For x As Integer = 0 To line.Length - 1
                If line(x) = "I" Then
                    If line(x + 1) = "V" Then
                        x += 1
                        number += 4
                    ElseIf line(x + 1) = "X" Then
                        x += 1
                        number += 9
                    Else
                        number += 1
                    End If
                ElseIf line(x) = "V" Then
                    number += 5
                ElseIf line(x) = "X" Then
                    If line(x + 1) = "L" Then
                        x += 1
                        number += 40
                    ElseIf line(x + 1) = "C" Then
                        x += 1
                        number += 90
                    Else
                        number += 10
                    End If
                ElseIf line(x) = "L" Then
                    number += 50
                ElseIf line(x) = "C" Then
                    If line(x + 1) = "D" Then
                        x += 1
                        number += 400
                    ElseIf line(x + 1) = "M" Then
                        x += 1
                        number += 900
                    Else
                        number += 100
                    End If
                ElseIf line(x) = "D" Then
                    number += 500
                ElseIf line(x) = "M" Then
                    number += 1000
                ElseIf line(x) = "E" Then
                    Exit For
                End If
            Next
            Console.Write(number & ": ")


            'now write the optimal number of characters
            Dim charCount As Integer = 0
            While number >= 1000
                charCount += 1
                number -= 1000
            End While
            While number >= 900
                charCount += 2
                number -= 900
            End While
            While number >= 500
                charCount += 1
                number -= 500
            End While
            While number >= 400
                charCount += 2
                number -= 400
            End While
            While number >= 100
                charCount += 1
                number -= 100
            End While
            While number >= 90
                charCount += 2
                number -= 90
            End While
            While number >= 50
                charCount += 1
                number -= 50
            End While
            While number >= 40
                charCount += 2
                number -= 40
            End While
            While number >= 10
                charCount += 1
                number -= 10
            End While
            While number >= 9
                charCount += 2
                number -= 9
            End While
            While number >= 5
                charCount += 1
                number -= 5
            End While
            While number >= 4
                charCount += 2
                number -= 4
            End While
            While number >= 1
                charCount += 1
                number -= 1
            End While
            Console.WriteLine(charCount & " : " & line2.Count - charCount)
            total2 += charCount

        Next
        Console.ReadLine()
        Console.WriteLine(total1 - total2)
        Console.ReadLine()
    End Sub

End Module
