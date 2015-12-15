Imports System.Data.SqlClient
Imports System.IO
Imports ClosedXML.Excel
Imports System.Data.SqlServerCe
Public Class PLLIST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.Page.User.Identity.IsAuthenticated Then
                FormsAuthentication.RedirectToLoginPage()
            Else
                If Session("user_name") = "" Then
                    FormsAuthentication.RedirectToLoginPage()
                    Exit Sub
                End If
                uname1.Text = Session("user_name").ToString
                If Not Me.IsPostBack Then
                    DG1.DataSource = sheet1_tbl
                    DG1.DataBind()
                End If
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub err_display(ByVal msg As String)
        errdisplay.Text = msg
        errpopup.Show()
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim dt As New DataTable("PRICE_LIST")
            Dim FKDG As New GridView
            FKDG.DataSource = sheet1_tbl
            FKDG.DataBind()
            For Each cell As TableCell In FKDG.HeaderRow.Cells
                dt.Columns.Add(cell.Text)
            Next
            For Each row As GridViewRow In FKDG.Rows
                dt.Rows.Add()
                For i As Integer = 0 To row.Cells.Count - 1
                    dt.Rows(dt.Rows.Count - 1)(i) = row.Cells(i).Text
                Next
            Next
            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt)
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;filename=PRICE_LIST.xlsx")
                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(Response.OutputStream)
                    Response.Flush()
                    Response.[End]()
                End Using
            End Using
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class