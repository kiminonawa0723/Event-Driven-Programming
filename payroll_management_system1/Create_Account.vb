Imports System.Windows
Imports MySql.Data.MySqlClient

Public Class Create_Account
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Connect_to_DB()
        Try
            If String.IsNullOrEmpty(firstName.Text) OrElse String.IsNullOrEmpty(lastName.Text) OrElse
                String.IsNullOrEmpty(email.Text) OrElse String.IsNullOrEmpty(userPassword.Text) Then
                MsgBox("Please Complete the Form!")
                Exit Sub
            Else
                Using cmd As New MySqlCommand("INSERT INTO admin(first_name, last_name, email, password) VALUES(?,?,?,MD5(?))", myconn)
                    cmd.Parameters.AddWithValue("first_name", firstName.Text)
                    cmd.Parameters.AddWithValue("last_name", lastName.Text)
                    cmd.Parameters.AddWithValue("email", email.Text)
                    cmd.Parameters.AddWithValue("password", userPassword.Text)
                    cmd.ExecuteNonQuery()
                End Using
                MsgBox("User Successfully Registered")
                Call Disconnect_to_DB()
                Login.Show()
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("An Error Occured: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class