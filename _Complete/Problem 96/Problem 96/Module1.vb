Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Module Module1
    'use a version of the recursive algorithm - might be slow
    'should I just backtrack? think its very slow but unsure

    'if can place a number, return next else return false
    Dim puzzles As List(Of String) = New List(Of String)
    Dim grid(8, 8) As Integer
    Dim poss(8, 8) As List(Of Integer)
    Dim res As Integer
    Dim T As Integer
    Dim doneCount As Integer = 0
    Dim solved As Boolean = False
    Public Function DeepCopy(ByVal ObjectToCopy As Object) As Object
        'https://stackoverflow.com/questions/10745026/vb-net-copy-a-list-to-store-original-values-to-be-used-later
        Using mem As New MemoryStream

            Dim bf As New BinaryFormatter
            bf.Serialize(mem, ObjectToCopy)

            mem.Seek(0, SeekOrigin.Begin)

            Return bf.Deserialize(mem)

        End Using

    End Function
    Public Sub DispGrid(thisGrid As Integer(,))
        Return
        Console.WriteLine("---------------")
        For y As Integer = 0 To 8
            For x As Integer = 0 To 8
                Console.Write(thisGrid(x, y))
                If x Mod 3 = 2 Then
                    Console.Write("  ")
                End If
            Next
            Console.WriteLine()
            If y Mod 3 = 2 Then
                Console.WriteLine()
            End If

        Next
    End Sub
    Public Function SudokuPass(thisGrid As Integer(,), thisPoss As List(Of Integer)(,)) As Boolean


        'check all possibilities for 1s, or 0s where grid = 0
        Dim xu As Integer = 9
        Dim yu As Integer = 9

        Dim solvePoss As Boolean = True
        While solvePoss
            'DEDUCTION STAGE 1: IT IS THE ONLY POSSIBILITY
            xu = 9
            yu = 9

            For ix As Integer = 0 To 8
                For iy As Integer = 0 To 8
                    If thisPoss(ix, iy).Count = 0 And thisGrid(ix, iy) = 0 Then
                        thisGrid(ix, iy) = -1
                        DispGrid(thisGrid)
                        Return False 'this produces a contradiction! immediately exit, go on to next branch

                    End If
                    If thisPoss(ix, iy).Count = 1 Then
                        xu = ix
                        yu = iy
                        SetNumber(ix, iy, thisPoss(xu, yu)(0), thisGrid, thisPoss)
                    End If
                Next
            Next
            If xu = 9 Then
                'DEDUCTION STAGE 2: NO WHERE ELSE CAN HAVE IT
                'for each row / column, if N is needed but no empty cells have N, exit
                'but if one cell has it, set it
                Dim successfulStage2 As Boolean = False
                For it As Integer = 0 To 8
                    '012
                    '345
                    '678
                    For testNumber As Integer = 1 To 9
                        Dim rowTests(8) As Boolean
                        Dim colTests(8) As Boolean
                        Dim boxTests(8) As Boolean
                        Dim rowCount As Integer = 0
                        Dim colCount As Integer = 0
                        Dim boxCount As Integer = 0
                        Dim rowContains As Boolean
                        Dim colContains As Boolean
                        Dim boxContains As Boolean
                        Dim rowFirst As Integer
                        Dim colFirst As Integer
                        Dim boxFirst As Integer
                        For it2 As Integer = 0 To 8
                            If thisGrid(it2, it) = testNumber Then
                                rowContains = True
                            End If
                            If thisGrid(it, it2) = testNumber Then
                                colContains = True
                            End If
                            If thisGrid(3 * (it Mod 3) + (it2 Mod 3), 3 * (it \ 3) + it2 \ 3) = testNumber Then
                                boxContains = True
                            End If
                            'check  the iterator
                            If thisPoss(it2, it).Contains(testNumber) Then
                                rowTests(it2) = True
                                rowFirst = it2
                                rowCount += 1

                            End If
                            If thisPoss(it, it2).Contains(testNumber) Then
                                colTests(it2) = True
                                colFirst = it2
                                colCount += 1

                            End If
                            If thisPoss(3 * (it Mod 3) + (it2 Mod 3), 3 * (it \ 3) + it2 \ 3).Contains(testNumber) Then
                                boxTests(it2) = True
                                boxFirst = it2
                                boxCount += 1

                            End If
                        Next
                        If (Not rowContains And rowCount = 0) Or (Not colContains And colCount = 0) Or (Not boxContains And boxCount = 0) Then
                            Console.WriteLine("Failed on stage 2")
                            Return False 'contradiction
                        End If
                        'Console.WriteLine("R:" & rowCount & " C:" & colCount & " B:" & boxCount)
                        'go through the row/col
                        If rowCount = 1 Then
                            successfulStage2 = True
                            SetNumber(rowFirst, it, testNumber, thisGrid, thisPoss)
                        End If
                        If colCount = 1 Then
                            successfulStage2 = True
                            SetNumber(it, colFirst, testNumber, thisGrid, thisPoss)
                        End If
                        If boxCount = 1 Then
                            successfulStage2 = True
                            SetNumber(3 * (it Mod 3) + (boxFirst Mod 3), 3 * (it \ 3) + boxFirst \ 3, testNumber, thisGrid, thisPoss)
                        End If

                    Next
                Next
                If Not successfulStage2 Then
                    'Console.WriteLine("Could not find a successful Stage 2 Deduction")
                    solvePoss = False
                Else
                    'Console.WriteLine("Stage 2 Successful")
                End If
            End If

        End While


        'now ALL of the possibilities are filled


        Console.WriteLine("Grid Before Guesses")
        DispGrid(thisGrid)
        xu = 9
        yu = 9

        For ix As Integer = 0 To 8
            For iy As Integer = 0 To 8
                If thisGrid(ix, iy) = 0 Then
                    Console.WriteLine("Count for guesses on cell " & ix & "," & iy & ":" & thisPoss(ix, iy).Count)
                    'reduce the possibilities in this one to 1
                    Dim cellBroke As Boolean = True
                    For Each P As Integer In thisPoss(ix, iy)
                        If solved Then Return True
                        Dim newPoss As List(Of Integer)(,) = DeepCopy(thisPoss)
                        Dim newGrid As Integer(,) = DeepCopy(thisGrid)
                        xu = ix
                        yu = iy
                        newPoss(ix, iy) = New List(Of Integer)
                        newPoss(ix, iy).Add(P)
                        'branch
                        Console.WriteLine("Entering New Pass")
                        If SudokuPass(newGrid, newPoss) Then
                            cellBroke = False
                            Return True
                        Else
                            Console.WriteLine("Pass Failed")
                        End If


                    Next
                    If cellBroke Then Return False

                End If
            Next
        Next
        If xu = 9 Then
            solved = True
            Console.WriteLine("Done!")
            'Console.Beep()
            'Console.ReadLine()
            'DispGrid(thisGrid)
            doneCount += 1
            T += thisGrid(0, 0) * 100 + thisGrid(1, 0) * 10 + thisGrid(2, 0)
            Return True
        End If
        Return False
    End Function

    Public Sub SetNumber(x As Integer, y As Integer, N As Integer, ByRef thisGrid As Integer(,), ByRef thisPoss As List(Of Integer)(,))
        thisGrid(x, y) = N
        thisPoss(x, y) = New List(Of Integer)
        For it As Integer = 0 To 8
            thisPoss(it, y).Remove(N)
            thisPoss(x, it).Remove(N)
        Next
        Dim cellX As Integer = (x \ 3) * 3
        Dim cellY As Integer = (y \ 3) * 3
        For ix As Integer = 0 To 2
            For iy As Integer = 0 To 2
                thisPoss(ix + cellX, iy + cellY).Remove(N)
            Next
        Next
    End Sub




    Sub Main()
        Dim SudokuString As String = My.Computer.FileSystem.ReadAllText("p096_sudoku.txt")
        SudokuString = SudokuString.Replace(vbLf, "").Replace(vbCr, "").Replace("rid ", "")
        For Each S As String In SudokuString.Split("G")
            If S.Length = 0 Then
                Continue For
            End If
            puzzles.Add(S.Remove(0, 2))
        Next


        Dim puzzleNo As Integer = 1
        For Each puzzle As String In puzzles
            Console.WriteLine("PUZZLE " & puzzleNo & ":")
            Console.WriteLine()
            'Console.ReadLine()
            puzzleNo += 1

            For x As Integer = 0 To 80
                poss(x Mod 9, x \ 9) = New List(Of Integer) From {1, 2, 3, 4, 5, 6, 7, 8, 9}
                grid(x Mod 9, x \ 9) = 0
            Next
            For x As Integer = 0 To 80
                If puzzle(x) <> "0" Then

                    SetNumber(x Mod 9, x \ 9, Convert.ToInt32(puzzle(x)) - 48, grid, poss)
                Else

                End If

            Next

            Dim lT As Integer = T
            'puzzle is initiated, now we can begin
            solved = False
            SudokuPass(grid, poss)
            If T = lT Then
                Console.WriteLine("FAILED!")
                Console.ReadLine()
            Else
                'Console.WriteLine(T)
            End If


        Next
        Console.WriteLine(T)
        Console.WriteLine("Solved: " & doneCount)
        Console.ReadLine()


    End Sub

End Module
