<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BILL.aspx.vb" Inherits="TEST_NEW.BILL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (INVOICE)</title>
    <link href="content/bootstrap.min.css" rel="stylesheet">
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <script src="Scripts/jquery-2.1.4.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border: 3px solid #0DA9D0;
            width: 100%;
            float: left;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                padding: 5px;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .button {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup td {
                text-align: left;
            }
 .left
    {
        float:left;
        width:600px;
        margin:0;
        padding:1em;
        border:2px double red;
    }
    .right
    {
        width:728px;
        margin-left:602px;
        padding:1em;
        border:2px double red;
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
                                <li><a href="PLAN.aspx">PM PLAN</a> </li>
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
                        <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="label label-warning " />
                    </div>
                </div>
            </div>
        </nav>
        <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="upd1" runat="server">
            <ContentTemplate>
                <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: left; height: 233px; overflow: auto">
                    <asp:Panel ID="pnlAddEdit" runat="server" CssClass="panel" BorderStyle="Double" BorderColor="#2FBDF1">
                        <div class="header" style="background-color: #2FBDF1; color: white; height: 30PX; line-height: 30PX; text-align: center; font-weight: bold">
                            Accounting & Inventory Details
                        </div>
                        <div class="table table-responsive ">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblbdate" runat="server" Text="Bill Date" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtbdate" runat="server" placeholder="Bill Date" />
                                        <asp:RadioButton ID="cash" runat="server" Text="CASH" />
                                        <asp:RadioButton ID="credit" runat="server" Text="CREDIT" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblptname" runat="server" Text="Product Name" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:ComboBox ID="txtptname" runat="server" Width="100%" AutoCompleteMode="SuggestAppend" AutoPostBack="true" OnSelectedIndexChanged="txtptname_SelectedIndexChanged" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblqty" runat="server" Text="QTY" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtqty" runat="server" placeholder="Item Quantity" AutoPostBack="True" Width="100%"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblbno" runat="server" Text="Bill No" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtbno" runat="server" placeholder="Bill No" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblptno" runat="server" Text="Part No" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:ComboBox ID="txtptno" runat="server" AutoCompleteMode="SuggestAppend" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lbltval" runat="server" Text="Tax Value" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txttval" runat="server" placeholder="Tax Value" Width="60%" />
                                        <asp:Button ID="BTNITMCALC" runat="server" Text="Calculate" CssClass="btn btn-info btn-xs" OnClick="BTNITMCALC_Click" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-success  btn-xs" OnClick="btnsave_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblcname" runat="server" Text="Customer Name" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:ComboBox ID="txtcname" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="True" Width="100%" OnSelectedIndexChanged="txtcname_SelectedIndexChanged" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblmrp" runat="server" Text="MRP" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtmrp" runat="server" placeholder="MRP" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblitot" runat="server" Text="Item Total" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtitot" runat="server" placeholder="Item Total" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbladdr" runat="server" Text="Address" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtaddr" runat="server" placeholder="Address" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblrate" runat="server" Text="Rate" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtrate" runat="server" placeholder="Rate" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblgtot" runat="server" Text="Grand Total" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtgtot" runat="server" placeholder="Grand Total" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblsname" runat="server" Text="Site Name" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:ComboBox ID="txtsname" runat="server" AutoCompleteMode="SuggestAppend" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblinstock" runat="server" Text="In Stock" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtinstock" runat="server" placeholder="In Stock" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lvlntval" runat="server" Text="Net Tax Value" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtntval" runat="server" placeholder="Net Tax Value" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblbal" runat="server" Text="Current Balance" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtbal" runat="server" placeholder="Current Balance" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lbltrate" runat="server" Text="Tax Rate" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txttrate" runat="server" placeholder="Tax Rate" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblround" runat="server" Text="Round Off" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtround" runat="server" placeholder="Round Off" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblvno" runat="server" Text="VAT / TIN No" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtvno" runat="server" placeholder="VAT / TIN No" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lbtunit" runat="server" Text="Unit" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtunit" runat="server" placeholder="Unit" Width="100%" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:Label ID="lblntot" runat="server" Text="Net Total" />
                                    </td>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <asp:TextBox ID="txtntot" runat="server" placeholder="Net Total" Width="100%" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <asp:TextBox ID="bid" runat="server" Visible="false" />
                            </table>
                        </div>
                    </asp:Panel>
                </div>

                <div style="width: 99%; margin-right: 1%; margin-left: 1%; text-align: left; height: 305px; overflow: auto; padding: 5px; margin: 5px">
                    <asp:Panel ID="pnldg" runat="server" CssClass="left">
                        <div class="header" style="background-color: #2FBDF1; color: white; height: 30PX; line-height: 30PX; text-align: center; font-weight: bold">
                            Invoice Summery
                        </div>
                        <asp:GridView ID="dg1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="BILLID, bid" RowStyle-Font-Size="Smaller" RowStyle-Wrap="false" HeaderStyle-Font-Size="Smaller">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30PX" HeaderText="Details">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit1" Text="Update" OnClick="Edit_itm" runat="server" CssClass="btn btn-primary  btn-xs "></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PART_NO" HeaderText="PART_NO" SortExpression="PART_NO" ItemStyle-Width="100px" />
                                <asp:BoundField DataField="PARTI" HeaderText="PARTI" SortExpression="PARTI" ItemStyle-Width="300px" />
                                <asp:BoundField DataField="QTY" HeaderText="QTY" SortExpression="QTY" ItemStyle-Width="40px" />
                                <asp:BoundField DataField="MRP" HeaderText="MRP" SortExpression="MRP" ItemStyle-Width="60px" />
                                <asp:BoundField DataField="SPRICE" HeaderText="SPRICE" SortExpression="SPRICE" ItemStyle-Width="100px" Visible="false" />
                                <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" ItemStyle-Width="65px" />
                                <asp:BoundField DataField="STOT" HeaderText="STOT" SortExpression="STOT" ItemStyle-Width="80px" Visible="false" />
                                <asp:BoundField DataField="UNIT" HeaderText="UNIT" SortExpression="UNIT" ItemStyle-Width="80px" />
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="YellowGreen" Font-Bold="True" ForeColor="Red"  />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" CssClass="right">
                        <div class="header" style="background-color: #2FBDF1; color: white; height: 30PX; line-height: 30PX; text-align: center; font-weight: bold">
                            Invoice Details
                        </div>
                        <asp:GridView ID="DG2" runat="server" AutoGenerateColumns="False" DataKeyNames="BID" CssClass="table table-hover table-striped" HorizontalAlign="Center" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor="YellowGreen" HeaderStyle-HorizontalAlign="Center" Font-Size="Smaller" HeaderStyle-Wrap="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="30PX" HeaderText="Details">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" Text="Details" OnClick="Edit" runat="server" CssClass="btn btn-primary  btn-xs " Width="60px"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="80px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BDATE" HeaderText="BILL DATE" SortExpression="BDATE" ItemStyle-Width="120px" DataFormatString="{0:dd-MMM-yyyy}" />
                                <asp:BoundField DataField="BNO" HeaderText="BILL NO" SortExpression="BNO" ItemStyle-Width="135px" />
                                <asp:BoundField DataField="CUST" HeaderText="CUSTOMER" SortExpression="CUST" ItemStyle-Width="180px" />
                                <asp:BoundField DataField="SNAME" HeaderText="SITE NAME" SortExpression="SNAME" ItemStyle-Width="220px" />
                                <asp:BoundField DataField="BAMT" HeaderText="AMOUNT" SortExpression="BAMT" ItemStyle-Width="100px" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="err" runat="server" CssClass="modalPopup " Style="display: none">
                        <div class="header">
                            ERROR
                        </div>
                        <asp:Label ID="errdisplay" runat="server" />
                        <asp:Button ID="btnerrcls" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
                    </asp:Panel>
                    <asp:Panel ID="pnlitmedt" runat="server" CssClass="modalPopup " Style="display: none; width: 800px; text-align: center">
                        <table class="table table-bordered table-hover table-responsive ">
                            <div class="header">
                                Details
                            </div>
                            <tr>
                                <td>
                                    <asp:Label ID="lblrec" runat="server" Text="Record ID" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtrec" runat="server" Enabled="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Part Name" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtptnameedt" runat="server" placeholder="Part Name" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Part No" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtptnoedt" runat="server" placeholder="Part No" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Mrp" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmrpedt" runat="server" placeholder="Mrp" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Qty" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtqtyedt" runat="server" placeholder="qty" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Tax Rate" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txttaxedt" runat="server" placeholder="Tax Rate" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Rate" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtrateedt" runat="server" placeholder="Rate" Style="width: 85%; margin: 0; padding: 0;" />
                                    <asp:Button ID="calcedt" runat="server" Text="Calculate" CssClass="btn btn-info btn-xs " />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Tax Value" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txttvaledt" runat="server" placeholder="Tax Value" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Gross Total" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtstotedt" runat="server" placeholder="Unit" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Total" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txttotedt" runat="server" placeholder="Total" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Unit" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtunitedt" runat="server" placeholder="Unit" Style="width: 100%; margin: 0; padding: 0;" />
                                </td>
                            </tr>
                            <asp:TextBox ID="hgtot" runat="server" Visible="false" />
                            <asp:TextBox ID="hqty" runat="server" Visible="false" />
                        </table>
                        <asp:Button ID="edtokbtn" runat="server" CssClass="btn btn-info btn-xs " Text="OK" />
                        <asp:Button ID="edtupdbtn" runat="server" CssClass="btn btn-success btn-xs " Text="UPDATE" />
                        <asp:Button ID="edtdelbtn" runat="server" CssClass="btn btn-danger btn-xs" Text="DELETE" />
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="errpopup" runat="server" OkControlID="btnerrcls" PopupControlID="err" TargetControlID="btnerr"></asp:ModalPopupExtender>
                    <asp:Button ID="btnerr" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
                    <asp:ModalPopupExtender ID="edtitmpop" runat="server" OkControlID="edtokbtn" PopupControlID="pnlitmedt" TargetControlID="edtitm"></asp:ModalPopupExtender>
                    <asp:Button ID="edtitm" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
                </div>
                <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; padding: 5px; margin: 5px">
                    <asp:Button ID="NEW_BILL" runat="server" CssClass="btn btn-success btn-xs " Text="New Bill" OnClick="NEW_BILL_Click" />
                    <asp:Button ID="Del_bill" runat="server" CssClass="btn btn-danger  btn-xs " Text="Delete Bill" OnClick="Del_bill_Click" />
                    <asp:Button ID="add_item" runat="server" CssClass="btn btn-info  btn-xs " Text="Add Item" OnClick="add_item_Click" />
                    <asp:Button ID="Print" runat="server" CssClass="btn btn-warning  btn-xs " Text="Print" OnClick="Print_Click" />
                    <asp:Button ID="bilcan" runat="server" CssClass="btn btn-primary  btn-xs " Text="Cancel Bill" OnClick="bilcan_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtcname" EventName="SelectedIndexChanged" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="NEW_BILL" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="add_item" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTNITMCALC" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtptname" EventName="SelectedIndexChanged" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Del_bill" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="bilcan" EventName="Click" />
            </Triggers>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Print" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
              <p style ="background-color :yellowgreen ; color :red ">
                  Please Wait! Update in Progress........
              </p>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center" class="table-responsive ">
            <asp:Panel ID="pnlprint" runat="server" CssClass="modalPopup " Style="display: none; width: 800px">
                <div class="header">
                    PRINT
                </div>
                <asp:Label ID="lblprint" runat="server" Text="Please Select a Action Below!" />
                <table class="table table-bordered table-hover table-responsive ">
                    <tr>
                        <td>
                            <asp:Button ID="challan" runat="server" CssClass="btn btn-success " Text="Print Challan" Style="width: 100%; margin: 0; padding: 0;" />
                        </td>
                        <td>
                            <asp:Button ID="bill" runat="server" CssClass="btn btn-success " Text="Print Invoice" Style="width: 100%; margin: 0; padding: 0;" />
                        </td>
                        <td>
                            <asp:Button ID="btnprintcnl" runat="server" CssClass="btn btn-danger " Text="Cancel" Style="width: 100%; margin: 0; padding: 0;" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" BackColor="LightCyan" BorderStyle="None" />
            </asp:Panel>
            <asp:ModalPopupExtender ID="popchallan" runat="server" OkControlID="Button1" PopupControlID="pnlprint" TargetControlID="Challan1"></asp:ModalPopupExtender>
        </div>
        <asp:Button ID="challan1" runat="server" Text="Challan" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
    </form>
</body>
</html>