using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Inbound_Show 的摘要描述
/// </summary>
public class Inbound_Show : System.Web.UI.Page
{
    //todo 加入參數
    public int SYSID { get; set; }
    public int EXTNO { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumber_Dialled { get; set; }
    public string IP { get; set; }
    public string CUSID { get; set; }
    public string Agent { get; set; }
    public string AgentPassword { get; set; }
    public string AgentName { get; set; }
    public string ExtnStatus { get; set; }
    public string WebStatus { get; set; }
    public DateTime CREATEDATE { get; set; }
    public DateTime OpenWebTime { get; set; }

    /// <summary>
    /// 初始化Inbound_Show
    /// </summary>
    /// <param name="extn"></param>
    public Inbound_Show(string extn)
    {
        string sqlcmd = string.Format(
            @"SELECT top 1 * FROM INBOUND_SHOW Where
                EXTNO = N'{0}'
                order by sysid desc", extn);
        var PhoneStatus = DBTool.Query<Inbound_Show2>(sqlcmd, new { });
        if (PhoneStatus.Any())
        {
            foreach (var item in PhoneStatus)
            {
                SYSID = item.SYSID;
                EXTNO = item.EXTNO;
                IP = item.IP;
                PhoneNumber = item.PhoneNumber;
                PhoneNumber_Dialled = item.PhoneNumber_Dialled;
                CUSID = item.CUSID;
                Agent = item.Agent;
                AgentPassword = item.AgentPassword;
                AgentName = item.AgentName;
                CREATEDATE = item.CREATEDATE;
                OpenWebTime = item.OpenWebTime;
                ExtnStatus = item.ExtnStatus;
                WebStatus = item.WebStatus;
            }
            //當電話有動作時被登出，登入後能保持在上一個階段。
            Session["WebStatus"] = WebStatus;
            Session["PhoneNumber"] = PhoneNumber;
            Session["PhoneNumber_Dialled"] = PhoneNumber_Dialled;
        }
    }

    public class Inbound_Show2 {
        //todo 加入參數
        public int SYSID { get; set; }
        public int EXTNO { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber_Dialled { get; set; }
        public string IP { get; set; }
        public string CUSID { get; set; }
        public string Agent { get; set; }
        public string AgentPassword { get; set; }
        public string AgentName { get; set; }
        public string ExtnStatus { get; set; }
        public string WebStatus { get; set; }
        public DateTime CREATEDATE { get; set; }
        public DateTime OpenWebTime { get; set; }
    }
}