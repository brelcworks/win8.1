<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="STOCK1.aspx.vb" Inherits="TEST_NEW.STOCK1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (STOCK MANAGEMENT)</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.2.0.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery.number.js"></script>
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
    .focus {
border: 2px solid red;
background-color: #FEFED5;
}  
</style>
</head>
<body style="background-color: lightcyan">
    <script type="text/javascript">
        $(function () {
            $('#<%=TXTPTNAME.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "STOCK1.aspx/GETPARTI",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });

        $(function () {
            $("#<%=TXTPTNAME.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    $(function (e1) {
                     var name = document.getElementById("<%=TXTPTNAME.ClientID %>").value;
                        $.ajax({
                            type: "POST",  
                            url: "STOCK1.aspx/gdata1",
                            data: "{ 'aData':'" + name + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json", 
                            success: function (data) {
                                $("#<%=TXTMRP.ClientID %>").val(data.d[0].MRP)
                                $("#<%=TXTGROP.ClientID %>").val(data.d[0].GROP)
                                $("#<%=TXTTYPE.ClientID %>").val(data.d[0].CATE)
                                $("#<%=TXTUNIT.ClientID %>").val(data.d[0].unit)
                                $("#<%=TXTTAX.ClientID %>").val(data.d[0].TRATE)
                                $("#<%=TXTPTNO.ClientID %>").val(data.d[0].PART_NO)
                                $("#<%=TXTPPRICE.ClientID %>").focus()
                                 var rmrp = parseFloat($("#<%=TXTMRP.ClientID %>").val())
                                var rtax = parseFloat($("#<%=TXTTAX.ClientID %>").val())+100
                                var rsprice = parseFloat(rmrp / rtax * 100)
                                $("#<%=TXTSPRICE.ClientID %>").val(rsprice)
                                $("#<%=TXTTVAL.ClientID %>").val(parseFloat(rsprice) * parseFloat($("#<%=TXTTAX.ClientID %>").val()) / 100)
                                $("#<%=TXTSPRICE.ClientID %>").number(true, 2);
                                $("#<%=TXTTVAL.ClientID %>").number(true, 2);
                            },
                            error: function OnErrorCall(response) {
                                alert(response.status + " " + response.responseText);
                            }
                        });
                    });
                }
            });
        });

         $(function () {
            $('#<%=TXTPTNO.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "STOCK1.aspx/GETPTNO",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
         });

         $(function () {
            $("#<%=TXTPTNO.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    $(function (e1) {
                     var name = document.getElementById("<%=TXTPTNO.ClientID %>").value;
                        $.ajax({
                            type: "POST",  
                            url: "STOCK1.aspx/gdata2",
                            data: "{ 'aData':'" + name + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json", 
                            success: function (data) {
                                $("#<%=TXTMRP.ClientID %>").val(data.d[0].MRP)
                                $("#<%=TXTGROP.ClientID %>").val(data.d[0].GROP)
                                $("#<%=TXTTYPE.ClientID %>").val(data.d[0].CATE)
                                $("#<%=TXTUNIT.ClientID %>").val(data.d[0].unit)
                                $("#<%=TXTTAX.ClientID %>").val(data.d[0].TRATE)
                                $("#<%=TXTPTNAME.ClientID %>").val(data.d[0].PARTI)
                                $("#<%=TXTPPRICE.ClientID %>").focus()
                                var rmrp = parseFloat($("#<%=TXTMRP.ClientID %>").val())
                                var rtax = parseFloat($("#<%=TXTTAX.ClientID %>").val())+100
                                var rsprice = parseFloat(rmrp / rtax * 100)
                                $("#<%=TXTSPRICE.ClientID %>").val(rsprice)
                                $("#<%=TXTTVAL.ClientID %>").val(parseFloat(rsprice) * parseFloat($("#<%=TXTTAX.ClientID %>").val()) / 100)
                                $("#<%=TXTSPRICE.ClientID %>").number(true, 2);
                                $("#<%=TXTTVAL.ClientID %>").number(true, 2);
                            },
                            error: function OnErrorCall(response) {
                                alert(response.status + " " + response.responseText);
                            }
                        });
                    });
                }
            });
         });

        $(document).ready(function () {
            $('INPUT[type="text"]').focus(function () {
                $(this).addClass("focus");
            });

            $('INPUT[type="text"]').blur(function () {
                $(this).removeClass("focus");
            });
        });

        $(function () {
            $("#<%=TXTQTY.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    var rmrp = $("#<%=TXTMRP.ClientID %>").val()
                    var rsprice = $("#<%=TXTSPRICE.ClientID %>").val()
                    $("#TXTTOT").val(parseFloat($("#<%=TXTQTY.ClientID %>").val()) * parseFloat(rmrp))
                    $("#TXTSTOT").val(parseFloat($("#<%=TXTQTY.ClientID %>").val()) * parseFloat(rsprice))
                    $("#TXTDPCODE").val("A1587")
                    $("#TXTRCNO").focus()
                    $("#TXTSTOT").number(true, 2);
                    $("#TXTUSER").val($("#<%=uname1.ClientID %>").text())
                }
            });
        });

         $(function () {
            $("#<%=TXTPPRICE.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    $("#TXTQTY").focus()
                }
            });
         });

        $(function () {
            $("#<%=TXTRCNO.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    $("#TXTEOR").focus()
                }
            });
        });

         $(function () {
            $("#<%=TXTEOR.ClientID %>").keypress(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSave').click();
                }
            });
        });
        btnSave
    </script>
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
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; height: 565px; overflow: auto">

            <p>
                STOCK MANAGEMENT
            </p>
            <asp:HiddenField ID="hfCustomerId" runat="server" />
            <asp:GridView ID="DG1" runat="server" AutoGenerateColumns="False" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="RID1" CssClass="table table-hover table-responsive " RowStyle-Wrap="false" Font-Size="Smaller" HeaderStyle-Wrap="false">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30PX" HeaderText="Details">
                        <ItemTemplate>
                            <asp:LinkButton ID="LNKDTLS" Text="Details" OnClick="DTLS" runat="server" CssClass="btn btn-primary  btn-xs "></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RID1" HeaderText="RID1" InsertVisible="False" ReadOnly="True" SortExpression="RID1" Visible="false" />
                    <asp:BoundField DataField="RID" HeaderText="RID" SortExpression="RID" Visible="false" />
                    <asp:BoundField DataField="TYPE" HeaderText="ITEM TYPE" SortExpression="TYPE" />
                    <asp:BoundField DataField="PART_NO" HeaderText="PART_NO" SortExpression="PART_NO" />
                    <asp:BoundField DataField="PARTI" HeaderText="PART NAME" SortExpression="PARTI" />
                    <asp:BoundField DataField="MRP" HeaderText="MRP" SortExpression="MRP" />
                    <asp:BoundField DataField="QTY" HeaderText="QTY" SortExpression="QTY" />
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" Visible="false" />
                    <asp:BoundField DataField="RACKNO" HeaderText="RACKNO" SortExpression="RACKNO" />
                    <asp:BoundField DataField="TAX" HeaderText="TAX" SortExpression="TAX" Visible="false" />
                    <asp:BoundField DataField="TVAL" HeaderText="TVAL" SortExpression="TVAL" Visible="false" />
                    <asp:BoundField DataField="STOTAL" HeaderText="STOTAL" SortExpression="STOTAL" Visible="false" />
                    <asp:BoundField DataField="PPRICE" HeaderText="PURCHASE PRICE" SortExpression="PPRICE" />
                    <asp:BoundField DataField="UNIT" HeaderText="UNIT" SortExpression="UNIT" />
                    <asp:BoundField DataField="SPRICE" HeaderText="SELL PRICE" SortExpression="SPRICE" />
                    <asp:BoundField DataField="SSTA" HeaderText="SSTA" SortExpression="SSTA" Visible="false" />
                    <asp:BoundField DataField="EOR" HeaderText="EOR" SortExpression="EOR" />
                    <asp:BoundField DataField="DPCODE" HeaderText="DPCODE" SortExpression="DPCODE" Visible="false" />
                    <asp:BoundField DataField="lmodi" HeaderText="lmodi" SortExpression="lmodi" Visible="false" />
                    <asp:BoundField DataField="grop" HeaderText="ITEM GROUP" SortExpression="grop" />
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
                <asp:Label ID="errdisplay" runat="server" />
                <asp:Button ID="btnerrcls" CssClass="btn btn-danger btn-xs" runat="server" Text="Cancel" />
                <asp:Button ID="btnerr" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
            </asp:Panel>
            <asp:ModalPopupExtender ID="errpopup" runat="server" OkControlID="btnerrcls" PopupControlID="err" TargetControlID="btnerr"></asp:ModalPopupExtender>
            <asp:ModalPopupExtender ID="popup" runat="server" OkControlID="btnCancel" PopupControlID="pnlAddEdit" TargetControlID="btnAdd">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlAddEdit" runat="server" CssClass="table-responsive ui-front" Style="display: none; background-color: #FFFFFF; border-color: aqua; border-style: double; text-align: left">
                <div class="header" style="background-color: aqua; height: 30px; text-align: center; font-weight: bold; color: red">
                    Details
                </div>
                <table class="table table-bordered">
                    <tr>
                        <td>
                            <asp:Label ID="LBLRID" runat="server" Text="RECORD ID" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTRID" runat="server" PLACEHOLDER="RECORD ID" Width="100%" Enabled="false" />
                        </td>
                        <td>
                            <asp:Label ID="LBLSTOT" runat="server" Text="SELL TOTAL" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTSTOT" runat="server" PLACEHOLDER="SELL TOTAL" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                         <td>
                            <asp:Label ID="LBLPTNO" runat="server" Text="PART NO" />
                        </td>
                        <td>
                            <asp:TextBox  ID="TXTPTNO" runat="server" Width="100%" Placeholder="PART NO"/>
                        </td>
                        <td>
                            <asp:Label ID="LBLTVAL" runat="server" Text="TAX VALUE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTTVAL" runat="server" PLACEHOLDER="TAX VALUE" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                       <td>
                            <asp:Label ID="LBLPTNAME" runat="server" Text="PART NAME" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTPTNAME" runat="server" CssClass="textboxAuto" Width="100%" Placeholder="PART NAME"/>
                        </td>
                        <td>
                            <asp:Label ID="LBLTYPE" runat="server" Text="ITEM TYPE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTTYPE" runat="server" PLACEHOLDER="ITEM TYPE" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLMRP" runat="server" Text="MRP" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTMRP" runat="server" PLACEHOLDER="TXTMRP" Width="100%" AutoPostBack="true" />
                        </td>
                        <td>
                            <asp:Label ID="LBLUNIT" runat="server" Text="UNIT" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTUNIT" runat="server" PLACEHOLDER="UNIT" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLTAX" runat="server" Text="ITEM TAX RATE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTTAX" runat="server" PLACEHOLDER="ITEM TAX RATE" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="LBLRCKNO" runat="server" Text="RACK NO" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTRCNO" runat="server" PLACEHOLDER="RACK NO" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLSPRICE" runat="server" Text="SELL PRICE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTSPRICE" runat="server" PLACEHOLDER="SELL PRICE" Width="70%" />
                            <asp:Button ID="BTNCACL" runat="server" Text="Calculate" CssClass="btn btn-info btn-xs" />
                        </td>

                        <td>
                            <asp:Label ID="LBLEOR" runat="server" Text="ITEM E.O.R" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTEOR" runat="server" PLACEHOLDER="ITEM E.O.R" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLPPRICE" runat="server" Text="PURCHASE PRICE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTPPRICE" runat="server" PLACEHOLDER="PURCHASE PRICE" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="LBLGROP" runat="server" Text="ITEM GROUP" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTGROP" runat="server" PLACEHOLDER="ITEM GROUP" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLQTY" runat="server" Text="QUANTITY" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTQTY" runat="server" PLACEHOLDER="QUANTITY" Width="100%"/>
                        </td>
                        <td>
                            <asp:Label ID="LBLDPCODE" runat="server" Text="DEALER CODE" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTDPCODE" runat="server" PLACEHOLDER="DEALER CODE" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LBLTOT" runat="server" Text="ITEM TOTAL" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTTOT" runat="server" PLACEHOLDER="ITEM TOTAL" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="LBLUSER" runat="server" Text="USER NAME" />
                        </td>
                        <td>
                            <asp:TextBox ID="TXTUSER" runat="server" PLACEHOLDER="USER NAME" Width="100%" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnCancel" CssClass="btn btn btn-danger btn-xs" runat="server" Text="Cancel" />
                <asp:Button ID="btncls" CssClass="btn btn-primary  btn-xs " runat="server" Text="Clear" />
                <asp:Button ID="btnSave" CssClass="btn btn-success btn-xs " runat="server" Text="Save" />
                <asp:Button ID="BTNDEL" CssClass="btn btn-warning btn-xs " runat="server" Text="Delete" />
                <asp:Button ID="nitem" runat="server" CssClass="btn btn-info btn-xs" Text="New Item" />
            </asp:Panel>

            <asp:Panel ID="pnlPLLIST" runat="server" CssClass="table-responsive" Style="display: none; background-color: #FFFFFF; border-color: aqua; border-style: double; text-align: left">
                <div class="header" style="background-color: aqua; height: 30px; text-align: center; font-weight: bold; color: red">
                    Details
                </div>
                <table class="table table-bordered">
                    <tr>
                        <td>
                            <asp:Label ID="PLRIDLBL" runat="server" Text="RECORD ID" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLRIDTXT" runat="server" PLACEHOLDER="RECORD NO" Enabled="false" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="PLGROPLBL" runat="server" Text="ITEM GROUP" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLGROPTXT" runat="server" PLACEHOLDER="ITEM GROUP" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PLPTNNAMELBL" runat="server" Text="PART NAME" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLPTNAMETXT" runat="server" PLACEHOLDER="PART NAME" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="PLTYPELBL" runat="server" Text="ITEM TYPE" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLTYPETXT" runat="server" PLACEHOLDER="ITEM TYPE" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PLPTNOLBL" runat="server" Text="PART NO" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLPTNOTXT" runat="server" PLACEHOLDER="PART NO" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="PLTRATELBL" runat="server" Text="ITEM TAX RATE" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLTRATETXT" runat="server" PLACEHOLDER="ITEM TAX RATE" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="PLMRPLBL" runat="server" Text="MRP" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLMRPTXT" runat="server" PLACEHOLDER="MRP" Width="100%" />
                        </td>
                        <td>
                            <asp:Label ID="PLUNITLBL" runat="server" Text="UNIT" />
                        </td>
                        <td>
                            <asp:TextBox ID="PLUNITTXT" runat="server" PLACEHOLDER="UNIT" Width="100%" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" CssClass="btn btn btn-danger btn-xs" runat="server" Text="Cancel" />
                <asp:Button ID="Button2" CssClass="btn btn-primary  btn-xs " runat="server" Text="Clear" />
                <asp:Button ID="PLLISTSAVE" CssClass="btn btn-success btn-xs " runat="server" Text="Save" />
            </asp:Panel>
            <asp:ModalPopupExtender ID="POPUP1" runat="server" OkControlID="Button1" PopupControlID="pnlPLLIST" TargetControlID="nitem">
            </asp:ModalPopupExtender>
        </div>
        <div style="width: 96%; margin-right: 2%; margin-left: 2%; text-align: center">
            <asp:Button ID="btnAdd" runat="server" Text="Add New Record" CssClass="btn  btn-success  btn-xs" />
            <asp:Button ID="btnexport" runat="server" Text="Export" CssClass="btn btn-info btn-xs" />
            <asp:Button ID="BTNPLIST" runat="server" BackColor="LightCyan" BorderStyle="None" CssClass="btn btn-warning btn-xs" />
        </div>
        <asp:ToolkitScriptManager ID="tlsp2" runat="server" EnablePageMethods="true"></asp:ToolkitScriptManager>
    </form>
</body>
</html>
