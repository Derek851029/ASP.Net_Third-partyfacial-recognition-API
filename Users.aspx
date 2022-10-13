<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    <h2 id="h2_back" style="display:none">
        <button type="button" id="back" class="btn btn-success btn-lg">返回</button>
    </h2>
     <div id="table_view"  style="width: 95%; margin: 10px 20px;display:inline-block">
        <div class="col-6">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0 d-flex align-items-center">
                    <li class="breadcrumb-item">
                        <a href="Member.aspx" class="link">
                            <i class="bi-house"></i>
                        </a>
                    </li>
                    <li class="breadcrumb-item active" aria-current="page">人臉辨識管理</li>
                </ol>
                </nav>
            <h1 class="mb-0 fw-bold">人員管理
                <button type="button" class="btn btn-success btn-lg" data-bs-toggle="modal" data-bs-target="#dialog1" onclick="Clear()"><span class="glyphicon glyphicon-plus">新增人員</span></button>
            </h1> 
        </div>
        <table id="table1" class="display table table-striped" style="text-align:center;width:100%">
            <thead>
                <tr>
                    <th style="text-align:center;">人員編號</th>
                    <th style="text-align:center;">身分證字號</th>
                    <th style="text-align:center;">人員姓名</th>
                    <th style="text-align:center;">電話</th>
                    <th style="text-align:center;">信箱</th>
                    <th style="text-align:center;">功能選單</th>
                </tr>
            </thead>
        </table>
    </div>
    <%--------------------------------看老師or學生資料--------------------------------%>
    <div class="row gutters-sm" id="view1" style="display:none">
        <div class="col-md-4 mb-3">
            <div class="card">
                <div class="card-body">
                    <div class="d-flex flex-column align-items-center text-center">
                        <img id="image" src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" width="150">
                    </div>
                </div>
            </div>
            <div class="card mt-3">
                <ul class="list-group list-group-flush">
                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6  class="mb-0">人員編號:</h6>
                        <span id="card_number" class="text-secondary">xxx</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6  class="mb-0">人員姓名:</h6>
                        <span id="card_name" class="text-secondary">xxx</span>
                    </li>
                    <%--<li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6 class="mb-0">Class:</h6>
                        <span id="card_class" class="text-secondary">09xxxxxxxx</span>
                    </li>--%>
                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6 class="mb-0">性別:</h6>
                        <span id="card_sex" class="text-secondary">先生</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6 class="mb-0">電話:</h6>
                        <span id="card_phone" class="text-secondary">09</span>
                    </li>
                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6 class="mb-0">Email:</h6>
                        <span id="card_email" class="text-secondary">2022/01/01</span>
                    </li>
                    <%--<li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                        <h6 id="card_time" class="mb-0">上次打卡時間:</h6>
                        <span class="text-secondary">2022/01/01</span>
                    </li>--%>
                </ul>
            </div>
        </div>
        <div class="col-lg-8">
            <div class="card-header">
                <h1>歷史紀錄</h1>
                <div class="row justify-content-around">
                    起始日期:<input id="startDate"  class="form-control" style="width:30%; background-color:white"/>
                    結束日期:<input id="endDate"  class="form-control" style="width:30%; background-color:white"/>
                    <button type="button" id="search" onclick="" class="btn btn-info" style="width:10%"><span class="glyphicon glyphicon-search">查詢</span></button>
                </div>
                
            </div>
            <div class="card">
            <div class="card-body">
                <table id="table2" class="table table-striped" style="text-align:center;width:100%">
                    <thead>
                        <tr>
                            <th style="text-align:center;">人員編號</th>
                            <th style="text-align:center;">人員姓名</th>
                            <th style="text-align:center;">體溫</th>
                            <th style="text-align:center;">狀態</th>
                            <th style="text-align:center;">進出時間</th>
                        </tr>
                    </thead>
                </table>
            </div>
            </div>
        </div>
    </div>

    <%--------------------------------會員資料--------------------------------%>

    <!-- ====== 新增會員dialog ====== -->
    <div class="modal fade" id="dialog1" data-bs-keyboard="false" data-bs-backdrop="static" style="overflow: auto">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title" id="dialogtitle">新增人員資料</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered">
                        <thead class="table-dark">
                            <tr>
                                <th style="text-align:center;" colspan="4">
                                    <span><strong>人員資料</strong></span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th><strong>人員編號</strong></th>
                                <th>
                                    <input type="text" id="MemberNum" class="form-control" placeholder="請輸入人員編號" />
                                </th>
                            </tr>
                            <tr>
                                <th><strong>人員姓名</strong></th>
                                <th>
                                    <input type="text" id="MemberName" class="form-control" placeholder="請輸入人員姓名" required="required"/>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>身分證字號</strong></th>
                                <th>
                                    <input type="text" id="MemberID" class="form-control" placeholder="請輸入身分證字號" required="required"/>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>人員進出通知</strong></th>
                                <th>
                                   <select id="LineUser" class="form-select">
                                      <option selected="selected">Open this select menu</option>
                                      <option value="1">One</option>
                                      <option value="2">Two</option>
                                      <option value="3">Three</option>
                                    </select>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>出生年月日</strong></th>
                                <th>
                                    <input class="form-control" id="MemberDate" placeholder="請選擇出生年月日" required="required"/>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>性別</strong></th>
                                <th>
                                    <input type="checkbox" id="Sex_Man" />先生
                                    <input type="checkbox" id="Sex_Lady"/>小姐
                                </th>
                            </tr>
                            <tr>
                                <th><strong>行動電話</strong></th>
                                <th>
                                    <input type="text" id="MemberPhone" class="form-control" placeholder="請輸入行動電話" required="required"/>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>Email</strong></th>
                                <th>
                                    <input type="text" id="MemberEmail" class="form-control" placeholder="請輸入信箱" required="required"/>
                                </th>
                            </tr>
                            <tr>
                                <th><strong>上傳照片</strong></th>
                                <th>
                                    <div>
                                        <input type="file" id="file" class="form-control" required="required"/>
                                        <button type="button" id="showImage" data-bs-toggle="modal" data-bs-target="#dialog2" onclick="" class="btn btn-outline-primary" style="display:none"><span class="glyphicon glyphicon-search">檢視照片</span></button>
                                        <button type="button" id="Camera" onclick="Start_Camera()" class="btn btn-info"><span class="glyphicon glyphicon-camera"></span>拍照</button>
                                    </div>
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                    <button type="button" id="btnAdd" onclick="LoadingControl(0)" class="btn btn-success">新增</button>
                    <button type="button" id="btnEdit" onclick="LoadingControl(1)" class="btn btn-primary">修改</button>
                </div>
            </div>
        </div>
    </div>
    <!-- ====== 新增會員dialog ====== -->
    <!-- ====== 看照片dialog ====== -->
    <div class="modal fade" id="dialog2" data-bs-keyboard="false" data-bs-backdrop="static" style="overflow: auto">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">檢視照片</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div id="View_image" style="text-align:center;"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                </div>
            </div>
        </div>
    </div>
    <!-- ====== 看照片dialog ====== -->
    <!-- ====== 開啟相機dialog ====== -->
    <div class="modal fade" id="dialog3" data-bs-keyboard="false" data-bs-backdrop="static" style="overflow: auto">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">拍攝照片</h2>
                    <button type="button" class="btn-close" onclick="webcam.stop()" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div style="text-align:center">
                        <video id="webcam" autoplay="autoplay" playsinline="" width="580" height="440"></video>     
                        <canvas id="canvas" style="display:none"></canvas>
                        <%--<canvas id="canvas" class="d-none"></canvas>
                        <audio id="snapSound" src="audio/snap.wav" preload = "auto"></audio>--%>
                    </div>
                    <div style="text-align:center">
                        <button type="button" style="width: 70px;
                                                                          height: 70px;
                                                                          padding: 10px 16px;
                                                                          font-size: 24px;
                                                                          line-height: 1.33;
                                                                          border-radius: 35px;"
                            id="photo" class="btn btn-info btn-xl"><i class="glyphicon glyphicon-camera"></i></button>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" id="dialog3Close"  data-bs-dismiss="modal" onclick="webcam.stop()"><span class="glyphicon glyphicon-remove"></span>&nbsp;關閉</button>
                    <button type="button" id="restart_photo" class="btn btn-info" style="display:none"><span class="glyphicon glyphicon-refresh"></span>重新拍攝</button>
                    <button type="button" id="init_photo" class="btn btn-success" style="display:none"><span class="glyphicon glyphicon-ok"></span>使用照片</button>
                </div>
            </div>
        </div>
    </div>
    <!-- ====== 開啟相機dialog ====== -->
    <script src="js/notiflix.js"></script>
    <link href="js/notiflix.css" rel="stylesheet" />
    <script src="js/webcam.js"></script>
    <script src="js/bootstrap-datepicker.min.js"></script>
    <link href="css/bootstrap-datepicker3.min.css" rel="stylesheet" />
    <script>
        var seqno = '<%= seqno %>';

        var b;

        var d = new Date()
        var year = d.getFullYear()
        var month = d.getMonth()
        var day = d.getDate()
        var monthAgo = new Date(year, (month - 1), day)
        var Now = new Date(year, (month), day+1)

        var webcamElement = document.getElementById('webcam');
        var canvasElement = document.getElementById('canvas');
        var webcam = new Webcam(webcamElement, 'user', canvasElement)
        var picture;
        var photo_base64 = "";

        $(function () {
            bindtable()
            initHTML()
            Listener_event()
            
        })

        function Listener_event() {
            $('#Users').css({ "background-color": "#1a9bfc", "color": "white" })

            $('#Sex_Man').on('change', function () { if ($('#Sex_Man').is(':checked')) { $('#Sex_Lady').prop('checked', false) } })
            $('#Sex_Lady').on('change', function () { if ($('#Sex_Lady').is(':checked')) { $('#Sex_Man').prop('checked', false) } })

            $('#file').change(function () {
                $.map($(this).get(0).files, function (file, index) {
                    var img_size = Math.floor(file.size / 1024)
                    var type = file.type.split('/')
                    type = type[0]
                    if (type != 'image') {
                        Notiflix.Report.Warning('請上傳圖片類型', '', '確定');
                        $('#file').val('')
                        $('#View_image').html('')
                        return false;
                    }
                    if (file) {
                        $('#View_image').html('')
                        var reader = new FileReader();
                        reader.readAsDataURL(file);
                        reader.onload = function (e) {
                            var urlData = reader.result;
                            var base64 = urlData.split(',')[1]
                            $('#showImage').show()
                            $('#View_image').html('')
                            $('#View_image').append('<img src="' + urlData + '" width=300 heigth:200></img>')
                        };
                    }
                });
            })

            $('#startDate').datepicker({
                autoclose: true,
                format: 'yyyy-mm-dd',
            }).datepicker("setDate", monthAgo)

            $('#endDate').datepicker({
                autoclose: true,
                format: 'yyyy-mm-dd',
            }).datepicker("setDate", Now)

            $('#search').click(function () {
                let startDate = $('#startDate').val()
                let endDate = $('#endDate').val()
                if (Date.parse(startDate).valueOf() > Date.parse(endDate).valueOf()) {
                    Notiflix.Report.Warning('起始時間大於結束時間，請重新選擇', '', '確定');
                }
                else {
                    let MemberNum = $('#card_number').text()
                    ListHistory(MemberNum, startDate, endDate)
                }
            })

            //按下拍照
            $('#photo').click(function () {
                picture = webcam.snap()

                photo_base64 = picture.split(",")[1]; //取的base64字串
                webcam.stop()
                $('#restart_photo').show()
                $('#init_photo').show()
                $('#webcam').hide()
                $('#canvas').show()
            })

            //按下重新拍攝
            $('#restart_photo').click(function () {
                webcam.start()
                $('#webcam').show()
                $('#canvas').hide()

                $('#restart_photo').hide()
                $('#init_photo').hide()
            })

            $('#init_photo').click(function () {
                if (photo_base64 == "") {
                    Notiflix.Report.Warning('未偵測到照片', '', '確定');
                    return false
                } else {
                    $('#dialog3Close').click()
                    $('#showImage').show()
                    $('#View_image').html('')
                    $('#View_image').append('<img src="' + picture + '" id="SnapImage" width=300 heigth:200></img>')

                    //let file = null;
                    //let img = $('#SnapImage').val()
                    //for (let i = 0; i < img.length; i++) {
                    //    if (img[i].type.match(/^image\//)) {
                    //        file = picture[i];
                    //        break;
                    //    }
                    //}
                    canvasElement.toBlob(function (blob) {
                        let file = new File([blob], "CameraImage.jpeg", { type: "image/jpeg", lastModified: new Date().getTime() }, 'utf-8');
                        let container = new DataTransfer();
                        container.items.add(file);
                        document.querySelector('#file').files = container.files
                        console.log(blob);
                    }, "image/jpeg", 0.8)
                }

            })
        }

        function initHTML() {
            $('#MemberDate').datepicker({
                autoclose: true,
                format: 'yyyy/mm/dd',
            })
            $('#btnEdit').hide()
        }

        function Clear() {
            $('#dialogtitle').text('新增人員資料')
            $('#btnAdd').show()
            $('#btnEdit').hide()
            $('#showImage').hide()
            $('#MemberNum').val('')
            $('#MemberName').val('')
            $('#MemberID').val('')
            $('#MemberDate').val('')
            $('#Sex_Man').removeAttr("checked")
            $('#Sex_Lady').removeAttr("checked")

            $('#MemberPhone').val('')
            $('#MemberEmail').val('')
            $('#file').val('')

            $('#MemberNum').attr('disabled', false)
            $('#MemberID').attr('disabled', false)
            $('#View_image').html('')

            $('#LineUser').empty()
            ListLineUser()
        }

        function bindtable() {
            $.ajax({
                type: 'post',
                url: 'Users.aspx/bindtable',
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
                            { "data": "MemberNum" },
                            { "data": "MemberID" },
                            { "data": "MemberName" },
                            { "data": "MemberPhone" },
                            { "data": "MemberEmail" },
                            {
                                "data": "SYSID",
                                "render": function (data, type, full, meta) {
                                    var bt = '<button id="view_' + data + '" type="button" class="btn btn-outline-info btn-lg" ><span class="glyphicon glyphicon-search">查詢</span></button>';
                                    bt += ' <button id="edit_' + data + '" type="button" class="btn btn-outline-primary btn-lg" data-bs-toggle="modal" data-bs-target="#dialog1"><span class="glyphicon glyphicon-pencil">編輯</span></button>';
                                    bt += ' <button id="delete_' + data + '" type="button" class="btn btn-outline-danger btn-lg" ><span class="glyphicon glyphicon-remove">刪除</span></button>';
                                    return bt;
                                }
                            },
                        ]
                    });
                    $('#table1 tbody').unbind('click').
                        on('click', 'button[id^=view_]', function () {
                            var SYSID = $(this).attr('id').split('_')[1]

                            $.each(full_data, function (index, obj) {
                                var ID = obj.SYSID
                                if (SYSID == ID) {
                                    initial(full_data[index], 'Card')
                                    return false
                                }
                            })
                        }).on('click', 'button[id^=edit_]', function () {
                            var SYSID = $(this).attr('id').split('_')[1]
                            $('#LineUser').empty()
                            ListLineUser()
                            $.each(full_data, function (index, obj) {
                                var ID = obj.SYSID
                                if (SYSID == ID) {
                                    initial(full_data[index],'Dialog')
                                    return false
                                }
                            })
                        }).on('click', 'button[id^=delete_]', function () {
                            var SYSID = $(this).attr('id').split('_')[1]
                            $.each(full_data, function (index, obj) {
                                var ID = obj.SYSID
                                if (SYSID == ID) {
                                    var data = full_data[index]
                                    DeleteMember(data.MemberNum, data.MemberName)
                                    return false
                                }
                            })
                            
                        })
                    if (seqno != "") {
                        $('#view_' + seqno + '').click()
                    }
                }
            });
        }

        function ListHistory(MemberNum, startDate, endDate) {
            
            console.log(MemberNum, startDate, endDate)
            $.ajax({
                type: 'post',
                url: 'Users.aspx/ListHistory',
                contentType: 'application/json;utf-8',
                data: JSON.stringify({
                    MemberNum: MemberNum,
                    startDate: startDate,
                    endDate: endDate,
                }),
                dataType: 'json',
                success: function (doc) {
                    var full_data = eval(doc.d)
                    $('#table2').dataTable({
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
                            { "data": "Number" },
                            { "data": "Name" },
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
                        ]
                    });
                }
            });
        }

        function ListLineUser() {
            $.ajax({
                url: 'Users.aspx/ListLineUser',
                type: 'POST',
                async: false,
                data: JSON.stringify({
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    var data = JSON.parse(doc.d);
                    var UserSelect = $('#LineUser')
                    UserSelect.append('<option selected = "selected" value="none">請選擇通知對象。。。</option >')
                    if (data.length != 0) {
                        $.each(data, function (index, obj) {
                            var UserID = obj.UserID
                            var UserName = obj.UserName
                            UserSelect.append('<option value="' + UserID + '">' + UserName+'</option>')
                        })
                    }
                }
            });
        }

        function initial(data,type) {
            if (type == 'Card') {
                $('#view1').show()
                $('#view2').show()
                $('#h2_back').show()
                $('#table_view').hide()

                $('#back').click(function () {
                    $('#view1').hide()
                    $('#view2').hide()
                    $('#h2_back').hide()
                    $('#table_view').show()
                })
                $('#image').attr('src', data.ImageURL)
                $('#card_number').text(data.MemberNum)
                $('#card_name').text(data.MemberName)
                /*$('#card_class').text(data.Class)*/
                $('#card_sex').text(data.Sex)
                $('#card_phone').text(data.MemberPhone)
                $('#card_email').text(data.MemberEmail)

                let startDate = $('#startDate').val()
                let endDate = $('#endDate').val()
                ListHistory(data.MemberNum, startDate, endDate)
            }
            else if (type == 'Dialog') {
                $('#dialogtitle').text('編輯人員資料')
                $('#btnAdd').hide()
                $('#btnEdit').show()
                $('#MemberName').val(data.MemberName)
                $('#MemberNum').val(data.MemberNum)
                $('#MemberNum').attr('disabled', 'disabled')
                $('#LineUser').val(data.LineUserID)
                $('#MemberID').val(data.MemberID)
                $('#MemberID').attr('disabled', 'disabled')
                $('#MemberDate').val(data.MemberDate)

                $('#Sex_Man').prop('checked', false)
                $('#Sex_Lady').prop('checked', false)
                if (data.Sex == 'Male') {
                    $('#Sex_Man').prop('checked', true)
                }
                else {
                    $('#Sex_Lady').prop('checked', true)
                }
                $('#MemberPhone').val(data.MemberPhone)
                $('#MemberEmail').val(data.MemberEmail)
                //$('#file').attr('disabled', 'disabled')
                //$('#file').css('background-color', '')
                if (data.ImageURL != "" || data.ImageURL != null) {
                    $('#showImage').show()
                    $('#View_image').html('')
                    $('#View_image').append('<img src="' + data.ImageURL + '" width=300 heigth:200></img>')
                }
                else {
                    $('#showImage').hide()
                    $('#View_image').html('')
                }
                
            }
    
        }

        function LoadingControl(index) {
            Notiflix.Loading.Dots('loading...');
            if (index == 0) {
                var status = AddMember(0)
                if (status == false) {
                    Notiflix.Loading.Remove(1923);
                }
            } else {
                var status = AddMember(1)
                if (status == false) {
                    Notiflix.Loading.Remove(1923);
                }
            }

        }

        function AddMember(type) {
            var MemberNum = $('#MemberNum').val().replace(/\s+/g, '')
            var MemberName = $('#MemberName').val().replace(/\s+/g, '')
            var MemberID = $('#MemberID').val().replace(/\s+/g, '')
            var LineUserID = $('#LineUser').val()
            var MemberDate = $('#MemberDate').val().replace(/\s+/g, '')
            var Sex

            var MemberPhone = $('#MemberPhone').val().replace(/\s+/g, '')
            var MemberEmail = $('#MemberEmail').val().replace(/\s+/g, '')

            if (MemberNum == '') {
                Notiflix.Report.Warning('請輸入人員編號', '', '確定');
                return false
            }

            if (MemberName == '') {
                Notiflix.Report.Warning('請輸入人員姓名', '', '確定');
                return false
            }

            if (MemberID.length != 10 || /[a-z]/i.test(MemberID) == false) {
                Notiflix.Report.Warning('身分證錯誤，請輸入正確身分證字號', '', '確定');
                return false;
            }

            if (LineUserID == 'none') {
                LineUserID = ''
            }

            if (MemberDate == '') {
                Notiflix.Report.Warning('請選擇出生年月日', '', '確定');
                return false
            }

            if ($('#Sex_Man').is(':checked')) {
                Sex = 'Male'
            }
            else {
                if ($('#Sex_Lady').is(':checked')) {
                    Sex = 'Female'
                }
                else {
                    Notiflix.Report.Warning('請選擇性別', '', '確定');
                    return false
                }
            }

            if (MemberPhone.length != 10) {
                Notiflix.Report.Warning('行動電話錯誤，請輸入正確行動電話', '', '確定');
                return false
            }

            if (MemberEmail.indexOf('@') == -1) {
                Notiflix.Report.Warning('信箱錯誤，請輸入正確信箱', '', '確定');
                return false
            }

            $.ajax({
                url: 'Users.aspx/AddMember',
                type: 'POST',
                async: false,
                data: JSON.stringify({
                    type:type,
                    MemberNum: MemberNum,
                    MemberName: MemberName,
                    MemberID: MemberID,
                    LineUserID: LineUserID,
                    MemberDate: MemberDate,
                    Sex: Sex,
                    MemberPhone: MemberPhone,
                    MemberEmail: MemberEmail,
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    if (doc.d == "Success") {
                        Control(type,MemberNum, MemberName);
                    }
                    else if (doc.d == "exist") {
                        Notiflix.Loading.Remove(1923);
                        Notiflix.Report.Warning('已有相同編號或身分證，請重新輸入', '', '確定');
                    }
                    else {
                        Notiflix.Loading.Remove(1923);
                        Notiflix.Report.Warning('人員建立失敗，請聯絡管理員', '', '確定');
                    }
                }
            });
        }

        function Control(type, MemberNum, MemberName) {
            var img_url = SaveImage(type,MemberNum)
            console.log(img_url)
            
            if (img_url != "error") {
                if (type == 0) {
                    var CreateMember = FaceControl(0, MemberName, img_url, MemberNum)
                    if (CreateMember == 'Success') {
                        var CreateFace = FaceControl(1, MemberName, img_url, MemberNum)
                        if (CreateFace == 'Success') {
                            Notiflix.Loading.Remove(1923);
                            bindtable()
                            $('.btn-close').click()
                            Notiflix.Report.Success('人員新增成功', '', '完成');
                        } else {
                            Notiflix.Loading.Remove(1923);
                            Notiflix.Report.Warning('人臉建立失敗，請聯絡管理員', '', '確定');
                        }
                    } else {
                        Notiflix.Loading.Remove(1923);
                        Notiflix.Report.Warning('辨識人員建立失敗，請聯絡管理員', '', '確定');
                    }
                }
                else if (type == 1) {
                    var EditMember = FaceControl(2, MemberName, img_url, MemberNum)
                    if (EditMember == 'Success') {
                        if (img_url != "") {
                            var EditFace = FaceControl(1, MemberName, img_url, MemberNum)
                            if (EditFace != 'Success') {
                                Notiflix.Report.Warning('人臉修改失敗，請聯絡管理員', '', '確定');
                            }
                        }
                        bindtable()
                        $('.btn-close').click()
                        Notiflix.Loading.Remove(1923);
                        Notiflix.Report.Success('人員修改成功', '', '完成');
                    }
                    else {
                        Notiflix.Loading.Remove(1923);
                        Notiflix.Report.Warning('辨識人員修改失敗，請聯絡管理員', '', '確定');
                    }
                    
                }
            }
            else {
                Notiflix.Loading.Remove(1923);
                Notiflix.Report.Warning('儲存照片失敗，請聯絡管理員', '', '確定');
            }
        }

        function DeleteMember(MemberNum, MemberName) {
            Notiflix.Loading.Dots('loading...');
            $.ajax({
                url: 'Users.aspx/DeleteMember',
                type: 'POST',
                async: false,
                data: JSON.stringify({
                    MemberNum: MemberNum
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    if (doc.d == "Success") {
                        var DeleteFace = FaceControl(3, MemberName, '', MemberNum)
                        if (DeleteFace == "Success") {
                            Notiflix.Report.Success('人員刪除成功', '', '確定');
                            bindtable()
                            Notiflix.Loading.Remove(1923);
                        }
                        else {
                            Notiflix.Report.Warning('人臉刪除失敗，請聯絡管理員', '', '確定');
                            Notiflix.Loading.Remove(1923);
                        }
                        
                    }
                    else {
                        Notiflix.Report.Warning('人員刪除失敗，請聯絡管理員', '', '確定');
                        Notiflix.Loading.Remove(1923);
                    }
                }
            });
        }

        function SaveImage(type,MemberNum) {
            let Status;
            let form = new FormData();
            var file = $('#file').get(0).files[0]

            if (file) {
                var SizeKB = file.size / 1024
                file = $('#file')[0].files[0]
                form.append('MemberNum', MemberNum)
                form.append('file', file)
                form.append('SizeKB', SizeKB)
                $.ajax({
                    url: 'UploadImage.ashx',
                    type: 'POST',
                    async:false,
                    data: form,
                    contentType: false,
                    processData: false,
                    dataType: "json",       //如果要回傳值，請設成 json
                    success: function (doc) {
                        Status = doc.Status
                    },
                    error: function () {
                        Status =  'error'
                    }
                });
                return Status
            }
            else {
                if (type == 0) {
                    Notiflix.Report.Warning('請拍攝照片或選擇照片', '', '確定');
                    return "fail"
                }
                else if (type == 1) {
                    return ""
                }
            }
        }

        function FaceControl(type, MemberName, img_url, MemberNum) {
            console.log(type, MemberName, img_url, MemberNum)
            var data;
            var status;
            switch (type) {
                case 0:
                    data = {
                        'UserInfo': {
                            'employeeNo': MemberNum,
                            'name': MemberName,
                            'userType': 'normal',
                            'Valid': {
                                'enable': true,
                                'beginTime': '2021-10-08T00:00:00',
                                'endTime': '2037-12-31T23:59:59',
                                'timeType': 'local',
                            },
                            'doorRight': '1',
                            'RightPlan': [{
                                'doorNo': 1,
                                'planTemplateNo': '1'
                            }],
                        }
                    }
                    break
                case 1:
                    data = {
                        'faceURL': img_url,
                        'faceLibType': 'blackFD',
                        'FDID': '1',
                        'FPID': MemberNum
                    }
                    break
                case 2:
                    data = {
                        'UserInfo': {
                            'employeeNo': MemberNum,
                            'name': MemberName,
                            'userType': 'normal',
                            'Valid': {
                                'enable': true,
                                'beginTime': '2021-10-08T00:00:00',
                                'endTime': '2037-12-31T23:59:59',
                                'timeType': 'local',
                            },
                            'doorRight': '1',
                            'RightPlan': [{
                                'doorNo': 1,
                                'planTemplateNo': '1'
                            }],
                        }
                    }
                    break
                case 3:
                    data = {
                        'UserInfoDelCond': {
                            'EmployeeNoList': [{ 'employeeNo': MemberNum }],
                            'operateType': 'byTerminal',
                            'terminalNoList': [1]
                        }
                    }
                    break
            }


            $.ajax({
                url: 'Users.aspx/FaceControl',
                type: 'POST',
                async: false,
                data: JSON.stringify({
                    data: JSON.stringify(data),
                    type: type
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    status = doc.d

                }
            });
            return status
        }

        function Start_Camera() {
            photo_base64 = ""
            var myModal = new bootstrap.Modal(document.getElementById('dialog3'))
            myModal.show()
            $('#webcam').show()
            $('#canvas').hide()

            $('#restart_photo').hide()
            $('#init_photo').hide()

            $('#View_image').html('')

            var context = canvas.getContext('2d');
            context.clearRect(0, 0, canvasElement.width, canvasElement.height);


            webcam.start()
                .then(result => {
                    console.log("webcam started");
                })
                .catch(err => {
                    Notiflix.Report.Warning('相機開啟失敗，請確認是否連接USB相機', '', '確定');
                    console.log(err);
                });
        }

        function Listen_Flag(Person_Number, btn_text) {
            var a = setInterval(function () {
                $.ajax({
                    url: 'Users.aspx/Listen_Flag',
                    type: 'POST',
                    async: false,
                    data: JSON.stringify({
                        Person_Number: Person_Number
                    }),
                    contentType: 'application/json; charset=UTF-8',
                    dataType: "json",       //如果要回傳值，請設成 json
                    success: function (doc) {
                        if (doc.d == 'Success') {
                            clearInterval(a)
                            clearTimeout(b)
                            Check_Mapping(Person_Number)
                            Notiflix.Loading.Remove(100)
                            if (btn_text == '確定') {
                                alert('新增成功。')
                                window.location.reload()
                            }
                            else {
                                alert('修改成功。')
                                window.location.reload()
                            }
                        }
                    }
                });
            },1000)
        }

        function Delete_Person(SYSID) {
            $.ajax({
                url: 'Users.aspx/Delete_Person',
                type: 'POST',
                data: JSON.stringify({
                    SYSID: SYSID
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    alert(doc.d)
                    bindtable()
                }
            });
        }
    </script>
</asp:Content>

