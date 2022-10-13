using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ContextContent 的摘要描述
/// </summary>
public class ContextContent
{
    public int SYSID { get; set; }
    public string UserID { get; set; }
    public int TypeID { get; set; }
    public string Content { get; set; }
    public DateTime createDate { get; set; }
    public DateTime updateDate { get; set; }
    public int Show_Flag { get; set; }
    public int del_flag { get; set; }
    public string Agent_Name { get; set; }
    public string TypeName { get; set; }

    public static string Search(string flag="0", string typeid = "0", string showflag = "0")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspContextContent");
        sqlcmd.Append(" @flag = " + flag);
        sqlcmd.Append(",@TypeID = " + typeid);
        sqlcmd.Append(",@Show_Flag = " + showflag);

        var result = DBTool.Query<ContextContent>(sqlcmd.ToString() , new { });
        return JsonConvert.SerializeObject(result);
    }

    public static void ADD(string typeid, string userid, string content)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspContextContent");
        sqlcmd.Append(" @flag = 5");
        sqlcmd.Append(" ,@TypeID = "+typeid);
        sqlcmd.Append(string.Format(" ,@Content = N'{0}'", content));
        sqlcmd.Append(string.Format(" ,@UserID = N'{0}'", userid));

        DBTool.Query<ContextContent>(sqlcmd.ToString(), new { });
    }

    public static void update(string flag, string ID)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspContextContent");
        sqlcmd.Append(" @flag = "+flag);
        sqlcmd.Append(",@SYSID = " + ID);

        DBTool.Query<ContextContent>(sqlcmd.ToString(), new { });
    }

    public static void update_content(string flag, string ID, string content, string type, string userid)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspContextContent");
        sqlcmd.Append(" @flag = " + flag);
        sqlcmd.Append(",@SYSID = " + ID);
        sqlcmd.Append(",@TypeID = " + type);
        sqlcmd.Append(",@Content = N'" + content + "'");
        sqlcmd.Append(",@UserID = N'" + userid + "'");

        DBTool.Query<ContextContent>(sqlcmd.ToString(), new { });
    }


}