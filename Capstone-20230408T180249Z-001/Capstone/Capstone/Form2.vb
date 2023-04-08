Imports MySql.Data.MySqlClient
Public Class Form2
    Dim MysqlConn As MySqlConnection
    Dim getUsernameAndSecretAnswerCommand As MySqlCommand
    Dim COMMAND2 As MySqlCommand


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "datasource = localhost; user = root; database = payroll_g2_v2"
        Dim getUsernameAndSecretAnswerReader As MySqlDataReader
        MysqlConn.Open()

        'for combobox changing values
        Dim comboBoxQuestion As String
        Dim questionValue As Integer


        comboBoxQuestion = QuestionCMBOX.SelectedItem.ToString

        If comboBoxQuestion = "What is your favorite color?" Then
            questionValue = 1
        ElseIf comboBoxQuestion = "Who is your fisrt teacher?" Then
            questionValue = 2
        ElseIf comboBoxQuestion = "What is your nickname?" Then
            questionValue = 3
        
        End If
       
        Try
            Dim getUsernameAndSecretAnswer As String
            getUsernameAndSecretAnswer = "SELECT ua.username, sq.question, sq.answer FROM user_account ua JOIN security_question sq ON ua.id = sq.id WHERE ua.username='" & TextBox1.Text & "' AND sq.question='" & questionValue & "' AND sq.answer='" & TextBox3.Text & "'"
            getUsernameAndSecretAnswerCommand = New MySqlCommand(getUsernameAndSecretAnswer, MysqlConn)
            getUsernameAndSecretAnswerReader = getUsernameAndSecretAnswerCommand.ExecuteReader

            Dim count As Integer

            count = 0
            While getUsernameAndSecretAnswerReader.Read
                count += 1
            End While

            If count = 1 Then
                MessageBox.Show("Your answer is correct")
                Form3.TextBox1.Text = TextBox1.Text
                Form3.TextBox2.Text = TextBox3.Text
                Me.Hide()
                Form3.Show()

            ElseIf count > 1 Then
                MessageBox.Show("Question and answer are Duplicate")
            Else
                MessageBox.Show("Question and Answer are not correct")

            End If

            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try


    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button1.Enabled = False
      
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    
    End Sub

    Private Sub QuestionCMBOX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuestionCMBOX.SelectedIndexChanged
        If QuestionCMBOX.Text = "1" Then
            Button1.Enabled = False

        Else
            Button1.Enabled = True
        End If
    End Sub
End Class