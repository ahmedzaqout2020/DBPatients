Imports System.Data.SqlClient

Module Module1
    Public i As Integer
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public rd As SqlDataReader
    Public Function display()
        cmd = con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from patient"
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        Return dt
    End Function
End Module
