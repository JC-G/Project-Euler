Module Module1

    Sub Main()
        'start with 997799 (construct 997)
        For construct = 997 To 101 Step -1
            'construct a palindrome
            Dim palin = Convert.ToInt32(Convert.ToString(construct) & StrReverse(Convert.ToString(construct)))
            For factor = 101 To Convert.ToInt32(Math.Sqrt(palin))
                If palin Mod factor = 0 And palin / factor < 1000 Then
                    MsgBox(palin & " = " & factor & " x " & palin / factor)
                End If
            Next
        Next
    End Sub

End Module
