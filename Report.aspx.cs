using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string bindtable(string startDate, string endDate)
    {
        string sql = "select * from FaceRecognitionLog where Date > @startDate and Date <=@endDate";
        var data = DBTool.Query(sql,new { startDate = startDate, endDate = endDate });
        return JsonConvert.SerializeObject(data);
    }
}