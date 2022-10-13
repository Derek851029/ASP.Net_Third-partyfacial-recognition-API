using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CusCase 的摘要描述
/// </summary>
public class CusCase
{
    #region 參數
    public string SYSID { get; set; }
    public string cusCaseID { get; set; }
    public string phoneNumber { get; set; }
    public string phoneCell { get; set; }
    public string cusName { get; set; }
    public string cusSpecialTypeID { get; set; }
    public string sex { get; set; }
    public string address { get; set; }
    public string email { get; set; }
    public string levelID { get; set; }
    public DateTime caseDate { get; set; }
    public string caseSourceID { get; set; }
    public string opinionTypeID { get; set; }
    public string bigClassID { get; set; }
    public string midClassID { get; set; }
    public string RoadID { get; set; }
    public string stationID { get; set; }
    public string opinionTitle { get; set; }
    public string opinionContent { get; set; }
    public string replyTypeID { get; set; }
    public DateTime replyDate { get; set; }
    public string UserID { get; set; }
    public string UpdateUserID { get; set; }
    public DateTime createDate { get; set; }
    public DateTime updateDate { get; set; }
    public string cusCaseflag { get; set; }
    public string dispatchflag { get; set; }
    public string Score { get; set; }
    public string caseResult { get; set; }
    public string reviewFlag { get; set; }
    public string rejectFlag { get; set; }
    public string CaseStatus { get; set; }


    public string levelName { get; set; }
    public string caseSourceName { get; set; }
    public string opinionTypeName { get; set; }
    public string Agent_Name { get; set; }
    public string bigClassName { get; set; }
    public string cusSpecialTypeName { get; set; }
    public string midClassName { get; set; }
    public string roadName { get; set; }
    public string stationName { get; set; }
    public string replyTypeName { get; set; }
    #endregion

    /// <summary>
    /// 將新案件登入至資料庫並回傳案件編號
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <param name="phoneCell"></param>
    /// <param name="cusName"></param>
    /// <param name="cusSpecialTypeID"></param>
    /// <param name="sex"></param>
    /// <param name="address"></param>
    /// <param name="email"></param>
    /// <param name="levelID"></param>
    /// <param name="caseDate"></param>
    /// <param name="caseSourceID"></param>
    /// <param name="opinionTypeID"></param>
    /// <param name="bigClassID"></param>
    /// <param name="midClassID"></param>
    /// <param name="RoadID"></param>
    /// <param name="stationID"></param>
    /// <param name="opinionTitle"></param>
    /// <param name="opinionContent"></param>
    /// <param name="replyTypeID"></param>
    /// <param name="replyDate"></param>
    /// <param name="UserID"></param>
    /// <param name="createDate"></param>
    /// <param name="Score"></param>
    /// <returns></returns>
    public static List<CusCase> ADD( string phoneNumber, string phoneCell, string cusName, string cusSpecialTypeID
      , string sex, string address, string email, string levelID, string caseDate, string caseSourceID
      , string opinionTypeID, string bigClassID, string midClassID, string RoadID, string stationID
      , string opinionTitle, string opinionContent, string replyTypeID, string replyDate, string UserID, 
        string createDate, string Score)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Edit");
        sqlcmd.Append(" @flag = 1");
        sqlcmd.Append(string.Format(",@phoneNumber = '{0}'" , phoneNumber));
        sqlcmd.Append(string.Format(",@phoneCell = '{0}'", phoneCell));
        sqlcmd.Append(string.Format(",@cusName = '{0}'", cusName));
        sqlcmd.Append(string.Format(",@cusSpecialTypeID = {0}", string.IsNullOrEmpty(cusSpecialTypeID)? "0" : cusSpecialTypeID));
        sqlcmd.Append(string.Format(",@sex = {0}", string.IsNullOrEmpty(sex) ? "0" : sex));
        sqlcmd.Append(string.Format(",@address = '{0}'", address));
        sqlcmd.Append(string.Format(",@email = '{0}'", email));
        sqlcmd.Append(string.Format(",@levelID = {0}", string.IsNullOrEmpty(levelID) ? "0" : levelID));
        sqlcmd.Append(string.Format(",@caseDate = '{0}'", caseDate));
        sqlcmd.Append(string.Format(",@caseSourceID = {0}", string.IsNullOrEmpty(caseSourceID) ? "0" : caseSourceID));
        sqlcmd.Append(string.Format(",@opinionTypeID = {0}", string.IsNullOrEmpty(opinionTypeID) ? "0" : opinionTypeID));
        sqlcmd.Append(string.Format(",@bigClassID = {0}", string.IsNullOrEmpty(bigClassID) ? "0" : bigClassID));
        sqlcmd.Append(string.Format(",@midClassID = {0}", string.IsNullOrEmpty(midClassID) ? "0" : midClassID));
        sqlcmd.Append(string.Format(",@RoadID = {0}", string.IsNullOrEmpty(RoadID) ? "0" : RoadID));
        sqlcmd.Append(string.Format(",@stationID = {0}", string.IsNullOrEmpty(stationID) ? "0" : stationID));
        sqlcmd.Append(string.Format(",@opinionTitle = '{0}'", opinionTitle));
        sqlcmd.Append(string.Format(",@opinionContent = '{0}'", opinionContent));
        sqlcmd.Append(string.Format(",@replyTypeID = '{0}'", string.IsNullOrEmpty(replyTypeID) ? "0" : replyTypeID));
        sqlcmd.Append(string.Format(",@replyDate = '{0}'", replyDate));
        sqlcmd.Append(string.Format(",@UserID = '{0}'", UserID));
        sqlcmd.Append(string.Format(",@createDate = '{0}'", createDate));
        sqlcmd.Append(string.Format(",@Score = {0}", string.IsNullOrEmpty(Score) ? "0" : Score));

        var result = DBTool.Query<CusCase>(sqlcmd.ToString(), new { }).ToList();
        return result;
    }

    /// <summary>
    /// 依照狀態搜尋案件
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="cusCaseflag"></param>
    /// <param name="dispatchflag"></param>
    /// <param name="SYSID"></param>
    /// <returns></returns>
    public static List<CusCase> search(string flag = "0", string cusCaseflag = "0", string dispatchflag = "0", string SYSID = "0", string top = "",
        string phoneCell = "", string phoneNumber = "", string email = "", string cusCaseID = "",string rejectFlag = "0",string reviewFlag = "0")
    {
        StringBuilder sqlcmd = new StringBuilder("uspCusCase_Search ");
        sqlcmd.Append("@flag = @f");
        sqlcmd.Append(",@cusCaseflag = @c");
        sqlcmd.Append(",@dispatchflag = @d");
        sqlcmd.Append(",@phoneCell = @pc");
        sqlcmd.Append(",@phoneNumber = @pn");
        sqlcmd.Append(",@email = @e");
        sqlcmd.Append(",@top = @top");
        sqlcmd.Append(",@cusCaseID = @cid");
        sqlcmd.Append(",@SYSID = @id");
        sqlcmd.Append(",@rejectFlag = @rf");
        sqlcmd.Append(",@reviewFlag = @rvf");

        var result = DBTool.Query<CusCase>(sqlcmd.ToString(), new { 
                f=flag,
                c = cusCaseflag,
                d = dispatchflag,
                pc = phoneCell,
                pn = phoneNumber,
                e = email,
                top = top,
                cid = cusCaseID,
                id = SYSID,
                rf = rejectFlag,
                rvf = reviewFlag
        }).ToList();
        return result;
    }

    /// <summary>
    /// 更新案件資料
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="ID"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="phoneCell"></param>
    /// <param name="cusName"></param>
    /// <param name="cusSpecialTypeID"></param>
    /// <param name="sex"></param>
    /// <param name="address"></param>
    /// <param name="email"></param>
    /// <param name="levelID"></param>
    /// <param name="caseDate"></param>
    /// <param name="caseSourceID"></param>
    /// <param name="opinionTypeID"></param>
    /// <param name="bigClassID"></param>
    /// <param name="midClassID"></param>
    /// <param name="RoadID"></param>
    /// <param name="stationID"></param>
    /// <param name="opinionTitle"></param>
    /// <param name="opinionContent"></param>
    /// <param name="replyTypeID"></param>
    /// <param name="replyDate"></param>
    /// <param name="UserID"></param>
    /// <param name="createDate"></param>
    /// <param name="Score"></param>
    public static void update(string flag, string ID, string phoneNumber, string phoneCell, string cusName, string cusSpecialTypeID
      , string sex, string address, string email, string levelID, string caseDate, string caseSourceID
      , string opinionTypeID, string bigClassID, string midClassID, string RoadID, string stationID
      , string opinionTitle, string opinionContent, string UserID,
        string createDate, string Score)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Edit ");
        sqlcmd.Append("@flag = "+flag);
        sqlcmd.Append(",@SYSID = " + ID);

        sqlcmd.Append(string.Format(",@phoneNumber = '{0}'", phoneNumber));
        sqlcmd.Append(string.Format(",@phoneCell = '{0}'", phoneCell));
        sqlcmd.Append(string.Format(",@cusName = '{0}'", cusName));
        sqlcmd.Append(string.Format(",@cusSpecialTypeID = {0}", string.IsNullOrEmpty(cusSpecialTypeID) ? "0" : cusSpecialTypeID));
        sqlcmd.Append(string.Format(",@sex = {0}", string.IsNullOrEmpty(sex) ? "0" : sex));
        sqlcmd.Append(string.Format(",@address = '{0}'", address));
        sqlcmd.Append(string.Format(",@email = '{0}'", email));
        sqlcmd.Append(string.Format(",@levelID = {0}", string.IsNullOrEmpty(levelID) ? "0" : levelID));
        sqlcmd.Append(string.Format(",@caseDate = '{0}'", caseDate));
        sqlcmd.Append(string.Format(",@caseSourceID = {0}", string.IsNullOrEmpty(caseSourceID) ? "0" : caseSourceID));
        sqlcmd.Append(string.Format(",@opinionTypeID = {0}", string.IsNullOrEmpty(opinionTypeID) ? "0" : opinionTypeID));
        sqlcmd.Append(string.Format(",@bigClassID = {0}", string.IsNullOrEmpty(bigClassID) ? "0" : bigClassID));
        sqlcmd.Append(string.Format(",@midClassID = {0}", string.IsNullOrEmpty(midClassID) ? "0" : midClassID));
        sqlcmd.Append(string.Format(",@RoadID = {0}", string.IsNullOrEmpty(RoadID) ? "0" : RoadID));
        sqlcmd.Append(string.Format(",@stationID = {0}", string.IsNullOrEmpty(stationID) ? "0" : stationID));
        sqlcmd.Append(string.Format(",@opinionTitle = '{0}'", opinionTitle));
        sqlcmd.Append(string.Format(",@opinionContent = '{0}'", opinionContent));
        sqlcmd.Append(string.Format(",@UserID = '{0}'", UserID));
        sqlcmd.Append(string.Format(",@createDate = '{0}'", createDate));
        sqlcmd.Append(string.Format(",@Score = {0}", string.IsNullOrEmpty(Score) ? "0" : Score));


        var result = DBTool.Query<CusCase>(sqlcmd.ToString(), new { });
    }

    /// <summary>
    /// 以來電號碼搜尋資料
    /// </summary>
    /// <param name="flag"></param>
    /// <param name="phoneCell"></param>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static List<CusCase> search_by_phone(string flag = "0", string phoneCell = "none", string phoneNumber = "none")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append(@"uspCusCase");
        sqlcmd.Append(" @flag = " + flag);
        sqlcmd.Append(",@phoneCell = '" + phoneCell + "'");
        sqlcmd.Append(",@phoneNumber = '" + phoneNumber + "'");
        var result = DBTool.Query<CusCase>(sqlcmd.ToString(), new { }).ToList();
        return result;
    }


    public static void ADD_Review(string flag, string cusCaseflag, string userid, string reviewFlag, string ID, string rejectFlag)
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspCusCase_Edit @flag=@f");
        sqlcmd.Append(",@cusCaseID = @cid");
        sqlcmd.Append(",@reviewFlag = @rf");
        sqlcmd.Append(",@UserID = @u");
        sqlcmd.Append(",@cusCaseflag = @cf");
        sqlcmd.Append(",@rejectFlag = @rjf");

        DBTool.Query<CusCase>(sqlcmd.ToString(), new { 
            f = flag,
            cid = ID,
            rf = reviewFlag,
            u = userid,
            cf = cusCaseflag,
            rjf = rejectFlag
        });


    }


}