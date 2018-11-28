Module ContinuedFractions
    Structure SpecialFraction
        Function getIntPart() As Integer
            Return Math.Floor((a + b * Math.Sqrt(c)) / d)
        End Function
        Sub New(na As Integer, nb As Integer, nc As Integer, nd As Integer)
            a = na
            b = nb
            c = nc
            d = nd

        End Sub
        Sub Invert()
            Dim Na As Integer = d * a
            Dim Nb As Integer = -d * b
            Dim Nd As Integer = a * a - b * b * c
            a = Na
            b = Nb
            d = Nd
            Dim h As Integer = hcf(Math.Abs(a), hcf(Math.Abs(b), Math.Abs(d)))
            a \= h
            b \= h
            d \= h
        End Sub
        Public Sub doStep()
            a -= d * getIntPart()
            Invert()

        End Sub
        Sub PrintOut()
            Console.WriteLine(a & "+" & b & " sqrt(" & c & ")/" & d)
        End Sub
        Public a As Integer
        Public b As Integer
        Public c As Integer
        Public d As Integer
        'a+bsqrt(c))/d
    End Structure
    Function hcf(a As Integer, b As Integer)
        If a = 0 Or b = 0 Then
            Return 0
        End If
        If a = b Then
            Return a
        End If
        If a > b Then
            Return hcf(a - b, b)
        End If
        Return hcf(a, b - a)
    End Function




    Public Function GetRootFraction(x As Integer) As List(Of Integer)
        Dim CF As List(Of Integer) = New List(Of Integer)
        Dim found As Boolean = False
        Dim L As List(Of SpecialFraction) = New List(Of SpecialFraction)

        Dim r As SpecialFraction = New SpecialFraction(0, 1, x, 1)
        While Not found
            CF.Add(r.getIntPart)
            r.doStep()
            If L.Contains(r) Then
                found = True
            End If
            L.Add(r)
        End While
        Return CF
    End Function
    Public Function GetNth(n As Integer, L As List(Of Integer)) As Integer
        If n < L.Count Then
            Return L(n)

        End If
        If n Mod (L.Count - 1) = 0 Then
            Return L.Last
        End If
        Return L(n Mod (L.Count - 1))
    End Function

    Public Structure Fraction
        Dim A As Integer
        Dim B As Integer

    End Structure
End Module
