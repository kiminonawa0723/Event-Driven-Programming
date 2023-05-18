Imports MySql.Data.MySqlClient

Public Class Login
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Create_Account.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        With Me
            Call Connect_to_DB()
            Dim mycmd As New MySqlCommand
            strSQL = "SELECT COUNT(*) FROM admin WHERE email = '" & .email.Text & "' AND password = MD5('" & .userPassword.Text & "')"
            mycmd.CommandText = strSQL
            mycmd.Connection = myconn

            Dim count As Integer = CInt(mycmd.ExecuteScalar())

            If count > 0 Then
                MsgBox("Login Successful!")
                Dashboard.Show()
                Me.Hide()
            Else
                MsgBox("Invalid Email or Password")
            End If
            Call Disconnect_to_DB()
        End With
    End Sub
End Class
