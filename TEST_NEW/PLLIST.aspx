<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PLLIST.aspx.vb" Inherits="TEST_NEW.PLLIST" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (PRICE LIST)</title>
    <link href="content/bootstrap.min.css" rel="stylesheet">
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 1200px;
        border: 3px solid #0DA9D0;
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        padding:5px
    }
    .modalPopup .footer
    {
        padding: 3px;
    }
    .modalPopup .button
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
    .modalPopup td
    {
        text-align:left;
    }   
</style>
</head>
<body style ="background-color:lightcyan ">
    <form id="form1" runat="server">
   <nav class="navbar navbar-inverse">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>

            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li class="active"><a href="main.aspx">Home <span class="sr-only">(current)</span></a></li>
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Services <span class="caret"></span></a>
                         <ul class="dropdown-menu">
                            <li><a href="POP.aspx">POPULATION</a></li>
                            <li><a href="pmr.aspx">PM / COMPLAINT</a></li>
                            <li><a href="Rmtracker.aspx">R & M TRACKER</a></li>
                            <li><a href ="PLAN.aspx">PM PLAN</a> </li>
                        </ul>
                    </li>
                     <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Inventory<span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="PLLIST.ASPX">PRICE LIST</a></li>
                            <li><a href="STOCK1.aspx">STOCK LIST</a></li>
                        </ul>
                    </li> 
                    <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Accounting<span class="caret"></span></a>
                             <ul class="dropdown-menu">
                                <li><a href="bill.aspx">SALES</a></li>
                                <li><a href="bill_pur.aspx">PURCHASE</a></li>
                                 <li><a href="slreport.aspx">SALES REPORT</a></li>
                            </ul>
                        </li>
                </ul>
                <div class=" navbar-form navbar-right" role="status">
                        <asp:Label ID="uname1" runat="server" CssClass="label label-success" />
                        <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass ="label label-warning "/>
                    </div>
            </div>
        </div>
    </nav>
          <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; height :565px; overflow :auto ">
              <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
            <p>
                PRICE LIST VIEW / ENTRY
            </p>
               <asp:GridView ID="DG1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="RID" CssClass ="table table-hover table-responsive " RowStyle-Wrap ="false" AllowSorting="True" Font-Size ="Smaller" HeaderStyle-Wrap ="false" >
                    <Columns>
                        <asp:BoundField DataField="RID" HeaderText="RID" InsertVisible="False" ReadOnly="True" SortExpression="RID" Visible ="false" />
                        <asp:BoundField DataField="PART_NO" HeaderText="PART_NO" SortExpression="PART_NO" />
                        <asp:BoundField DataField="PARTI" HeaderText="PART NAME" SortExpression="PARTI" />
                        <asp:BoundField DataField="MRP" HeaderText="MRP" SortExpression="MRP" />
                        <asp:BoundField DataField="GROP" HeaderText="ITEM GROUP" SortExpression="GROP" />
                        <asp:BoundField DataField="CATE" HeaderText="CATEGORY" SortExpression="CATE" />
                        <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" SortExpression="DPCODE" Visible ="false"  />
                        <asp:BoundField DataField="lmodi" HeaderText="lmodi" SortExpression="lmodi" Visible ="false"  />
                        <asp:BoundField DataField="TRATE" HeaderText="TAX RATE" SortExpression="TRATE" />
                        <asp:BoundField DataField="rid1" HeaderText="rid1" SortExpression="rid1" Visible ="false"  />
                        <asp:BoundField DataField="unit" HeaderText="UNIT" SortExpression="unit" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                
               <asp:Panel ID="err" runat="server" CssClass="modalPopup " Style="display: none">
                  <div class="header">
                    ERROR
                </div>
                 <asp:Label ID="errdisplay" runat ="server" />
                  <asp:Button ID="btnerrcls" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
                  <asp:Button ID="btnerr" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
             </asp:Panel> 
              <asp:ModalPopupExtender ID="errpopup" runat="server" OkControlID="btnerrcls" PopupControlID="err" TargetControlID="btnerr"></asp:ModalPopupExtender> 
          </div>
        <div style="width: 96%; margin-right: 2%; margin-left: 2%; text-align: center">
            <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-info btn-xs" />
        </div>
    </form>
</body>
</html>
