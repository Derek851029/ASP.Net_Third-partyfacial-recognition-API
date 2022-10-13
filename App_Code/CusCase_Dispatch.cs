using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CusCase_Dispatch 的摘要描述
/// </summary>
public class CusCase_Dispatch
{
    public string SYSID { get; set; }
    public string cusCaseID { get; set; }
    public string TeamID { get; set; }
    public string dispatchReason { get; set; }
    public string UserID { get; set; }
    public DateTime dispatchDate { get; set; }
    public string dispatchAgent { get; set; }
    public string dispatchReply { get; set; }
    public DateTime createDate { get; set; }
    public string finishFlag { get; set; }
    public string reviewFlag { get; set; }


    public string TeamName { get; set; }
    public string Agent_Name { get; set; }
    public string opinionTitle { get; set; }
    public string Reply { get; set; }
    public string Flag { get; set; }


    /// <summary>
    /// 搜尋子單資料
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="ID"></param>
    /// <param name="caseid"></param>
    /// <returns></returns>
    public static List<CusCase_Dispatch> Search(string flag = "0", string ID = "0", string Status = "0", string caseid = "0")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Dispatch_Search @flag="+flag);
        sqlcmd.Append(",@ID = " + ID);
        sqlcmd.Append(",@Status = " + Status);
        sqlcmd.Append(string.Format(",@cusCaseID = '{0}'", caseid));

        
        var result = DBTool.Query<CusCase_Dispatch>(sqlcmd.ToString(), new { }).ToList();
        return result;
        
    }
    
    public static List<CusCase_Dispatch> Reply_Search(string flag = "0", string ID = "0", string Status = "0", string caseid = "0")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Dispatch_Reply @flag="+flag);
        sqlcmd.Append(",@ID = " + ID);
        //sqlcmd.Append(",@Status = " + Status);
        //sqlcmd.Append(string.Format(",@cusCaseID = '{0}'", caseid));

        var result = DBTool.Query<CusCase_Dispatch>(sqlcmd.ToString(), new { }).ToList();
        return result;
        
    }
    

    /// <summary>
    /// 新增轉派子單
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="TeamID"></param>
    /// <param name="dispatchReason"></param>
    /// <param name="UserID"></param>
    /// <param name="dispatchdate"></param>
    /// <returns></returns>
    public static string ADD(string ID, string TeamID, string dispatchReason, string UserID, string dispatchdate)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Dispatch_Edit @flag=1");
        sqlcmd.Append(",@ID = " + ID);
        sqlcmd.Append(",@TeamID = " + TeamID);
        sqlcmd.Append(string.Format(",@dispatchReason = '{0}'", dispatchReason));
        sqlcmd.Append(string.Format(",@UserID = {0}",UserID));
        sqlcmd.Append(string.Format(",@Date='{0}'", dispatchdate));

        var result = DBTool.Query<CusCase_Dispatch>(sqlcmd.ToString(), new { });
        return JsonConvert.SerializeObject(result);
    }

    /// <summary>
    /// 轉派子單回覆
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="ID"></param>
    /// <param name="status"></param>
    /// <param name="response"></param>
    /// <param name="agent"></param>
    /// <param name="date"></param>
    public static void UPDATE(string flag ="0", string ID = "0", string status = "0", string response = "", string agent = "", string date = "",string userid = "")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Dispatch_Edit @flag = " + flag);
        sqlcmd.Append(",@Status = " + status);
        sqlcmd.Append(string.Format(",@dispatchReply = N'{0}'", response));
        sqlcmd.Append(string.Format(",@dispatchAgent = N'{0}'", agent));
        sqlcmd.Append(string.Format(",@UserID = N'{0}'", userid));
        sqlcmd.Append(string.Format(",@Date = N'{0}'", date));
        sqlcmd.Append(",@ID = " + ID);

        DBTool.Query<CusCase_Dispatch>(sqlcmd.ToString(), new { });

    }

    public static void dispatch_edit(string flag = "0", string cusCaseID = "", string sysID = "0", string dispatchReason = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspCusCase_Dispatch_Edit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@cusCaseID = @cid ");
        sqlcmd.Append(" ,@ID = @sysid ");
        sqlcmd.Append(" ,@dispatchReason = @dr ");

        DBTool.Query<CusCase_Dispatch>(sqlcmd.ToString(), new { 
            f = flag,
            cid = cusCaseID,
            sysid = sysID,
            dr = dispatchReason
        });
    }

}