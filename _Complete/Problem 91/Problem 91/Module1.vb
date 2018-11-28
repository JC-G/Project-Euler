Module Module1
    Dim S As Integer = 50
    Sub Main()
        Dim T As Integer = 0
        For P As Integer = 1 To (S + 1) * (S + 1) - 1
            For Q As Integer = P + 1 To (S + 1) * (S + 1) - 1
                Dim Px As Integer = P Mod (S + 1)
                Dim Py As Integer = P \ (S + 1)
                Dim Qx As Integer = Q Mod (S + 1)
                Dim Qy As Integer = Q \ (S + 1)
                If Qx + Px = 0 OrElse Qy + Py = 0 OrElse Qy * Px = Py * Qx Then
                    Continue For
                End If
                If Py * (Qy - Py) = -Px * (Qx - Px) OrElse Qy * (Qy - Py) = -Qx * (Qx - Px) OrElse Qy * Py + Qx * Px = 0 Then
                    T += 1
                    Console.WriteLine(Px & "," & Py)
                    Console.WriteLine(Qx & "," & Qy)
                    Console.WriteLine()
                    Continue For
                End If

            Next
        Next
        Console.WriteLine(T)
        Console.ReadLine()
    End Sub

End Module
