Public Class main

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AHMED\Documents\Visual Studio 2015\Projects\FinalPractical\FinalPractical\DatabasePatient.mdf;Integrated Security=True"
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.DataSource = display()

    End Sub

    Private Sub ADDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDToolStripMenuItem.Click
        add.Show()
    End Sub

    Private Sub REFRESHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REFRESHToolStripMenuItem.Click
        DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
        DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridView1.DataSource = display()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())
            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DELETEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELETEToolStripMenuItem.Click
        If i <> 0 Then
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "delete from patient where id='" & i & "'"
            cmd.ExecuteNonQuery()

            DataGridView1.DefaultCellStyle.SelectionBackColor = Color.White
            DataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black
            DataGridView1.DataSource = display()
        Else
            MsgBox("Please Select Record")
        End If

    End Sub

    Private Sub UPDATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATEToolStripMenuItem.Click
        If i <> 0 Then
            Dim ma As New update
            ma.Show()
        Else
            MsgBox("Please Select Record")
        End If
    End Sub
End Class
