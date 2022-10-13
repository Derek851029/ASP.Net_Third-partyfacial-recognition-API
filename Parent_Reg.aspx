<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Parent_Reg.aspx.cs" Inherits="Parent_Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/jquery.min.js"></script>
    <script src="bootstrap-5.0.2-dist/js/bootstrap.min.js"></script>
    <link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title></title>
</head>
<body>
    <section class="vh-100 bg-image" style="background-image: url('Reg_img.jpg');">
      <div class="mask d-flex align-items-center h-100 gradient-custom-3">
        <div class="container h-100">
          <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-9 col-lg-7 col-xl-6">
              <div class="card" style="border-radius: 15px;">
                <div class="card-body p-5">
                  <h2 class="text-uppercase text-center mb-5">Basic Information</h2>

                  <form>

                    <div class="form-outline mb-4">
                      <input type="text" id="Number" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Example1cg">Student Number</label>
                    </div>

                    <div class="form-outline mb-4">
                      <input type="text" id="Name" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Example3cg">Parent's Name</label>
                    </div>

                    <div class="d-flex justify-content-center">
                      <button type="button" class="btn btn-success btn-block btn-lg gradient-custom-4 text-body" onclick="Confirm()">Confirm</button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <style>
        .gradient-custom-3 {
          /* fallback for old browsers */
          background: #84fab0;

          /* Chrome 10-25, Safari 5.1-6 */
          background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5));

          /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
          background: linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5))
        }
        .gradient-custom-4 {
          /* fallback for old browsers */
          background: #84fab0;

          /* Chrome 10-25, Safari 5.1-6 */
          background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1));

          /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
          background: linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1))
        }
    </style>
    <script>
        var seqno = '<%= seqno %>';
        $(function () {
        })

        function Confirm() {
            var UserID = seqno
            var Student_Number = 'S' + $('#Number').val()
            var Name = $('#Name').val()
            if (Student_Number == '' || Name == '') {
                alert('Please enter basic information')
                return false
            }
            $.ajax({
                url: 'Parent_Reg.aspx/Confirm',
                type: 'POST',
                async: false,
                data: JSON.stringify({
                    UserID: UserID,
                    Student_Number: Student_Number,
                    Name: Name
                }),
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",       //如果要回傳值，請設成 json
                success: function (doc) {
                    alert('Add completed')
                    window.location.reload()
                }
            });
        }
    </script>
</body>
</html>
