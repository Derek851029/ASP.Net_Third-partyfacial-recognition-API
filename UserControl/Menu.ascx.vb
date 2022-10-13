Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data
Imports CMS_db

Partial Class UserControl_Menu
    Inherits System.Web.UI.UserControl
    Public Connsql As New CMS_db

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Menu_BindDB()
            End If
        Catch ex As Exception
            Response.Redirect("~/Error.aspx")
        End Try
    End Sub

    Sub Menu_BindDB()
        Try
            Dim menu As String = ""
            Dim TREE_ID As String = ""
            Dim txt As String = ""
            Dim mail As String = ""
            Dim Conn As New SqlConnection(Connsql.ConnStr())

            menu = ""
            menu += "<span class='glyphicon glyphicon-user'></span>&nbsp;登入人員：" & Session("UserIDNAME") & "&nbsp;<span class='caret'></span>"
            agent_info.InnerHtml = menu

            menu = ""
            menu += "<li role='presentation'><a role='menuitem'>&nbsp;人員編號：" & Session("UserID") & "&nbsp;&nbsp;</a></li>"
            menu += "<li role='presentation'><a role='menuitem'>&nbsp;人員姓名：" & Session("UserIDNAME") & "&nbsp;&nbsp;</a></li>"
            user_li.InnerHtml = menu
        Catch ex As Exception
            Response.Redirect("~/Error.aspx")
        End Try
    End Sub

    Protected Sub Logout(sender As Object, e As System.EventArgs)
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Redirect("~/Logout.aspx")
    End Sub
End Class

