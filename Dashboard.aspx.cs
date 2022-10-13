using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string ListPunch()
    {
        string sql = "select top 10 a.*,b.SYSID from FaceRecognitionLog a left join Memberdata b on a.Number = b.MemberNum order by Date desc";
        var data = DBTool.Query(sql);
        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string ClassCount(string today_formate)
    {
        DateTime currentTime = DateTime.Now;
        int week = Convert.ToInt32(currentTime.DayOfWeek);
        week = week == 0 ? 7 : week;
        string start_time= currentTime.AddDays(1 - week).ToString("yyyy-MM-dd");
        string end_time = currentTime.AddDays(7 - week).ToString("yyyy-MM-dd");

        string All_week = "";
        string sql;
        sql = "select count(Week) [Count] from FaceRecognitionLog where Week = '1' and Date >= '"+start_time+ "' and Date < '"+end_time+"'";

        var data = DBTool.Query(sql);
        string week1 = data.FirstOrDefault().Count.ToString();
        All_week = week1 + ",";

        sql = "select count(Week) [Count] from FaceRecognitionLog where Week = '2' and Date >= '" + start_time + "' and Date < '" + end_time + "'";
        data = DBTool.Query(sql);
        string week2 = data.FirstOrDefault().Count.ToString();
        All_week = All_week + week2 + ",";

        sql = "select count(Week) [Count] from FaceRecognitionLog where Week = '3' and Date >= '" + start_time + "' and Date < '" + end_time + "'";
        data = DBTool.Query(sql);
        string week3 = data.FirstOrDefault().Count.ToString();
        All_week = All_week + week3 + ",";

        sql = "select count(Week) [Count] from FaceRecognitionLog where Week = '4' and Date >= '" + start_time + "' and Date < '" + end_time + "'";
        data = DBTool.Query(sql);
        string week4 = data.FirstOrDefault().Count.ToString();
        All_week = All_week + week4 + ",";

        sql = "select count(Week) [Count] from FaceRecognitionLog where Week = '5' and Date >= '" + start_time + "' and Date < '" + end_time + "'";
        data = DBTool.Query(sql);
        string week5 = data.FirstOrDefault().Count.ToString();
        All_week = All_week + week5;

        return All_week;
    }

    [WebMethod(EnableSession = true)]
    public static string See_Image(string SYSID)
    {
        string sql = "select Image_url from FaceRecognition_Log where SYSID = '"+SYSID+"'";
        var data = DBTool.Query(sql).FirstOrDefault();

        string Image_url = data.Image_url;
        return Image_url;
    }
}