Imports System.Web
Imports System.Web.Services
Imports System.Data.SqlServerCe

Public Class Search_pt
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim prefixText As String = context.Request.QueryString("q")
        Dim conn As SqlCeConnection = New SqlCeConnection
        conn.ConnectionString = ConfigurationManager _
                .ConnectionStrings("constr").ConnectionString
        Dim cmd As SqlCeCommand = New SqlCeCommand
        cmd.CommandText = ("select parti from table1 where " &
                           "parti like @SearchText + '%'")
        cmd.Parameters.AddWithValue("@SearchText", prefixText)
        cmd.Connection = conn
        Dim sb As StringBuilder = New StringBuilder
        conn.Open()
        Dim sdr As SqlCeDataReader = cmd.ExecuteReader
        While sdr.Read
            sb.Append(sdr("parti")) _
                .Append(Environment.NewLine)
        End While
        conn.Close()
        context.Response.Write(sb.ToString)

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class