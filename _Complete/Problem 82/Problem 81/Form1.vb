Public Class Form1
    'cost is applied on the move IN TO A CELL
    'source and sink have cost 0
    Dim matrix(79, 79) As Integer
    Dim workingValues As SortedDictionary(Of Integer, Integer) = New SortedDictionary(Of Integer, Integer) '+val be shortest path 
    'define end as having key -1

    Dim used(79, 79) As Boolean

    'integer key because 80*m+n is unique and fast


    'implement djikstras
    'setup
    'put initial working value = first cell

    'pick smallest unused working value and mark it as used
    'write in working values using min()
    'remove own working value
    Public Function findSmallestWorking() As Integer 'return type 80*m+n
        Dim min As Integer = workingValues.First.Value
        Dim key As Integer = workingValues.First.Key
        For Each v As KeyValuePair(Of Integer, Integer) In workingValues
            If v.Value < min Then
                min = v.Value
                key = v.Key

            End If
        Next
        Return key
    End Function
    Public Sub PlaceWV(k As Integer, oldValue As Integer)

        If k >= 6400 Or k < 0 Then
            Return
        End If
        Dim m As Integer = k \ 80
        Dim n As Integer = k Mod 80
        If used(m, n) Then
            Return
        End If
        If workingValues.ContainsKey(k) Then
            workingValues(k) = Math.Min(workingValues(k), oldValue + matrix(m, n))
        Else
            workingValues(k) = oldValue + matrix(m, n)
        End If
    End Sub
    Public Function getKey(m As Integer, n As Integer) As Integer

        Return 80 * m + n
    End Function

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        OpenFileDialog1.ShowDialog()
        Dim matStr As String = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        matStr = matStr.Replace(vbLf, ",")
        Dim S As String() = matStr.Split(",")
        For m As Integer = 0 To 79
            For n As Integer = 0 To 79
                matrix(m, n) = S(m * 80 + n)
            Next
        Next
        WriteLn("Loaded Successfully")
    End Sub


    Public Sub WriteLn(x As String)
        consoleBox.Text += x & vbNewLine
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        'initial setup goes here
        For m As Integer = 0 To 79
            workingValues.Add(getKey(m, 0), matrix(m, 0))
        Next

        Dim done As Boolean = False
        While Not done

            Dim chosenKey As Integer = findSmallestWorking()
            Dim chosenValue As Integer = workingValues(chosenKey)


            If chosenKey Mod 80 = 79 Then
                WriteLn(chosenValue)
                done = True
            End If
            PlaceWV(chosenKey + 1, chosenValue)

            PlaceWV(chosenKey + 80, chosenValue)
            PlaceWV(chosenKey - 80, chosenValue)

            workingValues.Remove(chosenKey)
            used(chosenKey \ 80, chosenKey Mod 80) = True



        End While

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
