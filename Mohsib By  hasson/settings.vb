Public Class settings
    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = My.Settings.username
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ask As MsgBoxResult = MsgBox("هل انت   متأكد من تغير كلمه  السر  علما  اذا نسيتها  لا  يمكن  استرجاعها  ", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            My.Settings.password = TextBox1.Text
        End If
    End Sub
End Class