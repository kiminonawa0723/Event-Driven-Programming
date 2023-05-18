Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports MySql.Data.MySqlClient

Module Module1
    Public myconn As New MySql.Data.MySqlClient.MySqlConnection
    Public myConnectionString As String
    Public strSQL As String

    Public currentDate As DateTime = DateTime.Now
    Public strpassword = "BicolUni2020"
    Public xlsFiles As String = "C:\Users\Nissa\Documents\IT 120 Event Driven Programming\"
    Public Sub Connect_to_DB()
        myConnectionString = "server=127.0.0.1;" _
                    & "uid=root;" _
                    & "pwd=BicolUni2020;" _
                    & "database=payroll_management_system"
        Try
            myconn.ConnectionString = myConnectionString
            myconn.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MsgBox("Cannot Connect to Server")
                Case 1045
                    MsgBox("Invalid Username or password")
            End Select
        End Try
    End Sub
    Public Sub Disconnect_to_DB()
        myconn.Close()
        myconn.Dispose()
    End Sub
    Public Sub ExportToExcel(ByVal dgv As DataGridView, ByVal templatefilename As String)
        Dim xlsApp As Excel.Application = Nothing
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsSheet As Excel.Worksheet = Nothing
        Dim misValue As Object = System.Reflection.Missing.Value

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsWB = xlsApp.Workbooks.Add(misValue)
        xlsSheet = xlsWB.Sheets("Sheet1")

        Dim columnsCount As Integer = dgv.Columns.Count
        For column As Integer = 0 To columnsCount - 1
            xlsSheet.Cells(1, column + 1) = dgv.Columns(column).HeaderText
            For row As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(row).Cells(column).Value IsNot Nothing Then
                    xlsSheet.Cells(row + 2, column + 1) = dgv.Rows(row).Cells(column).Value.ToString()
                Else
                    xlsSheet.Cells(row + 2, column + 1) = ""
                End If
            Next
        Next

        Dim columnsRange As Range = xlsSheet.Columns
        columnsRange.AutoFit()

        templatefilename = templatefilename.Replace(".xlsx", "")
        templatefilename = templatefilename.Replace(".xls", "")
        Dim myfilename As String = templatefilename & " " & currentDate.ToString("mm-dd-yy hh-mm-ss") & ".xlsx"
        xlsSheet.Protect(strpassword)
        xlsApp.ActiveWindow.View = XlWindowView.xlPageLayoutView
        xlsApp.ActiveWindow.DisplayGridlines = False
        xlsWB.SaveAs(xlsFiles & myfilename, XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
        xlsWB.Close(True, misValue, misValue)
        xlsApp.Quit()

        releaseObject(xlsSheet)
        releaseObject(xlsWB)
        releaseObject(xlsApp)

        Dim filePath As String = Path.Combine(xlsFiles, myfilename)

        MsgBox("File saved to " + filePath)
    End Sub

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Module