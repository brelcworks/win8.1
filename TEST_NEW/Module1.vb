Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Data.OleDb
Imports LiteDB
Module Module1
    Public sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
    Public OLEDBCON As New OleDbConnection(ConfigurationManager.ConnectionStrings("OLEDbConnection").ConnectionString)
    Public SQLCE As New SqlCeConnection(ConfigurationManager.ConnectionStrings("SQLCE").ConnectionString)
    Public mainpop_adapter As New SqlCeDataAdapter("select * from MAINPOPU order by doc DESC", SQLCE)
    Public pmr_adapter As New SqlCeDataAdapter("SELECT * FROM PMR ORDER BY cdati", SQLCE)
    Public sheet1_adapter As New SqlCeDataAdapter("select * from sheet1 order by parti, grop, cate", SQLCE)
    Public stock_adapter As New SqlCeDataAdapter("select * from table1 order by parti, grop, type", SQLCE)
    Public BILL_adapter As New SqlCeDataAdapter("select * from BILL order BY BILLID", SQLCE)
    Public BILL1_adapter As New SqlCeDataAdapter("select * from BILL1 order BY BID", SQLCE)
    Public CUSTOMER_adapter As New SqlCeDataAdapter("select * from CUSTOMER order BY CID", SQLCE)
    Public PURCHSE_adapter As New SqlCeDataAdapter("select * from PURCHSE order BY BILLID", SQLCE)
    Public PURCHSE1_adapter As New SqlCeDataAdapter("select * from PURCHSE1 order BY BID", SQLCE)
    Public mainpop_builder As New SqlCeCommandBuilder(mainpop_adapter)
    Public pmr_builder As New SqlCeCommandBuilder(pmr_adapter)
    Public sheet1_builder As New SqlCeCommandBuilder(sheet1_adapter)
    Public stock_builder As New SqlCeCommandBuilder(stock_adapter)
    Public BILL_builder As New SqlCeCommandBuilder(BILL_adapter)
    Public BILL1_builder As New SqlCeCommandBuilder(BILL1_adapter)
    Public CUSTOMER_builder As New SqlCeCommandBuilder(CUSTOMER_adapter)
    Public PURCHSE_builder As New SqlCeCommandBuilder(PURCHSE_adapter)
    Public PURCHSE1_builder As New SqlCeCommandBuilder(PURCHSE1_adapter)
    Public mainpop_tbl As New DataTable
    Public pmr_tbl As New DataTable
    Public sheet1_tbl As New DataTable
    Public stock_tbl As New DataTable
    Public BILL_tbl As New DataTable
    Public BILL1_tbl As New DataTable
    Public CUSTOMER_tbl As New DataTable
    Public PURCHSE_tbl As New DataTable
    Public PURCHSE1_tbl As New DataTable

    Public mainpop_tbl_M As New DataTable
    Public pmr_tbl_M As New DataTable
    Public sheet1_tbl_M As New DataTable
    Public stock_tbl_M As New DataTable
    Public BILL_tbl_M As New DataTable
    Public BILL1_tbl_M As New DataTable
    Public CUSTOMER_tbl_M As New DataTable
    Public PURCHSE_tbl_M As New DataTable
    Public PURCHSE1_tbl_M As New DataTable

    Public Sub CREATEPMRTBL()


    End Sub
    Public Sub CREATEBILLTBL()
        BILL_tbl_M.Columns.Add("BILLID", GetType(Integer))
        BILL_tbl_M.Columns.Add("BID", GetType(String))
        BILL_tbl_M.Columns.Add("_id", GetType(Integer))
        BILL_tbl_M.Columns.Add("BILL_NO", GetType(String))
        BILL_tbl_M.Columns.Add("BDATE", GetType(DateTime))
        BILL_tbl_M.Columns.Add("DNAME", GetType(String))
        BILL_tbl_M.Columns.Add("CUST", GetType(String))
        BILL_tbl_M.Columns.Add("PART_NO", GetType(String))
        BILL_tbl_M.Columns.Add("PARTI", GetType(String))
        BILL_tbl_M.Columns.Add("QTY", GetType(String))
        BILL_tbl_M.Columns.Add("MRP", GetType(String))
        BILL_tbl_M.Columns.Add("SPRICE", GetType(String))
        BILL_tbl_M.Columns.Add("TOTAL", GetType(String))
        BILL_tbl_M.Columns.Add("TAX", GetType(String))
        BILL_tbl_M.Columns.Add("TVAL", GetType(String))
        BILL_tbl_M.Columns.Add("STOT", GetType(String))
        BILL_tbl_M.Columns.Add("CMP", GetType(String))
        BILL_tbl_M.Columns.Add("UNIT", GetType(String))
        BILL_tbl_M.Columns.Add("USER1", GetType(String))
        BILL_tbl_M.Columns.Add("SSTA", GetType(String))
        BILL_tbl_M.Columns.Add("MODE", GetType(String))
        BILL_tbl_M.Columns.Add("DPCODE", GetType(String))
        BILL_tbl_M.Columns.Add("LMODI", GetType(String))
        BILL_tbl_M.Columns.Add("AEDT", GetType(String))
    End Sub
End Module
