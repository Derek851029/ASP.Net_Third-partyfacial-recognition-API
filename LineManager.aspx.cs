using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LineManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string bindtable()
    {
        string sql = @"select * from LineMember where flag = '0'";
        var data = DBTool.Query(sql);
        return JsonConvert.SerializeObject(data);
    }
}