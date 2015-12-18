Imports System.Data.SqlClient
Imports LiteDB

Public Class SLREPORT
    Inherits System.Web.UI.Page
    Private BILL_M_TBL
    Private DT As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Me.IsPostBack Then
                CREATEBILLTBL()
                DG1.DataSource = DT
                DG1.DataBind()
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub CREATEBILLTBL()
        Try
            DT.Columns.Add("BILLID", GetType(Integer))
            DT.Columns.Add("BID", GetType(String))
            DT.Columns.Add("_id", GetType(Integer))
            DT.Columns.Add("BILL_NO", GetType(String))
            DT.Columns.Add("BDATE", GetType(DateTime))
            DT.Columns.Add("DNAME", GetType(String))
            DT.Columns.Add("CUST", GetType(String))
            DT.Columns.Add("PART_NO", GetType(String))
            DT.Columns.Add("PARTI", GetType(String))
            DT.Columns.Add("QTY", GetType(String))
            DT.Columns.Add("MRP", GetType(String))
            DT.Columns.Add("SPRICE", GetType(String))
            DT.Columns.Add("TOTAL", GetType(String))
            DT.Columns.Add("TAX", GetType(String))
            DT.Columns.Add("TVAL", GetType(String))
            DT.Columns.Add("STOT", GetType(String))
            DT.Columns.Add("CMP", GetType(String))
            DT.Columns.Add("UNIT", GetType(String))
            DT.Columns.Add("USER1", GetType(String))
            DT.Columns.Add("SSTA", GetType(String))
            DT.Columns.Add("MODE", GetType(String))
            DT.Columns.Add("DPCODE", GetType(String))
            DT.Columns.Add("LMODI", GetType(String))
            DT.Columns.Add("AEDT", GetType(String))
            Dim db = New LiteDatabase(Server.MapPath("~/App_Data/DB1.db"))
            BILL_M_TBL = db.GetCollection(Of BILLM)("BILL")
            Dim list = db.GetCollection(Of BILLM)("BILL").FindAll().ToList
            For Each P In list
                Dim DR As DataRow = DT.NewRow
                DR("BILLID") = P.BILLID
                DR("BID") = P.BID
                DR("BILL_NO") = P.BILL_NO
                DR("BDATE") = P.BDATE
                DR("_id") = P.Id
                DR("DNAME") = P.DNAME
                DR("CUST") = P.CUST
                DR("PART_NO") = P.PART_NO
                DR("PARTI") = P.PARTI
                DR("QTY") = P.QTY
                DR("MRP") = P.MRP
                DR("SPRICE") = P.SPRICE
                DR("TOTAL") = P.TOTAL
                DR("TAX") = P.TAX
                DR("TVAL") = P.TVAL
                DR("STOT") = P.STOT
                DR("CMP") = P.CMP
                DR("UNIT") = P.UNIT
                DR("USER1") = P.USER
                DR("MODE") = P.MODE
                DR("SSTA") = P.MODE
                DR("DPCODE") = P.DPCODE
                DR("LMODI") = P.LMODI
                DR("AEDT") = P.AEDT
                DT.Rows.Add(DR)
            Next
            DG1.DataSource = Nothing
            DG1.DataBind()
            DG1.DataSource = DT
            DG1.DataBind()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub FND_Click(sender As Object, e As EventArgs) Handles FND.Click
        Try
            Dim D1 As DateTime = DOS.Text
            Dim D2 As DateTime = cdati.Text
            CREATEBILLTBL()
            Dim dv As New DataView(DT)
            dv.RowFilter = "BDATE >= #" & D1 & "# and BDATE <= #" & D2 & "#"
            DG1.DataSource = Nothing
            DG1.DataBind()
            DG1.DataSource = dv
            DG1.DataBind()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub err_display(ByVal msg As String)
        errdisplay.Text = msg
        errpopup.Show()
    End Sub

    Private Sub BILLADD_Click(sender As Object, e As EventArgs) Handles BILLADD.Click
        Try
            Dim db = New LiteDatabase(Server.MapPath("~/App_Data/DB1.db"))
            BILL_M_TBL = db.GetCollection(Of BILLM)("BILL")
            If sqlcon.State <> ConnectionState.Open Then sqlcon.Open()
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
            err_display("OK")
            CREATEBILLTBL()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class