<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintingService.aspx.cs" Inherits="Report_PrintingService" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    <script src="../js/recorder/index.js"></script>
    <script src="../js/recorder/cfrm_recorder.js"></script>
    <script src="../js/recorder/cfrm_recorder_config.js"></script>
    <div style="width:80%">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Report\PrintingService.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>

