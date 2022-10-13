<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="0060010005.aspx.cs" Inherits="_0060010005" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    
    <script src="../DataTables/jquery.dataTables.min.js"></script>
    <script src="js/moment.min.js"></script>

    <style>
        body {
            font-family: "Microsoft JhengHei",Helvetica,Arial,Verdana,sans-serif;
            font-size: 18px;
            background-image:url('../images/395611d9c84158fc65e022292187ca81.gif');
        }

        thead th {
            background-color: #666666;
            color: white;
        }

        tr td:first-child,
        tr th:first-child {
            border-top-left-radius: 8px;
            border-bottom-left-radius: 8px;
        }

        tr td:last-child,
        tr th:last-child {
            border-top-right-radius: 8px;
            border-bottom-right-radius: 8px;
        }

        #data_company td:nth-child(2), #data_company td:nth-child(1),
        #data2 td:nth-child(3), #data2 td:nth-child(1),
        #data td:nth-child(6), #data td:nth-child(5), #data td:nth-child(4),
        #data td:nth-child(3), #data td:nth-child(2), #data td:nth-child(1) {
            text-align: center;
        }
        .auto-style1 {
            width: 182px;
        }

        #data th, #data td{
            text-align:center;
        }
        #agent-data th, #agent-data td{
            text-align:center;
        }
    </style>


    <div class="container">
        <div class="row">
            <h2>
                <strong>
                    人員資料管理(瀏覽)
                    <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#agent_modal" style="Font-Size: 20px;" onclick="edit('new', 0)"><span class='glyphicon glyphicon-plus'></span>&nbsp;&nbsp;新增人員</button>
                </strong>
            </h2>
        </div>
        <div class="row">
            <table id="data" class="display table table-striped table-sm" style="width:100%;text-align:center;">
                <thead>
                    <tr>
                        <th>員工編號</th>
                        <th>員工姓名</th>
                        <th>所屬部門</th>
                        <th>人員權限</th>
                        <th>系統選單全</th>
                        <th>修改</th>
                        <th>刪除(離職)</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>

    </div>

    
    <div class="container">
        <div id="agent_modal" class="modal inmodal fade"  tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
          <div class="modal-dialog modal-lg" >
            <div class="modal-content">
              <div class="modal-header ">
                <button type="button" class="close read_data" data-dismiss="modal" style="color:black;">
                  <span>&times;</span>
                </button>
                <div class="modal-title">
                    <h3><strong>人員資料<span id="agent_type">新增</span></strong></h3>
                </div>
              </div>
              <div class="modal-body" >
                  <table id="agent-data" class="table table-bordered table-striped"  style="width:100%;">
                    <thead>
                        <tr>
                            <th colspan="4" style="text-align:center;">人員資料</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th style="color:red">人員編號</th>
                            <td>
                                <input type="text" id="agent_id" placeholder="人員編號"  maxlength="10" onkeyup="value=value.replace(/[^\d]/g,'')"
                                    style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                            <th style="color:red">人員姓名</th>
                            <td>
                                <input type="text" id="agent_name" placeholder="人員姓名"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                        </tr>
                        <tr>
                            <th>選擇所屬部門</th>
                            <td>
                                <select id="teamid" style="width:100%;">

                                </select>
                            </td>
                            <th>所屬部門</th>
                            <td>
                                <input type="text" id="agent_team" placeholder="所屬部門"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>

                            </td>
                        </tr>
                        <tr>
                            <th>分機號碼</th>
                            <td>
                                <input type="text" id="agent_ext" placeholder="分機號碼"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                            <th></th>
                            <td></td>
                        </tr>
                        <tr>
                            <th><span style="color:red;">登入帳號</span></th>
                            <td>
                                <input type="text" id="userid" placeholder="登入帳號"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                            <th><span style="color:red;">IP位置</span></th>
                            <td>
                                <input type="text" id="ip" placeholder="電腦IP"  maxlength="20" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                        </tr>
                        <tr>
                            <th><span style="color:red;">登入密碼</span></th>
                            <td>
                                <input type="password" id="password" placeholder="登入密碼"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                            <th><span style="color:red;">確認密碼</span></th>
                            <td>
                                <input type="password" id="check_password" placeholder="再次輸入密碼"  maxlength="10" style="width:100%;Font-Size:18px;background-color:#ffffbb"/>
                            </td>
                        </tr>
                        <tr>
                            <th><span style="color:red;">人員權限</span></th>
                            <td>
                                <select id="Agent_LV" style="width: 100%; Font-Size: 18px">
                                    <option value="10">一般員工</option>
                                    <option value="20">部門主管</option>
                                    <option value="30">管理人員</option>
                                </select>
                            </td>
                            <th><span style="color:red;">系統選單權限</span></th>
                            <td>
                                <select id="Role_ID" style="width: 100%; Font-Size: 18px">
                                </select>
                            </td>
                        </tr>
                    </tbody>
                </table>
              </div>
              <div class="modal-footer" >
                <button id="edit_agent" type="button" class="btn btn-success read_data">新增</button>
              </div>
            </div>
          </div>
        </div>
    </div>




    <script type="text/javascript">
        $(function () {
            bind_team();
            bind_rolelist();
            bind_data();

            $('#teamid').change(function () {
                var text = $('#teamid option:selected').text();
                $('#agent_team').val(text);
            });

        });

        function bind_team() {
            $.ajax({
                type: 'post',
                url: '0020010004.aspx/data_team',
                contentType: 'application/json;utf-8',
                dataType: 'json',
                success: function (doc) {
                    //先將內容清過一次，再插入資料，以防重複寫入
                    $('#teamid').html('<option value="0">----請選擇----</option>');
                    var teamdata = eval(doc.d);
                    for (var i = 0; i < teamdata.length; i++) {
                        var option = '<option value="' + teamdata[i].TeamID + '">' + teamdata[i].TeamName
                            + '</option>';
                        $('#teamid').append(option);
                    }
                }
            });
        }

        function bind_rolelist() {
            $.ajax({
                type: 'post',
                url: '0060010005.aspx/ROLELIST_List',
                contentType: 'application/json;utf-8',
                dataType: 'json',
                success: function (doc) {
                    //先將內容清過一次，再插入資料，以防重複寫入
                    $('#Role_ID').html('');
                    var roledata = eval(doc.d);
                    for (var i = 0; i < roledata.length; i++) {
                        var option = '<option value="' + roledata[i].ROLE_ID + '">' + roledata[i].ROLE_NAME
                            + '</option>';
                        $('#Role_ID').append(option);
                    }
                }
            });

        }

        function bind_data() {
            $.ajax({
                type: 'post',
                url: '0060010005.aspx/bind_data',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({}),
                dataType: 'json',
                success: function (data) {
                    $('#data').dataTable({
                        searching: false,
                        destroy: true,
                        data: eval(data.d),
                        deferRender: true,
                        "oLanguage": {
                            "sLengthMenu": "顯示 _MENU_ 筆",
                            "sZeroRecords": "無回覆資料",
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
                        "aLengthMenu": [[5], [5]],
                        "iDisplayLength": 5,
                        "columnDefs": [{
                            "targets": -1,
                            "data": null,
                            "searchable": false,
                            "paging": false,
                            "ordering": false,
                            "info": false,
                        }],
                        columns: [
                            {"data": "Agent_ID"},
                            { "data": "Agent_Name" },
                            { "data": "Agent_Team" },
                            {
                                data: "Agent_ID", render: function (data, type, row, meta) {
                                    if (row.Agent_LV == "10") {
                                        return "<label> 一般員工 </label>";
                                    }
                                    else if (row.Agent_LV == "20") {
                                        return "<label> 部門主管 </label>";
                                    }
                                    else if (row.Agent_LV == "30") {
                                        return "<label> 管理人員 </label>";
                                    }
                                    else {
                                        return "<label>" + row.Agent_LV + "</label>";
                                    }
                                }
                            },
                            {
                                data: "ROLE_NAME"
                            },
                            {
                                "data": "SYSID",
                                "render": function (data, type, full, meta) {
                                    var bt_type = "'update'";
                                    var bt = '<button id="update" type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#agent_modal">修改</button>';
                                    return bt;
                                }
                            },
                            {
                                "data": "SYSID",
                                "render": function (data, type, full, meta) {
                                    var bt_type = "'delete'";
                                    var bt = '<button id="delete" type="button" class="btn btn-danger btn-lg" onclick="edit(' + bt_type + ',' + data +')">刪除(離職)</button>';
                                    return bt;
                                }
                            }
                        ]
                    });

                    //============================================
                    $('#data tbody').unbind('click')
                        .on('click', '#update', function () {
                            var table = $('#data').DataTable();
                            var data = table.row($(this).parents('tr')).data();
                            edit('update', data.SYSID);
                            $('#agent_id').val(data.Agent_ID);
                            $('#agent_name').val(data.Agent_Name);
                            $('#teamid').val(data.TeamID);
                            $('#agent_team').val(data.Agent_Team);
                            $('#agent_ext').val(data.Agent_ExtNum);
                            $('#userid').val(data.UserID);
                            $('#password').val(data.Password);
                            $('#check_password').val(data.Password);
                            $('#ip').val(data.IP);
                            $('#Agent_LV').val(data.Agent_LV);
                            $('#Role_ID').val(data.Role_ID);
                        });
                }
            });
        }

        function edit(type, id) {
            if (type == 'delete') {
                d_agent(id);

            }
            else {
                clear_table();
                if (type == 'update') {
                    agent_data(id);
                    $('#edit_agent').text('修改');
                    $('#agent_type').text('修改');
                }
                else {
                    $('#edit_agent').text('新增');
                    $('#agent_type').text('新增');

                }
                var click_type = "'" + type + "'"
                var onclick = 'w_agent(' + click_type + ',' + id + ')';
                $('#edit_agent').attr('onclick', onclick);
            }
        }

        function clear_table() {
            document.querySelector('#agent_id').value='';
            document.querySelector('#agent_name').value='';
            document.querySelector('#agent_team').value='';
            document.querySelector('#teamid').value='0';
            document.querySelector('#agent_ext').value='';
            document.querySelector('#userid').value='';
            document.querySelector('#ip').value='';
            document.querySelector('#password').value='';
            document.querySelector('#check_password').value='';
            document.querySelector('#Agent_LV').value='10';
            //bind_rolelist();

        }

        function agent_data(id) {

        }

        function w_agent(type, id) {
            var agentid = document.querySelector('#agent_id').value;
            var agentname = document.querySelector('#agent_name').value;
            var agentteam = document.querySelector('#agent_team').value;
            var teamid = document.querySelector('#teamid').value;
            var ext = document.querySelector('#agent_ext').value;
            var userid = document.querySelector('#userid').value;
            var ip = document.querySelector('#ip').value;
            var pwd = document.querySelector('#password').value;
            var cpwd = document.querySelector('#check_password').value;
            var agentlv = document.querySelector('#Agent_LV').value;
            var roleid = document.querySelector('#Role_ID').value;

            if (pwd != cpwd) {
                alert('密碼不一致');
                return
            }
            if (agentid == '') {
                alert('人員編號不得為空');
                return
            }
            if (agentname == '') {
                alert('人員姓名不得為空');
                return
            }

            $.ajax({
                type: 'post',
                url: '0060010005.aspx/w_agent',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({
                    type: type,
                    id: id,
                    agentid: agentid,
                    agentname: agentname,
                    agentteam: agentteam,
                    teamid: teamid,
                    ext: ext,
                    userid: userid, 
                    ip: ip,
                    pwd: pwd,
                    agentlv: agentlv,
                    roleid: roleid
                }),
                dataType: 'json',
                success: function (data) {
                    alert(data.d);
                    bind_data();
                }
            });
            
            $('#agent_modal').modal('hide');
        }

        function d_agent(id) {

            $.ajax({
                type: 'post',
                url: '0060010005.aspx/delete_agent',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({ ID: id }),
                dataType: 'json',
                success: function (doc) {
                    alert(doc.d);
                }
            });
        }

    </script>
</asp:Content>

