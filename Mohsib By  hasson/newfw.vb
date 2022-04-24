Imports System.Text.RegularExpressions

Public Class newfw
    Dim montag As String = Application.StartupPath & "\montag.dll"
    Private Sub newfw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox6.Text = My.Settings.fwtnum + 1
        TextBox5.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        Label22.Text = Form1.Label22.Text
        Label6.Text = Form1.Label6.Text
        Label7.Text = Form1.Label7.Text
        Label8.Text = Form1.Label8.Text
        Label9.Text = Form1.Label9.Text
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        Try
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(montag)
            For Each line As String In myCoolFileLines
                Dim lineArray() As String = line.Split("#")
                ComboBox1.Items.Add(lineArray(0))
            Next
        Catch ex As Exception
            MsgBox("حدث  خلل في  استيراد القيم  ")
        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim item As String = ComboBox1.SelectedItem.ToString
        Try
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(montag)
            For Each line As String In myCoolFileLines
                Dim lineArray() As String = line.Split("#")
                If lineArray(0) = item Then
                    TextBox1.Text = lineArray(1)
                    TextBox2.Text = lineArray(2)
                    TextBox3.Text = lineArray(3)
                End If

            Next
        Catch ex As Exception
            MsgBox("حدث  خلل في  استيراد القيم  ")
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If Regex.IsMatch(TextBox4.Text, "^[0-9 ]+$") Or TextBox4.Text = "" Then

        Else
            TextBox4.Text = ""
            MsgBox("لا  يجب ان يحتوي هذا الحقل على  حروف")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox4.Text = "" Then
            MsgBox(" يجب كتابة عدد ")
        Else
            Dim total As Single = TextBox4.Text * TextBox1.Text
            Dim cost As Single = TextBox4.Text * TextBox2.Text
            Dim profit As Single = TextBox4.Text * TextBox3.Text
            Dim newItem As New ListViewItem(ComboBox1.Text)
            newItem.SubItems.Add(TextBox4.Text)
            newItem.SubItems.Add(TextBox1.Text)
            newItem.SubItems.Add(total)
            newItem.SubItems.Add(cost)
            newItem.SubItems.Add(profit)
            ListView2.Items.Add(newItem)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim total As Single = 0
        Dim cost As Single = 0
        Dim profit As Single = 0
        Try
            For Each item As ListViewItem In ListView2.Items
                Dim total_info As Single = item.SubItems.Item(3).Text
                total = total + total_info
                Dim cost_info As Single = item.SubItems.Item(4).Text
                cost = cost + cost_info
                Dim profit_info As Single = item.SubItems.Item(5).Text
                profit = profit + profit_info
            Next
            Label16.Text = total
            Label23.Text = cost
            Label24.Text = profit
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub حذفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفToolStripMenuItem.Click
        For Each i As ListViewItem In ListView2.SelectedItems
            ListView2.Items.Remove(i)
        Next
    End Sub

    Private Sub حفظالفاتورةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حفظالفاتورةToolStripMenuItem.Click
        If ComboBox2.Text = "" Then
            MsgBox("يجب تحديد حاله الفاتورة ")
        Else
            Dim status As String
            If ComboBox2.Text = "مدفوع" Then
                status = "1"
            End If
            If ComboBox2.Text = "متبقي" Then
                status = "2"
            End If
            If ComboBox2.Text = "غير مدفوع" Then
                status = "3"
            End If
            Try
                Dim path As String = Application.StartupPath & "\database\" & Label22.Text & "\"
                Dim name As String = TextBox5.Text.Replace("/", "_") & "#" & Label16.Text & "#" & Label23.Text & "#" & Label24.Text & "#" & status & "#" & TextBox6.Text
                Dim filepath As String = path & name
                If Not System.IO.File.Exists(filepath) Then
                    System.IO.File.Create(filepath).Dispose()
                End If
                'save content 
                Dim all As New List(Of String)
                For Each item As ListViewItem In ListView2.Items
                    Dim x_1 As String = item.Text
                    Dim x_2 As String = item.SubItems.Item(1).Text
                    Dim x_3 As String = item.SubItems.Item(2).Text
                    Dim x_4 As String = item.SubItems.Item(3).Text
                    Dim x_5 As String = item.SubItems.Item(4).Text
                    Dim x_6 As String = item.SubItems.Item(5).Text
                    Dim x_7 As String = TextBox7.Text
                    Dim line As String = x_1 & "#" & x_2 & "#" & x_3 & "#" & x_4 & "#" & x_5 & "#" & x_6 & "#" & x_7
                    all.Add(line)
                Next
                If System.IO.File.Exists(filepath) = True Then
                    Dim objWriter As New System.IO.StreamWriter(filepath)
                    Dim r As New RichTextBox
                    r.Lines = all.ToArray
                    objWriter.Write(r.Text)
                    objWriter.Close()
                Else
                    MessageBox.Show("هنالك  مشكله ان ملف النصي  غير  موجود")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MsgBox("تم الحفظ بنجاح ")
            Me.Close()
        End If

    End Sub
End Class