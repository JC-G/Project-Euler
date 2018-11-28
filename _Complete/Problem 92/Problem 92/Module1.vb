Module Module1
    Dim a1(567) As Boolean
    Dim a89(567) As Boolean
    Function getSqDg(x As Integer) As Integer
        Dim res As Integer = 0
        Dim x2 = x
        While x2 > 0
            Dim D As Integer = x2 Mod 10
            res += D * D
            x2 \= 10
        End While
        Return res

    End Function
    Sub Main()
        Dim T As Integer = 0
        For x As Integer = 1 To 9999999
            Dim is89 As Boolean = False
            Dim seq As List(Of Integer) = New List(Of Integer)
            'initially reduce it
            Dim canRun As Boolean = True
            Dim res As Integer = x
            While canRun
                res = getSqDg(res)
                seq.Add(res)
                If a1(res) Then
                    canRun = False

                ElseIf a89(res) Then
                    canRun = False
                    T += 1
                    is89 = True

                ElseIf res = 89 Then
                    canRun = False
                    T += 1
                    is89 = True

                ElseIf res = 1 Then
                    canRun = False

                End If

            End While
            If is89 Then
                For Each i As Integer In seq
                    a89(i) = True
                Next
            Else
                For Each i As Integer In seq
                    a1(i) = True
                Next


            End If


        Next
        Console.WriteLine("DONE")
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
