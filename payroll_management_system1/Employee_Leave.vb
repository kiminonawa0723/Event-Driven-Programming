Imports MySql.Data.MySqlClient

Public Class Employee_Leave

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            myconn.Open()
            Dim query = "SELECT * FROM payroll_management_system.emp_leave;"
            Dim Search As New MySqlDataAdapter(query, myconn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, "emp_leave")
            DataGridView1.DataSource = ds.Tables("emp_leave")
            myconn.Close()

            For Each col As DataGridViewColumn In DataGridView1.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            DataGridView1.Columns(DataGridView1.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message)
            myconn.Close()
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dashboard.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Employee.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Job_Department.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Salary_Bonus.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Payroll.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        Call ExportToExcel(Me.DataGridView1, "Employee_Leave.xlsx")
    End Sub
End Class