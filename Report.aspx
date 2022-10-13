<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    <div id="table_view"  style="width: 95%; margin: 10px 20px;display:inline-block">
        <div class="col-6">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 d-flex align-items-center">
                    <li class="breadcrumb-item">
                        <a href="Report.aspx" class="link">
                            <i class="bi-house"></i>
                        </a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">人員進出報表</li>
                </ol>
                </nav>
            <h1 class="mb-0 fw-bold">報表</h1> 
        </div>
        <div class="row justify-content-around">
            起始日期:<input id="startDate"  class="form-control" style="width:30%; background-color:white"/>
            結束日期:<input id="endDate"  class="form-control" style="width:30%; background-color:white"/>
            <button type="button" id="search" onclick="" class="btn btn-info" style="width:10%"><span class="glyphicon glyphicon-search">查詢</span></button>
        </div>
        <table id="table1" class="display table table-striped" style="text-align:center;width:100%">
            <thead>
                <tr>
                    <th style="text-align:center;">人員編號</th>
                    <th style="text-align:center;">人員姓名</th>
                    <th style="text-align:center;">是否配戴口罩</th>
                    <th style="text-align:center;">體溫</th>
                    <th style="text-align:center;">進出日期</th>
                    <th style="text-align:center;">狀態</th>
                </tr>
            </thead>
        </table>
    </div>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.4.2/css/buttons.dataTables.css"/>
    <link href="js/notiflix.css" rel="stylesheet" />
    <link href="css/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.1/js/buttons.print.min.js"></script>
    <script src="js/bootstrap-datepicker.min.js"></script>
    <script src="js/notiflix.js"></script>
    
    
    <script>
        var d = new Date()
        var year = d.getFullYear()
        var month = d.getMonth()
        var day = d.getDate()
        var monthAgo = new Date(year, (month - 1), day)

        $(function () {
            $('#Report').css({ "background-color": "#1a9bfc", "color": "white" })

            $('#startDate').datepicker({
                autoclose: true,
                format: 'yyyy-mm-dd',
            }).datepicker("setDate", monthAgo)

            $('#endDate').datepicker({
                autoclose: true,
                format: 'yyyy-mm-dd',
            }).datepicker("setDate", 'now')

            $('#search').click(function () {
                bindtable()
            })
        });

        function bindtable() {
            let startDate = $('#startDate').val()
            let endDate = $('#endDate').val()
            if (Date.parse(startDate).valueOf() > Date.parse(endDate).valueOf()) {
                Notiflix.Report.Warning('起始時間大於結束時間，請重新選擇', '', '確定');
                return
            }
            $.ajax({
                type: 'post',
                url: 'Report.aspx/bindtable',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({
                    startDate: startDate,
                    endDate: endDate,
                }),
                dataType: 'json',
                success: function (doc) {
                    var full_data = eval(doc.d)
                    /*console.log(full_data)*/
                    $('#table1').dataTable({
                        dom: 'Bfrtip',
                        buttons: [
                            'copy', 'excel', 'print'
                        ],
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
                        "aaSorting": [[0, 'asc']],
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
                            { "data": "Date" },
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
                        ]
                    });
                }
            });
        }
    </script>
</asp:Content>

