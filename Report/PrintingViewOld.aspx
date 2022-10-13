<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintingViewOld.aspx.cs" Inherits="Report_PrintingViewOld" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head2" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="12pt" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="800px">
        <LocalReport ReportPath="Report\PrintingServiceOld.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

