Imports System.Web.Security
Public Class MAIN
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
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub
    Protected Sub tmtick(sender As Object, e As EventArgs)
        stimeout.Text = Now.ToString("dd-MMMM-yyyy hh:mm:ss tt")
    End Sub
End Class