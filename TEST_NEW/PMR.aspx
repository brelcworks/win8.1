<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PMR.aspx.vb" Inherits="TEST_NEW.PMR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html >

<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (PMR)</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
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
<body style="background-color: lightcyan">

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
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Services <span class="caret"></span></a>
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
                                <li><a href="bill.ASPX">Sales</a></li>
                                <li><a href="bill_pur.ASPX">Purchase</a></li>
                                 <li><a href="slreport.ASPX">Sales Report</a></li>
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
        <div style="width: 96%; margin-right: 2%; margin-left: 2%; text-align: center; height: 565px; overflow: auto">
            <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
            <p>
                PMR - COMLAINTS VIEW / ENTRY   
            </p>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID1" CssClass="table table-hover table-striped" Width="940px" HorizontalAlign="Center" DataSourceID="SqlDataSource1" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor="YellowGreen" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" Font-Size="Smaller">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30PX" HeaderText="Details">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" Text="Details" OnClick="Edit" runat="server" CssClass="btn btn-info btn-xs "></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RECID1" HeaderText="RECID1" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CUST" HeaderText="CUSTOMER" HtmlEncode="true" SortExpression="CUST" />
                    <asp:BoundField DataField="SID" HeaderText="SITE ID" HtmlEncode="true" SortExpression="SID" />
                    <asp:BoundField DataField="SNAME" HeaderText="SITE NAME" HtmlEncode="true" SortExpression="SNAME" />
                    <asp:BoundField DataField="ENGINE_No" HeaderText="ENGINE_NO" HtmlEncode="true" SortExpression="ENGINE_No" />
                    <asp:BoundField DataField="KVA" HeaderText="KVA" HtmlEncode="true" />
                    <asp:BoundField DataField="DOS" HeaderText="DATE OF SERVICE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STYPE" HeaderText="SERVICE TYPE" HtmlEncode="true" SortExpression="STYPE" />
                    <asp:BoundField DataField="HMR" HeaderText="HMR" />
                    <asp:BoundField DataField="Report" HeaderText="Report No" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="Technician" HeaderText="Technician" HtmlEncode="true" SortExpression="Technician" Visible="false" />
                    <asp:BoundField DataField="METERIAL" HeaderText="METERIAL USED" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="recid" HeaderText="RECORD ID" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CDATI" HeaderText="CLOSURE DATE" HtmlEncode="true" DataFormatString="{0:dd-MMM-yyyy hh:mm:ss tt}" />
                    <asp:BoundField DataField="DIST" HeaderText="DISTRICT" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STATE" HeaderText="STATE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CCATE" HeaderText="COMPLAINT CATEGORY" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="MODEL" HeaderText="MODEL" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DOI" HeaderText="DATE OF COMM." Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DGNO" HeaderText="DG SET NO" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="AMAKE" HeaderText="ALT. MAKE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="ALSN" HeaderText="ALT. SN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="BSN" HeaderText="BATTERY SN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="CNAT" HeaderText="COMPLAINT NATURE" HtmlEncode="true" SortExpression="CNAT" />
                    <asp:BoundField DataField="SERV" HeaderText="SEVERITY" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="RFAIL" HeaderText="REASON OF FAILURE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="STA" HeaderText="STATUS" HtmlEncode="true" />
                    <asp:BoundField DataField="WARR" HeaderText="WARRANTY STATUS" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="ACTION" HeaderText="ACTION TAKEN" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="OEA" HeaderText="OEA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="AMC" HeaderText="AMC" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="TTR" HeaderText="TTR" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="SLA" HeaderText="SLA STATUS" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="TSLOT" HeaderText="TIME SLOT" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="RESLA" HeaderText="REASON OF SLA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="SSTA" HeaderText="SSTA" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" Visible="False" HtmlEncode="true" />
                    <asp:BoundField DataField="lmodi" HeaderText="lmodi" Visible="False" HtmlEncode="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [PMR] ORDER BY [DOS] DESC"></asp:SqlDataSource>



            <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup " Style="display: none">
                <div class="header">
                    Details
                </div>
                <table id="tblview" class="table table-bordered">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Record Id"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="recid1" Width="40px" MaxLength="5" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Customer"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cust" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="Category"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ccate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Engine No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Engine_no" runat="server"></asp:TextBox>
                            <asp:Button ID="FETENS" runat="server" Text="Fetch" CssClass="btn btn-info btn-xs" />
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="DT. Of Comm."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="doi" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Complaint Nature"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Cnat" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Site Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sname" runat="server"></asp:TextBox>
                            <asp:Button ID="fetsname" runat="server" Text="Fetch" CssClass="btn btn-info btn-xs" />
                        </td>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="Warranty Status"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="warr" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Severity"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="serv" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Site Id"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
                            <asp:Button ID="fetsid" runat="server" Text="Fetch" CssClass="btn btn-info  btn-xs" />
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Name of OEA"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="oea" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label19" runat="server" Text="Complaint Status"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sta" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="DG Set No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dgno" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="AMC Status"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="amc" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Reason of Failure"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="rfail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="KVA"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="kva" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text="DT. of service"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="DOS" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgPopup" ImageUrl="Design/calendar.png" ImageAlign="Bottom" runat="server" />
                            <asp:CalendarExtender ID="DOSCLNDR" runat="server" TargetControlID="DOS" PopupButtonID="imgPopup" Format="dd-MMM-yyyy hh:mm:ss tt"></asp:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label23" runat="server" Text="Action Taken"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="action" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Model No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="model" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Closure Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="cdati" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="Design/calendar.png" ImageAlign="Bottom" runat="server" />
                            <asp:CalendarExtender ID="CDATICLNDR" runat="server" TargetControlID="cdati" PopupButtonID="ImageButton1" Format="dd-MMM-yyyy hh:mm:ss tt"></asp:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="Report No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="reportNo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Alt. Make"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="amake" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text="HMR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="HMR" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label27" runat="server" Text="Technician"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="technician" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Alt. Sr. No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="alsn" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label28" runat="server" Text="Service Type"></asp:Label>
                        </td>
                        <td>

                            <asp:ComboBox ID="stype1" runat="server"></asp:ComboBox>
                        </td>
                        <td>
                            <asp:Label ID="Label29" runat="server" Text="SLA Status"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="sla" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Batt. Sr. No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="bsn" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server" Text="TTR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ttr" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                            <asp:Button ID="btncalc" runat="server" CssClass="btn btn-primary btn-xs " Text="Calculate" />
                        </td>
                        <td>
                            <asp:Label ID="Label31" runat="server" Text="SLA Reason"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="resla" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="District"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dist" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label32" runat="server" Text="Time Slot"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tslot" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label33" runat="server" Text="Dealer Code"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dpcode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label34" runat="server" Text="State"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="state" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label35" runat="server" Text="Meterial Used"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="meterial" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label36" runat="server" Text="Next Service Dt."></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label37" runat="server" Text="AVG. HMR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="ahm" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label38" runat="server" Text="HMR Ageing"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="hmage1" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label39" runat="server" Text="User Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uname2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
                <asp:Button ID="btnSave" CssClass="btn btn-success btn-xs" runat="server" Text="Save" />
                <asp:Button ID="btncls" CssClass="btn btn-info btn-xs" runat="server" Text="Clear" />
                <asp:Button ID="BTNDEL" CssClass="btn btn-warning btn-xs" runat="server" Text="Delete" />
            </asp:Panel>
            <asp:ModalPopupExtender ID="popup" runat="server" OkControlID="btnCancel" PopupControlID="pnlAddEdit" TargetControlID="btnAdd">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PNLSEAR" runat="server" CssClass="modalPopup " Style="display: none">
                <div class="header">
                    Search Result
                </div>
                <asp:Label ID="Label40" runat="server" CssClass="label label-info "></asp:Label>
                <asp:GridView ID="dg1" runat="server" AutoGenerateColumns="False" DataKeyNames="RECID1" CssClass="table table-hover table-striped" Width="940px" HorizontalAlign="Center" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor="YellowGreen" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Wrap="false" Font-Size="Smaller">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30PX" HeaderText="Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit1" Text="Details" OnClick="Edit1" runat="server" CssClass="btn btn-info btn-xs "></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="30px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RECID1" HeaderText="RECID1" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="CUST" HeaderText="CUSTOMER" HtmlEncode="true" SortExpression="CUST" />
                        <asp:BoundField DataField="SID" HeaderText="SITE ID" HtmlEncode="true" SortExpression="SID" />
                        <asp:BoundField DataField="SNAME" HeaderText="SITE NAME" HtmlEncode="true" SortExpression="SNAME" />
                        <asp:BoundField DataField="ENGINE_No" HeaderText="ENGINE_NO" HtmlEncode="true" SortExpression="ENGINE_No" />
                        <asp:BoundField DataField="KVA" HeaderText="KVA" HtmlEncode="true" />
                        <asp:BoundField DataField="DOS" HeaderText="DATE OF SERVICE" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="STYPE" HeaderText="SERVICE TYPE" HtmlEncode="true" SortExpression="STYPE" />
                        <asp:BoundField DataField="HMR" HeaderText="HMR" />
                        <asp:BoundField DataField="Report" HeaderText="Report No" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="Technician" HeaderText="Technician" HtmlEncode="true" SortExpression="Technician" />
                        <asp:BoundField DataField="METERIAL" HeaderText="METERIAL USED" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="recid" HeaderText="RECORD ID" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="CDATI" HeaderText="CLOSURE DATE" HtmlEncode="true" DataFormatString="{0:dd-MMM-yyyy hh:mm:ss tt}" />
                        <asp:BoundField DataField="DIST" HeaderText="DISTRICT" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="STATE" HeaderText="STATE" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="CCATE" HeaderText="COMPLAINT CATEGORY" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="MODEL" HeaderText="MODEL" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="DOI" HeaderText="DATE OF COMM." Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="DGNO" HeaderText="DG SET NO" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="AMAKE" HeaderText="ALT. MAKE" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="ALSN" HeaderText="ALT. SN" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="BSN" HeaderText="BATTERY SN" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="CNAT" HeaderText="COMPLAINT NATURE" HtmlEncode="true" SortExpression="CNAT" />
                        <asp:BoundField DataField="SERV" HeaderText="SEVERITY" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="RFAIL" HeaderText="REASON OF FAILURE" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="STA" HeaderText="STATUS" HtmlEncode="true" />
                        <asp:BoundField DataField="WARR" HeaderText="WARRANTY STATUS" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="ACTION" HeaderText="ACTION TAKEN" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="OEA" HeaderText="OEA" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="AMC" HeaderText="AMC" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="TTR" HeaderText="TTR" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="SLA" HeaderText="SLA STATUS" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="TSLOT" HeaderText="TIME SLOT" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="RESLA" HeaderText="REASON OF SLA" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="SSTA" HeaderText="SSTA" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" Visible="False" HtmlEncode="true" />
                        <asp:BoundField DataField="lmodi" HeaderText="lmodi" Visible="False" HtmlEncode="true" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="Button2" CssClass="btn btn btn-danger " runat="server" Text="OK" />
            </asp:Panel>
            <asp:ModalPopupExtender ID="popup2" runat="server" OkControlID="Button2" PopupControlID="PNLSEAR" TargetControlID="Btnfnddg">
            </asp:ModalPopupExtender>
        </div>
        <div style="width: 96%; margin-right: 2%; margin-left: 2%; text-align: center">
            <asp:TextBox ID="fnddg" runat="server" />
            <asp:LinkButton ID="lnkEdit2" Text="Find" OnClick="fndreco" runat="server" CssClass="btn btn-primary  btn-xs "></asp:LinkButton>
            <asp:Button ID="btnAdd" runat="server" Text="Add New Record" CssClass="btn btn-success  btn-xs" />
            <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-info btn-xs" />
            <asp:Button ID="Btnfnddg" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
</body>
</html>
