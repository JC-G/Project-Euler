Module Module1
    Function StrSort(x As String)
        Dim A As Char() = x.ToCharArray
        Array.Sort(A)
        Return New String(A)
    End Function
    Dim max As Integer = 0
    Function squaresBetween(min As Long, max As Long) As String()
        Dim sqCount As Long = Math.Floor(Math.Sqrt(max)) - Math.Floor(Math.Sqrt(min - 1))
        Dim squares(sqCount - 1) As String
        Dim startNo As Long = Math.Ceiling(Math.Sqrt(min))
        For idx As Integer = 0 To sqCount - 1
            squares(idx) = ((startNo + idx) ^ 2).ToString
        Next
        Return squares
    End Function

    Function getPattern(key As String, word As String) As String
        Dim used As List(Of Char) = New List(Of Char)
        Dim idx As Integer = 97
        Dim newKey As String = key
        For Each c As Char In word
            'how to handle duplicates
            newKey = newKey.Replace(c, Chr(idx))
            If Not used.Contains(c) Then
                used.Add(c)
                idx += 1
            End If

        Next
        Return newKey
        'for example cheese and ceeehs should go
        '012232 -> 022213 -> acccbd
    End Function

    Sub findAnagrams(wordList() As String, ByRef anagramWords As Dictionary(Of String, List(Of String)))

        Dim idx As Integer = 0
        For Each word As String In wordList
            Dim alphaWord As String = StrSort(word)
            If Not anagramWords.ContainsKey(alphaWord) Then
                anagramWords(alphaWord) = New List(Of String)

            End If
            anagramWords(alphaWord).Add(wordList(idx))

            'then
            idx += 1
        Next
        Dim removeKeys As List(Of String) = New List(Of String)
        For Each i As KeyValuePair(Of String, List(Of String)) In anagramWords
            If i.Value.Count < 2 Then
                removeKeys.Add(i.Key)
            End If
        Next
        For Each i As String In removeKeys
            anagramWords.Remove(i)
        Next

    End Sub

    Sub Main()
        Console.WriteLine(getPattern("65973", "35967"))
        Console.ReadLine()
        Dim fileString As String = My.Computer.FileSystem.ReadAllText("p098_words.txt")
        Dim wordList() As String = fileString.Replace("""", "").Split(",")
        Dim squareList() As String = squaresBetween(100, 999999999)
        Console.WriteLine(squareList.Count)
        Console.ReadLine()

        Dim anagramwords As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
        Dim anagramSquares As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
        findAnagrams(wordList, anagramwords)
        findAnagrams(squareList, anagramSquares)
        'we dont need to look for 3s probably
        Dim removeKeys As List(Of String) = New List(Of String)
        For Each i As KeyValuePair(Of String, List(Of String)) In anagramwords
            If i.Value.Count <> 2 Then
                removeKeys.Add(i.Key)
            End If
        Next
        For Each i As String In removeKeys
            'anagramwords.Remove(i)
        Next

        For Each i As KeyValuePair(Of String, List(Of String)) In anagramwords
            Console.WriteLine("KEY: " & i.Key)
            For Each wordidx As String In i.Value
                Console.Write(wordidx & ",")

            Next
            Console.WriteLine()
            Console.WriteLine()

        Next


        For Each WordSet As List(Of String) In anagramwords.Values

            For wx As Integer = 0 To WordSet.Count - 1
                For wy As Integer = wx + 1 To WordSet.Count - 1
                    Dim patternMatch As String = getPattern(WordSet(wx), WordSet(wy))
                    For Each PrimeSet As List(Of String) In anagramSquares.Values
                        If PrimeSet(0).Length <> patternMatch.Length Then
                            Continue For
                        End If

                        For x As Integer = 0 To PrimeSet.Count - 1
                            For y As Integer = 0 To PrimeSet.Count - 1
                                If patternMatch = getPattern(PrimeSet(x), PrimeSet(y)) Then
                                    Console.WriteLine(PrimeSet(x) & " " & PrimeSet(y) & " " & WordSet(0) & " " & WordSet(1))
                                    max = Math.Max(max, Math.Max(Convert.ToInt32(PrimeSet(y)), Convert.ToInt32(PrimeSet(x))))
                                End If
                            Next
                        Next
                    Next
                Next
            Next
            'the pattern we want to match is:


            'determine if a square pair has this
        Next
        Console.WriteLine("MAX: " & max)


        Console.ReadLine()
    End Sub

End Module
