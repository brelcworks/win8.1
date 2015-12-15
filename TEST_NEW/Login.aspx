<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="TEST_NEW.Login" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>B & R ELECTRICAL WORKS (LOGIN)</title>
    <link href="content/bootstrap.min.css" rel="stylesheet">
    <link rel="shortcut icon" href="~/DESIGN/favicon.ico" />
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
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
                    <li class="active"><a href="#">Home <span class="sr-only">(current)</span></a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Our Services <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">AC ALTERNATORS</a></li>
                            <li><a href="#">AC & DC MOTORS</a></li>
                            <li><a href="#">ACB & VCB's</a></li>
                            <li><a href="#">DIESEL GENERATOR</a></li>
                            <li><a href="#">HT & LT TRANSFORMER</a></li>
                            <li><a href="#">PANEL BOARDS</a></li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">About Us <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">OUR OFFICE</a></li>
                            <li><a href="#">OUR WORKSHOP</a></li>
                            <li><a href="#">ACB & VCB's</a></li>
                        </ul>
                    </li> 
                </ul>
                <div class="navbar-form navbar-right" role="search" >
                    <asp:TextBox ID="txtuname" runat ="server" CssClass ="form-control " />
                    <asp:TextBox ID="txtpass" runat ="server" CssClass ="form-control " />
                    <asp:Button ID="btnlogin" runat ="server" CssClass ="btn btn-primary " Text ="Sign In" />
                </div>
            </div>
        </div>
    </nav>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
