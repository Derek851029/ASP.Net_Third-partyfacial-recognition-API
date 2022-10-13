<%@ Page Language="C#" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>LoginPage</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        localStorage.setItem('myName', 'admin')
        localStorage.setItem('myPassword', 'admin')
        
        function LoginPass() {
            $.ajax({
                type: 'POST',
                url: 'Login.aspx/PassLogin',
                contentType: 'application/json;charset=utf-8',
                data: JSON.stringify({
                    Acc: $('#tAcc').val(),
                    Pwd: $('#tPwd').val()
                }),
                dataType: 'json',
                cache: false, //避免一直抓到舊的資料
                success: function (data) {
                    var json = JSON.parse(data.d);
                    if (json.status = 'true') {
                        //TODO 更改登入頁面
                        window.location.href = "ContextReads.aspx"
                        //window.location.href ="0010010011.aspx"
                        //window.location.href ="Chat.aspx"
                    }
                }
            })
        }
    </script>
    <style>
        body {
            margin-top: 10%;
            /*background:url(/images/background.jpg) center center;*/
            /*background-position: center center;*/
        }
        table , th, td{
            font-size:25px;
            width:20%;
            padding:5px;
            margin:auto;
            border:3px double #aaa;
        }
    </style>
</head>
<body>
    <%--<div class="container">
        <table>
            <tr>
                <th colspan="2">
                    <h2>CTI System Login</h2>
                </th>
            </tr>
            <tr>
                <th>Account</th>
                <td>
                    <input id="tAcc" type="text" class="form-control" value=""/>
                </td>
            </tr>
            <tr>
                <th>Password</th>
                <td>
                    <input id="tPwd" type="password" class="form-control" value=""/>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="text-align:center">
                    <button id="btnLogin" type="button" class="btn btn-success" onclick="LoginPass()">
                        <span>Login</span>
                    </button>
                </th>
            </tr>
        </table>
    </div>--%>

    <div class="container">
        <form id="form2" runat="server">
		    <table class="" style="background-color:white;width:70%;">
                <tr>
                    <th colspan="2" style="text-align:center;padding-top:20px;padding-bottom:20px;">
                        廣佑人臉辨識系統 
                    </th>
                </tr>
			    <tr>
				    <th style="text-align:center;"><h4><strong style="color:black;">帳號:</strong></h4></th>
				    <th>
					    <asp:TextBox ID="act" runat="server" MaxLength="50" class="form-control" placeholder="帳號" type="text" autocomplete="off" Style="font-size: 18px;"></asp:TextBox>
				    </th>
			    </tr>
			    <tr>
				    <th style="text-align:center;"><h4><strong style="color:black;">密碼:</strong></h4></th>
				    <th>
					    <asp:TextBox ID="pwd" runat="server" MaxLength="50" class="form-control" TextMode="Password" placeholder="密碼" Style="font-size: 18px;"></asp:TextBox>
				    </th>
			    </tr>
			    <tr>
				    <th colspan="2" style="text-align:center;">
					    <asp:Button ID="UserLogin" runat="server" Text="登入" Style="font-size: 18px; font-family: Microsoft JhengHei;" class="btn btn-info btn-lg" OnClick="UserLogin_Click" />&nbsp;&nbsp;&nbsp;
				    </th>
			    </tr>
		    </table>
        </form>
    </div>


</body>
</html>
