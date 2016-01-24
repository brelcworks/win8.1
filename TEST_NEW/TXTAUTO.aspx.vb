Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Data.SqlServerCe

Public Class TXTAUTO
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <WebMethod>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function GETPARTI(ByVal pre As String) As List(Of String)
        Dim cmd As SqlCeCommand = New SqlCeCommand
        cmd.CommandText = "select PARTI from TABLE1 where PARTI like '%" & pre & "%'"
        If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
        cmd.Connection = SQLCE
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As SqlCeDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("parti").ToString)
        End While
        Return customers
    End Function
End Class