Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Public Class FLLIST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.Page.User.Identity.IsAuthenticated Then
                err_display("APPLICATION SESSION EXPIRED! PLEASE RE-LOGIN")
                FormsAuthentication.RedirectToLoginPage()
            Else
                If Session("user_name") = "" Then
                    err_display("USER SESSION EXPIRED! PLEASE RE-LOGIN")
                    FormsAuthentication.RedirectToLoginPage()
                    Exit Sub
                End If
                uname1.Text = Session("user_name").ToString
                If Not Me.IsPostBack Then
                    Dim DT As New DataTable
                    DT.Columns.Add("FLNAME", GetType(String))
                    DT.Columns.Add("FLLOC", GetType(String))
                    DT.Columns.Add("FLSIZE", GetType(String))
                    DT.Columns.Add("LMODI", GetType(String))
                    For Each foundfile As String In Directory.GetFiles(Server.MapPath("~/App_Data/"), searchPattern:="*.*", searchOption:=SearchOption.AllDirectories)
                        Dim DR As DataRow = DT.NewRow
                        DR("FLNAME") = Path.GetFileName(foundfile) & ""
                        DR("FLLOC") = foundfile.ToString & ""
                        Dim x = FileIO.FileSystem.GetFileInfo(foundfile).Length
                        DR("FLSIZE") = (FormatNumber(Val(x) / 1024, 0) & " KB" & "")
                        DR("LMODI") = Format(FileIO.FileSystem.GetFileInfo(foundfile).LastWriteTime, "dd-MMMM-yyyy hh:mm:ss tt")
                        DT.Rows.Add(DR)
                    Next
                    DT.DefaultView.Sort = "FLNAME ASC"
                    DG1.DataSource = DT
                    DG1.DataBind()
                End If
            End If
        Catch ex As Exception
            err_display(ex.Message)
        End Try
    End Sub
    Protected Sub DNLD(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub DG1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DG1.SelectedIndexChanged
        Try
            Response.Clear()
            Dim filePath As String = DG1.SelectedRow.Cells(1).Text
            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(filePath)))
            Response.WriteFile(filePath)
            Response.Flush()
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        Catch ex As Exception
            err_display(ex.Message)
        End Try
    End Sub
    Protected Sub UploadFile(sender As Object, e As EventArgs)
        Try
            Dim url1 As String = "https://dav.box.com/dav/ASP"
            Dim port1 As String = "443"
            If port1 <> "" Then
                Dim u As New Uri(url1)
                Dim host As String = u.Host
                url1 = url1.Replace(host, host & ":" & port1)
            End If
            Dim XY As String = Format(Now, "dd-MMMM-yyyy hh-mm-ss-fff tt")
            url1 = url1.TrimEnd("/"c) & "/" & XY
            Dim Request1 As System.Net.HttpWebRequest
            Request1 = CType(System.Net.WebRequest.Create(url1),
                          System.Net.HttpWebRequest)
            Request1.Credentials = New NetworkCredential(ConfigurationManager.AppSettings(0).ToString, ConfigurationManager.AppSettings(1).ToString)
            Request1.Method = "MKCOL"
            Dim Response1 As System.Net.HttpWebResponse
            Response1 = CType(Request1.GetResponse(), System.Net.HttpWebResponse)
            Response1.Close()
            If SQLCE.State = ConnectionState.Open Then SQLCE.Close()
            For I As Integer = 0 To DG1.Rows.Count - 1
                Dim fileToUpload As String = DG1.Rows(I).Cells(1).Text.Trim()
                Dim fileLength As Long = FileIO.FileSystem.GetFileInfo(fileToUpload).Length
                Dim url As String = "https://dav.box.com/dav/ASP/" & XY
                Dim port As String = "443"
                If port <> "" Then
                    Dim u As New Uri(url)
                    Dim host As String = u.Host
                    url = url.Replace(host, host & ":" & port)
                End If
                url = url.TrimEnd("/"c) & "/" & Path.GetFileName(fileToUpload)
                Dim request As HttpWebRequest =
                    DirectCast(System.Net.HttpWebRequest.Create(url), HttpWebRequest)
                request.Credentials = New NetworkCredential(ConfigurationManager.AppSettings(0).ToString, ConfigurationManager.AppSettings(1).ToString)
                request.Method = WebRequestMethods.Http.Put
                request.ContentLength = fileLength
                request.SendChunked = True
                request.Headers.Add("Translate: f")
                request.AllowWriteStreamBuffering = True
                Dim s As IO.Stream = Nothing
                Try
                    s = request.GetRequestStream()
                Catch ex As Exception
                    err_display(ex.ToString)
                    If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                End Try
                Dim fs As New IO.FileStream(fileToUpload, IO.FileMode.Open, IO.FileAccess.Read)
                Dim byteTransferRate As Integer = 1024
                Dim bytes(byteTransferRate - 1) As Byte
                Dim bytesRead As Integer = 0
                Dim totalBytesRead As Long = 0
                Do
                    bytesRead = fs.Read(bytes, 0, bytes.Length)
                    If bytesRead > 0 Then
                        totalBytesRead += bytesRead
                        s.Write(bytes, 0, bytesRead)
                    End If
                Loop While bytesRead > 0
                s.Close()
                s.Dispose()
                s = Nothing
                fs.Close()
                fs.Dispose()
                fs = Nothing
                Dim response As HttpWebResponse = Nothing
                Try
                    response = DirectCast(request.GetResponse(), HttpWebResponse)
                    Dim code As HttpStatusCode = response.StatusCode
                    response.Close()
                    response = Nothing
                    If totalBytesRead = fileLength AndAlso
                        code = HttpStatusCode.Created Then
                        Dim d1 As Date = Today
                    Else
                        err_display("The file did not upload successfully.")
                    End If
                Catch ex As Exception
                    err_display(ex.ToString)
                    If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                End Try
            Next
            err_display("FILES UPLOADED SUCCESS FULLY !")
            If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
        Catch ex As Exception
            err_display(ex.ToString)
            If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
        End Try
    End Sub
    Protected Sub err_display(ByVal msg As String)
        errdisplay.Text = msg
        errpopup.Show()
    End Sub

    Private Sub TST_Click(sender As Object, e As EventArgs) Handles TST.Click
        Try
            Dim conn As SqlConnection = Nothing
            Dim v As Object = Nothing
            conn = New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Integrated Security=SSPI;")
            Dim c As String = "SELECT COUNT (*) FROM sys.sysdatabases where name='" & "ASPDB" & "'"
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand(c, conn)
            v = cmd.ExecuteScalar()
            If v = Nothing Then
                Dim obj As SqlCommand
                Dim strSQL As String
                obj = conn.CreateCommand()
                strSQL = "CREATE DATABASE ASPDB ON PRIMARY" + "(Name=ASPDB, filename = '" & Server.MapPath("~/APP_DATA/ASPDB.mdf") & "', size=3, maxsize=5, filegrowth=10%)log on (name=mydbb_log, filename='" & Server.MapPath("~/APP_DATA/ASPDB_log.ldf") & "',size=3, maxsize=20,filegrowth=1)"
                obj.CommandText = strSQL
                obj.ExecuteNonQuery()
                conn.Close()
                obj.Dispose()
                err_display("OK")
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class