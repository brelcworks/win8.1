Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("select * from User1 where UID =@username and Pass=@password", con)
            cmd.Parameters.AddWithValue("@username", txtuname.Text)
            cmd.Parameters.AddWithValue("@password", txtpass.Text)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Session("user_name") = "Logged in as  " & dt.Rows(0)("fname") & "  " & dt.Rows(0)("lname")
                FormsAuthentication.RedirectFromLoginPage(txtuname.Text, False)
            Else
                ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Wrong User Id or Password!')</script>")
            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('" & ex.Message & "')</script>")
        End Try
    End Sub
End Class