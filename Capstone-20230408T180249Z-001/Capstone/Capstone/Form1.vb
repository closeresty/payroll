Imports MySql.Data.MySqlClient
Public Class Form1
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    
    Private countAttempts = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        

        If Timer1.Enabled = True Then
            Timer1.Start()
        Else
            Label3.Text = 5
            Timer1.Start()
        End If
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
      "datasource = localhost; user = root; database = payroll_g2_v2"
        Dim READER As MySqlDataReader


        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select * from user_account where username='" & UsernameTextBox.Text & "' and password='" & PasswordTextBox.Text & "' "
            Command = New MySqlCommand(Query, MysqlConn)
            READER = Command.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1

            End While

            If count = 1 Then
                MessageBox.Show("Username and password are correct")
                Me.Hide()
                payroll.show()
            ElseIf count > 1 Then
                MessageBox.Show("")
            Else
                countAttempts += 1
                If countAttempts = 3 Then
                    MessageBox.Show("You’ve reached the maximum login attempts, Please try again later.")
                    UsernameTextBox.Clear()
                    PasswordTextBox.Clear()
                    UsernameTextBox.Enabled = False
                    PasswordTextBox.Enabled = False
                    Button1.Enabled = False
                    Label1.Enabled = False
                   
                ElseIf countAttempts < 3 Then
                    MessageBox.Show("Username and password are not correct")
                End If


            End If
            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
    End Sub

    Private Sub CLOSEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
    End Sub

    ' Private Sub ACCOUNTRECOVERYToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCOUNTRECOVERYToolStripMenuItem.Click
    '  Me.Hide()
    ' Form2.Show()
    'End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        PasswordTextBox.PasswordChar = If(CheckBox1.Checked, Nothing, "*"c)
        'PasswordTextBox.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Button1.Enabled = False Then
            Timer1.Start()
            Timer1.Interval = 1000
            Label3.ForeColor = Color.White

            If Label3.Text = 0 Then
                countAttempts = 0
                Timer1.Enabled = False
                UsernameTextBox.Clear()
                PasswordTextBox.Clear()
                UsernameTextBox.Enabled = True
                PasswordTextBox.Enabled = True
                Button1.Enabled = True
                Label1.Enabled = True
                MsgBox("You may try login again.")

            Else
                Label3.Text = Val(Label3.Text) - 1



            End If

        End If




    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Label3.ForeColor = Color.White
        If Timer1.Enabled = False Then
            Timer1.Start()
        Else
            Label3.Text = 5
            Timer1.Start()
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub
End Class