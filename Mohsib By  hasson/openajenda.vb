Imports System.IO
Public Class openajenda
    Dim zbon As String = Application.StartupPath & "\zbon.dll"
    Private Sub openajenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Dim searchstring As String = TextBox1.Text
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.ListView1.Items.Clear()
        Dim all As New List(Of String)
        Try
            Dim clientnumber As String = ListView1.SelectedItems(0).SubItems(4).Text
            If (Not System.IO.Directory.Exists(Application.StartupPath & "\database\" & clientnumber)) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\database\" & clientnumber)
            End If
            Form1.Label22.Text = ListView1.SelectedItems(0).SubItems(4).Text
            Form1.Label6.Text = ListView1.SelectedItems(0).SubItems(0).Text
            Form1.Label7.Text = ListView1.SelectedItems(0).SubItems(1).Text
            Form1.Label8.Text = ListView1.SelectedItems(0).SubItems(2).Text
            Form1.Label9.Text = ListView1.SelectedItems(0).SubItems(3).Text
        Catch ex As Exception
            MsgBox("خطأ في إنشاء الملف  أو اضافه البينات في الفورم ")
        End Try
        'get  fwater  info 
        Try
            Dim di As New IO.DirectoryInfo(Application.StartupPath & "\database\" & ListView1.SelectedItems(0).SubItems(4).Text)
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.*")
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                Dim name As String = fi.Name
                all.Add(name)
            Next
            Dim r As New RichTextBox
            r.Lines = all.ToArray
            If r.Text = "" Then
                MsgBox("لا يوجد  فواتير لهذا الزبون ")
            End If
            For Each line In r.Lines
                Dim lineArray() As String = line.Split("#")
                Dim newItem As New ListViewItem(lineArray(0).Replace("_", "/"))
                newItem.SubItems.Add(lineArray(1))
                newItem.SubItems.Add(lineArray(2))
                newItem.SubItems.Add(lineArray(3))
                newItem.SubItems.Add(getype(lineArray(4)))
                newItem.SubItems.Add(lineArray(5))
                Form1.ListView1.Items.Add(newItem)
            Next
        Catch ex As Exception
            MsgBox("خطأ في  استرداد الفيم  ")
        End Try
        'done  get fw info 
        Me.Close()
    End Sub
    Function getype(ByVal n As String)
        Dim status As String
        If n = "1" Then
            status = "مدفوع"
        End If
        If n = "2" Then
            status = "متبقي"
        End If
        If n = "3" Then
            status = "غير مدفوع"
        End If
        Return status
    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
End Class