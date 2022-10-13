$(function () {
    bindtable()
    List_Teacher()
    Listener_event()
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
        url: 'Class_Managerment.aspx/bindtable',
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
                    { "data": "SYSID" },
                    { "data": "Class_Name" },
                    {
                        "data": "SYSID",
                        "render": function (data, type, full, meta) {
                            var bt = '<button id="view_' + data + '" type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#dialog1" title="Edit"><span class="glyphicon glyphicon-pencil"></span>&nbsp;修改</button>';
                            return bt;
                        }
                    },
                    {
                        "data": "SYSID",
                        "render": function (data, type, full, meta) {
                            var bt = '<button id="delete_' + data + '" type="button" class="btn btn-danger"  title="Delete"><span class="glyphicon glyphicon-remove"></span>&nbsp;刪除</button>';
                            return bt;
                        }
                    }
                ]
            });
            $('#table1 tbody').unbind('click').
                on('click', 'button[id^=view_]', function () {
                    var table = $('#table1').DataTable();
                    var SYSID = $(this).attr('id').split('_')[1]
                    $('#SYSID').val(SYSID);
                    $.each(full_data, function (index, obj) {
                        var ID = obj.SYSID
                        if (SYSID == ID) {
                            initial(full_data[index])
                            return false
                        }
                    })
                    $('#btn_add').html('<span class="glyphicon glyphicon-pencil"></span>修改')
                }).
                on('click', 'button[id^=delete_]', function () {
                    var table = $('#table1').DataTable();
                    var SYSID = $(this).attr('id').split('_')[1]
                    Delete_Class(SYSID)
                })
        }
    });
}

function initial(data) {
    $('#Class_Name').val(data.Class_Name)
    $('#Teacher').val(data.UserID)
    console.log($('#Teacher').val())
}

function List_Teacher() {
    $.ajax({
        url: 'Class_Managerment.aspx/List_Teacher',
        type: 'POST',
        data: JSON.stringify({
        }),
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",       //如果要回傳值，請設成 json
        success: function (doc) {
            var data = eval(doc.d)
            var select = $('#Teacher')
            select.html('')
            select.append('<option value="none">Please select teacher．．．</option>')
            console.log(data);
            $.each(data, function (index, obj) {
                if (obj.MName == '') {
                    return
                }
                else {
                    select.append('<option value="' + obj.UserID + '">' + obj.MName + '</option>')
                }
                
            })
        }
    });
}

function Add_Class() {
    var SYSID = $('#SYSID').val()
    var Class_Name = $('#Class_Name').val()
    //var Teacher_UserID = $('#Teacher').val()
    //var Teacher_Name = $('#Teacher option:selected').text();
    var btn_text = $('#btn_add').text()
    //console.log(Class_Name)
    //console.log(Teacher_Name)
    if (Class_Name == '') {
        alert('請輸入部門名稱。')
        return false
    }
    //if (Teacher == 'none') {
    //    alert('請選擇班導師。')
    //    return false
    //}
    
    $.ajax({
        url: 'Class_Managerment.aspx/Add_Class',
        type: 'POST',
        data: JSON.stringify({
            SYSID: SYSID,
            Class_Name: Class_Name,
            btn_text: btn_text,
        }),
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",       //如果要回傳值，請設成 json
        success: function (doc) {
            var data = doc.d
            if (data == "Success") {
                if (btn_text == '確定') {
                    alert('新增成功。')
                }
                else {
                    alert('修改成功。')
                }
                window.location.reload()
            }
            else {
                alert('伺服器發生錯誤，請重新嘗試或聯絡管理員')
            }
        }
    });
}

function Delete_Class(SYSID) {
    $.ajax({
        url: 'Class_Managerment.aspx/Delete_Class',
        type: 'POST',
        data: JSON.stringify({
            SYSID: SYSID,
        }),
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",       //如果要回傳值，請設成 json
        success: function (doc) {
            var data = doc.d
            alert(data)
            window.location.reload()
        }
    });
}