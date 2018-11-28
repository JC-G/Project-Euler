Public Class Form1
    Dim target As Integer = 100
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = sumTo(target) ^ 2 - sumSQTo(target)
    End Sub

    Public Function sumTo(x As Integer)
        Return (x * (x + 1)) / 2
    End Function
    Public Function sumSQTo(x)
        Return (x * (x + 1) * (2 * x + 1)) / 6
    End Function
End Class
