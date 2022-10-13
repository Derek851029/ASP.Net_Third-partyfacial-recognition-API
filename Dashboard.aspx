<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
<div class="content">
    <div class="page-breadcrumb">
        <div class="row align-items-center">
            <div class="col-6">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb mb-0 d-flex align-items-center">
                        <li class="breadcrumb-item">
                            <a href="Dashboard.aspx" class="link">
                                <i class="bi-house"></i>
                            </a>
                        </li>
                        <li class="breadcrumb-item active" aria-current="page">儀錶板</li>
                    </ol>
                </nav>
                <h1 class="mb-0 fw-bold">儀錶板</h1> 
            </div>
        </div>
            <div class="row">
                <div class="col">
                    <div id="main" style="width:800px;height:600px;"></div>
                </div>
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-md-flex">
                                <div>
                                    <h4 class="card-title">即時打卡紀錄(每五秒更新)</h4>
                                    <table id="table1" class="display table table-striped" style="text-align:center;width:100%">
                                        <thead>
                                            <tr>
                                                <th style="text-align:center;">人員編號</th>
                                                <th style="text-align:center;">人員姓名</th>
                                                <th style="text-align:center;">是否配戴口罩</th>
                                                <th style="text-align:center;">體溫</th>
                                                <th style="text-align:center;">狀態</th>
                                                <th style="text-align:center;">進出時間</th>
                                                <th style="text-align:center;">功能選單</th>
                                            </tr>
                                        </thead>
                                    </table>    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="col">
                    <nav aria-label="breadcrumb">
                    <ol class="breadcrumb mb-0 d-flex align-items-center">
                        <li class="breadcrumb-item active" style="color:blue;margin-right:30px">總進入次數:</li>
                        <li class="breadcrumb-item active" style="color:red">總離開次數:</li>
                    </ol>
                </nav>
                    <ul class="nav nav-tabs">
                        <li class="nav-item">
                            <button type="button" id="li_bt1" class="nav-link active">即時打卡紀錄</button>
                            <ul id="PunchHistroy" style="line-height:60px">
                            </ul>
                        </li>
                    </ul>
                </div>--%>
            </div>
    </div>
        
        
</div>
    <script src="js/echarts.min.js"></script>
    <script>
        $(function () {
            $('#dashboard').css({ "background-color": "#1a9bfc", "color": "white" })
            ClassCount()
            ListPunch()
            setInterval(ListPunch, 5000)
            Listener_event()
        })

        function Listener_event() {
            $('#Dashboard').addClass('nav_link active')
        }

        function ListPunch() {
            $.ajax({
                type: 'post',
                url: 'Dashboard.aspx/ListPunch',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({}),
                dataType: 'json',
                success: function (doc) {
                    var full_data = eval(doc.d)
                    /*console.log(full_data)*/
                    $('#table1').dataTable({
                        "searching": false,
                        "bLengthChange": false,
                        "bInfo": false,
                        responsive: true,
                        destroy: true,
                        data: full_data,
                        "oLanguage": {
                            "sLengthMenu": "顯示 _MENU_ 筆",
                            "sZeroRecords": "無資料",
                            "sInfo": "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
                            "sInfoFiltered": "(從 _MAX_ 項結果過濾)",
                            "sInfoPostFix": "",
                            "sSearch": "搜索:",
                            "sUrl": "",
                            "oPaginate": {
                                "sFirst": "首頁",
                                "sPrevious": "上頁",
                                "sNext": "下頁",
                                "sLast": "尾頁"
                            }
                        },
                        "aaSorting": [[5, 'desc']],
                        "aLengthMenu": [[10], [10]],
                        "iDisplayLength": 10,
                        "columnDefs": [{
                            "targets": -1,
                            "data": null,
                            "searchable": false,
                            "paging": false,
                            "info": false,
                        }],
                        columns: [
                            { "data": "Number" },
                            { "data": "Name" },
                            {
                                "data": "Mask", "render": function (data, type, full, meta) {
                                    var text;
                                    if (data == "no") {
                                        text = "否"
                                    }
                                    else {
                                        text = "是"
                                    }
                                    return text
                                }
                            },
                            { "data": "Temperature" },
                            {
                                "data": "Status", "render": function (data, type, full, meta) {
                                    var text
                                    if (data == "In") {
                                        text = "進入"
                                    }
                                    else {
                                        text = "離開"
                                    }
                                    return text
                                }
                            },
                            { "data": "Date" },
                            {
                                "data": "SYSID", "render": function (data, type, full, meta) {
                                    var bt;
                                    if (full.Name == "陌生人") {
                                        bt = ""
                                    }
                                    else {
                                        bt = '<button id="view_' + data + '" type="button" class="btn btn-outline-info btn-lg"><span class="glyphicon glyphicon-search">詳細資料</span></button>'
                                    }
                                    return bt
                                }
                            },
                        ]
                    });
                    $('#table1 tbody').unbind('click').
                        on('click', 'button[id^=view_]', function () {
                            var SYSID = $(this).attr('id').split('_')[1]

                            window.location.assign('http://192.168.2.14:7017/Users.aspx?seqno=' + SYSID+'');
                        })
                }
            });
        }

        function ClassCount() {
            var Today = new Date();
            var today_formate = Today.getFullYear() + '-' + (Today.getMonth() + 1) + '-' + Today.getDate()

            $.ajax({
                url: 'Dashboard.aspx/ClassCount',
                type: 'POST',
                data: JSON.stringify({
                    today_formate: today_formate
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    var data_array = doc.d.split(',')
                    var myChart = echarts.init(document.getElementById('main'));

                    var option = {
                        title: {
                            text: '每日打卡數'
                        },
                        tooltip: {
                            trigger: 'axis',
                            axisPointer: {
                                type: 'shadow'
                            }
                        },
                        grid: {
                            left: '3%',
                            right: '4%',
                            bottom: '3%',
                            containLabel: true
                        },
                        xAxis: {
                            type: 'category',
                            data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
                            axisTick: {
                                alignWithLabel: true
                            }
                        },
                        yAxis: {
                            type: 'value'
                        },
                        series: [
                            {
                                name: '人數',
                                data: [parseInt(data_array[0]), data_array[1], data_array[2], data_array[3], data_array[4]],
                                type: 'bar',
                                showBackground: true,
                                backgroundStyle: {
                                    color: 'rgba(180, 180, 180, 0.2)'
                                }
                            }
                        ]
                    };

                    // 使用刚指定的配置项和数据显示图表。
                    myChart.setOption(option);
                }
            });
        }

        function See_Image(SYSID) {
            $.ajax({
                url: 'Dashboard.aspx/See_Image',
                type: 'POST',
                data: JSON.stringify({
                    SYSID: SYSID
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",
                success: function (doc) {
                    var url = doc.d
                    console.log(url)
                    window.open(url, '_blank')
                }
            });
        }
    </script>
</asp:Content>

