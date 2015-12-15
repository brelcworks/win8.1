Imports System.Data.SqlClient
Imports System.Data.SqlServerCe
Imports System.Data.OleDb
Module Module1
    Public sqlcon As New SqlConnection(ConfigurationManager.ConnectionStrings("APPHARBOR").ConnectionString)
    Public OLEDBCON As New OleDbConnection(ConfigurationManager.ConnectionStrings("OLEDbConnection").ConnectionString)
    Public SQLCE As New SqlCeConnection(ConfigurationManager.ConnectionStrings("SQLCE").ConnectionString)
    Public mainpop_adapter As New SqlDataAdapter("select * from MAINPOPU", sqlcon)
    Public pmr_adapter As New SqlDataAdapter("SELECT * FROM PMR ORDER BY cdati", sqlcon)
    Public sheet1_adapter As New SqlDataAdapter("select * from sheet1 order by parti, grop, cate", sqlcon)
    Public stock_adapter As New SqlDataAdapter("select * from table1 order by parti, grop, type", sqlcon)
    Public BILL_adapter As New SqlDataAdapter("select * from BILL order BY BILLID", sqlcon)
    Public BILL1_adapter As New SqlDataAdapter("select * from BILL1 order BY BID", sqlcon)
    Public CUSTOMER_adapter As New SqlDataAdapter("select * from CUSTOMER order BY CID", sqlcon)
    Public PURCHSE_adapter As New SqlDataAdapter("select * from PURCHSE order BY BILLID", sqlcon)
    Public PURCHSE1_adapter As New SqlDataAdapter("select * from PURCHSE1 order BY BID", sqlcon)
    Public mainpop_builder As New SqlCommandBuilder(mainpop_adapter)
    Public pmr_builder As New SqlCommandBuilder(pmr_adapter)
    Public sheet1_builder As New SqlCommandBuilder(sheet1_adapter)
    Public stock_builder As New SqlCommandBuilder(stock_adapter)
    Public BILL_builder As New SqlCommandBuilder(BILL_adapter)
    Public BILL1_builder As New SqlCommandBuilder(BILL1_adapter)
    Public CUSTOMER_builder As New SqlCommandBuilder(CUSTOMER_adapter)
    Public PURCHSE_builder As New SqlCommandBuilder(BILL_adapter)
    Public PURCHSE1_builder As New SqlCommandBuilder(BILL1_adapter)
    Public mainpop_tbl As New DataTable
    Public pmr_tbl As New DataTable
    Public sheet1_tbl As New DataTable
    Public stock_tbl As New DataTable
    Public BILL_tbl As New DataTable
    Public BILL1_tbl As New DataTable
    Public CUSTOMER_tbl As New DataTable
    Public PURCHSE_tbl As New DataTable
    Public PURCHSE1_tbl As New DataTable
End Module
