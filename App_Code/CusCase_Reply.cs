using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CusCase_Reply 的摘要描述
/// </summary>
public class CusCase_Reply
{
    public string SYSID { get; set; }
	public string cusCaseID { get; set; }
	public string UserID { get; set; }
	public DateTime createDate { get; set; }
	public string caseStatus { get; set; }
	public string caseResult { get; set; }

	public string Agent_Name { get; set; }

	/// <summary>
	/// 回復歷程
	/// </summary>
	/// <param name="caseid"></param>
	/// <returns></returns>
	public static string Search(string caseid)
	{
		StringBuilder sqlcmd = new StringBuilder();
		sqlcmd.Append("uspCusCase_Reply @flag = 1");
		sqlcmd.Append(string.Format(",@ID = "+caseid));

		var result = DBTool.Query<CusCase_Reply>(sqlcmd.ToString());
		return JsonConvert.SerializeObject(result);
	}

	/// <summary>
	/// 新增回覆
	/// </summary>
	/// <param name="caseid"></param>
	/// <param name="UserID"></param>
	/// <param name="createDate"></param>
	/// <param name="caseStatus"></param>
	/// <param name="caseResult"></param>
	/// <param name="score"></param>
	/// <returns></returns>
	public static string ADD(string caseid, string UserID, string createDate, string caseStatus, string caseResult, string replyDate, string replyType)
	{
		StringBuilder sqlcmd = new StringBuilder();
		sqlcmd.Append("uspCusCase_Reply @flag=2");
		sqlcmd.Append(",@ID = " + caseid);
		sqlcmd.Append(string.Format(",@UserID = N'{0}'", UserID));
		sqlcmd.Append(string.Format(",@createDate = N'{0}'",createDate));
		sqlcmd.Append(",@caseStatus = " + caseStatus);
		sqlcmd.Append(string.Format(",@caseResult = N'{0}'" , caseResult));
		sqlcmd.Append(",@replyType = " + replyType);
		sqlcmd.Append(string.Format(",@replyDate = N'{0}'", replyDate));

		var result = DBTool.Query<CusCase_Reply>(sqlcmd.ToString());
		return JsonConvert.SerializeObject(result);
	}


}