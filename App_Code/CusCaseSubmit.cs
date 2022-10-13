using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CusCaseSubmit 的摘要描述
/// </summary>
public class CusCaseSubmit
{
    public string SYSID { get; set; }
    public string cusCaseID { get; set; }
    public string cusCaseFlag { get; set; }
    public string SubmitUserID { get; set; }
    public string reply { get; set; }
    public string replyUserID { get; set; }
    public DateTime SubmitDate { get; set; }
    public DateTime replyDate { get; set; }
    public string replyFlag { get; set; }
    public string reviewFlag { get; set; }


    public string opinionTitle { get; set; }
    public string levelName { get; set; }
    public string levelID { get; set; }
    public string cusSpecialTypeName { get; set; }
    public string cusSpecialTypeID { get; set; }
    public string replyTypeName { get; set; }
    public string replyTypeID { get; set; }
    public string UserID { get; set; }
    public string Agent_Name { get; set; }




    public static void SubmitCase(string flag = "0", string reply = "", string ID = "0", string UserID = "", string date = "", string replyflag = "0", string cusCaseID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspCusCase_Submit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @sysid ");
        sqlcmd.Append(" ,@UserID = @u ");
        sqlcmd.Append(" ,@reply = @r ");
        sqlcmd.Append(" ,@replyDate = @rd ");
        sqlcmd.Append(" ,@replyFlag = @rf ");
        sqlcmd.Append(" ,@cusCaseID = @cid ");

        DBTool.Query<CusCase>(sqlcmd.ToString(), new
        {
            f = flag,
            sysid = ID,
            u = UserID,
            r = reply,
            rd = date,
            rf = replyflag,
            cid = cusCaseID
        });
    }

    public static List<CusCaseSubmit> SubmitCaseSearch(string flag = "0", string ID = "0", string cusCaseFlag="0", string reviewFlag="0", string cusCasaeID = "")
    {
        StringBuilder sqlcmd = new StringBuilder("uspCusCase_Submit ");
        sqlcmd.Append(" @flag = @f ");
        sqlcmd.Append(" ,@ID = @sysid ");
        sqlcmd.Append(" ,@cusCaseFlag = @cf ");
        sqlcmd.Append(" ,@reviewFlag = @rf ");
        sqlcmd.Append(" ,@cusCaseID = @cid ");

         var result = DBTool.Query<CusCaseSubmit>(sqlcmd.ToString(), new
        {
            f = flag,
            sysid = ID,
            cf = cusCaseFlag,
            rf = reviewFlag,
            cid = cusCasaeID
        }).ToList();

        return result;
    }

}