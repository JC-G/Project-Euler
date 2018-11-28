Module Module1
    'find (a,b,c) with c=sqrta^2+b^2
    'if a+b > L/sqrt2 then discard
    'if a+b < L/2 then discard
    'generate the triples first using the complex method
    Dim HashList As SortedSet(Of Long) = New SortedSet(Of Long)
    Dim lim As Integer = 1500000
    Dim L(lim) As Integer
    Function getHash(a As Long, b As Long, c As Long) As Long
        Dim NL() As Long = {a, b, c}
        Array.Sort(NL)
        Return NL(0) + NL(1) * lim + NL(2) * lim * lim
    End Function
    Sub Main()
        For t As Integer = 1 To lim
            L(t) = 0
        Next
        Console.WriteLine("Array Allocated")
        For x As Long = 1 To 10000
            For y As Long = 1 To 10000
                Dim idx As Long = 2 * x * (x + y)
                Dim mul As Integer = 1
                While idx <= lim
                    Dim a As Integer = mul * (x * x - y * y)
                    Dim b As Integer = mul * 2 * x * y
                    Dim c As Integer = mul * (x * x + y * y)
                    If a < 1 Or b < 1 Or c < 1 Then
                        Exit While
                    End If
                    idx = mul * 2 * x * (x + y)
                    If idx <= lim Then
                        'If a < b And b < c Then
                        Dim h As Long = getHash(a, b, c)
                            If Not HashList.Contains(h) Then
                                HashList.Add(h)
                                L(idx) += 1
                                If idx = 120 Then
                                    Console.WriteLine(a & " " & b & " " & c)
                                End If

                            End If

                        'End If
                    End If

                        mul += 1
                    'strict a<b<c and cache which ones we have hit- perhaps hash for 3 integers?

                End While
            Next
        Next
        Console.WriteLine("Triples Generated")
        Dim Total As Integer = 0
        For t As Integer = 1 To lim
            If L(t) = 1 Then
                Total += 1
                'Console.WriteLine(t & " : " & A(t))
            End If
        Next
        Console.WriteLine(Total)
        Console.WriteLine(L(120))
        Console.Beep()
        Console.ReadLine()
    End Sub

End Module
