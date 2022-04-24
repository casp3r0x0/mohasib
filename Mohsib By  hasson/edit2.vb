Public Class edit2
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub edit2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = addzbon.ListView1.SelectedItems.Item(0).SubItems(0).Text
        TextBox2.Text = addzbon.ListView1.SelectedItems.Item(0).SubItems(1).Text
        TextBox3.Text = addzbon.ListView1.SelectedItems.Item(0).SubItems(2).Text
        TextBox4.Text = addzbon.ListView1.SelectedItems.Item(0).SubItems(3).Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addzbon.ListView1.SelectedItems.Item(0).SubItems(0).Text = TextBox1.Text
        addzbon.ListView1.SelectedItems.Item(0).SubItems(1).Text = TextBox2.Text
        addzbon.ListView1.SelectedItems.Item(0).SubItems(2).Text = TextBox3.Text
        addzbon.ListView1.SelectedItems.Item(0).SubItems(3).Text = TextBox4.Text
        Me.Close()
    End Sub
End Class