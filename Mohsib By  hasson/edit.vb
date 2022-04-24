Public Class edit
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = montag.ListView1.SelectedItems.Item(0).SubItems(0).Text
        TextBox2.Text = montag.ListView1.SelectedItems.Item(0).SubItems(1).Text
        TextBox3.Text = montag.ListView1.SelectedItems.Item(0).SubItems(2).Text
        TextBox4.Text = montag.ListView1.SelectedItems.Item(0).SubItems(3).Text
        TextBox5.Text = montag.ListView1.SelectedItems.Item(0).SubItems(4).Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        montag.ListView1.SelectedItems.Item(0).SubItems(0).Text = TextBox1.Text
        montag.ListView1.SelectedItems.Item(0).SubItems(1).Text = TextBox2.Text
        montag.ListView1.SelectedItems.Item(0).SubItems(2).Text = TextBox3.Text
        montag.ListView1.SelectedItems.Item(0).SubItems(3).Text = TextBox4.Text
        montag.ListView1.SelectedItems.Item(0).SubItems(4).Text = TextBox5.Text
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            TextBox4.Text = TextBox2.Text - TextBox3.Text
        Catch ex As Exception

        End Try
    End Sub


End Class