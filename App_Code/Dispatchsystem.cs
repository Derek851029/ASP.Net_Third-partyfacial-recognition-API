using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Dispatchsystem 的摘要描述
/// </summary>
public class Dispatchsystem : System.Web.UI.Page
{
    public int SYSID { get; set; }
    public string Agent_ID { get; set; }
    public string Agent_Name { get; set; }
    public string Agent_Status { get; set; }
    public string Agent_ExtNum { get; set; }
    public string Agent_Team { get; set; }
    public string TeamID { get; set; }
    public string UserID { get; set; }
    public string Password { get; set; }
    public string Agent_LV { get; set; }
    public string Role_ID { get; set; }
    public string ROLE_NAME { get; set; }
    public string IP { get; set; }

    public Dispatchsystem()
    {
        
    }

    /// <summary>
    /// 初始化DispathSystem
    /// </summary>
    /// <param name="Acc"></param>
    /// <param name="Pwd"></param>
    public Dispatchsystem(string Acc,string Pwd,out string Status, out string extn)
    {
        //初始化OutPut的值
        Status = "";
        extn = "";

        string sqlcmd = string.Format(
            @"SELECT top 1 * FROM DispatchSystem Where
                UserID = N'{0}'
                AND Password = N'{1}'
                AND Agent_Status != N'離職'", Acc, Pwd);
        var Agent = DBTool.Query<Dispatchsystem2>(sqlcmd, new { });
        if (Agent.Any())
        {
            foreach (var item in Agent)
            {
                UserID = item.UserID;
                Password = item.Password;
                Agent_ID = item.Agent_ID;
                Agent_Name = item.Agent_Name;
                Role_ID = item.Role_ID;
                Agent_ExtNum = item.Agent_ExtNum;
                Agent_Team = item.Agent_Team;
                TeamID = item.TeamID;
            }
            Status = "true";
            extn = Agent_ExtNum;
        }
        else
        {
            Status = "false";
        }
    }

    /// <summary>
    /// 初始化DispathSystem form MobileLogin
    /// </summary>
    /// <param name="extn"></param>
    /// <param name="Status"></param>
    public Dispatchsystem(string extn, out string Status)
    {
        Status = "";
        string sqlcmd = string.Format(
            @"SELECT top 1 * FROM DispatchSystem Where
                Agent_ExtNum = N'{0}'
                AND Agent_Status != N'離職' order by sysid desc", extn);
        var Agent = DBTool.Query<Dispatchsystem2>(sqlcmd, new { });
        if (Agent.Any())
        {
            foreach (var item in Agent)
            {
                UserID = item.UserID;
                Password = item.Password;
                Agent_ID = item.Agent_ID;
                Agent_Name = item.Agent_Name;
                Role_ID = item.Role_ID;
                Agent_ExtNum = item.Agent_ExtNum;
                Agent_Team = item.Agent_Team;
                TeamID = item.TeamID;
            }
            Status = "true";
        }
        else
        {
            Status = "false";
        }
    }

    /// <summary>
    /// Session設置
    /// </summary>
    public void SessionSet()
    {
        Session["UserID"] = UserID;
        Session["p"] = Password;
        Session["UserIDNO"] = Agent_ID;
        Session["UserIDNAME"] = Agent_Name;
        Session["RoleID"] = Role_ID;
        Session["Agent_ExtNum"] = Agent_ExtNum;
        Session["Agent_Team"] = Agent_Team;
        Session["TeamID"] = TeamID;
    }

    public List<Dispatchsystem2> SerchWithRole() {
        var AgentList = DBTool.Query<Dispatchsystem2>(
            @"SELECT d.[SYSID]
	                ,d.[Agent_ID]
	                ,d.[Agent_Name]
	                ,d.[Agent_ExtNum]
	                ,d.[TeamID]
	                ,d.[UserID]
	                ,d.[Password]
	                ,d.[Agent_LV]
	                ,d.[Role_ID]
	                ,r.ROLE_NAME
              FROM DispatchSystem  d
              LEFT JOIN ROLELIST r on d.Role_ID = r.ROLE_ID
              WHERE Agent_Status = '在職'", new { }).ToList();
        return AgentList;
    }

    public List<Dispatchsystem2> SerchByAgentID(string Agent_ID)
    {
        var AgentList = 
            DBTool.Query<Dispatchsystem2>(
                @"SELECT * FROM DispatchSystem WHERE Agent_ID=@AgentID", new { AgentID = Agent_ID }).ToList();
        return AgentList;
    }

    public void Delete(string Agent_ID)
    {
        //TODO 更改至Class DispatchSystem Method : Delete
        string sqlstr = 
            @"UPDATE DispatchSystem 
              SET Agent_Status='離職', 
                  UpdateTime=@UpdateTime 
              WHERE Agent_ID = @Agent_ID 
                AND Agent_Status = '在職'";
        DBTool.Query<Dispatchsystem2>(sqlstr, new { Agent_ID = Agent_ID, UpdateTime = DateTime.Now });
    }

    public void Insert(AgentList agentList, out string statusT)
    {
        string Sqlstr;
        string sql_pass = "";

        statusT = "";
        //TODO 更改至Class DispatchSystem Method : Insert
        //if (Flag == "0")
        //{
        //    //TODO INSERT Agent_Extn Value to DispatchSystem
        //    Sqlstr = @"INSERT INTO DispatchSystem
        //               (Agent_ID,Agent_Name, 
        //                Agent_Status,Agent_ExtNum, 
        //                UserID,Password, 
        //                Agent_LV,Role_ID,IP)
        //               VALUES(@Agent_ID,@Agent_Name, 
        //                    @Agent_Status,
        //                    @UserID,@Password, 
        //                    @Agent_LV,@Role_ID,@IP)";
        //    back = "new";
        //}
        //else
        //{
        //    Sqlstr = @"UPDATE DispatchSystem SET 
        //            Agent_Name = @Agent_Name, 
        //            Agent_Company = @Agent_Company, 
        //            Agent_Team = @Agent_Team, 
        //            UserID = @UserID, 
        //            Agent_LV = @Agent_LV, 
        //            Role_ID = @Role_ID, 
        //            IP = @IP,
        //            UpdateTime = @UpdateTime " + sql_pass + "WHERE Agent_ID = @Agent_ID AND Agent_Status != '離職' ";
        //    back = "update";
        //}

        //var b = DBTool.Query<ClassTemplate>(Sqlstr, new
        //{
        //    Agent_ID = Agent_ID.Trim(),
        //    Agent_Name = Agent_Name.Trim(),
        //    Agent_Status = "在職",
        //    UserID = UserID.Trim(),
        //    Role_ID = Role_ID,
        //    Agent_LV = Agent_LV,
        //    Password = Password,
        //    IP = IP,
        //    UpdateTime = DateTime.Now
        //});
    }


    /// <summary>
    /// Dispatchsystem2 的摘要描述
    /// </summary>
    public class Dispatchsystem2
    {
        public int SYSID { get; set; }
        public string Agent_ID { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_Status { get; set; }
        public string Agent_ExtNum { get; set; }
        public string Agent_Team { get; set; }
        public string TeamID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Agent_LV { get; set; }
        public string Role_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string IP { get; set; }
    }
}

public class AgentList
{
    public string Agent_ID { get; set; }
    public string Agent_Name { get; set; }
    public string Agent_Extn { get; set; }
    public string Agent_Team { get; set; }
    public string TeamID { get; set; }
    public string UserID { get; set; }
    public string Password { get; set; }
    public string Role_ID { get; set; }
    public string Agent_LV { get; set; }
    public string Flag { get; set; }
    public string IP { get; set; }
    public void Check(out string s) {
        s = "";
        StringBuilder statusTotal = new StringBuilder();
        if (!String.IsNullOrEmpty(Agent_ID))
            Agent_ID = Agent_ID.Trim();
        else
            statusTotal.Append("請填寫【人員編號】\n");

        if (!String.IsNullOrEmpty(Agent_Name))
        {
            if (JASON.IsNumericOrLetterOrChinese(Agent_Name) != true)
                statusTotal.Append("【人員姓名】只能輸入數字、英文或中文。\n");
            else
                Agent_Name = Agent_Name.Trim();
        }
        else
            statusTotal.Append("請填寫【人員姓名】\n");

        if (!String.IsNullOrEmpty(Agent_Extn))
        {
            if (JASON.IsNumeric(Agent_Extn) != true)
                statusTotal.Append("【分機號碼】只能輸入數字\n");
            else
                Agent_Extn = Agent_Extn.Trim();
        }
        else
            statusTotal.Append("請填寫【分機號碼】\n");

        if (!String.IsNullOrEmpty(UserID))
        {
            if (JASON.IsNumericOrLetter(UserID) != true)
                statusTotal.Append("【登入帳號】只能是英文或數字。\n");
            else
                UserID = UserID.Trim();
        }
        else
            statusTotal.Append("請填寫【登入帳號】\n");

        if (!String.IsNullOrEmpty(IP))
        {
            if (IP.Length > 15)
                statusTotal.Append("【電腦IP】不能超過１５個字元。\n");
            else
                IP = IP.Trim();
        }
        else
            statusTotal.Append("請填寫【電腦IP】\n");

        if (Flag == "0")
        {
            //string sqlcmd = @"SELECT TOP 1 SYSID FROM DispatchSystem WHERE Agent_Status != '離職' AND Agent_ID=@Agent_ID";
            //var a = DBTool.Query<Dispatchsystem>(sqlcmd, new { Agent_ID = Agent_ID });
            //if (a.Any())
            //    statusTotal.Append("已有相同的【人員編號】\n");

            ////TODO 更改至Class DispatchSystem Method : Insert2
            //if (!String.IsNullOrEmpty(Password))
            //    if (JASON.IsNumericOrLetter(Password) != true)
            //        statusTotal.Append("【登入密碼】只能是英文或數字。\n");
            //    else
            //        Password = Password.Trim();
            //else
            //    statusTotal.Append("請填寫【登入密碼】\n");
        }
        else
        {
            //TODO 更改至Class DispatchSystem Method : Update
            if (Password.Trim() != "")
            {

                if (!String.IsNullOrEmpty(Password))
                    if (JASON.IsNumericOrLetter(Password) != true)
                        statusTotal.Append("【登入密碼】只能是英文或數字。\n");
                    else
                        Password = Password.Trim();
                else
                    statusTotal.Append("請填寫【登入密碼】\n");
                //sql_pass = ", Password = @Password ";
            }
        }

        if (Agent_LV != "10" && Agent_LV != "20")
            statusTotal.Append("沒有此【人員權限】\n");

        var Sqlstr = @"SELECT TOP 1 Role_ID 
                    FROM ROLELIST 
                    WHERE OPEN_DEL != 'N' 
                      AND Role_ID=@Role_ID";
        var a = DBTool.Query<Dispatchsystem>(Sqlstr, new { Role_ID = Role_ID });
        if (!a.Any())
            statusTotal.Append("沒有此【系統選單權限】\n");

        Sqlstr = @"SELECT UserID 
                   FROM DispatchSystem 
                   WHERE Agent_Status != '離職' 
                     AND UserID=@UserID";
        a = DBTool.Query<Dispatchsystem>(Sqlstr, new { UserID = UserID });
        if (a.Any())
            statusTotal.Append("已有相同的【登入帳號】\n");
        s = statusTotal.ToString();
    }
}
