Imports System.Data.SqlClient
Imports LiteDB

Public Class SLREPORT
    Inherits System.Web.UI.Page
    Private BILL_M_TBL
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
                    CREATEBILLTBL()
                    LOADBILLTBL()
                End If
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub LOADBILLTBL()
        Try
            Dim LDB = New LiteDatabase(Server.MapPath("~/App_Data/DB1.db"))
            Dim list = LDB.GetCollection(Of BILLM)("BILL").FindAll().ToList
            For Each P In list
                Dim DR As DataRow = BILL_tbl_M.NewRow
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
                BILL_tbl_M.Rows.Add(DR)
            Next
            DG1.DataSource = Nothing
            DG1.DataBind()
            DG1.DataSource = BILL_tbl
            DG1.DataBind()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub FND_Click(sender As Object, e As EventArgs) Handles FND.Click
        Try
            Dim D1 As DateTime = DOS.Text
            Dim D2 As DateTime = cdati.Text
            Dim dv As New DataView(BILL_tbl)
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
            Dim LDB = New LiteDatabase(Server.MapPath("~/App_Data/DB1.db"))
            BILL_M_TBL = LDB.GetCollection(Of BILLM)("BILL")
            If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
            For I As Integer = 0 To BILL_tbl.Rows.Count - 1
                Dim apd As String = BILL_tbl(I)("BID").ToString
                Dim query1 = Query.EQ("BID", apd)
                Dim prod = LDB.GetCollection(Of BILLM)("BILL").Find(query1)
                For Each P In prod
                    If P.BID = "" Then
                        Dim P1 = New BILLM() With {
                       .BID = BILL_tbl("BID").ToString,
                       .BILL_NO = BILL_tbl("BILL_NO").ToString,
                       .BDATE = BILL_tbl("BDATE").ToString,
                       .DNAME = BILL_tbl("DNAME").ToString,
                       .CUST = BILL_tbl("CUST").ToString,
                       .PART_NO = BILL_tbl("PART_NO").ToString,
                       .PARTI = BILL_tbl("PARTI").ToString,
                       .QTY = BILL_tbl("QTY").ToString,
                       .MRP = BILL_tbl("MRP").ToString,
                       .SPRICE = BILL_tbl("SPRICE").ToString,
                       .TOTAL = BILL_tbl("TOTAL").ToString,
                       .TAX = BILL_tbl("TAX").ToString,
                       .TVAL = BILL_tbl("TVAL").ToString,
                       .STOT = BILL_tbl("STOT").ToString,
                       .CMP = BILL_tbl("CMP").ToString,
                       .UNIT = BILL_tbl("UNIT").ToString,
                      .USER = BILL_tbl("USER1").ToString,
                      .MODE = BILL_tbl("MODE").ToString,
                      .SSTA = BILL_tbl("SSTA").ToString,
                      .AEDT = BILL_tbl("AEDT").ToString,
                      .LMODI = BILL_tbl("LMODI").ToString,
                      .BILLID = BILL_tbl("BILLID").ToString,
                      .DPCODE = BILL_tbl("DPCODE").ToString
                       }
                        BILL_M_TBL.Insert(P1)
                    End If
                Next
            Next
            err_display("OK")
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class