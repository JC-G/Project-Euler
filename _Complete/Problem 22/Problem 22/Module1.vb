Module Module1

    Sub Main()
        Dim Text As String = My.Computer.FileSystem.ReadAllText("p022_names.txt").Replace("""", "") '5163 names in total
        Dim Names As String() = Split(Text, ",")
        Array.Sort(Names)
        Dim total As Integer = 0
        For x As Integer = 0 To Names.Count - 1
            Dim currentName As String = Names(x) '-64
            Dim currentScore As Integer = 0
            For y As Integer = 0 To currentName.Length - 1
                currentScore += Convert.ToInt32(currentName(y)) - 64
            Next

            total += (x + 1) * currentScore
        Next
        Console.WriteLine(total)
        Console.ReadLine()
    End Sub

End Module
