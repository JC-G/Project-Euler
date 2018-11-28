Module Module1
    Dim c As Integer = 10
    Dim S As Long = 0
    Dim digits As String = "0123456789"
    Dim checkList As List(Of Long) = New List(Of Long)
    Dim digitSets As List(Of List(Of Integer)) = New List(Of List(Of Integer))

    Dim masks As List(Of List(Of String)) = New List(Of List(Of String))

    Sub Main()
        For x As Integer = 0 To c
            masks.Add(New List(Of String))
        Next
        For x As Integer = 0 To (1 << c) - 1
            Dim thisMask As String = Convert.ToString(x, 2) 'binary lol
            While thisMask.Length < c
                thisMask = "0" + thisMask
            End While
            masks(thisMask.Count(Function(z) (z = "1"))).Add(thisMask)

        Next
        For Each z As List(Of String) In masks
            Console.WriteLine(z.Count)
        Next
        Console.ReadLine()

        For dig As Integer = 0 To 9
            Dim primeFound As Boolean = False
            For repCount As Integer = c - 1 To 0 Step -1
                digitSets.Clear()
                checkList = New List(Of Long)
                GetDigitSets(New List(Of Integer), dig, repCount)
                For Each digitSet As List(Of Integer) In digitSets
                    For Each Mask As String In masks(repCount)
                        Dim i As Integer = 0
                        '1 = repeat, 0 = digit
                        Dim thisNum As List(Of Integer) = New List(Of Integer)
                        For Each s As Char In Mask
                            If s = "1" Then
                                thisNum.Add(dig)
                            Else
                                thisNum.Add(digitSet(i))
                                i += 1
                            End If

                        Next

                        'check if prime
                        Dim thisi As Long = makeInteger(thisNum)
                        If thisi >= 10 ^ (c - 1) AndAlso isPrime(thisi) Then
                            primeFound = True
                            'Console.WriteLine(thisi)
                            S += thisi
                        End If
                    Next
                Next
                If primeFound Then Exit For


                'splice the repeated digit and the digitsets using the masks


            Next
        Next

        Console.WriteLine("DONE: " & S)
        Console.ReadLine()

    End Sub
    Public Function isPrime(x As Long) As Boolean
        If x < 2 Then Return False
        Dim root As Long = Math.Floor(Math.Sqrt(x))
        For t As Long = 2 To root
            If x Mod t = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
    Function makeInteger(L As List(Of Integer)) 'perhaps a string is not the best way to do this
        Dim S As String = ""
        For Each digit As Integer In L
            S += digit.ToString
        Next
        Return Convert.ToInt64(S)
    End Function

    Public Sub GetDigitSets(L As List(Of Integer), chooseDigit As Integer, repeatCount As Integer)

        If L.Count >= c - repeatCount Then

            digitSets.Add(L)
            Return
        End If
        For z As Integer = 0 To 9

            If Not (z = chooseDigit) Then
                Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

                L3.Add(z)
                GetDigitSets(L3, chooseDigit, repeatCount)
            End If
        Next

    End Sub
End Module
