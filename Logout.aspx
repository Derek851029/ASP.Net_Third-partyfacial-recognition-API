<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="../js/recorder/index.js"></script>
    <script src="../js/recorder/cfrm_recorder.js"></script>
    <script src="../js/recorder/cfrm_recorder_config.js"></script>
    <script type="text/javascript">
        $(function () {
            setTimeout(Login, 1500);
            function Login() {
                window.location.href = "/Login.aspx";
            }
        });
    </script>
</head>
<body>
    <style>
        body {
            font-family: "Microsoft JhengHei",Helvetica,Arial,Verdana,sans-serif;
            font-size: 18px;
        }
    </style>
    <form id="form1" runat="server">
        <div class="container" style="width: 100%">
            <div class="alert alert-info" style="width: 100%">
                <div style="width: 100%; height: 500px;">
                    <h1 class="alert-heading" style="float: left;"><strong>提醒：</strong>帳號已登出</h1></div>
            </div>
        </div>
    </form>
</body>
</html>
