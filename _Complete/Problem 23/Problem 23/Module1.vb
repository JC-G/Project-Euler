Module Module1
    Function listSum(L As List(Of Integer)) As Integer
        Dim T As Integer = 0
        For Each I As Integer In L
            T += I
        Next
        Return T
    End Function
    Function setSum(L As SortedSet(Of Integer)) As Integer
        Dim T As Integer = 0
        For Each I As Integer In L
            T += I
        Next
        Return T
    End Function
    Function getDivisorSum(x As Integer) As Integer
        Dim Total As Integer = 0
        For t As Integer = 1 To Math.Floor(Math.Sqrt(x))
            If x Mod t = 0 Then
                Total += t
                If x / t <> t And t <> 1 Then
                    Total += x / t

                End If
            End If
        Next
        Return Total
    End Function
    Function getProperDivisors(x As Integer) As List(Of Integer) 'find all combinations of prime factors
        Dim L As List(Of Integer) = New List(Of Integer)
        For t As Integer = 1 To Math.Floor(Math.Sqrt(x))
            If x Mod t = 0 Then
                L.Add(t)
                If x / t <> t And t <> 1 Then
                    L.Add(x / t)

                End If
            End If
        Next
        Return L
    End Function
    Function d(n As Integer)
        Return getDivisorSum(n)
    End Function
    Function isAbundant(x As Integer) As Boolean
        Return d(x) > x
    End Function
    Sub Main()
        'first get all abundant numbers for easy lookup
        Dim numbersList As SortedSet(Of Integer) = New SortedSet(Of Integer)
        Dim abundantList As List(Of Integer) = New List(Of Integer)

        For x As Integer = 1 To 28123
            numbersList.Add(x)
            If isAbundant(x) Then
                abundantList.Add(x)
            End If
        Next

        For x As Integer = 0 To abundantList.Count - 1
            For y As Integer = 0 To abundantList.Count - 1
                Dim T As Integer = abundantList(x) + abundantList(y)
                If numbersList.Contains(T) Then
                    numbersList.Remove(T)
                End If
            Next
        Next
        Console.WriteLine(setSum(numbersList))
        Console.ReadLine()
    End Sub

End Module
