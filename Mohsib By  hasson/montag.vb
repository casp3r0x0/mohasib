Public Class montag
    Private _AddText As New List(Of String)


    Dim montag As String = Application.StartupPath & "\montag.dll"
    Private Sub montag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(montag)
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
        newItem.SubItems.Add(TextBox2.Text)
        newItem.SubItems.Add(TextBox3.Text)
        newItem.SubItems.Add(TextBox4.Text)
        newItem.SubItems.Add(TextBox5.Text)
        ListView1.Items.Add(newItem)
    End Sub

    Private Sub مسحToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles مسحToolStripMenuItem.Click
        For Each i As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(i)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = ListView1.Items.Count
        Try
            TextBox4.Text = TextBox2.Text - TextBox3.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim searchstring As String = TextBox6.Text
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

    Private Sub قرأهالملاحضةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles قرأهالملاحضةToolStripMenuItem.Click
        MsgBox(ListView1.SelectedItems.Item(0).SubItems(4).Text)
    End Sub

    Private Sub تحريرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تحريرToolStripMenuItem.Click
        edit.Show()
    End Sub

    Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown, TextBox4.KeyDown, TextBox3.KeyDown, TextBox2.KeyDown, TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            Button2.PerformClick()
        End If
    End Sub
End Class