


Public Class add


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Name")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Age")
        Else
            Try
                cmd = con.CreateCommand()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "insert into patient values('" + TextBox1.Text + "','" + TextBox2.Text + "')"
                cmd.ExecuteNonQuery()
                MessageBox.Show("Added Successfully")
                Me.Hide()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

End Class