Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Public Class PLAN
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
                If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                Dim D1 As Date = DateAdd(DateInterval.Month, 1, Today)
                Dim DV As New DataView(mainpop_tbl)
                DV.RowFilter = "NSD < #" & D1 & "# "
                DG1.DataSource = DV
                DG1.DataBind()
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
            Dim D1 As Date = DateAdd(DateInterval.Month, 1, Today)
            Dim DV As New DataView(mainpop_tbl)
            DV.RowFilter = "NSD < #" & D1 & "# "
            Dim DT As DataTable
            DT = DV.ToTable
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.ClearContent()
            HttpContext.Current.Response.ClearHeaders()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.ContentType = "application/ms-excel"
            HttpContext.Current.Response.Write("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">")
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls")

            HttpContext.Current.Response.Charset = "utf-8"
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250")
            'sets font
            HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>")
            HttpContext.Current.Response.Write("<BR><BR><BR>")
            'sets the table border, cell spacing, border color, font of the text, background, foreground, font height
            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " + "borderColor='#000000' cellSpacing='0' cellPadding='0' " + "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>")
            'am getting my grid's column headers
            Dim columnscount As Integer = dt.Columns.Count

            For j As Integer = 0 To columnscount - 1
                'write in new column
                HttpContext.Current.Response.Write("<Td>")
                'Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>")
                HttpContext.Current.Response.Write(dt.Columns(j).ToString)
                HttpContext.Current.Response.Write("</B>")
                HttpContext.Current.Response.Write("</Td>")
            Next
            HttpContext.Current.Response.Write("</TR>")
            For Each row As DataRow In dt.Rows
                'write in new row
                HttpContext.Current.Response.Write("<TR>")
                For i As Integer = 0 To dt.Columns.Count - 1
                    HttpContext.Current.Response.Write("<Td>")
                    HttpContext.Current.Response.Write(row(i).ToString())
                    HttpContext.Current.Response.Write("</Td>")
                Next

                HttpContext.Current.Response.Write("</TR>")
            Next
            HttpContext.Current.Response.Write("</Table>")
            HttpContext.Current.Response.Write("</font>")
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.[End]()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class