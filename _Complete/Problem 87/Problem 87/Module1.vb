Module Module1
    Dim LIM As Integer = 50000000
    Dim L2 As Integer = Math.Sqrt(LIM)
    Dim L3 As Integer = Math.Pow(LIM, 1 / 3)
    Dim L4 As Integer = Math.Pow(LIM, 1 / 4)
    Public Function PrimeSieve(x As Integer) As SortedSet(Of Integer) 'return all primes less than or equal to x
        Dim L As SortedSet(Of Integer) = New SortedSet(Of Integer)
        For t As Integer = 2 To x
            L.Add(t)
        Next
        For testValue As Integer = 2 To Math.Floor(Math.Sqrt(x))
            For testNumber As Integer = 2 * testValue To x Step testValue
                If L.Contains(testNumber) Then
                    L.Remove(testNumber)
                End If
            Next
        Next
        Return L
    End Function
    Sub Main()
        Dim P2 As SortedSet(Of Integer) = PrimeSieve(L2)
        Dim P3 As SortedSet(Of Integer) = PrimeSieve(L3)
        Dim P4 As SortedSet(Of Integer) = PrimeSieve(L4)
        Dim pr As List(Of Integer) = New List(Of Integer)
        For Each I In P2
            For Each J In P3
                For Each K In P4
                    Dim L As Integer = I * I + J * J * J + K * K * K * K
                    If L < LIM Then
                        pr.Add(L)
                    End If

                Next
            Next
        Next
        Console.WriteLine("P2: " & P2.Count & " P3: " & P3.Count & " P4: " & P4.Count)
        Console.WriteLine("UNIQUE: " & pr.Distinct.Count)
        Console.ReadLine()

    End Sub

End Module
