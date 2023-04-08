Imports MySql.Data.MySqlClient
Public Class payroll
    Dim con As MySqlConnection
    Dim cnstr As String = "datasource = localhost; user = root; database = payroll_g2_v2"
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim result As Integer
    Dim hw, rate, ni, sss, ph, pi, tax, td, netpay, oth, otf As Double
    Dim inputTxt As String
    Dim numericCheck As Boolean


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        enTXT.Enabled = True
        hwTXT.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            MsgBox("Connected Successfully")
        Catch ex As Exception
        End Try

    End Sub


   
    Private Sub payroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.FlatAppearance.BorderSize = 0

        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
            Dim con As New MySqlConnection("server=localhost;user= root;database=payroll_g2_v2")
            Dim cmd As MySqlCommand
            Dim dr As MySqlDataReader
            Dim sql As String

            Try
                con.Open()
                sql = "SELECT p.*, e.first_name FROM payroll p JOIN employee e WHERE p.employee_id = e.employee_id GROUP BY e.employee_id"
                cmd = New MySqlCommand
                With cmd
                    .Connection = con
                    .CommandText = sql
                    dr = .ExecuteReader()
                End With
                ListView1.Items.Clear()
                Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                    list.SubItems.Add(dr(12))
                    list.SubItems.Add(dr(2))
                    list.SubItems.Add(dr(3))
                    list.SubItems.Add(dr(4))
                    list.SubItems.Add(dr(5))
                    list.SubItems.Add(dr(6))
                    list.SubItems.Add(dr(7))
                    list.SubItems.Add(dr(8))
                    list.SubItems.Add(dr(9))
                    list.SubItems.Add(dr(10))
                list.SubItems.Add(dr(11))
                list.SubItems.Add(dr(1))


                Loop
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                'con.Close()
            End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            con = New MySqlConnection(cnstr)
            Dim mysqlCommand As MySqlCommand
            Dim mysqlDataReader As MySqlDataReader
            con.Open()
            cmd = New MySqlCommand()

            Dim sql As String
            sql = "INSERT INTO employee (`employee_id`,`first_name`) VALUES ('" & TextBox2.Text & "','" & enTXT.Text & "')"
            sql = sql & "; INSERT INTO payroll (`employee_id`,`no_of_hours`,`net_income`,`overtime_hours`,`overtime_fees`,`sss`,`pagibig`,`philhealth`,`tax`,`total_deduction`,`netpay`) VALUES ('" & TextBox2.Text & "', '" & hwTXT.Text & "', '" & niTXT.Text & "', '" & othTXT.Text & "', '" & otfTXT.Text & "', '" & sssTXT.Text & "', '" & piTXT.Text & "', '" & phTXT.Text & "', '" & taxTXT.Text & "', '" & tdTXT.Text & "', '" & netpayTXT.Text & "')"

            mysqlCommand = New MySqlCommand(sql, con)
            mysqlDataReader = mysqlCommand.ExecuteReader
        
                MessageBox.Show("Inserted!")
                TextBox2.Clear()
                hwTXT.Clear()
                enTXT.Clear()
                niTXT.Clear()
                sssTXT.Clear()
                phTXT.Clear()
                piTXT.Clear()
                taxTXT.Clear()
                tdTXT.Clear()
                netpayTXT.Clear()
                othTXT.Clear()
                otfTXT.Clear()


        Catch ex As Exception
        End Try
        con.Close()



        'Dim con As New MySqlConnection("server=localhost;user= root;database=payroll_g2_v2")
        'Dim cmd As MySqlCommand
        Dim dr As MySqlDataReader
        Dim sql1 As String

        Try
            con.Open()
            sql1 = "SELECT p.*, e.first_name FROM payroll p JOIN employee e WHERE p.employee_id = e.employee_id GROUP BY e.employee_id"
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = sql1
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(12))
                list.SubItems.Add(dr(2))
                list.SubItems.Add(dr(3))
                list.SubItems.Add(dr(4))
                list.SubItems.Add(dr(5))
                list.SubItems.Add(dr(6))
                list.SubItems.Add(dr(7))
                list.SubItems.Add(dr(8))
                list.SubItems.Add(dr(9))
                list.SubItems.Add(dr(10))
                list.SubItems.Add(dr(11))
                list.SubItems.Add(dr(1))
             

                ' End If


            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'con.Close() 
            
        End Try
    End Sub

    Private Sub hwTXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hwTXT.TextChanged

        Dim lnumber As Double
        Dim lResult As Long

        lnumber = 1232534.234
        lResult = Int(lnumber)
        inputTxt = hwTXT.Text()
        numericCheck = IsNumeric(inputTxt)

        If numericCheck Then
            hw = inputTxt
            Button1.Enabled = True

        ElseIf inputTxt = "" Then
            niTXT.Clear()
            sssTXT.Clear()
            phTXT.Clear()
            piTXT.Clear()
            taxTXT.Clear()
            tdTXT.Clear()
            netpayTXT.Clear()
            othTXT.Clear()
            otfTXT.Clear()
            Button1.Enabled = False
        Else

            MsgBox("You did not enter a numeric value.")
        End If

        If hw >= 40 And hw <= 500 And numericCheck Then
            rate = 108.33
            niTXT.Text = rate * hw
            ni = niTXT.Text
            othTXT.Text = hw - 40
            oth = othTXT.Text
            otfTXT.Text = (oth * 1.5) * 108.33
            otf = otfTXT.Text
            ni = rate * 40
            ni = ni + otf
            sssTXT.Text = ni * 0.0572
            sss = sssTXT.Text
            phTXT.Text = ni * 0.082
            ph = phTXT.Text
            piTXT.Text = ni * 0.075
            pi = piTXT.Text
            taxTXT.Text = ni * 0.12
            tax = taxTXT.Text
            tdTXT.Text = sss + ph + pi + tax
            td = tdTXT.Text
            netpayTXT.Text = ni - td
            netpay = netpayTXT.Text
            lnumber = 1232534.234
            lResult = Int(netpay)


        ElseIf hw >= 1 And hw <= 40 And numericCheck Then
            rate = 108.33
            niTXT.Text = rate * hw
            ni = niTXT.Text
            sssTXT.Text = ni * 0.0572
            sss = sssTXT.Text
            phTXT.Text = ni * 0.082
            ph = phTXT.Text
            piTXT.Text = ni * 0.075
            pi = piTXT.Text
            taxTXT.Text = ni * 0.12
            tax = taxTXT.Text
            tdTXT.Text = sss + ph + pi + tax
            td = tdTXT.Text
            netpayTXT.Text = ni - td
            netpay = netpayTXT.Text
        ElseIf hw >= 500 And numericCheck Then
            MsgBox("Invalid hours")

        End If

    End Sub

    Private Sub enTXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enTXT.TextChanged
        If enTXT.Text <> "" Then
            Dim time As DateTime = DateTime.Now
            Dim format As String = "yyyyMMdHHmm"

            Try
                con = New MySqlConnection(cnstr)
                con.Open()

                Dim mysqlCommand As MySqlCommand
                Dim Query As String

                Query = "SELECT COUNT(*) FROM employee"
                mysqlCommand = New MySqlCommand(Query, con)

                TextBox2.Text = time.ToString(format) + mysqlCommand.ExecuteScalar().ToString()

                con.Close()
            Catch ex As Exception
            End Try
        End If
        If hwTXT.Text = "" And enTXT.Text = "" Then
            TextBox2.Clear()

        End If
    End Sub

    Private Sub ListView1_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        Button1.Enabled = False

    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        Button1.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True

        TextBox1.Text = ListView1.SelectedItems(0).SubItems(0).Text
        enTXT.Text = ListView1.SelectedItems(0).SubItems(1).Text
        enTXT.Enabled = False
        hwTXT.Text = ListView1.SelectedItems(0).SubItems(2).Text
        niTXT.Text = ListView1.SelectedItems(0).SubItems(3).Text
        othTXT.Text = ListView1.SelectedItems(0).SubItems(4).Text
        otfTXT.Text = ListView1.SelectedItems(0).SubItems(5).Text
        sssTXT.Text = ListView1.SelectedItems(0).SubItems(6).Text
        piTXT.Text = ListView1.SelectedItems(0).SubItems(7).Text
        phTXT.Text = ListView1.SelectedItems(0).SubItems(8).Text
        taxTXT.Text = ListView1.SelectedItems(0).SubItems(9).Text
        tdTXT.Text = ListView1.SelectedItems(0).SubItems(10).Text
        netpayTXT.Text = ListView1.SelectedItems(0).SubItems(11).Text
        TextBox2.Text = ListView1.SelectedItems(0).SubItems(12).Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        'MsgBox(enTXT.Text)
        ' MsgBox(TextBox1.Text)
        ' MsgBox(hwTXT.Text)
        Dim MysqlConn As MySqlConnection '
        Dim updatePayrollCommand As MySqlCommand '

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "datasource = localhost; user = root; database = payroll_g2_v2"
        Dim updatePayrollReader As MySqlDataReader '
        MysqlConn.Open()
        Try
            Dim updatePayroll As String
            updatePayroll = "UPDATE payroll SET no_of_hours='" & hwTXT.Text & "', net_income='" & niTXT.Text & "',overtime_hours='" & othTXT.Text & "',overtime_fees='" & otfTXT.Text & "',sss='" & sssTXT.Text & "',pagibig='" & piTXT.Text & "',philhealth='" & phTXT.Text & "',tax='" & taxTXT.Text & "',total_deduction='" & tdTXT.Text & "',netpay='" & netpayTXT.Text & "' WHERE employee_id='" & TextBox2.Text & "' AND id = '" & TextBox1.Text & "' "
            updatePayrollCommand = New MySqlCommand(updatePayroll, MysqlConn)
            updatePayrollReader = updatePayrollCommand.ExecuteReader

            MessageBox.Show("Success.")
         
            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
        '--------------------

        Try
            con = New MySqlConnection(cnstr)
            Dim mysqlCommand As MySqlCommand
            Dim mysqlDataReader As MySqlDataReader
            con.Open()
            cmd = New MySqlCommand()

            Dim time As DateTime = DateTime.Now
            Dim format As String = "yyyy/MM/dd HH:mm:ss"

            Dim sql As String
            sql = "INSERT INTO payroll_history (`employee_id`,`no_of_hours`,`net_income`,`overtime_hours`,`overtime_fees`,`sss`,`pagibig`,`philhealth`,`tax`,`total_deduction`,`netpay`, `date_created`) VALUES ('" & TextBox2.Text & "', '" & hwTXT.Text & "', '" & niTXT.Text & "', '" & othTXT.Text & "', '" & otfTXT.Text & "', '" & sssTXT.Text & "', '" & piTXT.Text & "', '" & phTXT.Text & "', '" & taxTXT.Text & "', '" & tdTXT.Text & "', '" & netpayTXT.Text & "', '" & time.ToString(format) & "')"

            mysqlCommand = New MySqlCommand(sql, con)
            mysqlDataReader = mysqlCommand.ExecuteReader
            TextBox2.Clear()
            TextBox1.Clear()
            hwTXT.Clear()
            enTXT.Clear()
            niTXT.Clear()
            sssTXT.Clear()
            phTXT.Clear()
            piTXT.Clear()
            taxTXT.Clear()
            tdTXT.Clear()
            netpayTXT.Clear()
            othTXT.Clear()
            otfTXT.Clear()
        Catch ex As Exception
        End Try

        con.Close()

        Dim dr As MySqlDataReader
        Dim sql1 As String

        Try
            con.Open()
            sql1 = "SELECT p.*, e.first_name FROM payroll p JOIN employee e WHERE p.employee_id = e.employee_id GROUP BY e.employee_id"
            cmd = New MySqlCommand
            With cmd
                .Connection = con
                .CommandText = sql1
                dr = .ExecuteReader()
            End With
            ListView1.Items.Clear()
            Do While dr.Read = True
                Dim list = ListView1.Items.Add(dr(0))
                list.SubItems.Add(dr(12))
                list.SubItems.Add(dr(2))
                list.SubItems.Add(dr(3))
                list.SubItems.Add(dr(4))
                list.SubItems.Add(dr(5))
                list.SubItems.Add(dr(6))
                list.SubItems.Add(dr(7))
                list.SubItems.Add(dr(8))
                list.SubItems.Add(dr(9))
                list.SubItems.Add(dr(10))
                list.SubItems.Add(dr(11))
                list.SubItems.Add(dr(1))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim MysqlConn As MySqlConnection
        Dim deletePayrollCommand As MySqlCommand
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "datasource = localhost; user = root; database = payroll_g2_v2"
        Dim deletePayrollReader As MySqlDataReader
        MysqlConn.Open()
        Try
            Dim deletepayroll As String
            deletepayroll = "DELETE FROM payroll WHERE employee_id='" & TextBox2.Text & "' AND id = '" & TextBox1.Text & "'"
            deletePayrollCommand = New MySqlCommand(deletePayroll, MysqlConn)
            deletePayrollReader = deletePayrollCommand.ExecuteReader
            MessageBox.Show("DELETED!.")

            MysqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try
        '--------------------

        Try
            con = New MySqlConnection(cnstr)
            Dim mysqlCommand As MySqlCommand
            Dim mysqlDataReader As MySqlDataReader
            con.Open()
            cmd = New MySqlCommand()

            Dim time As DateTime = DateTime.Now
            Dim format As String = "yyyy/MM/dd HH:mm:ss"

            Dim sql As String
            sql = "INSERT INTO deleted_payroll (`employee_id`,`no_of_hours`,`net_income`,`overtime_hours`,`overtime_fees`,`sss`,`pagibig`,`philhealth`,`tax`,`total_deduction`,`netpay`, `date_created`) VALUES ('" & TextBox2.Text & "', '" & hwTXT.Text & "', '" & niTXT.Text & "', '" & othTXT.Text & "', '" & otfTXT.Text & "', '" & sssTXT.Text & "', '" & piTXT.Text & "', '" & phTXT.Text & "', '" & taxTXT.Text & "', '" & tdTXT.Text & "', '" & netpayTXT.Text & "', '" & time.ToString(format) & "')"

            mysqlCommand = New MySqlCommand(sql, con)
            mysqlDataReader = mysqlCommand.ExecuteReader


            Dim response As Integer
            For Each i As ListViewItem In ListView1.SelectedItems
                response = MsgBox("Are you sure you want to delete Employee: " + enTXT.Text, vbYesNo, "Confirm Delete")
                If response = vbYes Then
                    ListView1.Items.Remove(i)

                End If
            Next



            TextBox2.Clear()
            TextBox1.Clear()
            hwTXT.Clear()
            enTXT.Clear()
            niTXT.Clear()
            sssTXT.Clear()
            phTXT.Clear()
            piTXT.Clear()
            taxTXT.Clear()
            tdTXT.Clear()
            netpayTXT.Clear()
            othTXT.Clear()
            otfTXT.Clear()
        Catch ex As Exception
        End Try

        con.Close()

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class


