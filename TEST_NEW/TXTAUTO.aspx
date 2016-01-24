<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TXTAUTO.aspx.vb" Inherits="TEST_NEW.TXTAUTO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
    <link href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" rel="Stylesheet"/>
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" rel="Stylesheet"/>
    <script type ="text/javascript" >
        $(function () {
            $('#<%=TXTPTNAME.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "TXTAUTO.aspx/GETPARTI",
                        data: "{ 'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d,function(item)
                            {
                                return {value: item}
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>ENTER PART NAME:</td>
            <td>
                <div class="ui-widget" style ="text-align :left ">

                </div>
            </td>
        </tr>
    </table>
        <div class="ui-widget" style ="text-align :left ">
            <asp:TextBox ID="TXTPTNAME" runat ="server" CssClass ="textboxAuto" Width ="350px" Font-Size ="12px" />
        </div>
    </div>
    </form>
</body>
</html>
