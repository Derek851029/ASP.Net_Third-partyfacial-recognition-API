<%@ Page Title="LINE會員資料" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LineMemberList.aspx.cs" Inherits="LineMemberList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    
    <script src="../DataTables/jquery.dataTables.min.js"></script>
    <script src="js/moment.min.js"></script>

    
    <style>
        body {
            font-family: "Microsoft JhengHei",Helvetica,Arial,Verdana,sans-serif;
            font-size: 18px;
        }
    </style>

    

    <div id="table_view" style="width: 95%; margin: 10px 20px;display:inline-block">
        <div class="col-6">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 d-flex align-items-center">
                    <li class="breadcrumb-item">
                        <a href="LineMemberList.aspx" class="link">
                            <i class="bi-house"></i>
                        </a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">會員管理</li>
                </ol>
                </nav>
            <h1 class="mb-0 fw-bold">LINE會員資料
            </h1> 
        </div>
        <div class="row">
            <table id="data" class="table table-striped" style="text-align:center;width:100%">
                <thead>
                    <tr>
                        <th style="text-align:center;">編號</th>
                        <th style="text-align:center;">身份</th>
                        <th style="text-align:center;">LINE名稱</th>
                        <th style="text-align:center;">加入日期</th>
                        <th style="text-align:center;">編輯</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>

    </div>
    <!-- ====== 編輯dialog ====== -->
    <div class="modal fade" id="dialog1" data-bs-keyboard="false" data-bs-backdrop="static" style="overflow: auto">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="hide"></h5>
                    <h2 class="modal-title" id="dialogtitle">編輯Line@</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th style="text-align:center;" colspan="4">
                                    <span><strong>Line使用者資料</strong></span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th><strong>Line名稱</strong></th>
                                <th>
                                    <input type="text" id="Name" class="form-control" disabled="disabled" />
                                </th>
                            </tr>
                            <tr>
                                <th><strong>身份</strong></th>
                                <th>
                                    <select id="select" class="form-select">
                                        <option value="0">請選擇身份…</option>
                                    </select>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" id="dialog3Close"  data-bs-dismiss="modal" onclick="webcam.stop()"><span class="glyphicon glyphicon-remove"></span>&nbsp;關閉</button>
                    <button type="button" id="btnEdit" class="btn btn-primary">修改</button>
                </div>
            </div>
        </div>
    </div>
    <!-- ====== 編輯dialog ====== -->
    
    <script src="js/notiflix.js"></script>
    <link href="js/notiflix.css" rel="stylesheet" />


    <script type="text/javascript">
        $(function () {
            $('#member').css({ "background-color": "#1a9bfc", "color": "white" })
            bindMember();
            ListIdentity()

            $('#btnEdit').click(function () {
                Update()
            })
        });


        function bindMember() {
            $.ajax({
                type: 'post',
                url: 'LineMemberList.aspx/bindMember',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({}),
                dataType: 'json',
                success: function (doc) {
                    let data = eval(doc.d)
                    $('#data').dataTable({
                        searching: true,
                        destroy: true,
                        data: data,
                        deferRender: true,
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
                        "aLengthMenu": [[10,50], [10,50]],
                        "iDisplayLength": 10,
                        "columnDefs": [{
                            "targets": -1,
                            "data": null,
                            "searchable": false,
                            "paging": false,
                            "ordering": false,
                            "info": false,
                        }],
                        columns: [
                            { "data": "LMBID" },
                            { "data": "Num" },
                            { "data": "UserName" },
                            {
                                "data": "CreateDate",
                                "render": function (data, type, full, meta) {
                                    let text = data.replace('T',' ')
                                    return text
                                }
                            },
                            {
                                "data": "LMBID",
                                "render": function (data, type, full, meta) {
                                    let bt = '<button id="update_'+data+'" type="button" class="btn btn-outline-primary btn-lg" data-bs-toggle="modal" data-bs-target="#dialog1" ><span class="glyphicon glyphicon-pencil">編輯</span></button>';
                                    return bt;
                                }
                            },
                            
                        ]
                    });
                    $('#data tbody').unbind('click').
                        on('click', 'button[id^=update]', function () {
                            $('#Name').val('')
                            $('#select').val('0')
                            var LMBID = $(this).attr('id').split('_')[1]
                            $('#hide').html(LMBID)
                            $.each(data, function (index, obj) {
                                console.log(obj)
                                var SYSID = obj.LMBID
                                if (SYSID == LMBID) {
                                    console.log(data[index])
                                    $('#Name').val(data[index].UserName)
                                    $('#select').val(data[index].Num)
                                }
                            })
                        })

                }
            });
        }

        function ListIdentity() {
            $.ajax({
                type: 'post',
                url: 'LineMemberList.aspx/ListIdentity',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({}),
                dataType: 'json',
                success: function (doc) {
                    let data = JSON.parse(doc.d)
                    $.each(data, function (idx, obj) {
                        $('#select').append("<option value='" + obj.Agent_Team + "'>" + obj.Agent_Team + "</option>");
                    });
                }

            });
        }

        function Update() {
            var LMBID = $('#hide').html()
            var select = $('#select').val()
            if (select == "0") {
                Notiflix.Report.Warning('請選擇身份', '', '確定');
                return
            }
            $.ajax({
                type: 'post',
                url: 'LineMemberList.aspx/Update',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({ LMBID: LMBID, select: select }),
                dataType: 'json',
                success: function (doc) {
                    Notiflix.Report.Success('編輯完成', '', '完成');
                    bindMember()
                    $('.btn-close').click()
                }
            })
        }

        function openpage(id) {
            $.ajax({
                type: 'post',
                url: 'LineMemberList.aspx/openpage',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({ID:id}),
                dataType: 'json',
                success: function (doc) {
                    location.href = 'LineMsgList.aspx';
                }
            })
        }

        function openedit(id) {
            $.ajax({
                type: 'post',
                url: 'LineMemberList.aspx/openedit',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({ ID: id }),
                dataType: 'json',
                success: function (doc) {
                    location.href = 'MemberEdit.aspx';
                }
            })
        }


    </script>


</asp:Content>

