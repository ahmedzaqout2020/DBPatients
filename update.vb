
Imports System.Data.SqlClient

Public Class update
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles EDIT.Click
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Name")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Age")
        Else
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update patient set name='" + TextBox1.Text + "',age='" + TextBox2.Text + "' where id=" & i & ""
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Updated Successfully")
                Me.Hide()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub update_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from patient where id=" & i & ""
        Try
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                TextBox1.Text = dr.GetString(1).ToString()
                TextBox2.Text = dr.GetString(2).ToString()

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class