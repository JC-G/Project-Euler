Module Module1
    'monte carlo lol
    Dim numTurns As Integer = 1000000
    Dim lastSquare As Integer = 0
    Dim squareCount As Integer = 40
    Dim squares(squareCount - 1) As Integer
    Dim CC As Integer() = {2, 17, 33}
    Dim CH As Integer() = {7, 22, 36}
    Public Function randInt(x As Integer) 'from 1 to x
        Return Math.Floor(Rnd() * x) + 1
    End Function
    Sub Main()

        For x As Integer = 1 To numTurns
            'do a turn and record the final square
            Dim diceSquare As Integer = (lastSquare + randInt(4) + randInt(4)) Mod squareCount
            Dim actualSquare As Integer = diceSquare
            If diceSquare = 30 Then
                actualSquare = 10
            End If
            If CC.Contains(diceSquare) Then
                Dim cardNo As Integer = randInt(16)
                Select Case cardNo
                    Case 1
                        actualSquare = 0

                    Case 2
                        actualSquare = 10

                End Select
            End If
            If CH.Contains(diceSquare) Then
                Dim cardNo As Integer = randInt(16)
                Select Case cardNo
                    Case 1
                        actualSquare = 0

                    Case 2
                        actualSquare = 10

                    Case 3
                        actualSquare = 11

                    Case 4
                        actualSquare = 24

                    Case 5
                        actualSquare = 39

                    Case 6
                        actualSquare = 5

                    Case 7
                        If diceSquare = 7 Then
                            actualSquare = 15
                        ElseIf diceSquare = 22 Then
                            actualSquare = 25
                        Else
                            actualSquare = 5

                        End If

                    Case 8
                        If diceSquare = 7 Then
                            actualSquare = 15
                        ElseIf diceSquare = 22 Then
                            actualSquare = 25
                        Else
                            actualSquare = 5

                        End If

                    Case 9
                        If diceSquare = 7 Then
                            actualSquare = 12
                        ElseIf diceSquare = 22 Then
                            actualSquare = 28
                        Else
                            actualSquare = 12

                        End If

                        '7 to 12
                        '22 to 28
                        '36 to 12
                    Case 10
                        actualSquare = (37 + diceSquare) Mod squareCount

                End Select
            End If
            squares(actualSquare) += 1
            lastSquare = actualSquare
        Next
        'find the top 3
        'hope they arent exactly the same, dodgy sln
        Dim str As String = ""
        For x As Integer = 1 To 3
            Dim i As Integer = Array.IndexOf(squares, squares.Max)
            str += i.ToString
            squares(i) = -1

        Next
        Console.WriteLine(str)
        Console.ReadLine()
    End Sub

End Module
