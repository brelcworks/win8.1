﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FLLIST.aspx.vb" Inherits="TEST_NEW.FLLIST" %>
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
    <script src="Scripts/jquery-2.2.0.js"></script>
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
   <asp:ToolkitScriptManager ID="tlsp2" runat="server"></asp:ToolkitScriptManager>
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
                <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: left; height: 540px; overflow: auto; border-style :double ;border-color :red ">
                    <asp:Panel ID="PNLSHOW" runat="server" CssClass="table-responsive" Style="background-color: #FFFFFF; border-color: aqua; border-style: double; text-align: left">
                        <asp:GridView ID="DG1" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped" HorizontalAlign="Center" RowStyle-Wrap="false" AllowSorting="True" HeaderStyle-BackColor="YellowGreen" HeaderStyle-HorizontalAlign="Center" Font-Size="Smaller" HeaderStyle-Wrap="false" OnSelectedIndexChanged ="DG1_SelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="FLNAME" HeaderText="FILE NAME" />
                                <asp:BoundField DataField="FLLOC" HeaderText="FILE LOCATION" />
                                <asp:BoundField DataField="FLSIZE" HeaderText="FILE SIZE" />
                                <asp:BoundField DataField="LMODI" HeaderText="LAST MODIFIED" />
                                <asp:ButtonField Text="SELECT" CommandName="Select" HeaderText ="DOWNLOAD" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
        <asp:Panel ID="err" runat="server" CssClass="modalPopup " Style="display: none">
                  <div class="header">
                    ERROR
                </div>
                 <asp:Label ID="errdisplay" runat ="server" />
                  <asp:Button ID="btnerrcls" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
             </asp:Panel> 
              <asp:ModalPopupExtender ID="errpopup" runat="server" OkControlID="btnerrcls" PopupControlID="err" TargetControlID="btnerr"></asp:ModalPopupExtender> 
        <BR />
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: left; border-style :double ;border-color :red ">
            <asp:Button ID="btnupd" runat ="server" Text ="UPLOAD FILES" CssClass ="btn btn-primary btn-xs " OnClick ="UploadFile"  />
             <asp:Button ID="btnerr" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
        </div>
    </form>
</body>
</html>
