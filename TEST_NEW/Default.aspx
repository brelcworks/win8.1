<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="TEST_NEW._Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS</title>
    <link href="content/bootstrap.min.css" rel="stylesheet">
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
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
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <img src="http://p1.pichost.me/i/66/1910819.jpg"
        style="width: 100%; height: 100%; position: absolute; top: 0; left: 0; z-index: -5000;">
</body>
</html>