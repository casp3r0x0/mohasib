Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Settings.username = "" Then
            Form2.Show()
        Else

        End If
        '
        If My.Settings.cokies = "1" Then
            Me.Enabled = True
        ElseIf My.Settings.username = "" Then

        Else
            sginin.Show()
        End If

        Try
            ToolStripStatusLabel6.Text = ListView2.Items.Count
            ToolStripStatusLabel4.Text = ListView1.Items.Count
            Dim totalprofit As Single = 0
            For Each item As ListViewItem In ListView1.Items
                totalprofit = totalprofit + item.SubItems.Item(3).Text
            Next
            ToolStripStatusLabel2.Text = totalprofit
            'الجمع 
            Dim total As Single = 0
            Dim cost As Single = 0
            Dim profit As Single = 0
            For Each item2 As ListViewItem In ListView2.Items
                total = total + item2.SubItems.Item(3).Text
                cost = cost + item2.SubItems.Item(4).Text
                profit = profit + item2.SubItems.Item(5).Text
            Next
            Label17.Text = total
            Label18.Text = cost
            Label19.Text = profit

        Catch ex As Exception

        End Try


    End Sub

    Private Sub اعداداتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اعداداتToolStripMenuItem.Click
        settings.Show()
    End Sub

    Private Sub اضافهمنتجاتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافهمنتجاتToolStripMenuItem.Click
        montag.Show()
    End Sub

    Private Sub اضافهزبونجديدToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اضافهزبونجديدToolStripMenuItem.Click
        addzbon.Show()
    End Sub

    Private Sub فتحاجندهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles فتحاجندهToolStripMenuItem.Click
        openajenda.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label22.Text = 0 Then
            MsgBox("يجب  اختيار الزبون  عن طريق خيار فتح اجنده ")
        Else
            newfw.Show()
        End If
    End Sub

    Private Sub استعراضتفاصيلالفاتورةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استعراضتفاصيلالفاتورةToolStripMenuItem.Click
        Dim fwpath As String = Application.StartupPath & "\database\" & Label22.Text & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text) & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        ListView2.Items.Clear()
        Label11.Text = "0/0/0"
        Label13.Text = "n/n"
        RichTextBox1.Text = ""
        Label17.Text = "0"
        Label18.Text = "0"
        Label19.Text = "0"
        Label24.Text = "n/n"
        'get  info  
        Try
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(fwpath)
            For Each line As String In myCoolFileLines
                Dim lineArray() As String = line.Split("#")
                Dim newItem As New ListViewItem(lineArray(0))
                newItem.SubItems.Add(lineArray(1))
                newItem.SubItems.Add(lineArray(2))
                newItem.SubItems.Add(lineArray(3))
                newItem.SubItems.Add(lineArray(4))
                newItem.SubItems.Add(lineArray(5))
                RichTextBox1.Text = lineArray(6)
                ListView2.Items.Add(newItem)
            Next
            Label11.Text = ListView1.SelectedItems.Item(0).SubItems(0).Text
            Label13.Text = ListView1.SelectedItems.Item(0).SubItems(4).Text
            Label24.Text = ListView1.SelectedItems.Item(0).SubItems(5).Text
        Catch ex As Exception
            MsgBox("حدث  خلل في  استيراد القيم  ")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
    Function getnumber(ByVal n As String)
        Dim status As String
        If n = "مدفوع" Then
            status = "1"
        End If
        If n = "متبقي" Then
            status = "2"
        End If
        If n = "غير مدفوع" Then
            status = "3"
        End If
        Return status
    End Function

    Private Sub تمدفعالفاتورةواحسبتواصلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تمدفعالفاتورةواحسبتواصلToolStripMenuItem.Click
        Dim namefile As String = Application.StartupPath & "\database\" & Label22.Text & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text) & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        Dim namefile2 As String = ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text).replace("2", "1").replace("3", "1") & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        '
        Dim filePath As String = namefile

        If File.Exists(filePath) Then
            Dim strNewFileName As String = namefile2
            My.Computer.FileSystem.RenameFile(filePath, strNewFileName)
        End If
        '
        ListView1.SelectedItems.Item(0).SubItems(4).Text = "مدفوع"
    End Sub

    Private Sub تغيرحالةالفاتورةالىمتبقيToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تغيرحالةالفاتورةالىمتبقيToolStripMenuItem.Click
        Dim namefile As String = Application.StartupPath & "\database\" & Label22.Text & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text) & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        Dim namefile2 As String = ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text).replace("1", "2").replace("3", "2") & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        '
        Dim filePath As String = namefile
        If File.Exists(filePath) Then
            Dim strNewFileName As String = namefile2
            My.Computer.FileSystem.RenameFile(filePath, strNewFileName)
        End If
        '
        ListView1.SelectedItems.Item(0).SubItems(4).Text = "متبقي"
    End Sub

    Private Sub تغيرحالةالفاتورةإلىغيرواصلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تغيرحالةالفاتورةإلىغيرواصلToolStripMenuItem.Click
        Dim namefile As String = Application.StartupPath & "\database\" & Label22.Text & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text) & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        Dim namefile2 As String = ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text).replace("1", "3").replace("2", "3") & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        '
        Dim filePath As String = namefile
        If File.Exists(filePath) Then
            Dim strNewFileName As String = namefile2
            My.Computer.FileSystem.RenameFile(filePath, strNewFileName)
        End If
        '
        ListView1.SelectedItems.Item(0).SubItems(4).Text = "غير مدفوع"
    End Sub

    Private Sub حذفالفاتورهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفالفاتورهToolStripMenuItem.Click
        Dim namefile As String = Application.StartupPath & "\database\" & Label22.Text & "\" & ListView1.SelectedItems.Item(0).SubItems(0).Text.Replace("/", "_") & "#" & ListView1.SelectedItems.Item(0).SubItems(1).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(2).Text & "#" & ListView1.SelectedItems.Item(0).SubItems(3).Text & "#" & getnumber(ListView1.SelectedItems.Item(0).SubItems(4).Text) & "#" & ListView1.SelectedItems.Item(0).SubItems(5).Text
        Dim result As DialogResult = MessageBox.Show("هل تريد فعلا حذف هذه الفاتورة ؟", "تأكيد", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(namefile)
            For Each i As ListViewItem In ListView1.SelectedItems
                ListView1.Items.Remove(i)
            Next
        ElseIf result = DialogResult.No Then
            MsgBox("تم الغاء  العمليه ")
        End If
    End Sub

    Private Sub تحريرالفاتورةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تحريرالفاتورةToolStripMenuItem.Click
        editfw.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim all As New List(Of String)
        Try
            ListView1.Items.Clear()
            Dim di As New IO.DirectoryInfo(Application.StartupPath & "\database\" & Label22.Text)
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
                ListView1.Items.Add(newItem)
            Next
        Catch ex As Exception
            MsgBox("خطأ في  استرداد الفيم  ")
        End Try
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
            Button2.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintPreviewDialog1.Size = Me.Size
        If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim margin As Single = 40
        Dim marginBetween As Single = 7
        Dim currentTop As Single = margin


        Dim fnt As New Font("Arial", 18, FontStyle.Bold)
        Dim fwNo As String = "#NO " & Label24.Text
        Dim strdate As String = "التاريخ  : " & Label11.Text
        Dim strname As String = "الاسم :" & Label6.Text

        Dim fontSizeno As SizeF = e.Graphics.MeasureString(fwNo, fnt)
        Dim fontSizedate As SizeF = e.Graphics.MeasureString(strdate, fnt)
        Dim fontsizename As SizeF = e.Graphics.MeasureString(strname, fnt)

        e.Graphics.DrawString(fwNo, fnt, Brushes.Red, (e.PageBounds.Width - 800), margin)
        currentTop += fontSizeno.Height + marginBetween
        e.Graphics.DrawString(strdate, fnt, Brushes.Black, e.PageBounds.Width - fontSizedate.Width - margin, currentTop)
        currentTop += fontSizedate.Height + marginBetween
        e.Graphics.DrawString(strname, fnt, Brushes.Black, e.PageBounds.Width - fontsizename.Width - margin, currentTop)
        currentTop += fontsizename.Height + marginBetween

        e.Graphics.DrawRectangle(Pens.Black, margin, currentTop, e.PageBounds.Width - margin * 2, e.PageBounds.Height - currentTop - margin)
        currentTop += marginBetween

        Dim colheight As Single = 60
        Dim col1width As Single = 300
        Dim col2width As Single = 125 + col1width
        Dim col3width As Single = 125 + col2width
        Dim col4width As Single = 125 + col3width


        e.Graphics.DrawLine(Pens.Black, margin, currentTop + colheight, e.PageBounds.Width - margin, currentTop + colheight)
        e.Graphics.DrawString("الصنف", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col1width / 2), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col1width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("الكميه", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col2width - 40), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col2width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("السعر ", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col3width - 40), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col3width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("اجمالي ", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col4width - 10), currentTop)
        ''''''''''''''''''''''''''''''''''''''''' تفاصيل '''''''''''''''''''''''''''''''''''''''''
        Dim rowHeight As Single = 70
        Dim ccc As Integer = ListView2.Items.Count
        For x = 0 To ccc - 1
            Dim sinf As String = ListView2.Items(x).Text
            Dim count As String = ListView2.Items.Item(x).SubItems.Item(1).Text
            Dim cost As String = ListView2.Items.Item(x).SubItems.Item(2).Text
            Dim total_info As String = ListView2.Items.Item(x).SubItems.Item(3).Text

            e.Graphics.DrawString(sinf, fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - col1width, currentTop + rowHeight)
            e.Graphics.DrawString(count, fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - col2width + 10, currentTop + rowHeight)
            e.Graphics.DrawString(cost, fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - col3width + 10, currentTop + rowHeight)
            e.Graphics.DrawString(total_info & "JD", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - col4width + 10, currentTop + rowHeight)

            e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colheight, e.PageBounds.Width - margin, currentTop + rowHeight + colheight)

            rowHeight += 70
        Next
        e.Graphics.DrawString("المجموع", fnt, Brushes.Blue, e.PageBounds.Width - margin * 2 - col3width + 10, currentTop + rowHeight)
        e.Graphics.DrawString(Label17.Text, fnt, Brushes.Red, e.PageBounds.Width - margin * 2 - col4width + 10, currentTop + rowHeight)
        e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colheight, e.PageBounds.Width - margin, currentTop + rowHeight + colheight)

        ''''''''''''''''''''''''''''''''''''''''' نهايه التفاصيل  '''''''''''''''''''''''''''''''


    End Sub

    Private Sub عنالبرنامجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles عنالبرنامجToolStripMenuItem.Click
        MsgBox("تم برمجه هذا البرنامج من قبل حسن علي  " & vbCrLf & "نسخه  beta 1.0.0 " & vbCrLf & "تاريخ الاصدار 24/4/2020")
    End Sub
End Class
