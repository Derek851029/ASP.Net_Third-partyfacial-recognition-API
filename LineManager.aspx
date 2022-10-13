<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LineManager.aspx.cs" Inherits="LineManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    <div id="table_view"  style="width: 95%; margin: 10px 20px;display:inline-block">
        <div class="col-6">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 d-flex align-items-center">
                    <li class="breadcrumb-item">
                        <a href="LineManager.aspx" class="link">
                            <i class="bi-house"></i>
                        </a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">Line管理介面</li>
                </ol>
                </nav>
            <h1 class="mb-0 fw-bold">Line會員管理
                <%--<button type="button" class="btn btn-success btn-lg" data-bs-toggle="modal" data-bs-target="#dialog1" onclick="Clear()"><span class="glyphicon glyphicon-plus">新增人員</span></button>--%>
            </h1> 
        </div>
        <table id="table1" class="display table table-striped" style="text-align:center;width:100%">
            <thead>
                <tr>
                    <th style="text-align:center;">Line名稱</th>
                    <th style="text-align:center;">加入日期</th>
                </tr>
            </thead>
        </table>
    </div>

    <!-- ====== 新增班級dialog ====== -->
    <div class="modal fade" id="dialog1" data-bs-keyboard="false" data-bs-backdrop="static" style="overflow: auto">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">新增部門</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th style="text-align:center;" colspan="4">
                                    <span><strong>部門資訊</strong></span>
                                    <input type="hidden" id="SYSID" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th><strong>部門名稱</strong></th>
                                <th>
                                    <input type="text" id="Class_Name" class="form-control" placeholder="請輸入部門名稱．．．" />
                                </th>
                            </tr>
                            <%--<tr>
                                <th><strong>Teacher</strong></th>
                                <th>
                                    <select id="Teacher" class="form-select" />
                                </th>
                            </tr>--%>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" title="Close"><span class="glyphicon glyphicon-remove"></span>&nbsp;關閉</button>
                    <button type="button" id="btn_add" onclick="SetLineClass()" class="btn btn-success" title="Confirm"><span class="glyphicon glyphicon-ok"></span>&nbsp;確認</button>
                </div>
            </div>
        </div>
    </div>
    <!-- ====== 新增班級dialog ====== -->
    <script src="js/notiflix.js"></script>
    <link href="js/notiflix.css" rel="stylesheet" />
    <script>
        $(function () {
            $('#LineManager').css({ "background-color": "#1a9bfc", "color": "white" })
            bindtable()
        })

        function Listener_event() {
            $('#Class_Managerment').addClass('nav_link active')
            $('#add_class').click(function () {
                $('#btn_add').html('<span class="glyphicon glyphicon-ok"></span>確定')
                $('#Class_Name').val('')
                $('#Teacher').val('none')
            })
        }

        function bindtable() {
            $.ajax({
                type: 'post',
                url: 'LineManager.aspx/bindtable',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({}),
                dataType: 'json',
                success: function (doc) {
                    var full_data = eval(doc.d)
                    $('#table1').dataTable({
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
                        //"aaSorting": [[0, 'asc']],
                        //"aLengthMenu": [[10,50], [10,50]],
                        //"iDisplayLength": 10,
                        "columnDefs": [{
                            "targets": -1,
                            "data": null,
                            "searchable": false,
                            "paging": false,
                            "ordering": false,
                            "info": false,
                        }],
                        columns: [
                            { "data": "UserName" },
                            {
                                "data": "UpdateDate",
                                "render": function (data, type, full, meta) {
                                    var date = new Date(data).format("yyyy-MM-dd")
                                    return date;
                                }
                            },
                        ]
                    });
                }
            });
        }
    </script>
    <style>
        .fade{
            transition:opacity .15s linear
        }
    </style>
</asp:Content>

