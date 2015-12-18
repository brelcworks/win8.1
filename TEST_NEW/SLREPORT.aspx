<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SLREPORT.aspx.vb" Inherits="TEST_NEW.SLREPORT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (SALES REPORT)</title>
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
<body>
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
                </ul>
                <div class=" navbar-form navbar-right" role="status">
                        <asp:Label ID="uname1" runat="server" CssClass="label label-success" />
                        <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass ="label label-warning "/>
                    </div>
            </div>
        </div>
    </nav>
         <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align:center ; height: 565px; overflow: auto" class ="table table-responsive ">
            <asp:GridView ID="DG1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="BILLID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="table table-hover table-striped" Width="940px" HorizontalAlign="Center" RowStyle-Wrap="false"  HeaderStyle-HorizontalAlign ="Center"  Font-Size ="Smaller" HeaderStyle-Wrap ="false">
                <Columns>
                    <asp:BoundField DataField="BILL_NO" HeaderText="BILL_NO" SortExpression="BILL_NO" />
                    <asp:BoundField DataField="BDATE" HeaderText="BILL DATE" SortExpression="BDATE" DataFormatString="{0:dd-MMM-yyyy}" />
                    <asp:BoundField DataField="DNAME" HeaderText="CUSTOMER" SortExpression="DNAME" ControlStyle-Width ="50PX"/>
                    <asp:BoundField DataField="CUST" HeaderText="SITE NAME" SortExpression="CUST" />
                    <asp:BoundField DataField="PART_NO" HeaderText="PART_NO" SortExpression="PART_NO" />
                    <asp:BoundField DataField="PARTI" HeaderText="PRODUCT NAME" SortExpression="PARTI" />
                    <asp:BoundField DataField="QTY" HeaderText="QTY" SortExpression="QTY" />
                    <asp:BoundField DataField="MRP" HeaderText="MRP" SortExpression="MRP" />
                    <asp:BoundField DataField="SPRICE" HeaderText="SELL PRICE" SortExpression="SPRICE" />
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" />
                    <asp:BoundField DataField="TAX" HeaderText="TAX %" SortExpression="TAX" />
                    <asp:BoundField DataField="TVAL" HeaderText="TAX VALUE" SortExpression="TVAL" Visible ="false"  />
                    <asp:BoundField DataField="STOT" HeaderText="SELL TOTAL" SortExpression="STOT" />
                    <asp:BoundField DataField="UNIT" HeaderText="UNIT" SortExpression="UNIT" />
                    <asp:BoundField DataField="BILLID" HeaderText="BILLID" InsertVisible="False" ReadOnly="True" SortExpression="BILLID" Visible ="false"  />
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
        </div>
         <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align:left  " class ="table table-responsive ">
             <asp:TextBox ID="DOS" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgPopup" ImageUrl="Design/calendar.png" ImageAlign="Bottom" runat="server" />
                            <asp:CalendarExtender ID="DOSCLNDR" runat="server" TargetControlID="DOS" PopupButtonID="imgPopup" Format="dd-MMM-yyyy hh:mm:ss tt"></asp:CalendarExtender>
             <asp:TextBox ID="cdati" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="Design/calendar.png" ImageAlign="Bottom" runat="server" />
                            <asp:CalendarExtender ID="CDATICLNDR" runat="server" TargetControlID="cdati" PopupButtonID="ImageButton1" Format="dd-MMM-yyyy hh:mm:ss tt"></asp:CalendarExtender>
             <asp:Button ID="FND" runat ="server" Text ="FIND" CssClass ="btn btn-primary btn-xs " />
             <asp:Button ID="btnerr" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
             <asp:Button ID="BILLADD" runat ="server" Text ="BILL ADD" />
         </div>
         <asp:Panel ID="err" runat="server" CssClass="modalPopup " Style="display: none">
                  <div class="header">
                    ERROR
                </div>
                 <asp:Label ID="errdisplay" runat ="server" />
                  <asp:Button ID="btnerrcls" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
             </asp:Panel> 
              <asp:ModalPopupExtender ID="errpopup" runat="server" OkControlID="btnerrcls" PopupControlID="err" TargetControlID="btnerr"></asp:ModalPopupExtender> 
    </form>
</body>
</html>
