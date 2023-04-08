Imports MySql.Data.MySqlClient
Public Class Form3
    Dim MysqlConn As MySqlConnection
    Dim updatePasswordCommand As MySqlCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox3.Text = TextBox4.Text Then
            Label1.Visible = False

            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString = "datasource = localhost; user = root; database = payroll_g2_v2"
            Dim updatePasswordReader As MySqlDataReader
            MysqlConn.Open()

            Try
                Dim updatePassword As String
                updatePassword = "UPDATE user_account SET password='" & TextBox3.Text & "' WHERE username='" & TextBox1.Text & "'"
                updatePasswordCommand = New MySqlCommand(updatePassword, MysqlConn)
                updatePasswordReader = updatePasswordCommand.ExecuteReader

                MessageBox.Show("Success. Please relogin")
                Me.Hide()
                Form1.Show()

                MysqlConn.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()
            End Try
        ElseIf TextBox3.Text <> TextBox4.Text Then
            Label1.Visible = True
            Label1.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        TextBox3.PasswordChar = If(CheckBox1.Checked, Nothing, "*"c)
        TextBox4.PasswordChar = If(CheckBox1.Checked, Nothing, "*"c)
    End Sub

    
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class