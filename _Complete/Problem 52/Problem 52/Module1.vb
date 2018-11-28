Module Module1
    Public Function SortString(x As String) As String
        Dim chars() As Char = x.ToCharArray
        Array.Sort(chars)
        Return New String(chars)
    End Function
    'note the first digit MUST be 1
    Sub Main()
        'assume 6 digits and see where that gets us
        For x As Integer = 100000 To 199999
            Dim OK As Boolean = True
            Dim S As String = SortString(x.ToString)
            For M As Integer = 2 To 6
                If SortString((M * x).ToString) <> S Then
                    OK = False
                End If
            Next
            If OK Then
                Console.WriteLine(x)
                Console.ReadLine()
            End If
        Next
    End Sub

End Module
