Imports System.Data.SqlClient
Public Class TESTING
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If sqlcon.State <> ConnectionState.Open Then sqlcon.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Add_clm_Click(sender As Object, e As EventArgs) Handles Add_clm.Click
        Try
            Dim x As New SqlCommand("alter table table1 add USER1 VARCHAR(255)", sqlcon)
            x.ExecuteNonQuery()
            MsgBox("OK")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class