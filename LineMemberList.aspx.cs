using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineMemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string ListIdentity()
    {
        string sqlcmd = @"SELECT DISTINCT Agent_Team FROM DispatchSystem";
        var data = DBTool.Query(sqlcmd, new { });

        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string Update(string LMBID, string select)
    {
        string sqlcmd = @"update LineMember set Num = @select where LMBID = @LMBID";
        var data = DBTool.Query(sqlcmd, new { select = select, LMBID = LMBID });

        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string bindMember()
    {
        string sqlcmd = @" SELECT *
                            FROM LineMember";
        var data = DBTool.Query(sqlcmd, new { });

        return JsonConvert.SerializeObject(data);
    }


    [WebMethod(EnableSession = true)]
    public static void openpage(string ID)
    {
        HttpContext.Current.Session["LMBID"] = ID;
    }


    [WebMethod(EnableSession = true)]
    public static void openedit(string ID)
    {
        HttpContext.Current.Session["MemberEdit"] = ID;
    }


}