using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _0060010005 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string bind_data()
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append(@"SELECT a.*, b.ROLE_NAME FROM DispatchSystem  a
                        LEFT JOIN ROLELIST b ON a.Role_ID = b.ROLE_ID
                        WHERE a.Agent_Status != '離職'");

        var result = DBTool.Query<agentparams>(sqlcmd.ToString(), new { });

        return JsonConvert.SerializeObject(result);
    }

    [WebMethod(EnableSession = true)]//或[WebMethod(true)]
    public static string ROLELIST_List()
    {
        string sqlcmd = @"SELECT ROLE_ID, ROLE_NAME FROM ROLELIST WHERE OPEN_DEL = 'Y' ";
        var a = DBTool.Query<agentparams>(sqlcmd).ToList().Select(p => new
        {
            ROLE_ID = p.Role_ID.Trim(),
            ROLE_NAME = p.ROLE_NAME.Trim()
        });
        return JsonConvert.SerializeObject(a);
    }
    
    [WebMethod(EnableSession = true)]//或[WebMethod(true)]
    public static string w_agent(string type,string id,string agentid,string agentname,string agentteam,string teamid,
        string ext,string userid,string ip,string pwd,string agentlv,string roleid)
    {
        string sqlcmd = "";
        StringBuilder returnText = new StringBuilder();
        sqlcmd = "SELECT * FROM DispatchSystem";
        var a = DBTool.Query<agentparams>(sqlcmd, new { }).Where(w => w.SYSID != id).ToList();
        foreach(var i in a)
        {
            if(i.Agent_ID == agentid)
            {
                return "員工編號重複";
            }
            if(i.UserID == userid)
            {
                return "帳號已註冊";
            }
        }
        
        if(type == "new")
        {
            sqlcmd = @"
                INSERT INTO DispatchSystem 
                (Agent_ID,Agent_Name,Agent_Status,Agent_ExtNum,Agent_Team,TeamID,UserID,Password,Agent_LV,Role_ID,IP)
                VALUES
                (@agentid,@agentname,'在職',@ext,@agentteam,@teamid,@userid,@pwd,@agentlv,@roleid,@ip)
            ";
            returnText.Append("新增");
        }
        else if(type == "update")
        {
            sqlcmd = @"
                UPDATE DispatchSystem 
                SET
                Agent_ID = @agentid,
                Agent_Name = @agentname,
                Agent_ExtNum = @ext,
                Agent_Team =@agentteam,
                TeamID = @teamid,
                UserID = @userid,
                Password = @pwd,
                Agent_LV = @agentlv,
                Role_ID = @roleid,
                IP = @ip
                WHERE SYSID = @ID
            ";
            returnText.Append("更新");
        }

        try
        {
            DBTool.Query<agentparams>(sqlcmd, new { 
                agentid = agentid,
                agentname = agentname,
                ext = ext,
                agentteam = agentteam,
                teamid = teamid,
                userid = userid,
                pwd = pwd,
                agentlv = agentlv,
                roleid = roleid,
                ip = ip,
                ID = id
            });
            returnText.Append("成功");
        }
        catch(Exception e)
        {
            return e.ToString();
            returnText.Append("失敗");
        }

        return returnText.ToString();
    }


    [WebMethod(EnableSession =true)]
    public static string delete_agent(string ID)
    {
        try
        {
            StringBuilder sqlcmd = new StringBuilder();
            sqlcmd.Append("UPDATE DispatchSystem SET Agent_Status = N'離職' ");
            sqlcmd.Append("WHERE SYSID = @ID ");

            DBTool.Query<agentparams>(sqlcmd.ToString(), new { ID = ID });

            return "刪除成功";
        }
        catch
        {
            return "刪除失敗";
        }
    }


    public class agentparams
    {
        public string SYSID { get; set; }
        public string Agent_ID { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_Status { get; set; }
        public string Agent_ExtNum { get; set; }
        public string Agent_Num { get; set; }
        public string Agent_Company { get; set; }
        public string Agent_Team { get; set; }
        public string TeamID { get; set; }
        public string Agent_Mail { get; set; }
        public string Agent_Phone { get; set; }
        public string Agent_Phone_2 { get; set; }
        public string Agent_Phone_3 { get; set; }
        public string Agent_TEL { get; set; }
        public string Agent_Co_TEL { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Role_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string Agent_LV { get; set; }
        public string UpdateTime { get; set; }
        public string login { get; set; }
        public string Agent_Code { get; set; }
        public string Agent_MVPN { get; set; }
        public string IP { get; set; }
        public string Image { get; set; }
    }
}