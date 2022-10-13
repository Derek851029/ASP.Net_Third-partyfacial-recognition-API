<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/menu.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="js/menu.js"></script>
</head>
<body>
    <nav class="navbar-inverse navbar-static-top" role="navigation">
        <div class="container-fluid">
            <div class="collapse navbar-collapse bs-example-js-navbar-collapse">
                <ul id="menu" class="nav navbar-nav"></ul>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
