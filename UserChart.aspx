<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserChart.aspx.cs" Inherits="UserChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="chart.js-3.4.1/package/dist/chart.min.js"></script>
</head>
<body>
    <div id="CharDiv">
        <canvas id="myChart"></canvas>
    </div>
</body>
</html>


<script>
    var labels = '<%=labels%>'.split(',');
    console.log(labels);
    var datas = '<%=datas%>'.split(',');
    console.log(datas);

    var data = [0, 10, 5, 2, 20, 30, 45];
    $(function () {
        
        const config = {
            type: 'line',
            data:{
                labels: labels,
                datasets: [{
                    label: 'My First dataset',
                    backgroundColor: 'rgb(255, 99, 132)',
                    borderColor: 'rgb(255, 99, 132)',
                    data: datas,
                }]
            },
            options: {}
        };
        var myChart = new Chart(
            document.getElementById('myChart'),
            config
        );

    });





</script>
