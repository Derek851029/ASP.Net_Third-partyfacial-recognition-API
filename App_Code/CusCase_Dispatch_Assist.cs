using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// CusCase_Dispatch_Assist 的摘要描述
/// </summary>
public class CusCase_Dispatch_Assist
{
	public int SYSID { get; set; }
	public string cusCaseID { get; set; }
	public int DispatchID { get; set; }
	public int TeamID { get; set; }
	public string dispatchReason { get; set; }
	public string UserID { get; set; }
	public DateTime dispatchDate { get; set; }
	public string dispatchAgent { get; set; }
	public string dispatchReply { get; set; }
	public DateTime createDate { get; set; }
	public string finishFlag { get; set; }
	public string TeamName { get; set; }
	public string assistTeamName { get; set; }
	public string Agent_Name { get; set; }
	public string opinionTitle { get; set; }
	public string Reply { get; set; }
	public string Flag { get; set; }
	public string reviewFlag { get; set; }


	public static void Edit(string flag="0",string ID="0", string DispatchID="0", string TeamID="0", string dispatchReason="", 
		string UserID="", string dispatchdate="", string cusCaseID = "")
	{
		StringBuilder sqlcmd = new StringBuilder();
		sqlcmd.Append("uspCusCase_Dispatch_Assist_Edit @flag=@f");
		sqlcmd.Append(",@ID = @sysid");
		sqlcmd.Append(",@dispatchID = @did");
		sqlcmd.Append(",@TeamID = @tid");
		sqlcmd.Append(",@dispatchReason = @dr");
		sqlcmd.Append(",@UserID = @uid");
		sqlcmd.Append(",@cusCaseID = @cid");

		var result = DBTool.Query<CusCase_Dispatch_Assist>(sqlcmd.ToString(), new { 
			f = flag,
			sysid = ID,
			did = DispatchID,
			tid = TeamID,
			dr = dispatchReason,
			uid = UserID,
			cid = cusCaseID
		});
	}

	public static List<CusCase_Dispatch_Assist> search(string flag="0",string ID = "0", string dispatchID = "0", string Status = "0", string finishFlag = "0")
	{
		StringBuilder sqlcmd = new StringBuilder();
		sqlcmd.Append("uspCusCase_Dispatch_Assist_Search @flag=@f");
		sqlcmd.Append(",@dispatchID = @did");
		sqlcmd.Append(",@finishFlag = @fs");
		sqlcmd.Append(",@ID = @sid");

		var result = DBTool.Query<CusCase_Dispatch_Assist>(sqlcmd.ToString(), new { 
			f = flag,
			did = dispatchID,
			fs = finishFlag,
			sid = ID
		}).ToList();
		return result;
	}
	
	public static void reply(string flag="0", string ID = "0", string status = "0", string response = "", string agent = "", string date = "", string userid = "")
	{
		StringBuilder sqlcmd = new StringBuilder();
		sqlcmd.Append("uspCusCase_Dispatch_Assist_Edit @flag="+flag);
		sqlcmd.Append(",@Status = " + status);
		sqlcmd.Append(string.Format(",@dispatchReply = N'{0}'", response));
		sqlcmd.Append(string.Format(",@dispatchAgent = N'{0}'", agent));
		sqlcmd.Append(string.Format(",@UserID = N'{0}'", userid));
		sqlcmd.Append(string.Format(",@Date = N'{0}'", date));
		sqlcmd.Append(",@ID = " + ID);

		var result = DBTool.Query<CusCase_Dispatch_Assist>(sqlcmd.ToString(), new { }).ToList();
		
	}


}