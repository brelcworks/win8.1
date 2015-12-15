<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PLAN.aspx.vb" Inherits="TEST_NEW.PLAN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (PM PLAN)</title>
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
<body style ="background-color:lightcyan">
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
         <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; height :565px; overflow :auto ">
              <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
            <p>
                PM PLAN
            </p>
             <asp:GridView ID="DG1" runat="server" AutoGenerateColumns="False" DataKeyNames="RID" CssClass="table table-hover table-striped" Width="940px" HorizontalAlign="Center" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor ="YellowGreen" HeaderStyle-HorizontalAlign ="Center"  Font-Size ="Smaller" HeaderStyle-Wrap ="false">
                 <Columns >
                      <asp:BoundField DataField="RID" HeaderText="RID" InsertVisible="False" ReadOnly="True" SortExpression="RID" Visible ="false"  />
                    <asp:BoundField DataField="RID1" HeaderText="RID1" SortExpression="RID1" Visible ="false"  />
                    <asp:BoundField DataField="SID" HeaderText="SITE ID" SortExpression="SID" Visible ="false"  />
                    <asp:BoundField DataField="CNAME" HeaderText="CUSTOMER NAME" SortExpression="CNAME" />
                    <asp:BoundField DataField="SNAME" HeaderText="SITE NAME" SortExpression="SNAME"/>
                    <asp:BoundField DataField="ENS" HeaderText="ENGINE NO" SortExpression="ENS" />
                    <asp:BoundField DataField="ALSN" HeaderText="ALSN" SortExpression="ALSN" Visible ="false"  />
                    <asp:BoundField DataField="RAT_PH" HeaderText="RATING" SortExpression="RAT_PH" />
                    <asp:BoundField DataField="PHASE" HeaderText="PHASE" SortExpression="PHASE" />
                    <asp:BoundField DataField="MODEL" HeaderText="MODEL" SortExpression="MODEL" Visible ="false"  />
                    <asp:BoundField DataField="BSN" HeaderText="BSN" SortExpression="BSN" Visible ="false" />
                    <asp:BoundField DataField="CPN" HeaderText="CONTACT PERSON" SortExpression="CPN" />
                    <asp:BoundField DataField="PHNO" HeaderText="PHONE NO" SortExpression="PHNO" />
                    <asp:BoundField DataField="ADDR" HeaderText="ADDR" SortExpression="ADDR" Visible ="false" />
                    <asp:BoundField DataField="DOC" HeaderText="DT. OF COMM." SortExpression="DOC" DataFormatString ="{0:dd-MMM-yyyy}" Visible ="FALSE"/>
                    <asp:BoundField DataField="SPIN" HeaderText="SPIN" SortExpression="SPIN" Visible ="false" />
                    <asp:BoundField DataField="AMC" HeaderText="AMC STATUS" SortExpression="AMC" Visible ="false"  />
                    <asp:BoundField DataField="CHMR" HeaderText="HMR" SortExpression="CHMR" Visible ="false" />
                    <asp:BoundField DataField="CHMD" HeaderText="CHMD" SortExpression="CHMD" Visible ="false" />
                    <asp:BoundField DataField="lhmr" HeaderText="LAST SERVICE HMR" SortExpression="lhmr"   />
                    <asp:BoundField DataField="lsd" HeaderText="LAST SERVICE DATE" SortExpression="lsd" DataFormatString ="{0:dd-MMM-yyyy}"/>
                    <asp:BoundField DataField="nsd" HeaderText="NEXT SERVICE DATE" SortExpression="nsd" DataFormatString ="{0:dd-MMM-yyyy}" />
                    <asp:BoundField DataField="ahm" HeaderText="ahm" SortExpression="AVG. HMR"/>
                    <asp:BoundField DataField="DGNO" HeaderText="DGNO" SortExpression="DGNO" Visible ="false" />
                    <asp:BoundField DataField="ACTION" HeaderText="ACTION" SortExpression="ACTION" Visible ="false" />
                    <asp:BoundField DataField="DIST" HeaderText="DIST" SortExpression="DIST" Visible ="false" />
                    <asp:BoundField DataField="STATE" HeaderText="STATE" SortExpression="STATE" Visible ="false" />
                    <asp:BoundField DataField="AMAKE" HeaderText="AMAKE" SortExpression="AMAKE" Visible ="false" />
                    <asp:BoundField DataField="WARR" HeaderText="WARR" SortExpression="WARR" Visible ="false" />
                    <asp:BoundField DataField="OEA" HeaderText="OEA" SortExpression="OEA" Visible ="false" />
                    <asp:BoundField DataField="SSTA" HeaderText="SSTA" SortExpression="SSTA" Visible ="false" />
                    <asp:BoundField DataField="hmage" HeaderText="hmage" SortExpression="hmage" Visible ="false" />
                    <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" SortExpression="DPCODE" Visible ="false" />
                    <asp:BoundField DataField="lmodi" HeaderText="lmodi" SortExpression="lmodi" Visible ="false" />
                    <asp:BoundField DataField="AEDT" HeaderText="AEDT" SortExpression="AEDT" Visible ="false" />
                 </Columns>
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
