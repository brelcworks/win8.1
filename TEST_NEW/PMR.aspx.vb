Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security

Public Class PMR
    Inherits System.Web.UI.Page
    Public nsd1, lhm1, lsd1 As String
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
                Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
                con.Open()
                Dim da As New SqlDataAdapter("select STYPE from pmr GROUP BY STYPE", con)
                Dim dt As New DataTable
                da.Fill(dt)
                If stype1.Items.Count = 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        stype1.Items.Add(dt(i)("stype").ToString)
                    Next
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    
    Public Sub bindgrid()
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim da As New SqlDataAdapter("select * from pmr", con)
            Dim dt As New DataTable
            da.Fill(dt)

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
            Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
            Dim fid As String = GridView1.DataKeys(gRow.RowIndex).Value.ToString()
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM PMR", con)
            Dim dt As New DataTable
            DA.Fill(dt)
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM PMR", con)
            Dim dabld As New SqlCommandBuilder(DA)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim DA1 As New SqlDataAdapter("SELECT * FROM mainpopu", con)
            Dim dabld1 As New SqlCommandBuilder(DA1)
            Dim dt1 As New DataTable
            DA1.Fill(dt1)
            If recid1.Text = "" Then
                Dim dr As DataRow = dt.NewRow
                dr("sid") = sid.Text
                dr("sname") = sname.Text
                dr("engine_no") = Engine_no.Text
                If IsDate(DOS.Text) Then dr("dos") = DOS.Text
                dr("stype") = stype1.Text
                dr("hmr") = HMR.Text
                dr("report") = reportNo.Text
                dr("Technician") = technician.Text
                dr("METERIAL") = meterial.Text
                dr("cust") = cust.Text
                If IsDate(cdati.Text) Then dr("cdati") = cdati.Text
                dr("dist") = dist.Text
                dr("sta") = sta.Text
                dr("DGNO") = dgno.Text
                dr("AMAKE") = amake.Text
                dr("ALSN") = alsn.Text
                dr("BSN") = bsn.Text
                dr("sLA") = sla.Text
                dr("RESLA") = resla.Text
                dr("TTR") = ttr.Text
                dr("TSLOT") = tslot.Text
                dr("RFAIL") = rfail.Text
                dr("ACTION") = action.Text
                dr("WARR") = warr.Text
                dr("OEA") = oea.Text
                dr("AMC") = amc.Text
                dr("staTE") = state.Text
                dr("CCATE") = ccate.Text
                dr("CNAT") = Cnat.Text
                dr("sERV") = serv.Text
                dr("DPCODE") = dpcode.Text
                dr("KVA") = kva.Text
                dr("MODEL") = model.Text
                dr("DOI") = doi.Text
                dr("ssta") = "NEW"
                dr("lmodi") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                dr("recid") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                dr("AEDT") = "TRUE"
                dt.Rows.Add(dr)

                Dim dv As New DataView(dt1, "", "ENS", DataViewRowState.CurrentRows)
                Dim index As Integer = dv.Find(Engine_no.Text)
                If Not index = -1 Then
                    dv(index)("chmr") = HMR.Text
                    If IsDate(cdati.Text) Then dv(index)("chmd") = cdati.Text
                    dv(index)("SSTA") = "MOD"
                    dv(index)("hmage") = hmage1.Text
                    dv(index)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    dv(index)("action") = action.Text
                    dv(index)("AHM") = ahm.Text
                    dv(index)("AEDT") = "TRUE"
                    If stype1.Text = "OIL SERVICE" Then
                        dv(index)("LHMR") = HMR.Text
                        dv(index)("LSD") = cdati.Text
                    End If
                End If
                DA.Update(dt)
                DA1.Update(dt1)
                recid1.Text = ""
                sid.Text = ""
                sname.Text = ""
                Engine_no.Text = ""
                DOS.Text = ""

                HMR.Text = ""
                reportNo.Text = ""
                technician.Text = ""
                meterial.Text = ""
                cust.Text = ""
                cdati.Text = ""
                dist.Text = ""
                sta.Text = ""
                dgno.Text = ""
                amake.Text = ""
                alsn.Text = ""
                bsn.Text = ""
                sla.Text = ""
                resla.Text = ""
                ttr.Text = ""
                tslot.Text = ""
                rfail.Text = ""
                action.Text = ""
                warr.Text = ""
                oea.Text = ""
                amc.Text = ""
                state.Text = ""
                ccate.Text = ""
                Cnat.Text = ""
                serv.Text = ""
                dpcode.Text = ""
                kva.Text = ""
                model.Text = ""
                doi.Text = ""
                uname.Text = ""
                hmage1.Text = ""
                ahm.Text = ""
                GridView1.DataBind()
            Else
                Dim DV As New DataView(dt, "", "recid1", DataViewRowState.CurrentRows)
                Dim index As Integer = DV.Find(recid1.Text)
                If Not index = -1 Then
                    DV(index)("sid") = sid.Text
                    DV(index)("sname") = sname.Text
                    DV(index)("engine_no") = Engine_no.Text
                    DV(index)("dos") = DOS.Text
                    DV(index)("stype") = stype1.Text
                    DV(index)("hmr") = HMR.Text
                    DV(index)("report") = reportNo.Text
                    DV(index)("Technician") = technician.Text
                    DV(index)("METERIAL") = meterial.Text
                    DV(index)("cust") = cust.Text
                    DV(index)("cdati") = cdati.Text
                    DV(index)("dist") = dist.Text
                    DV(index)("sta") = sta.Text
                    DV(index)("DGNO") = dgno.Text
                    DV(index)("AMAKE") = amake.Text
                    DV(index)("ALSN") = alsn.Text
                    DV(index)("BSN") = bsn.Text
                    DV(index)("sLA") = sla.Text
                    DV(index)("RESLA") = resla.Text
                    DV(index)("TTR") = ttr.Text
                    DV(index)("TSLOT") = tslot.Text
                    DV(index)("RFAIL") = rfail.Text
                    DV(index)("ACTION") = action.Text
                    DV(index)("WARR") = warr.Text
                    DV(index)("OEA") = oea.Text
                    DV(index)("AMC") = amc.Text
                    DV(index)("staTE") = state.Text
                    DV(index)("CCATE") = ccate.Text
                    DV(index)("CNAT") = Cnat.Text
                    DV(index)("sERV") = serv.Text
                    DV(index)("DPCODE") = dpcode.Text
                    DV(index)("KVA") = kva.Text
                    DV(index)("MODEL") = model.Text
                    DV(index)("DOI") = doi.Text
                    DV(index)("lmodi") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    DV(index)("AEDT") = "TRUE"

                    Dim dv1 As New DataView(dt1, "", "ENS", DataViewRowState.CurrentRows)
                    Dim index1 As Integer = dv1.Find(Engine_no.Text)
                    If Not index1 = -1 Then
                        dv1(index1)("chmr") = HMR.Text
                        If IsDate(cdati.Text) Then dv1(index1)("chmd") = cdati.Text
                        dv1(index1)("SSTA") = "MOD"
                        dv1(index1)("hmage") = hmage1.Text
                        dv1(index1)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                        dv1(index1)("action") = action.Text
                        dv1(index1)("AHM") = ahm.Text
                        dv1(index1)("AEDT") = "TRUE"
                        If stype1.Text = "OIL SERVICE" Then
                            dv1(index1)("LHMR") = HMR.Text
                            dv1(index1)("LSD") = cdati.Text
                            If IsDate(uname.Text) Then dv1(index1)("NSD") = uname.Text
                        End If
                    End If
                    DA.Update(dt)
                    DA1.Update(dt1)
                    recid1.Text = ""
                    sid.Text = ""
                    sname.Text = ""
                    Engine_no.Text = ""
                    DOS.Text = ""

                    HMR.Text = ""
                    reportNo.Text = ""
                    technician.Text = ""
                    meterial.Text = ""
                    cust.Text = ""
                    cdati.Text = ""
                    dist.Text = ""
                    sta.Text = ""
                    dgno.Text = ""
                    amake.Text = ""
                    alsn.Text = ""
                    bsn.Text = ""
                    sla.Text = ""
                    resla.Text = ""
                    ttr.Text = ""
                    tslot.Text = ""
                    rfail.Text = ""
                    action.Text = ""
                    warr.Text = ""
                    oea.Text = ""
                    amc.Text = ""
                    state.Text = ""
                    ccate.Text = ""
                    Cnat.Text = ""
                    serv.Text = ""
                    dpcode.Text = ""
                    kva.Text = ""
                    model.Text = ""
                    doi.Text = ""
                    uname.Text = ""
                    hmage1.Text = ""
                    ahm.Text = ""
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub btncls_Click(sender As Object, e As EventArgs) Handles btncls.Click
        recid1.Text = ""
        sid.Text = ""
        sname.Text = ""
        Engine_no.Text = ""
        DOS.Text = ""
        stype1.Text = "SELECT"
        HMR.Text = ""
        reportNo.Text = ""
        technician.Text = ""
        meterial.Text = ""
        cust.Text = ""
        cdati.Text = ""
        dist.Text = ""
        sta.Text = ""
        dgno.Text = ""
        amake.Text = ""
        alsn.Text = ""
        bsn.Text = ""
        sla.Text = ""
        resla.Text = ""
        ttr.Text = ""
        tslot.Text = ""
        rfail.Text = ""
        action.Text = ""
        warr.Text = ""
        oea.Text = ""
        amc.Text = ""
        state.Text = ""
        ccate.Text = ""
        Cnat.Text = ""
        serv.Text = ""
        dpcode.Text = ""
        kva.Text = ""
        model.Text = ""
        doi.Text = ""
        uname.Text = ""
        hmage1.Text = ""
        ahm.Text = ""
        popup.Show()
    End Sub
    

    Private Sub FETENS_Click(sender As Object, e As EventArgs) Handles FETENS.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM mainpopu", con)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim dv As New DataView(dt)
            dv.RowFilter = "ens='" & Engine_no.Text & "'"
            If Not dv.Count < 1 Then
                sid.Text = dv(0)("sid").ToString
                sname.Text = dv(0)("sname").ToString
                cust.Text = dv(0)("cname").ToString
                dist.Text = dv(0)("dist").ToString
                dgno.Text = dv(0)("DGNO").ToString
                amake.Text = dv(0)("AMAKE").ToString
                alsn.Text = dv(0)("ALSN").ToString
                bsn.Text = dv(0)("BSN").ToString
                warr.Text = dv(0)("WARR").ToString
                oea.Text = dv(0)("OEA").ToString
                amc.Text = dv(0)("AMC").ToString
                state.Text = dv(0)("staTE").ToString
                kva.Text = dv(0)("RAT_PH").ToString
                model.Text = dv(0)("MODEL").ToString
                doi.Text = dv(0)("DOc").ToString
            End If
            popup.Show()
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub fetsid_Click(sender As Object, e As EventArgs) Handles fetsid.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM mainpopu", con)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim dv As New DataView(dt)
            dv.RowFilter = "sid='" & sid.Text & "'"
            If Not dv.Count < 1 Then
                Engine_no.Text = dv(0)("ens").ToString
                sname.Text = dv(0)("sname").ToString
                cust.Text = dv(0)("cname").ToString
                dist.Text = dv(0)("dist").ToString
                dgno.Text = dv(0)("DGNO").ToString
                amake.Text = dv(0)("AMAKE").ToString
                alsn.Text = dv(0)("ALSN").ToString
                bsn.Text = dv(0)("BSN").ToString
                warr.Text = dv(0)("WARR").ToString
                oea.Text = dv(0)("OEA").ToString
                amc.Text = dv(0)("AMC").ToString
                state.Text = dv(0)("staTE").ToString
                kva.Text = dv(0)("RAT_PH").ToString
                model.Text = dv(0)("MODEL").ToString
                doi.Text = dv(0)("DOc").ToString
            End If
            popup.Show()
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub fetsname_Click(sender As Object, e As EventArgs) Handles fetsname.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM mainpopu", con)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim dv As New DataView(dt)
            dv.RowFilter = "sname='" & sname.Text & "'"
            If Not dv.Count < 1 Then
                sid.Text = dv(0)("sid").ToString
                Engine_no.Text = dv(0)("ens").ToString
                cust.Text = dv(0)("cname").ToString
                dist.Text = dv(0)("dist").ToString
                dgno.Text = dv(0)("DGNO").ToString
                amake.Text = dv(0)("AMAKE").ToString
                alsn.Text = dv(0)("ALSN").ToString
                bsn.Text = dv(0)("BSN").ToString
                warr.Text = dv(0)("WARR").ToString
                oea.Text = dv(0)("OEA").ToString
                amc.Text = dv(0)("AMC").ToString
                state.Text = dv(0)("staTE").ToString
                kva.Text = dv(0)("RAT_PH").ToString
                model.Text = dv(0)("MODEL").ToString
                doi.Text = dv(0)("DOc").ToString
            End If
            popup.Show()
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Private Sub BTNDEL_Click(sender As Object, e As EventArgs) Handles BTNDEL.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM pmr", con)
            Dim UPD As New SqlCommandBuilder(DA)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim dv As New DataView(dt)
            dv.RowFilter = "recid1='" & recid1.Text & "'"
            If Not dv.Count < 1 Then
                dv.Delete(0)
                DA.Update(dt)
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub fndreco()
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM pmr", con)
            Dim udt As New SqlCommandBuilder(DA)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim dv As New DataView(dt)
            dv.RowFilter = "sname like '%" & fnddg.Text & "%'"
            If dv.Count < 1 Then
                Label40.Text = "No Record Found"
            Else
                Label40.Text = "Total Record Found  " & dv.Count
                dg1.DataSource = dv
                dg1.DataBind()
            End If
            popup2.Show()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
    Protected Sub Edit1(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
        Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
        Dim fid As String = dg1.DataKeys(gRow.RowIndex).Value.ToString()
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
        con.Open()
        Dim DA As New SqlDataAdapter("SELECT * FROM PMR", con)
        Dim dt As New DataTable
        DA.Fill(dt)
        Dim dv As New DataView(dt)
        dv.RowFilter = "RECID1='" & fid & "'"
        recid1.Text = dg1.DataKeys(gRow.RowIndex).Value.ToString()
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
    End Sub

   

    Private Sub btncalc_Click(sender As Object, e As EventArgs) Handles btncalc.Click
        Try
            If IsDate(cdati.Text) = True Then
                Dim span As TimeSpan
                Dim starttime As DateTime = Convert.ToDateTime(DOS.Text)
                Dim endtime As DateTime = Convert.ToDateTime(cdati.Text)
                span = endtime.Subtract(starttime)
                Dim sec As String = span.TotalSeconds
                ttr.Text = Val(sec) / 3600
            End If

            Select Case Val(ttr.Text)
                Case Is >= 72
                    tslot.Text = ">72"
                Case Is >= 48
                    tslot.Text = "48-72"
                Case Is >= 24
                    tslot.Text = "24-48"
                Case Is >= 10
                    tslot.Text = "10-24"
                Case Else
                    tslot.Text = "0-10"
            End Select

            Select Case Val(HMR.Text)
                Case Is >= 15000
                    hmage1.Text = ">15000"
                Case Is >= 12500
                    hmage1.Text = "12500-15000"
                Case Is >= 10000
                    hmage1.Text = "10000-12500"
                Case Is >= 7500
                    hmage1.Text = "7500-10000"
                Case Is >= 5000
                    hmage1.Text = "5000-7500"
                Case Is >= 2500
                    hmage1.Text = "2500-5000"
                Case Else
                    hmage1.Text = "<2500"
            End Select
            If stype1.Text = "OIL SERVICE" Then
                Select Case kva.Text
                    Case "7.5"
                        meterial.Text = "1)LUBE OIL 7.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 1 NOS"
                    Case "10"
                        meterial.Text = "1)LUBE OIL 7.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 1 NOS"
                    Case "15"
                        meterial.Text = "1)LUBE OIL 8 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "20"
                        meterial.Text = "1)LUBE OIL 9.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "25"
                        meterial.Text = "1)LUBE OIL 9.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "30"
                        meterial.Text = "1)LUBE OIL 9.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "35"
                        meterial.Text = "1)LUBE OIL 9.5 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "40"
                        meterial.Text = "1)LUBE OIL 8 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "45"
                        meterial.Text = "1)LUBE OIL 8 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                    Case "62.5"
                        meterial.Text = "1)LUBE OIL 8 LTR , 2)LUBE OIL FILTER 1 NOS , 3)FUEL FILTER 2 NOS"
                End Select
                ccate.Text = "ENGINE"
                Cnat.Text = "NA"
                serv.Text = "NA"
                sta.Text = "CLOSED"
                action.Text = "SERVICING DONE"
                rfail.Text = "NA"
            End If


            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA As New SqlDataAdapter("SELECT * FROM PMR ORDER BY RECID1", con)
            Dim dt As New DataTable
            DA.Fill(dt)
            Dim DA1 As New SqlDataAdapter("SELECT * FROM mainpopu", con)
            Dim dt1 As New DataTable
            DA1.Fill(dt1)

            If IsDate(cdati.Text) Then
                Dim dv1 As New DataView(dt1, "", "ENS", DataViewRowState.CurrentRows)
                Dim index1 As Integer = dv1.Find(Engine_no.Text)
                If Not index1 = -1 Then
                    Dim chmr1 As String = dv1(index1)("chmr") & ""
                    If Val(chmr1) = Val(HMR.Text) Then
                        chmr1 = Val(chmr1) - 0.5
                    End If
                    Dim chmd1 As Date
                    If Not IsDBNull(dv1(index1)("chmd")) Then
                        chmd1 = dv1(index1)("chmd")
                    Else
                        chmd1 = DateAdd(DateInterval.Year, -1, Today)
                    End If

                    Dim DV As New DataView(dt)
                    DV.RowFilter = "engine_no='" & Engine_no.Text & "' and stype='" & "OIL SERVICE" & "'"
                    If DV.Count = 0 Then
                        Dim lasth As String = chmr1
                        Dim lastsd As Date = chmd1
                        Dim csd As Date = cdati.Text
                        If Val(HMR.Text) < Val(lasth) Then
                            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Current Hmr is Lower Then The Privious HMR! Please Review')</script>")
                            popup.Show()
                            Exit Sub
                        ElseIf csd < lastsd Then
                            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Current Service Date is Older Then The Previous Service Date! Please Review')</script>")
                            popup.Show()
                            Exit Sub
                        Else
                            Dim CURSD As Date = cdati.Text
                            Dim difd As String = DateDiff(DateInterval.Day, lastsd, CURSD)
                            Dim difh As String = Val(HMR.Text) - Val(lasth)
                            Dim avgh As String = difh / difd
                            Dim ab As String
                            ab = 500 / avgh
                            Dim bavg As Date = DateAdd(DateInterval.Day, Val(ab), CURSD)
                            Dim bdt As Date = DateAdd(DateInterval.Month, 6, CURSD)
                            If bavg > bdt Then
                                uname.Text = Format(bdt, "dd-MMMM-yyyy hh:mm:ss tt")
                            Else
                                uname.Text = Format(bavg, "dd-MMMM-yyyy hh:mm:ss tt")
                            End If
                            lhm1 = lasth
                            lsd1 = lastsd
                            ahm.Text = avgh
                        End If
                    Else
                        Dim I As Integer = DV.Count - 1
                        Dim lasth As String = DV(I)("HMR") & ""
                        Dim lastsd As Date = DV(I)("cdati") & ""
                        Dim csd As Date = cdati.Text
                        If Val(HMR.Text) < Val(lasth) Then
                            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Current Hmr is Lower Then The Privious HMR! Please Review')</script>")
                            popup.Show()
                            Exit Sub
                        ElseIf csd < lastsd Then
                            ClientScript.RegisterStartupScript(Page.[GetType](), "validation", "<script language='javascript'>alert('Current Service Date is Older Then The Previous Service Date! Please Review')</script>")
                            popup.Show()
                            Exit Sub
                        Else
                            Dim CURSD As Date = cdati.Text
                            Dim difd As String = DateDiff(DateInterval.Day, lastsd, CURSD)
                            Dim difh As String = Val(HMR.Text) - Val(lasth)
                            Dim avgh As String = difh / difd
                            Dim ab As String
                            ab = 500 / avgh
                            Dim bavg As Date = DateAdd(DateInterval.Day, Val(ab), CURSD)
                            Dim bdt As Date = DateAdd(DateInterval.Month, 6, CURSD)
                            If bavg > bdt Then
                                uname.Text = Format(bdt, "dd-MMMM-yyyy hh:mm:ss tt")
                            Else
                                uname.Text = Format(bavg, "dd-MMMM-yyyy hh:mm:ss tt")
                            End If
                            lhm1 = lasth
                            lsd1 = lastsd
                            ahm.Text = avgh
                        End If
                    End If
                End If
            End If
            popup.Show()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
            con.Open()
            Dim DA1 As New SqlDataAdapter("SELECT cust as Customer, stype as Amc_Out_of_Scope, DOS as Dt_of_Complaint, recid as Complaint_Service_No, Sid as Site_id, sname as Site_Name, dist as District, State, ccate as Complaint_Category, Engine_no, Model, KVA, DOI, dgno as Genset_no, amake as Alt_Make, alsn as Alt_Sr_no, bsn as Battery_Sr_no, HMR, cnat as Complaint_Nature, serv as Severity, rfail as Reason_of_Failure, sta as Status, cdati as Complaint_Closure_Date, warr as O_W_U_W, action as Action_taken, meterial as Meterial_Changed, dpcode as Service_Dealer, technician, Oea, amc as Amc_status, TTR, sla as Sla_Osla, tslot as Time_Slot, resla as Reason_of_Sla FROM PMR", con)
            Dim DT2 As New DataTable
            DA1.Fill(DT2)
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
            Dim columnscount As Integer = DT2.Columns.Count

            For j As Integer = 0 To columnscount - 1
                'write in new column
                HttpContext.Current.Response.Write("<Td>")
                'Get column headers  and make it as bold in excel columns
                HttpContext.Current.Response.Write("<B>")
                HttpContext.Current.Response.Write(DT2.Columns(j).ToString)
                HttpContext.Current.Response.Write("</B>")
                HttpContext.Current.Response.Write("</Td>")
            Next
            HttpContext.Current.Response.Write("</TR>")
            For Each row As DataRow In DT2.Rows
                'write in new row
                HttpContext.Current.Response.Write("<TR>")
                For i As Integer = 0 To DT2.Columns.Count - 1
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
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Sub Btnfnddg_Click(sender As Object, e As EventArgs) Handles Btnfnddg.Click

    End Sub
End Class