Public Class Form1
    Dim target As Integer = 20
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mainPrimes As List(Of Integer) = New List(Of Integer)
        Dim product As Integer = 1
        For x As Integer = 2 To target
            Dim xfactors As List(Of Integer) = getPrimeFactorization(x)
            For Each item As Integer In xfactors
                Dim tmp As Integer = item
                If mainPrimes.FindAll(Function(p) p = item).Count < xfactors.FindAll(Function(p) p = item).Count Then
                    mainPrimes.Add(item)
                    product *= item
                End If
            Next


        Next



        'Dim col As Collection = getPrimeFactorization()
        MsgBox(product)
        TextBox1.Text = product

    End Sub



    Public Function getPrimeFactorization(x As Integer) As List(Of integer)
        Dim r As List(Of Integer) = New List(Of Integer)
        Dim isPrime = True
        Dim total As Integer = x
        While Not total = 1
            For iter As Integer = 2 To Math.Ceiling(x / 2)
                If total Mod iter = 0 Then
                    isPrime = False
                    r.Add(iter)
                    total /= iter
                    Exit For
                End If
            Next
            If isPrime Then
                r.Add(x)
                Return r
            End If
        End While
        Return r
    End Function
End Class
