Imports System.Data.SqlClient
Imports LiteDB
Imports ClosedXML.Excel
Imports System.IO

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
                    DG1.DataSource = BILL_tbl
                    DG1.DataBind()
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

    Private Sub BTNEXPORT_Click(sender As Object, e As EventArgs) Handles BTNEXPORT.Click
        Try
            Dim wb As XLWorkbook = New XLWorkbook
            Dim ws = wb.Worksheets.Add("SALES REPORT")
            ws.Range("a1", "O1").Merge()
            ws.Range("a1").Value = "SALES REPORT"
            ws.Range("a1").Style.Font.FontName = "Book Antiqua"
            ws.Range("a1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            ws.Range("a1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            ws.Range("a1").Style.Font.FontSize = 24
            ws.Range("a1").Style.Font.Bold = True
            ws.Cell(2, 1).Value = "SL NO"
            ws.Cell(2, 2).Value = "BILL NO"
            ws.Cell(2, 3).Value = "BILL DATE"
            ws.Cell(2, 4).Value = "CUSTOMER"
            ws.Cell(2, 5).Value = "SITE NAME"
            ws.Cell(2, 6).Value = "PART NO"
            ws.Cell(2, 7).Value = "PRODUCT NAME"
            ws.Cell(2, 8).Value = "QTY"
            ws.Cell(2, 9).Value = "MRP"
            ws.Cell(2, 10).Value = "UNIT"
            ws.Cell(2, 11).Value = "SELL PRICE"
            ws.Cell(2, 12).Value = "TOTAL"
            ws.Cell(2, 13).Value = "SELL TOTAL"
            ws.Cell(2, 14).Value = "TAX%"
            ws.Cell(2, 15).Value = "TAX VALUE"
            Dim dv As New DataView(BILL_tbl)
            If Not IsDate(cdati.Text) And Not IsDate(DOS.Text) Then
                dv.RowFilter = Nothing
            Else
                Dim D1 As DateTime = DOS.Text
                Dim D2 As DateTime = cdati.Text
                Dim x1 As TimeSpan = New TimeSpan(0, 23, 59, 59)
                D2 = D2.Add(x1)
                dv.RowFilter = "BDATE >= #" & D1 & "# and BDATE <= #" & D2 & "#"
            End If

            For I As Integer = 0 To dv.Count - 1
                ws.Cell(I + 3, 1).Value = I.ToString + 1
                ws.Cell(I + 3, 2).Value = dv(I)("BILL_NO").ToString
                ws.Cell(I + 3, 3).Value = dv(I)("BDATE").ToString
                ws.Cell(I + 3, 4).Value = dv(I)("DNAME").ToString
                ws.Cell(I + 3, 5).Value = dv(I)("CUST").ToString
                ws.Cell(I + 3, 6).Value = dv(I)("PART_NO").ToString
                ws.Cell(I + 3, 7).Value = dv(I)("PARTI").ToString
                ws.Cell(I + 3, 8).Value = dv(I)("QTY").ToString
                ws.Cell(I + 3, 9).Value = dv(I)("MRP").ToString
                ws.Cell(I + 3, 10).Value = dv(I)("UNIT").ToString
                ws.Cell(I + 3, 11).Value = dv(I)("SPRICE").ToString
                ws.Cell(I + 3, 12).Value = dv(I)("TOTAL").ToString
                ws.Cell(I + 3, 13).Value = dv(I)("STOT").ToString
                ws.Cell(I + 3, 14).Value = dv(I)("TAX").ToString
                ws.Cell(I + 3, 15).Value = dv(I)("TVAL").ToString
            Next
            Dim X As Integer = ws.RowsUsed.Count
            ws.Range("c3", "c" & X).Style.NumberFormat.SetFormat("dd-MMMM-yyyy")
            ws.Range("K3", "O" & X).Style.NumberFormat.SetFormat("#.00")
            ws.Range("a" & X + 1, "k" & X + 1).Merge()
            ws.Range("a" & X + 1).Value = "TOTAL"
            ws.Range("a" & X + 1).Style.Font.FontName = "Book Antiqua"
            ws.Range("a" & X + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            ws.Range("a" & X + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
            ws.Range("a" & X + 1).Style.Font.Bold = True
            ws.Range("L" & X + 1).Value = "=SUM(L3:L" & X & ")"
            ws.Range("m" & X + 1).Value = "=SUM(m3:m" & X & ")"
            ws.Range("o" & X + 1).Value = "=SUM(o3:o" & X & ")"
            X = X + 1
            ws.Range("A1", "O" & X).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            ws.Range("A1", "O" & X).Style.Border.TopBorder = XLBorderStyleValues.Thin
            ws.Range("A1", "O" & X).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            ws.Range("A1", "O" & X).Style.Border.RightBorder = XLBorderStyleValues.Thin
            ws.Range("a2", "o2").Style.Fill.BackgroundColor = XLColor.Aqua
            ws.Range("a2", "o2").Style.Font.Bold = True
            ws.Columns().AdjustToContents()
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=SALES REPORT ON: " & Format(Now(), "dd-MMMM-yyyy") & ".XLSX")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.[End]()
            End Using
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class