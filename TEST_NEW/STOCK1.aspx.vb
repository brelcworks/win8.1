Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Data.OleDb
Imports ClosedXML.Excel
Imports System.IO
Public Class STOCK1
    Inherits System.Web.UI.Page

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
                    For i As Integer = 0 To sheet1_tbl.Rows.Count - 1
                        TXTPTNAME.Items.Add(sheet1_tbl.Rows(i)("parti"))
                        TXTPTNO.Items.Add(sheet1_tbl.Rows(i)("part_no"))
                    Next
                    DG1.DataSource = stock_tbl
                    DG1.DataBind()
                End If
            End If
        Catch ex As Exception
            err_display(ex.Message)
        End Try
    End Sub
    Protected Sub err_display(ByVal msg As String)
        errdisplay.Text = msg
        errpopup.Show()
    End Sub
    Protected Sub DTLS(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For Each c As Control In pnlAddEdit.Controls
                If TypeOf c Is TextBox Then
                    CType(c, TextBox).Text = ""
                End If
            Next
            Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
            Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
            Dim fid As String = DG1.DataKeys(gRow.RowIndex).Value.ToString()
            Dim dv As New DataView(stock_tbl)
            dv.RowFilter = "RID1='" & fid & "'"
            TXTRID.Text = DG1.DataKeys(gRow.RowIndex).Value.ToString()
            If Not IsDBNull(dv(0)("PARTI")) Then TXTPTNAME.Text = dv(0)("PARTI")
            If Not IsDBNull(dv(0)("TYPE")) Then TXTTYPE.Text = dv(0)("TYPE")
            If Not IsDBNull(dv(0)("PART_NO")) Then TXTPTNO.Text = dv(0)("PART_NO")
            If Not IsDBNull(dv(0)("MRP")) Then TXTMRP.Text = dv(0)("MRP")
            If Not IsDBNull(dv(0)("QTY")) Then TXTQTY.Text = dv(0)("QTY")
            If Not IsDBNull(dv(0)("TOTAL")) Then TXTTOT.Text = dv(0)("TOTAL")
            If Not IsDBNull(dv(0)("RACKNO")) Then TXTRCNO.Text = dv(0)("RACKNO")
            If Not IsDBNull(dv(0)("TAX")) Then TXTTAX.Text = dv(0)("TAX")
            If Not IsDBNull(dv(0)("TVAL")) Then TXTTVAL.Text = dv(0)("TVAL")
            If Not IsDBNull(dv(0)("STOTAL")) Then TXTSTOT.Text = dv(0)("STOTAL")
            If Not IsDBNull(dv(0)("PPRICE")) Then TXTPPRICE.Text = dv(0)("PPRICE")
            If Not IsDBNull(dv(0)("UNIT")) Then TXTUNIT.Text = dv(0)("UNIT")
            If Not IsDBNull(dv(0)("SPRICE")) Then TXTSPRICE.Text = dv(0)("SPRICE")
            If Not IsDBNull(dv(0)("EOR")) Then TXTEOR.Text = dv(0)("EOR")
            If Not IsDBNull(dv(0)("DPCODE")) Then TXTDPCODE.Text = dv(0)("DPCODE")
            If Not IsDBNull(dv(0)("GROP")) Then TXTGROP.Text = dv(0)("GROP")
            If Not IsDBNull(dv(0)("user1")) Then TXTUSER.Text = dv(0)("user1")
            popup.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub TXTPTNO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTPTNO.SelectedIndexChanged
        Try
            Dim DV As New DataView(sheet1_tbl)
            DV.RowFilter = "part_no='" & TXTPTNO.SelectedValue.ToString & "'"
            If DV.Count > 0 Then
                TXTPTNAME.Text = DV(0)("parti")
                TXTMRP.Text = DV(0)("mrp")
                TXTTAX.Text = DV(0)("trate")
                TXTUNIT.Text = DV(0)("UNIT")
                TXTTYPE.Text = DV(0)("cate")
                TXTGROP.Text = DV(0)("grop")
            End If
            popup.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub btncls_Click(sender As Object, e As EventArgs) Handles btncls.Click
        For Each c As Control In pnlAddEdit.Controls
            If TypeOf c Is TextBox Then
                CType(c, TextBox).Text = ""
            End If
        Next
        popup.Show()
    End Sub

    Private Sub TXTPTNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTPTNAME.SelectedIndexChanged
        Try
            Dim DV As New DataView(sheet1_tbl)
            DV.RowFilter = "parti='" & TXTPTNAME.SelectedValue.ToString & "'"
            If DV.Count > 0 Then
                TXTPTNO.Text = DV(0)("part_no")
                TXTMRP.Text = DV(0)("mrp")
                TXTTAX.Text = DV(0)("trate")
                TXTUNIT.Text = DV(0)("UNIT")
                TXTTYPE.Text = DV(0)("cate")
                TXTGROP.Text = DV(0)("grop")
            End If
            popup.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub PLLISTSAVE_Click(sender As Object, e As EventArgs) Handles PLLISTSAVE.Click
        Try
            Dim DR As DataRow = sheet1_tbl.NewRow
            DR("PARTI") = PLPTNAMETXT.Text
            DR("PART_NO") = PLPTNOTXT.Text
            DR("MRP") = PLMRPTXT.Text
            DR("UNIT") = PLUNITTXT.Text
            DR("GROP") = PLGROPTXT.Text
            DR("CATE") = PLTYPETXT.Text
            DR("TRATE") = PLTRATETXT.Text
            DR("DPCODE") = "A1587"
            DR("RID1") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            DR("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            sheet1_tbl.Rows.Add(DR)
            sheet1_adapter.Update(sheet1_tbl)
            sheet1_tbl.AcceptChanges()
            sheet1_tbl.Clear()
            sheet1_adapter.Fill(sheet1_tbl)
            TXTPTNAME.Items.Clear()
            TXTPTNO.Items.Clear()
            For i As Integer = 0 To sheet1_tbl.Rows.Count - 1
                TXTPTNAME.Items.Add(sheet1_tbl.Rows(i)("parti"))
                TXTPTNO.Items.Add(sheet1_tbl.Rows(i)("part_no"))
            Next
            TXTPTNAME.Text = PLPTNAMETXT.Text
            TXTPTNO.Text = PLPTNOTXT.Text
            TXTMRP.Text = PLMRPTXT.Text
            TXTGROP.Text = PLGROPTXT.Text
            TXTTYPE.Text = PLTYPETXT.Text
            TXTTAX.Text = PLTRATETXT.Text
            TXTUNIT.Text = PLUNITTXT.Text
            TXTSPRICE.Text = Format(Val(TXTMRP.Text) / (Val(TXTTAX.Text) + 100) * 100, "0.00")
            TXTPPRICE.Text = Format(Val(TXTMRP.Text) / 122 * 100, "0.00")
            TXTTVAL.Text = Format(Val(TXTSPRICE.Text) * Val(TXTTAX.Text) / 100, "0.00")
            For Each c As Control In pnlPLLIST.Controls
                If TypeOf c Is TextBox Then
                    CType(c, TextBox).Text = ""
                End If
            Next
            popup.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub TXTMRP_TextChanged(sender As Object, e As EventArgs) Handles TXTMRP.TextChanged
        Try
            TXTSPRICE.Text = Format(Val(TXTMRP.Text) / (Val(TXTTAX.Text) + 100) * 100, "0.00")
            TXTPPRICE.Text = Format(Val(TXTMRP.Text) / 122 * 100, "0.00")
            TXTTVAL.Text = Format(Val(TXTSPRICE.Text) * Val(TXTTAX.Text) / 100, "0.00")
            popup.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub BTNCACL_Click(sender As Object, e As EventArgs) Handles BTNCACL.Click
        TXTSPRICE.Text = Format(Val(TXTMRP.Text) / (Val(TXTTAX.Text) + 100) * 100, "0.00")
        TXTPPRICE.Text = Format(Val(TXTMRP.Text) / 122 * 100, "0.00")
        TXTTVAL.Text = Format(Val(TXTSPRICE.Text) * Val(TXTTAX.Text) / 100, "0.00")
        popup.Show()
    End Sub

    Private Sub TXTQTY_TextChanged(sender As Object, e As EventArgs) Handles TXTQTY.TextChanged
        TXTTOT.Text = Format(Val(TXTQTY.Text) * Val(TXTMRP.Text), "0.00")
        TXTSTOT.Text = Format(Val(TXTSPRICE.Text) * Val(TXTQTY.Text), "0.00")
        TXTUSER.Text = Session("user_name").ToString
        TXTDPCODE.Text = "A1587"
        popup.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If TXTRID.Text = "" Then
                If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                Dim dr As DataRow = stock_tbl.NewRow
                dr("parti") = TXTPTNAME.Text
                dr("part_no") = TXTPTNO.Text
                dr("mrp") = TXTMRP.Text
                dr("qty") = TXTQTY.Text
                dr("type") = TXTTYPE.Text
                dr("total") = TXTTOT.Text
                dr("rackno") = TXTRCNO.Text
                dr("tax") = TXTTAX.Text
                dr("tval") = TXTTVAL.Text
                dr("stotal") = TXTSTOT.Text
                dr("pprice") = TXTPPRICE.Text
                dr("sprice") = TXTSPRICE.Text
                dr("unit") = TXTUNIT.Text
                dr("ssta") = "NEW"
                dr("eor") = TXTEOR.Text
                dr("rid") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                dr("lmodi") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                dr("grop") = TXTGROP.Text
                dr("USER1") = TXTUSER.Text
                dr("dpcode") = TXTDPCODE.Text
                stock_tbl.Rows.Add(dr)
                stock_adapter.Update(stock_tbl)
                stock_tbl.AcceptChanges()
                stock_tbl.Clear()
                stock_adapter.Fill(stock_tbl)
                DG1.DataSource = stock_tbl
                DG1.DataBind()
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
            Else
                Dim dv As New DataView(stock_tbl)
                dv.RowFilter = "RID1='" & TXTRID.Text & "'"
                dv(0)("parti") = TXTPTNAME.Text
                dv(0)("part_no") = TXTPTNO.Text
                dv(0)("mrp") = TXTMRP.Text
                dv(0)("qty") = TXTQTY.Text
                dv(0)("type") = TXTTYPE.Text
                dv(0)("total") = TXTTOT.Text
                dv(0)("rackno") = TXTRCNO.Text
                dv(0)("tax") = TXTTAX.Text
                dv(0)("tval") = TXTTVAL.Text
                dv(0)("stotal") = TXTSTOT.Text
                dv(0)("pprice") = TXTPPRICE.Text
                dv(0)("sprice") = TXTSPRICE.Text
                dv(0)("unit") = TXTUNIT.Text
                dv(0)("ssta") = "NEW"
                dv(0)("eor") = TXTEOR.Text
                dv(0)("lmodi") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                dv(0)("grop") = TXTGROP.Text
                dv(0)("USER1") = TXTUSER.Text
                dv(0)("dpcode") = TXTDPCODE.Text
                stock_adapter.Update(stock_tbl)
                stock_tbl.AcceptChanges()
                stock_tbl.Clear()
                stock_adapter.Fill(stock_tbl)
                DG1.DataSource = stock_tbl
                DG1.DataBind()
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Try
            Dim wb As XLWorkbook = New XLWorkbook
            Dim ws = wb.Worksheets.Add("Sheet1")
            ws.Cell(1, 1).Value = "SL. NO."
            ws.Cell(1, 2).Value = "PART NAME"
            ws.Cell(1, 3).Value = "PART NO"
            ws.Cell(1, 4).Value = "QTY"
            ws.Cell(1, 5).Value = "MRP"
            ws.Cell(1, 6).Value = "SELL PRICE"
            ws.Cell(1, 7).Value = "UNIT"
            ws.Cell(1, 8).Value = "RACK NO"
            ws.Cell(1, 9).Value = "MRP TOTAL"
            ws.Cell(1, 10).Value = "SELL PRICE TOTAL"
            For I As Integer = 0 To stock_tbl.Rows.Count - 1
                ws.Cell(I + 2, 1).Value = I.ToString + 1
                ws.Cell(I + 2, 2).Value = stock_tbl.Rows(I)("PARTI").ToString
                ws.Cell(I + 2, 3).Value = stock_tbl.Rows(I)("PART_NO").ToString
                ws.Cell(I + 2, 4).Value = stock_tbl.Rows(I)("QTY").ToString
                ws.Cell(I + 2, 5).Value = stock_tbl.Rows(I)("MRP").ToString
                ws.Cell(I + 2, 6).Value = stock_tbl.Rows(I)("SPRICE").ToString
                ws.Cell(I + 2, 7).Value = stock_tbl.Rows(I)("UNIT").ToString
                ws.Cell(I + 2, 8).Value = stock_tbl.Rows(I)("RACKNO").ToString
                ws.Cell(I + 2, 9).Value = stock_tbl.Rows(I)("TOTAL").ToString
                ws.Cell(I + 2, 10).Value = stock_tbl.Rows(I)("STOTAL").ToString
            Next
            Dim RCNT As String = "J" & ws.RowsUsed.Count
            ws.Range("a1", RCNT).Style.Border.TopBorder = XLBorderStyleValues.Thin
            ws.Range("a1", RCNT).Style.Border.RightBorder = XLBorderStyleValues.Thin
            ws.Range("a1", RCNT).Style.Border.LeftBorder = XLBorderStyleValues.Thin
            ws.Range("a1", RCNT).Style.Border.BottomBorder = XLBorderStyleValues.Thin
            ws.Range("a1", "J1").Style.Fill.BackgroundColor = XLColor.Turquoise
            ws.Columns().AdjustToContents()
            ws.SheetView.FreezeRows(1)
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=STOCK_LIST.xlsx")
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
    Protected Sub DNLDDB(sender As Object, e As EventArgs)
        Try
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/sdf"
            Dim x As String = Server.MapPath("~/App_data/db1.sdf")
            Response.AppendHeader("content-disposition", "attachment; filename=db1.sdf")
            Response.WriteFile(x)
            Response.End()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub BTNDEL_Click(sender As Object, e As EventArgs) Handles BTNDEL.Click
        Try
            If TXTRID.Text <> "" Then
                For i As Integer = 0 To stock_tbl.Rows.Count - 1
                    If stock_tbl(i)("RID1") = TXTRID.Text Then
                        stock_tbl(i).Delete()
                        stock_adapter.Update(stock_tbl)
                        stock_tbl.AcceptChanges()
                        stock_tbl.Clear()
                        stock_adapter.Fill(stock_tbl)
                        DG1.DataSource = stock_tbl
                        DG1.DataBind()
                        For Each c As Control In pnlAddEdit.Controls
                            If TypeOf c Is TextBox Then
                                CType(c, TextBox).Text = ""
                            End If
                        Next
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class