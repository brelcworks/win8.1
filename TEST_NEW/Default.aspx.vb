Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Data
Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Try
            If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
            Dim cmd As New SqlCeCommand("select * from User1 where UID =@username and Pass=@password", SQLCE)
            cmd.Parameters.AddWithValue("@username", txtuname.Text)
            cmd.Parameters.AddWithValue("@password", txtpass.Text)
            Dim da As New SqlCeDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Session("user_name") = "Logged in as  " & dt.Rows(0)("fname") & "  " & dt.Rows(0)("lname")
                If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                sheet1_tbl.Clear()
                stock_tbl.Clear()
                CUSTOMER_tbl.Clear()
                BILL_tbl.Clear()
                BILL1_tbl.Clear()
                mainpop_tbl.Clear()
                pmr_tbl.Clear()
                PURCHSE_tbl.Clear()
                PURCHSE1_tbl.Clear()
                sheet1_adapter.Fill(sheet1_tbl)
                stock_adapter.Fill(stock_tbl)
                CUSTOMER_adapter.Fill(CUSTOMER_tbl)
                BILL_adapter.Fill(BILL_tbl)
                BILL1_adapter.Fill(BILL1_tbl)
                mainpop_adapter.Fill(mainpop_tbl)
                pmr_adapter.Fill(pmr_tbl)
                PURCHSE_adapter.Fill(PURCHSE_tbl)
                PURCHSE1_adapter.Fill(PURCHSE1_tbl)
                FormsAuthentication.RedirectFromLoginPage(txtuname.Text, False)
            Else
                ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Wrong User Id or Password!')</script>")
            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('" & ex.Message & "')</script>")
        End Try
    End Sub
End Class