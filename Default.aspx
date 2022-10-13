<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
  
    <div id="map">

    </div>

    <script>
        $(function () {
            makeRequest();
        });

        function makeRequest() {
            let lat = '';
            let lng = ''

            navigator.geolocation.watchPosition((position) => {
                console.log(position.coords);
                lat = position.coords.latitude;
                lng = position.coords.longitude;
                console.log(lat)
                console.log(lng)

                let txt = '';
                txt += '<iframe width="50%" height="300" frameborder="0" ';
                txt += 'src="https://www.google.com/maps?';
                txt += 'q=' + lat + ',' + lng;
                txt += '&hl=zh-TW&output=embed" '
                txt += '</iframe>';
                $('#map').html(txt);
            });
        }
    </script>
</asp:Content>

