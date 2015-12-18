Imports System.Data.SqlClient
Imports LiteDB
Public Class TESTING
    Inherits System.Web.UI.Page
    Private PMR_M_TBL
    Private BILL_M_TBL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim db1 = New LiteDatabase(Server.MapPath(".\DB1.db"))
            Dim col = db1.GetCollection(Of BILLM)("BILL")
            PMR_M_TBL = db1.GetCollection(Of BILLM)("BILL")
            Dim DOC = db1.GetCollection(Of BILLM)("BILL").FindAll().ToList
            GridView1.DataSource = DOC
            GridView1.DataBind()
            BILL_M_TBL = db1.GetCollection(Of BILLM)("BILL")
            Dim BILL1_M_TBL = db1.GetCollection(Of BILL1M)("BILL1")
            Dim MAINPOPU_M_TBL = db1.GetCollection(Of MAINPOPUM)("MAINPOPU")
            Dim TABLE1_M_TBL = db1.GetCollection(Of STOCK)("STOCK")
            Dim SHEET1M_M_TBL = db1.GetCollection(Of SHEET1M)("SHEET1")
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

    Private Sub BILLADD_Click(sender As Object, e As EventArgs) Handles BILLADD.Click
        Try
            If sqlcon.State <> ConnectionState.Open Then
                Dim DA As New SqlDataAdapter("SELECT * FROM BILL", sqlcon)
                Dim DT As New DataTable
                DA.Fill(DT)
                For I As Integer = 0 To DT.Rows.Count - 1
                    Dim P = New BILLM() With {
                        .BID = DT(I)("BID").ToString,
                        .BILL_NO = DT(I)("BILL_NO").ToString,
                        .BDATE = DT(I)("BDATE").ToString,
                        .DNAME = DT(I)("DNAME").ToString,
                        .CUST = DT(I)("CUST").ToString,
                        .PART_NO = DT(I)("PART_NO").ToString,
                        .PARTI = DT(I)("PARTI").ToString,
                        .QTY = DT(I)("QTY").ToString,
                        .MRP = DT(I)("MRP").ToString,
                        .SPRICE = DT(I)("SPRICE").ToString,
                        .TOTAL = DT(I)("TOTAL").ToString,
                        .TAX = DT(I)("TAX").ToString,
                        .TVAL = DT(I)("TVAL").ToString,
                        .STOT = DT(I)("STOT").ToString,
                        .CMP = DT(I)("CMP").ToString,
                        .UNIT = DT(I)("UNIT").ToString,
                       .USER = DT(I)("USER1").ToString,
                       .MODE = DT(I)("MODE").ToString,
                       .SSTA = DT(I)("SSTA").ToString,
                       .AEDT = DT(I)("AEDT").ToString,
                       .LMODI = DT(I)("LMODI").ToString,
                       .BILLID = DT(I)("BILLID").ToString,
                      .DPCODE = DT(I)("DPCODE").ToString
                        }
                    BILL_M_TBL.Insert(P)
                Next
                MsgBox("OK")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Mongo_Click(sender As Object, e As EventArgs) Handles Mongo.Click
        Try
            If sqlcon.State <> ConnectionState.Open Then
                Dim DA As New SqlDataAdapter("SELECT * FROM PMR", sqlcon)
                Dim DT As New DataTable
                DA.Fill(DT)
                For I As Integer = 0 To DT.Rows.Count - 1
                    Dim P = New PMRM() With {
                     .SID = DT(I)("SID"),
                     .SNAME = DT(I)("SNAME"),
                     .ENGINE_NO = DT(I)("ENGINE_NO"),
                     .DOS = DT(I)("DOS"),
                     .STYPE = DT(I)("STYPE"),
                     .HMR = DT(I)("HMR"),
                     .REPORT = DT(I)("REPORT"),
                     .TECHNICIAN = DT(I)("TECHNICIAN"),
                     .METERIAL = DT(I)("METERIAL"),
                     .CUST = DT(I)("CUST"),
                     .RECID = DT(I)("RECID"),
                     .CDATI = DT(I)("CDATI"),
                     .DIST = DT(I)("DIST"),
                     .STATE = DT(I)("STATE"),
                     .CCATE = DT(I)("CCATE"),
                     .MODEL = DT(I)("MODEL"),
                     .DOI = DT(I)("DOI"),
                     .DGNO = DT(I)("DGNO"),
                     .AMAKE = DT(I)("AMAKE"),
                     .ALSN = DT(I)("ALSN"),
                     .BSN = DT(I)("BSN"),
                     .CNAT = DT(I)("CNAT"),
                     .SERV = DT(I)("SERV"),
                     .RFAIL = DT(I)("RFAIL"),
                     .STA = DT(I)("STA"),
                     .WARR = DT(I)("WARR"),
                     .ACTION = DT(I)("ACTION"),
                     .OEA = DT(I)("OEA"),
                     .AMC = DT(I)("AMC"),
                     .TTR = DT(I)("TTR"),
                     .SLA = DT(I)("SLA"),
                     .TSLOT = DT(I)("TSLOT"),
                     .RESLA = DT(I)("RESLA"),
                     .KVA = DT(I)("KVA"),
                     .LMODI = DT(I)("LMODI"),
                     .RECID1 = DT(I)("RECID1"),
                     .SSTA = DT(I)("SSTA")
                 }
                    PMR_M_TBL.InsertOne(P)
                Next
            End If
            MsgBox("OK")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub mongoupd_Click(sender As Object, e As EventArgs) Handles mongoupd.Click
        Try
            Dim db1 = New LiteDatabase(Server.MapPath(".\DB1.db"))
            Dim col = db1.GetCollection(Of BILLM)("BILL")
            If sqlcon.State <> ConnectionState.Open Then
                Dim DA As New SqlDataAdapter("SELECT * FROM BILL", sqlcon)
                Dim DT As New DataTable
                DA.Fill(DT)
                For I As Integer = 0 To DT.Rows.Count - 1
                    Dim P = New BILLM() With {
                        .BID = DT(I)("BID").ToString,
                        .BILL_NO = DT(I)("BILL_NO").ToString,
                        .BDATE = DT(I)("BDATE").ToString,
                        .DNAME = DT(I)("DNAME").ToString,
                        .CUST = DT(I)("CUST").ToString,
                        .PART_NO = DT(I)("PART_NO").ToString,
                        .PARTI = DT(I)("PARTI").ToString,
                        .QTY = DT(I)("QTY").ToString,
                        .MRP = DT(I)("MRP").ToString,
                        .SPRICE = DT(I)("SPRICE").ToString,
                        .TOTAL = DT(I)("TOTAL").ToString,
                        .TAX = DT(I)("TAX").ToString,
                        .TVAL = DT(I)("TVAL").ToString,
                        .STOT = DT(I)("STOT").ToString,
                        .CMP = DT(I)("CMP").ToString,
                        .UNIT = DT(I)("UNIT").ToString,
                       .USER = DT(I)("USER1").ToString,
                       .MODE = DT(I)("MODE").ToString,
                       .SSTA = DT(I)("SSTA").ToString,
                       .AEDT = DT(I)("AEDT").ToString,
                       .LMODI = DT(I)("LMODI").ToString,
                       .BILLID = DT(I)("BILLID").ToString,
                      .DPCODE = DT(I)("DPCODE").ToString
                        }
                    col.Insert(P)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class