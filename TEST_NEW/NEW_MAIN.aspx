<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NEW_MAIN.aspx.vb" Inherits="TEST_NEW.NEW_MAIN" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS</title>
    <link href="content/bootstrap.min.css" rel="stylesheet">
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
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
        width:400px;
        margin:0;
        padding:1em;
    }
    .right
    {
        width:728px;
        margin-left:410px;
        padding:1em;
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
                    <li class="active"><a href="#">Home <span class="sr-only">(current)</span></a></li>
                </ul>
                <div class="navbar-form navbar-right" role="search" >
                    <asp:TextBox ID="txtuname" runat ="server" CssClass ="form-control " placeholder="User Name" />
                    <asp:TextBox ID="txtpass" TextMode ="Password"  runat ="server" CssClass ="form-control" placeholder="Password" />
                    <asp:Button ID="btnlogin" runat ="server" CssClass ="btn btn-primary " Text ="Sign In" />
                </div>
            </div>
        </div>
    </nav>
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; height: 200px; overflow: auto">
            <asp:Panel ID="pnlLOGO" runat="server" CssClass="left">
                <div class="col-md-4">
                    <img src="/DESIGN/BR.PNG"
                        style="position: absolute; left: 25PX; z-index: -5000; width: 100%; height: 160PX">
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" CssClass="right">
                    <h1 style="font-family:'Book Antiqua'">
                        B. & R. ELECTRICAL WORKS
                    </h1>
                    <h3>
                        AUTORIZED SERVICE CENTER OF K.E.C
                    </h3>
            </asp:Panel>
        </div>
        <div style="width: 98%; margin-right: 1%; margin-left: 1%; text-align: center; height: 600px; overflow: auto">

        </div>
    </form>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
