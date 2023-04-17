﻿Imports MySql.Data.MySqlClient

Public Class Form5

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            myconn.Open()
            Dim query = "SELECT * FROM payroll_management_system.job_department;"
            Dim Search As New MySqlDataAdapter(query, myconn)
            Dim ds As DataSet = New DataSet
            Search.Fill(ds, "job_department")
            DataGridView1.DataSource = ds.Tables("job_department")
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
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Form6.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Form7.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Form8.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class