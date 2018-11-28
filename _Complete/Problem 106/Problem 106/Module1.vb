Module Module1
    Dim n As Integer = 12
    Dim setOfSets As List(Of List(Of Integer)) = New List(Of List(Of Integer))
    Sub Main()
        Dim count As Integer = 0
        For ssSize As Integer = 2 To n \ 2
            setOfSets.Clear()
            RecursionTest(New List(Of Integer), n, ssSize) 'get all the sets in order

            For s1i As Integer = 0 To setOfSets.Count - 1
                For s2i As Integer = s1i + 1 To setOfSets.Count - 1

                    Dim needsCheck As Boolean = False
                    Dim s1 As List(Of Integer) = setOfSets(s1i)
                    Dim s2 As List(Of Integer) = setOfSets(s2i)
                    'check for disjointness
                    If (s1.Intersect(s2)).Count = 0 Then
                        For z As Integer = 0 To s1.Count - 1
                            If s1(z) > s2(z) Then
                                needsCheck = True
                            End If
                        Next
                    End If

                    If needsCheck Then
                        count += 1
                    End If
                Next
            Next


        Next
        Console.WriteLine(count)
        Console.ReadLine()

    End Sub




    Public Sub RecursionTest(L As List(Of Integer), n As Integer, setSize As Integer)

        If L.Count = setSize Then
            setOfSets.Add(L)
            Return
        End If
        Dim last As Integer = 0
        If L.Count > 0 Then last = L.Last
        For z As Integer = last + 1 To n

            Dim L3 As List(Of Integer) = New List(Of Integer)(L.AsEnumerable)

            L3.Add(z)
            RecursionTest(L3, n, setSize)
        Next

    End Sub
End Module
