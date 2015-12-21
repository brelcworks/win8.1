Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports System.Web.Security
Imports System.Data.SqlServerCe
Imports ClosedXML.Excel
Imports System.IO
Public Class BILL_PUR
    Inherits System.Web.UI.Page
    Public DV As New DataView(PURCHSE_tbl)
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
                If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
                If Not Me.IsPostBack Then
                    For i As Integer = 0 To PURCHSE1_tbl.Rows.Count - 1
                        If Not IsDBNull(PURCHSE1_tbl.Rows(i)("cust")) Then txtcname.Items.Add(PURCHSE1_tbl.Rows(i)("cust"))
                        If Not IsDBNull(PURCHSE1_tbl.Rows(i)("SNAME")) Then txtsname.Items.Add(PURCHSE1_tbl.Rows(i)("SNAME"))
                    Next
                    For i As Integer = 0 To stock_tbl.Rows.Count - 1
                        txtptname.Items.Add(stock_tbl.Rows(i)("PARTI"))
                        txtptno.Items.Add(stock_tbl.Rows(i)("PART_NO"))
                    Next
                End If
                DV.RowFilter = "bill_no='" & txtbno.Text & "'"
                dg1.DataSource = DV
                dg1.DataBind()
                DG2.DataSource = PURCHSE1_tbl
                DG2.DataBind()
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub txtcname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtcname.SelectedIndexChanged
        Try
            If SQLCE.State <> ConnectionState.Open Then SQLCE.Open()
            Dim DV1 As New DataView(PURCHSE1_tbl)
            DV1.RowFilter = "cust='" & txtcname.SelectedValue.ToString & "'"

            If DV1.Count > 0 Then
                txtaddr.Text = DV1(0)("ADDRESS")
                txtvno.Text = DV1(0)("VNO")
                txtsname.Items.Clear()
                For I As Integer = 0 To DV1.Count - 1
                    If Not IsDBNull(DV1(I)("SNAME")) Then txtsname.Items.Add(DV1(I)("SNAME"))
                Next
                Dim X As New SqlCeCommand("SELECT SUM(NTOT) FROM PURCHSE1 WHERE cust='" & txtcname.Text & "'", SQLCE)
                Dim X1 As String = X.ExecuteScalar & ""
                Dim Y As New SqlCeCommand("SELECT SUM(PAYMENT) FROM PURCHSE1 WHERE cust='" & txtcname.Text & "'", SQLCE)
                Dim Y1 As String = Y.ExecuteScalar & ""
                txtbal.Text = Val(X1) - Val(Y1)
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub txtcname_TextChanged(sender As Object, e As EventArgs) Handles txtcname.TextChanged

    End Sub



    Protected Sub txtptname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtptname.SelectedIndexChanged
        Try
            Dim DV1 As New DataView(stock_tbl)
            DV1.RowFilter = "PARTI='" & txtptname.SelectedValue.ToString & "'"
            If DV1.Count > 0 Then
                txtptno.Text = DV1(0)("PART_NO")
                txtmrp.Text = DV1(0)("MRP")
                txttrate.Text = DV1(0)("TAX")

                txtunit.Text = DV1(0)("UNIT")
                txtinstock.Text = DV1(0)("QTY")
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub BTNITMCALC_Click(sender As Object, e As EventArgs) Handles BTNITMCALC.Click
        Try
            If Not txtrate.Text = "" Then
                txttval.Text = Val(txtqty.Text) * Val(txtrate.Text) * Val(txttrate.Text) / 100
                txtitot.Text = Val(txtqty.Text) * Val(txtrate.Text)
            Else
                err_display("Please Fill the Rate Field!")
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub add_item_Click(sender As Object, e As EventArgs) Handles add_item.Click
        Try
            Dim dr As DataRow = PURCHSE_tbl.NewRow
            dr("bid") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            dr("bill_no") = txtbno.Text
            dr("bdate") = txtbdate.Text
            dr("dname") = txtcname.Text
            dr("cust") = txtsname.Text
            dr("part_no") = txtptno.Text
            dr("parti") = txtptname.Text
            dr("qty") = txtqty.Text
            dr("mrp") = txtmrp.Text
            dr("sprice") = txtrate.Text
            dr("total") = Val(txtqty.Text) * Val(txtmrp.Text)
            dr("tax") = txttrate.Text
            dr("tval") = txttval.Text
            dr("stot") = txtitot.Text
            dr("cmp") = "EICHER"
            dr("UNIT") = txtunit.Text
            dr("USER1") = "ANJAN PAUL"
            If cash.Checked = True Then
                dr("MODE") = "CASH"
            Else
                dr("MODE") = "CREDIT"
            End If
            dr("SSTA") = "NEW"
            dr("DPCODE") = "A1587"
            dr("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            PURCHSE_tbl.Rows.Add(dr)

            Dim DV1 As New DataView(stock_tbl, "", "part_no", DataViewRowState.CurrentRows)
            Dim index As Integer = DV1.Find(txtptno.Text)
            If Not index = -1 Then
                Dim Z As String = CType(DV1(index)("qty"), String)
                DV1(index)("qty") = Val(Z) + Val(txtqty.Text)
                Dim x1 As String = CType(DV1(index)("qty"), String)
                DV1(index)("stotal") = Val(x1) * CType(DV1(index)("SPRICE"), String)
                DV1(index)("total") = Val(x1) * CType(DV1(index)("mrp"), String)
                DV1(index)("SSTA") = "MOD"
                DV1(index)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            End If

            dv.RowFilter = "bill_no='" & txtbno.Text & "'"
            dg1.DataBind()
            txtgtot.Text = Val(txtgtot.Text) + Val(txtitot.Text)
            txtntval.Text = Val(txttval.Text) + Val(txtntval.Text)
            txtntot.Text = Math.Round(Val(txtgtot.Text) + Val(txtntval.Text))
            txtround.Text = FormatNumber(Val(txtntot.Text) - (Val(txtgtot.Text) + Val(txtntval.Text)), 2)
            txtmrp.Text = ""
            txtrate.Text = ""
            txtqty.Text = ""
            txtinstock.Text = ""
            txttrate.Text = ""
            txtunit.Text = ""
            txttval.Text = ""
            txtitot.Text = ""
            txtptname.SelectedValue = Nothing
            txtptno.SelectedValue = Nothing
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub err_display(ByVal msg As String)
        errdisplay.Text = msg
        errpopup.Show()
    End Sub

    Protected Sub NEW_BILL_Click(sender As Object, e As EventArgs) Handles NEW_BILL.Click
        Try
            If NEW_BILL.Text = "New Bill" Then
                NEW_BILL.Text = "Save Bill"
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is ComboBox Then
                        CType(c, ComboBox).SelectedValue = Nothing
                    End If
                Next
                txtbdate.Text = Now.ToString("dd-MMMM-yyyy")
                Dim yy As String = Today.ToString("yy")
                Dim dv1 As New DataView(PURCHSE1_tbl)
                dv1.RowFilter = "BNO LIKE '%" & "MB" & "%'"
                Dim Y As Integer = dv1.Count - 1
                DV.RowFilter = "bill_no='" & txtbno.Text & "'"
                dg1.DataBind()
                If Y < 0 Then
                    txtbno.Text = "MB " & "1" & "/" & yy & "-" & Val(yy) + 1
                Else
                    Dim X1 As String = dv1(Y)("BNO").ToString
                    Dim Rlst As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(X1, "\d+")
                    txtbno.Text = "MB " & Rlst.Value + 1 & "/" & yy & "-" & Val(yy) + 1
                End If
                txtgtot.Text = "0.00"
                txtntval.Text = "0.00"
                txtround.Text = "0.00"
                txtntot.Text = "0.00"
                txtcname.SelectedValue = Nothing
                txtsname.SelectedValue = Nothing
            Else
                If bid.Text = "" Then
                    Dim DR As DataRow = PURCHSE1_tbl.NewRow
                    DR("bid1") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    DR("BDATE") = txtbdate.Text
                    DR("BNO") = txtbno.Text
                    DR("CUST") = txtcname.Text
                    DR("SNAME") = txtsname.Text
                    DR("ADDRESS") = txtaddr.Text
                    DR("GTOT") = FormatNumber(txtgtot.Text, 2)
                    If cash.Checked = True Then
                        DR("MODE") = "CASH"
                        DR("CBILL") = txtntot.Text
                        DR("total") = txtbal.Text
                    Else
                        DR("MODE") = "CREDIT"
                        DR("NTOT") = txtntot.Text
                        DR("BAPAY") = txtntot.Text
                        DR("BST") = "UP"
                        DR("total") = Val(txtbal.Text) + Val(txtntot.Text)
                    End If
                    DR("BAMT") = txtntot.Text
                    DR("ROUND") = txtround.Text
                    DR("TVAL") = txtntval.Text
                    DR("USER1") = Session("user_name").ToString
                    DR("SSTA") = "NEW"
                    DR("DPCODE") = "A1587"
                    DR("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    DR("VNO") = txtvno.Text
                    PURCHSE1_tbl.Rows.Add(DR)
                    stock_adapter.Update(stock_tbl)
                    stock_tbl.AcceptChanges()
                    stock_tbl.Clear()
                    stock_adapter.Fill(stock_tbl)
                    PURCHSE_adapter.Update(PURCHSE_tbl)
                    PURCHSE_tbl.AcceptChanges()
                    PURCHSE_tbl.Clear()
                    PURCHSE_adapter.Fill(PURCHSE_tbl)
                    PURCHSE1_adapter.Update(PURCHSE1_tbl)
                    PURCHSE1_tbl.AcceptChanges()
                    PURCHSE1_tbl.Clear()
                    PURCHSE1_adapter.Fill(PURCHSE1_tbl)
                    NEW_BILL.Text = "New Bill"
                    DG2.DataBind()
                    bid.Text = ""
                    popchallan.Show()
                Else
                    Dim dv1 As New DataView(PURCHSE1_tbl, "", "bid", DataViewRowState.CurrentRows)
                    Dim index As Integer = dv1.Find(bid.Text)
                    If Not index = -1 Then
                        dv1(index)("BDATE") = txtbdate.Text
                        dv1(index)("BNO") = txtbno.Text
                        dv1(index)("CUST") = txtcname.Text
                        dv1(index)("SNAME") = txtsname.Text
                        dv1(index)("ADDRESS") = txtaddr.Text
                        dv1(index)("GTOT") = FormatNumber(txtgtot.Text, 2)
                        If cash.Checked = True Then
                            dv1(index)("MODE") = "CASH"
                            dv1(index)("CBILL") = txtntot.Text
                        Else
                            dv1(index)("MODE") = "CREDIT"
                            dv1(index)("NTOT") = txtntot.Text
                            dv1(index)("BAPAY") = txtntot.Text
                            dv1(index)("BST") = "UP"
                        End If
                        dv1(index)("BAMT") = txtntot.Text
                        dv1(index)("ROUND") = txtround.Text
                        dv1(index)("TVAL") = txtntval.Text
                        dv1(index)("USER1") = Session("user_name").ToString
                        dv1(index)("SSTA") = "NEW"
                        dv1(index)("DPCODE") = "A1587"
                        dv1(index)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                        dv1(index)("VNO") = txtvno.Text

                        Dim DV3 As New DataView(PURCHSE1_tbl)
                        DV3.RowFilter = "cust = '" & txtcname.Text & "'"
                        For i As Integer = 0 To DV3.Count - 1
                            Dim tot As String
                            Dim btot As String = DV3(i)("ntot") & ""
                            Dim ptot As String = DV3(i)("payment") & ""
                            If i = 0 Then
                                tot = "0"
                            Else
                                tot = DV3(i - 1)("total") & ""
                            End If
                            DV3(i)("total") = Val(tot) + (Val(btot) - Val(ptot))
                        Next
                    End If
                    stock_adapter.Update(stock_tbl)
                    stock_tbl.AcceptChanges()
                    stock_tbl.Clear()
                    stock_adapter.Fill(stock_tbl)
                    PURCHSE_adapter.Update(PURCHSE_tbl)
                    PURCHSE_tbl.AcceptChanges()
                    PURCHSE_tbl.Clear()
                    PURCHSE_adapter.Fill(PURCHSE_tbl)
                    PURCHSE1_adapter.Update(PURCHSE1_tbl)
                    PURCHSE1_tbl.AcceptChanges()
                    PURCHSE1_tbl.Clear()
                    PURCHSE1_adapter.Fill(PURCHSE1_tbl)
                    NEW_BILL.Text = "New Bill"
                    DG2.DataBind()
                    bid.Text = ""
                    popchallan.Show()
                End If
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
    Protected Sub Edit(sender As Object, e As EventArgs)
        Try
            Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
            Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
            Dim fid As String = DG2.DataKeys(gRow.RowIndex).Value.ToString()
            Dim dv1 As New DataView(PURCHSE1_tbl)
            bid.Text = fid
            dv1.RowFilter = "bID='" & fid & "'"
            txtbno.Text = dv1(0)("bno")
            txtbdate.Text = dv1(0)("bdate")
            txtntot.Text = dv1(0)("bamt")
            txtcname.Text = dv1(0)("cust")
            txtsname.Text = dv1(0)("SNAME")
            txtgtot.Text = dv1(0)("gtot")
            txtround.Text = dv1(0)("round")
            txtntval.Text = dv1(0)("tval")
            txtaddr.Text = dv1(0)("ADDRESS")
            DV.RowFilter = "bill_no='" & txtbno.Text & "'"
            dg1.DataBind()
        Catch ex As Exception
            err_display(ex.Message)
        End Try
    End Sub

    Private Sub challan1_Click(sender As Object, e As EventArgs) Handles challan1.Click

    End Sub
    Protected Sub Edit_itm(sender As Object, e As EventArgs)
        Try
            Dim btnsubmit As LinkButton = TryCast(sender, LinkButton)
            Dim gRow As GridViewRow = DirectCast(btnsubmit.NamingContainer, GridViewRow)
            Dim fid As String = dg1.DataKeys(gRow.RowIndex).Values(1).ToString
            Dim dv1 As New DataView(PURCHSE_tbl)
            dv1.RowFilter = "BID='" & fid & "'"
            txtptnameedt.Text = dv1(0)("parti")
            txtptnoedt.Text = dv1(0)("part_no")
            txtqtyedt.Text = dv1(0)("qty")
            txtmrpedt.Text = dv1(0)("mrp")
            txtrateedt.Text = dv1(0)("sprice")
            txttotedt.Text = dv1(0)("total")
            txttaxedt.Text = (dv1(0)("tax"))
            txttvaledt.Text = dv1(0)("tval")
            txtunitedt.Text = dv1(0)("unit")
            txtstotedt.Text = dv1(0)("stot")
            txtrec.Text = dv1(0)("bid")
            hgtot.Text = dv1(0)("stot")
            hqty.Text = dv1(0)("qty")
            edtitmpop.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If txtrate.Text = "" Then Exit Sub
            txttval.Text = Val(txtqty.Text) * Val(txtrate.Text) * Val(txttrate.Text) / 100
            txtitot.Text = Val(txtqty.Text) * Val(txtrate.Text)
            Dim dr As DataRow = PURCHSE_tbl.NewRow
            dr("bid") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            dr("bill_no") = txtbno.Text
            dr("bdate") = txtbdate.Text
            dr("dname") = txtcname.Text
            dr("cust") = txtsname.Text
            dr("part_no") = txtptno.Text
            dr("parti") = txtptname.Text
            dr("qty") = txtqty.Text
            dr("mrp") = txtmrp.Text
            dr("sprice") = txtrate.Text
            dr("total") = Val(txtqty.Text) * Val(txtmrp.Text)
            dr("tax") = txttrate.Text
            dr("tval") = txttval.Text
            dr("stot") = txtitot.Text
            dr("cmp") = "EICHER"
            dr("UNIT") = txtunit.Text
            dr("USER1") = "ANJAN PAUL"
            If cash.Checked = True Then
                dr("MODE") = "CASH"
            Else
                dr("MODE") = "CREDIT"
            End If
            dr("SSTA") = "NEW"
            dr("DPCODE") = "A1587"
            dr("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            PURCHSE_tbl.Rows.Add(dr)

            Dim DV1 As New DataView(stock_tbl, "", "part_no", DataViewRowState.CurrentRows)
            Dim index As Integer = DV1.Find(txtptno.Text)
            If Not index = -1 Then
                Dim Z As String = CType(DV1(index)("qty"), String)
                DV1(index)("qty") = Val(Z) + Val(txtqty.Text)
                Dim x1 As String = CType(DV1(index)("qty"), String)
                DV1(index)("stotal") = Val(x1) * CType(DV1(index)("SPRICE"), String)
                DV1(index)("total") = Val(x1) * CType(DV1(index)("mrp"), String)
                DV1(index)("SSTA") = "MOD"
                DV1(index)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            End If

            DV.RowFilter = "bill_no='" & txtbno.Text & "'"
            dg1.DataBind()
            txtgtot.Text = Val(txtgtot.Text) + Val(txtitot.Text)
            txtntval.Text = Val(txttval.Text) + Val(txtntval.Text)
            txtntot.Text = Math.Round(Val(txtgtot.Text) + Val(txtntval.Text))
            txtround.Text = FormatNumber(Val(txtntot.Text) - (Val(txtgtot.Text) + Val(txtntval.Text)), 2)
            txtmrp.Text = ""
            txtrate.Text = ""
            txtqty.Text = ""
            txtinstock.Text = ""
            txttrate.Text = ""
            txtunit.Text = ""
            txttval.Text = ""
            txtitot.Text = ""
            txtptname.SelectedValue = Nothing
            txtptno.SelectedValue = Nothing
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub challan_Click(sender As Object, e As EventArgs) Handles challan.Click
        Try
            If dg1.Rows.Count > 12 Then
                Dim wb As XLWorkbook = New XLWorkbook
                Dim ws = wb.Worksheets.Add("CHALLAN")
                ws.Column(1).Width = 5.43
                ws.Column(2).Width = 6
                ws.Column(3).Width = 6.29
                ws.Column(4).Width = 8.43
                ws.Column(5).Width = 8.43
                ws.Column(6).Width = 17.57
                ws.Column(7).Width = 3
                ws.Column(8).Width = 7.29
                ws.Column(9).Width = 9.5
                ws.Column(10).Width = 7.43
                ws.Column(11).Width = 10.86
                ws.Range("a2", "k2").Merge()
                ws.Range("a2").Value = "B. & R. ELECTRICAL WORKS"
                ws.Range("a2").Style.Font.FontName = "Book Antiqua"
                ws.Range("a2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                ws.Range("a2").Style.Font.FontSize = 24
                ws.Range("a2").Style.Font.Bold = True
                Dim range As ClosedXML.Excel.IXLRange
                range = ws.Range("a1", "k1")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Row(6).Height = 3
                ws.Cell(7, 1).Value = "CHALLAN NO:-"
                ws.Cell(7, 10).Value = "DATE:-"
                ws.Cell(7, 11).Value = txtbdate.Text
                ws.Cell(8, 1).Value = "CUSTOMER:-"
                ws.Cell(10, 1).Value = "VAT NO:-"
                range = ws.Range("a1", "k5")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("a7", "k10")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Row(11).Height = 3
                ws.Cell(12, 1).Value = "SL NO"
                ws.Cell(12, 2).Value = "PART NO"
                ws.Cell(12, 4).Value = "PARTICULARS"
                ws.Cell(12, 9).Value = "MRP"
                ws.Cell(12, 10).Value = "QTY"
                ws.Cell(12, 11).Value = "PER"
                range = ws.Range("a12", "k12")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("a12", "A52")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("d12", "H52")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("j12", "j52")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("k12", "k52")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range("i12", "i52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                ws.Range("j12", "j52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                ws.Range("k12", "k52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a13", "k52").Style.Font.FontSize = 9.5
                ws.Range("a56", "k56").Style.Font.Bold = True
                ws.PageSetup.Margins.Left = 0.25
                ws.PageSetup.Margins.Right = 0.17
                ws.PageSetup.Margins.Top = 0.15
                ws.PageSetup.Margins.Bottom = 0.02
                ws.PageSetup.Margins.Header = 0.02
                ws.PageSetup.Margins.Footer = 0.02
                For i As Integer = 0 To dg1.Rows.Count - 1
                    ws.Cell(i + 13, 1).Value = i.ToString + 1
                    ws.Cell(i + 13, 2).Value = "'" & dg1.Rows(i).Cells(1).Text
                    ws.Cell(i + 13, 4).Value = dg1.Rows(i).Cells(2).Text
                    ws.Cell(i + 13, 9).Value = dg1.Rows(i).Cells(4).Text
                    ws.Cell(i + 13, 10).Value = dg1.Rows(i).Cells(3).Text
                    ws.Cell(i + 13, 11).Value = dg1.Rows(i).Cells(8).Text
                Next
                Dim X1 As String = txtbno.Text
                Dim Rlst As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(X1, "\d+")
                ws.Cell(7, 3).Value = Rlst.Value
                If txtsname.Text <> "" Then
                    ws.Cell(8, 3).Value = txtcname.Text & "  [SITE: " & txtsname.Text & "]"
                Else
                    ws.Cell(8, 3).Value = txtcname.Text
                End If
                ws.Cell(9, 1).Value = "ADDRESS:-"
                ws.Cell(9, 3).Value = txtaddr.Text
                ws.Range("c10", "d10").Merge()
                ws.Range("c10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                ws.Cell(10, 3).Value = txtvno.Text
                ws.Range("i56").Value = "For, B & R ELECTRICAL WORKS"
                ws.Range("i56", "k56").Merge()
                ws.Range("i56").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                range = ws.Range("a53", "k56")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range("a1", "k1").Merge()
                ws.Range("a1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a1").Value = "CHALLAN"
                ws.Range("a1").Style.Font.Underline = XLFontUnderlineValues.Single
                ws.Row(32).Height = 3
                ws.Range("a3", "k3").Merge()
                ws.Range("a3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a3").Value = "STALL NO. T/542, NEAR DOOARS BUS STAND, BIDHAN MARKET, SILIGURI - 734001"
                ws.Range("a4", "k4").Merge()
                ws.Range("a4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a4").Value = "0353 - 2433269, 2526285"
                ws.Range("a5", "k5").Merge()
                ws.Range("a5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a5").Value = "VAT NO: " & "19896290025" & ", CST NO: " & "19896290219" & ", PAN NO: " & "AACFB7969H" & ", S.TAX NO: " & "AACFB7969HST001"

                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;filename=CHALLAN.xlsx")
                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(Response.OutputStream)
                    Response.Flush()
                    Response.[End]()
                End Using
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
                NEW_BILL.Text = "New Bill"
                DV.RowFilter = "bill_no='" & txtbno.Text & "'"
                dg1.DataBind()
                DG2.DataBind()
            Else

                Dim wb As XLWorkbook = New XLWorkbook
                Dim ws = wb.Worksheets.Add("CHALLAN")
                ws.Column(1).Width = 5.43
                ws.Column(2).Width = 6
                ws.Column(3).Width = 6.29
                ws.Column(4).Width = 8.43
                ws.Column(5).Width = 8.43
                ws.Column(6).Width = 17.57
                ws.Column(7).Width = 3
                ws.Column(8).Width = 7.29
                ws.Column(9).Width = 9.5
                ws.Column(10).Width = 7.43
                ws.Column(11).Width = 10.86
                ws.Range("a2", "k2").Merge()
                ws.Range("a2").Value = "B. & R. ELECTRICAL WORKS"
                ws.Range("a2").Style.Font.FontName = "Book Antiqua"
                ws.Range("a2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                ws.Range("a2").Style.Font.FontSize = 24
                ws.Range("a2").Style.Font.Bold = True
                Dim range As ClosedXML.Excel.IXLRange
                range = ws.Range("a1", "k5")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Row(6).Height = 3
                ws.Cell(7, 1).Value = "CHALLAN NO:-"
                ws.Cell(7, 10).Value = "DATE:-"
                ws.Cell(7, 11).Value = txtbdate.Text
                ws.Range("K7").Style.NumberFormat.SetFormat("dd-MMM-yyyy")
                ws.Cell(8, 1).Value = "CUSTOMER:-"
                ws.Cell(10, 1).Value = "VAT NO:-"
                range = ws.Range("a7", "k10")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Row(11).Height = 3
                ws.Cell(12, 1).Value = "SL NO"
                ws.Cell(12, 2).Value = "PART NO"
                ws.Cell(12, 4).Value = "PARTICULARS"
                ws.Cell(12, 9).Value = "MRP"
                ws.Cell(12, 10).Value = "QTY"
                ws.Cell(12, 11).Value = "PER"
                range = ws.Range("a12", "k12")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("a12", "A24")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("d12", "H24")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("j12", "j24")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                range = ws.Range("k12", "k24")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range("i12", "i24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                ws.Range("j12", "j24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                ws.Range("k12", "k24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a13", "k24").Style.Font.FontSize = 9.5
                ws.Range("a27", "k27").Style.Font.Bold = True
                ws.Range("i24", "k24").Style.Font.Bold = True
                ws.Range("i13", "i24").Style.NumberFormat.SetFormat("#.00")
                ws.PageSetup.Margins.Left = 0.25
                ws.PageSetup.Margins.Right = 0.17
                ws.PageSetup.Margins.Top = 0.15
                ws.PageSetup.Margins.Bottom = 0.02
                ws.PageSetup.Margins.Header = 0.02
                ws.PageSetup.Margins.Footer = 0.02
                For i As Integer = 0 To dg1.Rows.Count - 1
                    ws.Cell(i + 13, 1).Value = i.ToString + 1
                    ws.Cell(i + 13, 2).Value = "'" & dg1.Rows(i).Cells(1).Text
                    ws.Cell(i + 13, 4).Value = dg1.Rows(i).Cells(2).Text
                    ws.Cell(i + 13, 9).Value = dg1.Rows(i).Cells(4).Text
                    ws.Cell(i + 13, 10).Value = dg1.Rows(i).Cells(3).Text
                    ws.Cell(i + 13, 11).Value = dg1.Rows(i).Cells(8).Text
                Next
                Dim X1 As String = txtbno.Text
                Dim Rlst As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(X1, "\d+")
                ws.Cell(7, 3).Value = Rlst.Value
                If txtsname.Text <> "" Then
                    ws.Cell(8, 3).Value = txtcname.Text & "  [SITE: " & txtsname.Text & "]"
                Else
                    ws.Cell(8, 3).Value = txtcname.Text
                End If
                ws.Cell(9, 1).Value = "ADDRESS:-"
                ws.Cell(9, 3).Value = txtaddr.Text
                ws.Range("c10", "d10").Merge()
                ws.Range("c10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                ws.Cell(10, 3).Value = txtvno.Text
                ws.Range("i27").Value = "For, B & R ELECTRICAL WORKS"
                ws.Range("i27", "k27").Merge()
                ws.Range("i27").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                range = ws.Range("a25", "k27")
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin
                ws.Range("a1", "k1").Merge()
                ws.Range("a1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a1").Value = "CHALLAN"
                ws.Range("a1").Style.Font.Underline = XLFontUnderlineValues.Single
                ws.Row(32).Height = 3
                ws.Range("a3", "k3").Merge()
                ws.Range("a3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a3").Value = "STALL NO. T/542, NEAR DOOARS BUS STAND, BIDHAN MARKET, SILIGURI - 734001"
                ws.Range("a4", "k4").Merge()
                ws.Range("a4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a4").Value = "0353 - 2433269, 2526285"
                ws.Range("a5", "k5").Merge()
                ws.Range("a5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a5").Value = "VAT NO: " & "19896290025" & ", CST NO: " & "19896290219" & ", PAN NO: " & "AACFB7969H" & ", S.TAX NO: " & "AACFB7969HST001"
                ws.Range("b13", "b24").Style.NumberFormat.SetFormat("@")
                ws.Cell(27, 1).Value = "Signature of Customer"
                ws.Range("a24").Style.Font.FontName = "Book Antiqua"
                ws.Range("a24").Style.Font.Bold = True
                ws.Range("a13", "a24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a41", "a52").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                ws.Range("a24").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left
                range = ws.Range("a1", "k27")
                ws.Cell(30, 1).Value = range
                ws.Row(35).Height = 3
                ws.Row(40).Height = 3
                ws.Range("a28", "k28").Style.Border.BottomBorder = XLBorderStyleValues.SlantDashDot
                ws.Row(28).Height = 20

                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;filename=CHALLAN" & Rlst.Value & ".XLSX")
                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(Response.OutputStream)
                    Response.Flush()
                    Response.[End]()
                End Using
                Call btnprintcnl_Click(sender, e)
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click
        popchallan.Show()
    End Sub

    Private Sub btnprintcnl_Click(sender As Object, e As EventArgs) Handles btnprintcnl.Click
        Call bilcan_Click(sender, e)
        popchallan.Hide()
    End Sub

    Protected Sub edtupdbtn_Click(sender As Object, e As EventArgs) Handles edtupdbtn.Click
        Try
            Dim lq1 As String = String.Empty
            Dim dv1 As New DataView(PURCHSE_tbl)
            dv1.RowFilter = "BID='" & txtrec.Text & "'"
            dv1(0)("parti") = txtptnameedt.Text
            dv1(0)("part_no") = txtptnoedt.Text
            dv1(0)("qty") = txtqtyedt.Text
            dv1(0)("mrp") = txtmrpedt.Text
            dv1(0)("sprice") = txtrateedt.Text
            dv1(0)("total") = txttotedt.Text
            dv1(0)("tax") = txttaxedt.Text
            dv1(0)("tval") = txttvaledt.Text
            dv1(0)("unit") = txtunitedt.Text
            dv1(0)("stot") = txtstotedt.Text
            dv1(0)("SSTA") = "MOD"
            dv1(0)("DPCODE") = "A1587"
            dv1(0)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
            DV.RowFilter = "bill_no='" & txtbno.Text & "'"
            dg1.DataBind()
            txtgtot.Text = Val(txtgtot.Text) + (Val(txtstotedt.Text) - Val(hgtot.Text))
            txtntval.Text = Val(txtgtot.Text) * Val(txttaxedt.Text) / 100
            txtntot.Text = Math.Round(Val(txtgtot.Text) + Val(txtntval.Text))
            txtround.Text = FormatNumber(Val(txtntot.Text) - (Val(txtgtot.Text) + Val(txtntval.Text)), 2)

            Dim dv2 As New DataView(stock_tbl, "", "part_no", DataViewRowState.CurrentRows)
            Dim index1 As Integer = dv2.Find(txtptnoedt.Text)
            If Not index1 = -1 Then
                Dim lq As String = dv2(index1)("qty").ToString
                dv2(index1)("qty") = Val(lq) - (Val(hqty.Text) + Val(txtqtyedt.Text))
                lq1 = dv2(index1)("qty").ToString
                dv2(index1)("total") = Val(lq1) * Val(dv2(index1)("mrp").ToString)
                dv2(index1)("stotal") = Val(lq1) * Val(dv2(index1)("sprice").ToString)
                dv2(index1)("SSTA") = "MOD"
                dv2(index1)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                For Each c As Control In pnlitmedt.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
            End If
            NEW_BILL.Text = "Save Bill"
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub calcedt_Click(sender As Object, e As EventArgs) Handles calcedt.Click
        Try
            txttvaledt.Text = Val(txtqtyedt.Text) * Val(txtrateedt.Text) * Val(txttaxedt.Text) / 100
            txtstotedt.Text = Val(txtqtyedt.Text) * Val(txtrateedt.Text)
            txttotedt.Text = Val(txtqtyedt.Text) * Val(txtmrpedt.Text)
            edtitmpop.Show()
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Private Sub edtdelbtn_Click(sender As Object, e As EventArgs) Handles edtdelbtn.Click
        Try
            Dim lq1 As String = String.Empty
            For i As Integer = 0 To PURCHSE_tbl.Rows.Count - 1
                If PURCHSE_tbl(i)("bid") = txtrec.Text Then
                    PURCHSE_tbl(i).Delete()
                    DV.RowFilter = "bill_no='" & txtbno.Text & "'"
                    dg1.DataBind()
                    txtgtot.Text = Val(txtgtot.Text) - Val(hgtot.Text)
                    txtntval.Text = Val(txtgtot.Text) * 14.5 / 100
                    txtntot.Text = Format(Val(txtgtot.Text) + Val(txtntval.Text), "fixed")
                    txtround.Text = FormatNumber(Val(txtntot.Text) - (Val(txtgtot.Text) + Val(txtntval.Text)), 2)
                    Dim dv2 As New DataView(stock_tbl, "", "part_no", DataViewRowState.CurrentRows)
                    Dim index1 As Integer = dv2.Find(txtptnoedt.Text)
                    If Not index1 = -1 Then
                        Dim lq As String = dv2(index1)("qty").ToString
                        dv2(index1)("qty") = Val(lq) - Val(hqty.Text)
                        lq1 = dv2(index1)("qty").ToString
                        dv2(index1)("total") = Val(lq1) * Val(dv2(index1)("mrp").ToString)
                        dv2(index1)("stotal") = Val(lq1) * Val(dv2(index1)("sprice").ToString)
                        dv2(index1)("SSTA") = "MOD"
                        dv2(index1)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    End If
                    For Each c As Control In pnlitmedt.Controls
                        If TypeOf c Is TextBox Then
                            CType(c, TextBox).Text = ""
                        End If
                    Next
                    NEW_BILL.Text = "Save Bill"
                    Exit For
                End If
            Next
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub bilcan_Click(sender As Object, e As EventArgs) Handles bilcan.Click
        Try
            PURCHSE_tbl.RejectChanges()
            PURCHSE1_tbl.RejectChanges()
            stock_tbl.RejectChanges()
            For Each c As Control In pnlAddEdit.Controls
                If TypeOf c Is TextBox Then
                    CType(c, TextBox).Text = ""
                End If
            Next
            For Each c As Control In pnlAddEdit.Controls
                If TypeOf c Is ComboBox Then
                    CType(c, ComboBox).SelectedValue = Nothing
                End If
            Next
            DV.RowFilter = "bill_no='" & txtbno.Text & "'"
            dg1.DataBind()
            NEW_BILL.Text = "New Bill"
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub

    Protected Sub Del_bill_Click(sender As Object, e As EventArgs) Handles Del_bill.Click
        Try
            If bid.Text <> "" Then
                Dim lq1 As String = String.Empty
                For i As Integer = 0 To dg1.Rows.Count - 1
                    Dim dv1 As New DataView(stock_tbl, "", "part_no", DataViewRowState.CurrentRows)
                    Dim index1 As Integer = dv1.Find(dg1.Rows(i).Cells(0).Text)
                    If Not index1 = -1 Then
                        Dim lq As String = dv1(index1)("qty").ToString
                        dv1(index1)("qty") = Val(lq) - Val(dg1.Rows(i).Cells(2).Text)
                        lq1 = dv1(index1)("qty").ToString
                        dv1(index1)("total") = Val(lq1) * Val(dv1(index1)(3).ToString)
                        dv1(index1)("stotal") = Val(lq1) * Val(dv1(index1)(4).ToString)
                        dv1(index1)("SSTA") = "MOD"
                        dv1(index1)("LMODI") = Format(Now, "ddMMyyyyhhmmssfff") & "A1587"
                    End If
                Next

                For y As Integer = 0 To PURCHSE_tbl.Rows.Count - 1
                    Dim dv2 As New DataView(PURCHSE_tbl, "", "Bill_no", DataViewRowState.CurrentRows)
                    Dim index1 As Integer = dv2.Find(txtbno.Text)
                    If Not index1 = -1 Then
                        dv2(index1).Delete()
                    End If
                Next
            End If

            Dim dv3 As New DataView(PURCHSE1_tbl, "", "bid", DataViewRowState.CurrentRows)
            Dim index As Integer = dv3.Find(bid.Text)
            If index = -1 Then
                err_display("Something Went Wrong, Please Contact to The Developer!")
                Exit Sub
            Else
                dv3(index).Delete()
                Dim DV4 As New DataView(PURCHSE1_tbl)
                DV4.RowFilter = "cust = '" & txtcname.Text & "'"
                For i As Integer = 0 To DV4.Count - 1
                    Dim tot As String
                    Dim btot As String = DV4(i)("ntot") & ""
                    Dim ptot As String = DV4(i)("payment") & ""
                    If i = 0 Then
                        tot = "0"
                    Else
                        tot = dv3(i - 1)("total") & ""
                    End If
                    DV4(i)("total") = Val(tot) + (Val(btot) - Val(ptot))
                Next
                stock_adapter.Update(stock_tbl)
                stock_tbl.AcceptChanges()
                stock_tbl.Clear()
                stock_adapter.Fill(stock_tbl)
                PURCHSE_adapter.Update(PURCHSE_tbl)
                PURCHSE_tbl.AcceptChanges()
                PURCHSE_tbl.Clear()
                PURCHSE_adapter.Fill(PURCHSE_tbl)
                PURCHSE1_adapter.Update(PURCHSE1_tbl)
                PURCHSE1_tbl.AcceptChanges()
                PURCHSE1_tbl.Clear()
                PURCHSE1_adapter.Fill(PURCHSE1_tbl)
                NEW_BILL.Text = "New Bill"
                DG2.DataBind()
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is TextBox Then
                        CType(c, TextBox).Text = ""
                    End If
                Next
                For Each c As Control In pnlAddEdit.Controls
                    If TypeOf c Is ComboBox Then
                        CType(c, ComboBox).SelectedValue = Nothing
                    End If
                Next
            End If
        Catch ex As Exception
            err_display(ex.ToString)
        End Try
    End Sub
End Class