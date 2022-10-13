using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Parent_Reg : System.Web.UI.Page
{
    protected string seqno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        seqno = Request.Params["seqno"];
    }

    [WebMethod(EnableSession = true)]
    public static string Confirm(string UserID, string Student_Number, string Name)
    {
        string sql = "select Serial_Number from Person_List where Serial_Number = '" + Student_Number + "'";
        var b = DBTool.Query(sql);
        if (b.Any())
        {
            sql = "select UserID from MemberData where UserID = '" + UserID + "'";
            var a = DBTool.Query(sql);
            if (a.Any())
            {
                sql = "update MemberData set MName = '" + Name + "', MIdentity = 'Parent' where UserID = '" + UserID + "'";
                DBTool.Query(sql);
            }
            else
            {
                sql = "insert into MemberData (MName,MIdentity,UserID) values('" + Name + "','Parent','" + UserID + "')";
                DBTool.Query(sql);
            }
            sql = "update Person_List set Parent_UserID = '" + UserID + "' where Serial_Number = '" + Student_Number + "'";
            DBTool.Query(sql);
        }
        else
        {
            sql = "insert into Parent_Line_Register(Serial_Number,Parent_Name,UserID,Flag) values('"+ Student_Number + "','"+ Name + "','"+ UserID + "',0)";
            DBTool.Query(sql);
        }
        return "success";
    }
    
}