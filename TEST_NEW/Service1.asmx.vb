Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data.SqlServerCe
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
'<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<ScriptService()>
Public Class Service1
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()>
    Public Function GetCompletionList(prefixText As String, count As Integer) As List(Of String)
        Using con As New SqlCeConnection()
            con.ConnectionString = ConfigurationManager.ConnectionStrings("SQLCE").ConnectionString
            Using com As New SqlCeCommand()
                com.CommandText = "select parti from table1 where parti like '%" & "@Search" & "%'"
                com.Parameters.AddWithValue("@Search", prefixText)
                com.Connection = con
                con.Open()
                Dim countryNames As New List(Of String)()
                Using sdr As SqlCeDataReader = com.ExecuteReader()
                    While sdr.Read()
                        countryNames.Add(sdr("parti").ToString())
                    End While
                End Using
                con.Close()
                Return countryNames
            End Using
        End Using
    End Function
End Class