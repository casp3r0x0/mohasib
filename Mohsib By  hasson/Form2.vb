Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.username = TextBox1.Text
        My.Settings.password = TextBox2.Text
        sginin.Show()
        Me.Close()
    End Sub
End Class