Imports System.Data.SqlClient
Imports AjaxControlToolkit
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Public Class Rmtracker
    Inherits System.Web.UI.Page
    Public con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
   
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
                    If con.State <> ConnectionState.Open Then con.Open()
                    Dim DA As New SqlDataAdapter("SELECT * FROM PMR ORDER BY DOS DESC", con)
                    Dim DT As New DataTable
                    DA.Fill(DT)
                    Dim DT1 As Date
                    Dim D1 As DateTime
                    Dim D2 As DateTime
                    Dim mon As String = Today.ToString("MMM")
                    Select Case mon
                        Case "Jan"
                            D1 = "1/1/" & (Today.ToString("yyyy"))
                            D2 = "1/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Feb"
                            D1 = "2/1/" & Today.ToString("yyyy")
                            D2 = "2/28/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Mar"
                            D1 = "3/1/" & Today.ToString("yyyy")
                            D2 = "3/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Apr"
                            D1 = "4/1/" & Today.ToString("yyyy")
                            D2 = "4/30/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "May"
                            D1 = "5/1/" & Today.ToString("yyyy")
                            D2 = "5/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Jun"
                            D1 = "6/1/" & Today.ToString("yyyy")
                            D2 = "6/30/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Jul"
                            D1 = "7/1/" & Today.ToString("yyyy")
                            D2 = "7/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Aug"
                            D1 = "8/1/" & Today.ToString("yyyy")
                            D2 = "8/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Sep"
                            D1 = "9/1/" & Today.ToString("yyyy")
                            D2 = "9/30/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Oct"
                            D1 = "10/1/" & Today.ToString("yyyy")
                            D2 = "10/31/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Nov"
                            D1 = "11/1/" & Today.ToString("yyyy")
                            D2 = "11/30/" & Today.ToString("yyyy") & " 23:59:59"
                        Case "Dec"
                            D1 = "12/1/" & Today.ToString("yyyy")
                            D2 = "12/31/" & Today.ToString("yyyy") & " 23:59:59"
                    End Select
                    Dim dname As String = Format(Today(), "dddd")
                    If dname = "Monday" Then
                        DT1 = DateAdd(DateInterval.Day, -2, Today)
                    Else
                        DT1 = DateAdd(DateInterval.Day, -1, Today)
                    End If
                    Dim dv As New DataView(DT)
                    dv.RowFilter = "DOS >= #" & D1 & "# and DOS <= #" & D2 & "#"

                    GridView1.DataSource = dv
                    GridView1.DataBind()
                    stype1.Items.Add("CUSTOMER COMPLAINT")
                    stype1.Items.Add("OIL SERVICE")
                    stype1.Items.Add("PM VISIT")
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim DA As New SqlDataAdapter("SELECT * FROM PMR ORDER BY DOS DESC", con)
            Dim DT As New DataTable
            DA.Fill(DT)
            Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
            Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
            Dim fid As String = GridView1.DataKeys(gRow.RowIndex).Value.ToString()
            Dim dv As New DataView(dt)
            dv.RowFilter = "RECID1='" & fid & "'"
            recid1.Text = GridView1.DataKeys(gRow.RowIndex).Value.ToString()
            sid.Text = dv(0)("sid").ToString
            sname.Text = dv(0)("sname").ToString
            Engine_no.Text = dv(0)("engine_no").ToString
            DOS.Text = dv(0)("dos").ToString
            stype1.Text = dv(0)("stype").ToString
            HMR.Text = dv(0)("hmr").ToString
            reportNo.Text = dv(0)("report").ToString
            technician.Text = dv(0)("Technician").ToString
            meterial.Text = dv(0)("METERIAL").ToString
            cust.Text = dv(0)("cust").ToString
            cdati.Text = dv(0)("cdati").ToString
            dist.Text = dv(0)("dist").ToString
            sta.Text = dv(0)("sta").ToString
            dgno.Text = dv(0)("DGNO").ToString
            amake.Text = dv(0)("AMAKE").ToString
            alsn.Text = dv(0)("ALSN").ToString
            bsn.Text = dv(0)("BSN").ToString
            sla.Text = dv(0)("sLA").ToString
            resla.Text = dv(0)("RESLA").ToString
            ttr.Text = dv(0)("TTR").ToString
            tslot.Text = dv(0)("TSLOT").ToString
            rfail.Text = dv(0)("RFAIL").ToString
            action.Text = dv(0)("ACTION").ToString
            warr.Text = dv(0)("WARR").ToString
            oea.Text = dv(0)("OEA").ToString
            amc.Text = dv(0)("AMC").ToString
            state.Text = dv(0)("staTE").ToString
            ccate.Text = dv(0)("CCATE").ToString
            Cnat.Text = dv(0)("CNAT").ToString
            serv.Text = dv(0)("sERV").ToString
            dpcode.Text = dv(0)("DPCODE").ToString
            kva.Text = dv(0)("KVA").ToString
            model.Text = dv(0)("MODEL").ToString
            doi.Text = dv(0)("DOI").ToString
            popup.Show()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub FIND_Click(sender As Object, e As EventArgs) Handles FIND.Click
        Try
            Dim DA As New SqlDataAdapter("SELECT * FROM PMR ORDER BY DOS DESC", con)
            Dim DT As New DataTable
            DA.Fill(DT)
            Dim DTFRM As Date = DTFROM.Text
            Dim DTTOO As Date = DTTO.Text
            Dim ts As TimeSpan = New TimeSpan(23, 59, 59)
            DTTOO = DTTOO + ts
            Dim DV As New DataView(DT)
            DV.RowFilter = "cdati >= #" & DTFRM & "# AND cdati <= #" & DTTOO & "#"
            GridView1.DataSource = DV
            GridView1.DataBind()
            DTFROM.Text = ""
            DTTO.Text = ""
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub EXPORT_Click(sender As Object, e As EventArgs) Handles EXPORT.Click
        Try
            If DTFROM.Text = "" Then
                If con.State <> ConnectionState.Open Then con.Open()
                Dim DT1 As Date
                Dim D1 As DateTime
                Dim D2 As DateTime
                Dim mon As String = Today.ToString("MMM")
                Select Case mon
                    Case "Jan"
                        D1 = "1/1/" & (Today.ToString("yyyy"))
                        D2 = "1/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Feb"
                        D1 = "2/1/" & Today.ToString("yyyy")
                        D2 = "2/28/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Mar"
                        D1 = "3/1/" & Today.ToString("yyyy")
                        D2 = "3/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Apr"
                        D1 = "4/1/" & Today.ToString("yyyy")
                        D2 = "4/30/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "May"
                        D1 = "5/1/" & Today.ToString("yyyy")
                        D2 = "5/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Jun"
                        D1 = "6/1/" & Today.ToString("yyyy")
                        D2 = "6/30/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Jul"
                        D1 = "7/1/" & Today.ToString("yyyy")
                        D2 = "7/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Aug"
                        D1 = "8/1/" & Today.ToString("yyyy")
                        D2 = "8/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Sep"
                        D1 = "9/1/" & Today.ToString("yyyy")
                        D2 = "9/30/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Oct"
                        D1 = "10/1/" & Today.ToString("yyyy")
                        D2 = "10/31/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Nov"
                        D1 = "11/1/" & Today.ToString("yyyy")
                        D2 = "11/30/" & Today.ToString("yyyy") & " 23:59:59"
                    Case "Dec"
                        D1 = "12/1/" & Today.ToString("yyyy")
                        D2 = "12/31/" & Today.ToString("yyyy") & " 23:59:59"
                End Select
                Dim dname As String = Format(Today(), "dddd")
                If dname = "Monday" Then
                    DT1 = DateAdd(DateInterval.Day, -2, Today)
                Else
                    DT1 = DateAdd(DateInterval.Day, -1, Today)
                End If
                Dim DA1 As New SqlDataAdapter("SELECT cust as Customer, stype as Amc_Out_of_Scope, DOS as Dt_of_Complaint, recid as Complaint_Service_No, Sid as Site_id, sname as Site_Name, dist as District, State, ccate as Complaint_Category, Engine_no, Model, KVA, DOI, dgno as Genset_no, amake as Alt_Make, alsn as Alt_Sr_no, bsn as Battery_Sr_no, HMR, cnat as Complaint_Nature, serv as Severity, rfail as Reason_of_Failure, sta as Status, cdati as Complaint_Closure_Date, warr as O_W_U_W, action as Action_taken, meterial as Meterial_Changed, dpcode as Service_Dealer, technician, Oea, amc as Amc_status, TTR, sla as Sla_Osla, tslot as Time_Slot, resla as Reason_of_Sla FROM PMR", con)
                Dim DT2 As New DataTable
                DA1.Fill(DT2)
                Dim dv As New DataView(DT2)
                dv.RowFilter = "dt_of_Complaint >= #" & D1 & "# and dt_of_Complaint <= #" & D2 & "#"
                Dim DT3 As DataTable
                DT3 = dv.ToTable
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
                Dim columnscount As Integer = DT3.Columns.Count

                For j As Integer = 0 To columnscount - 1
                    'write in new column
                    HttpContext.Current.Response.Write("<Td>")
                    'Get column headers  and make it as bold in excel columns
                    HttpContext.Current.Response.Write("<B>")
                    HttpContext.Current.Response.Write(DT3.Columns(j).ToString)
                    HttpContext.Current.Response.Write("</B>")
                    HttpContext.Current.Response.Write("</Td>")
                Next
                HttpContext.Current.Response.Write("</TR>")
                For Each row As DataRow In DT3.Rows
                    'write in new row
                    HttpContext.Current.Response.Write("<TR>")
                    For i As Integer = 0 To DT3.Columns.Count - 1
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
            Else
                If con.State <> ConnectionState.Open Then con.Open()
                Dim DTFRM As Date = DTFROM.Text
                Dim DTTOO As Date = DTTO.Text
                Dim ts As TimeSpan = New TimeSpan(23, 59, 59)
                DTTOO = DTTOO + ts
                Dim DA1 As New SqlDataAdapter("SELECT cust as Customer, stype as Amc_Out_of_Scope, DOS as Dt_of_Complaint, recid as Complaint_Service_No, Sid as Site_id, sname as Site_Name, dist as District, State, ccate as Complaint_Category, Engine_no, Model, KVA, DOI, dgno as Genset_no, amake as Alt_Make, alsn as Alt_Sr_no, bsn as Battery_Sr_no, HMR, cnat as Complaint_Nature, serv as Severity, rfail as Reason_of_Failure, sta as Status, cdati as Complaint_Closure_Date, warr as O_W_U_W, action as Action_taken, meterial as Meterial_Changed, dpcode as Service_Dealer, technician, Oea, amc as Amc_status, TTR, sla as Sla_Osla, tslot as Time_Slot, resla as Reason_of_Sla FROM PMR", con)
                Dim DT2 As New DataTable
                DA1.Fill(DT2)
                Dim DV As New DataView(DT2)
                DV.RowFilter = "Complaint_Closure_Date >= #" & DTFRM & "# AND Complaint_Closure_Date <= #" & DTTOO & "#"
                Dim DT3 As DataTable
                DT3 = DV.ToTable
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
                Dim columnscount As Integer = DT3.Columns.Count

                For j As Integer = 0 To columnscount - 1
                    'write in new column
                    HttpContext.Current.Response.Write("<Td>")
                    'Get column headers  and make it as bold in excel columns
                    HttpContext.Current.Response.Write("<B>")
                    HttpContext.Current.Response.Write(DT3.Columns(j).ToString)
                    HttpContext.Current.Response.Write("</B>")
                    HttpContext.Current.Response.Write("</Td>")
                Next
                HttpContext.Current.Response.Write("</TR>")
                For Each row As DataRow In DT3.Rows
                    'write in new row
                    HttpContext.Current.Response.Write("<TR>")
                    For i As Integer = 0 To DT3.Columns.Count - 1
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
                DTFROM.Text = ""
                DTTO.Text = ""
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub
End Class