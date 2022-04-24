Public Class addzbon
    Private _AddText As New List(Of String)
    Dim zbon As String = Application.StartupPath & "\zbon.dll"
    Private Sub addzbon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        Try
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(zbon)
            For Each line As String In myCoolFileLines
                Dim lineArray() As String = line.Split("#")
                Dim newItem As New ListViewItem(lineArray(0))
                newItem.SubItems.Add(lineArray(1))
                newItem.SubItems.Add(lineArray(2))
                newItem.SubItems.Add(lineArray(3))
                newItem.SubItems.Add(lineArray(4))
                ListView1.Items.Add(newItem)
            Next
        Catch ex As Exception
            MsgBox("حدث  خلل في  استيراد القيم  ")
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newItem As New ListViewItem(TextBox1.Text)
        newItem.SubItems.Add(ComboBox1.Text)
        newItem.SubItems.Add(TextBox3.Text)
        newItem.SubItems.Add(TextBox4.Text)
        newItem.SubItems.Add(My.Settings.zbnnum + 1)
        My.Settings.zbnnum = My.Settings.zbnnum + 1
        ListView1.Items.Add(newItem)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim searchstring As String = TextBox2.Text
        ListView1.SelectedIndices.Clear()
        For Each lvi As ListViewItem In ListView1.Items
            For Each lvisub As ListViewItem.ListViewSubItem In lvi.SubItems
                If lvisub.Text.Contains(searchstring) Then
                    ListView1.SelectedIndices.Add(lvi.Index)
                    Exit For
                End If
            Next
        Next
        ListView1.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = ListView1.Items.Count
    End Sub

    Private Sub تحريرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تحريرToolStripMenuItem.Click
        edit2.Show()
    End Sub

    Private Sub مسحToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles مسحToolStripMenuItem.Click
        For Each i As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(i)
        Next
    End Sub

    Private Sub نسخرقمهاتفالزبونToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخرقمهاتفالزبونToolStripMenuItem.Click
        'ListView1.SelectedItems.Item(0).SubItems(4).Text
        My.Computer.Clipboard.SetText(ListView1.SelectedItems.Item(0).SubItems(2).Text)
        MsgBox("تم  النسخ  ")
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown, TextBox3.KeyDown, TextBox1.KeyDown, ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class