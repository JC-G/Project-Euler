Public Class Form1
    Dim target As Integer = 10001
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim total As Integer = 0
        Dim P As Integer = 1
        While total < target
            P += 1
            If isPrime(P) Then
                total += 1
            End If
        End While
        MsgBox(P)
    End Sub

    Public Function isPrime(x)
        Dim P As Boolean = True
        If x = 1 Then Return False

        For y As Integer = 2 To Math.Floor(Math.Sqrt(x))
            If x Mod y = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
