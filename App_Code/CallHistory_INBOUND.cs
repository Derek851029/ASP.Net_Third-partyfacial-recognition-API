using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CallHistory_INBOUND 的摘要描述
/// </summary>
public class CallHistory_INBOUND
{
    public int SYSID {get;set;}
    public string aName {get;set;}
    public string bName {get;set;}
    public string Status {get;set;}
    public DateTime Time {get;set;}
    public DateTime AnswerTime {get;set;}
    public DateTime HangupTime {get;set;}
    public int Len {get;set;}
    public int CTI_FLAG {get;set;}
    public int ReCall_FLAG { get; set; }
    public CallHistory_INBOUND()
    {
        
    }

    public string Serch() {

        string sqlcmd = @"SELECT TOP 1000 * 
              FROM Call_History_INBUOND 
              ORDER BY SYSID DESC";
        var Call_History = DBTool.Query<CallHistory_INBOUND2>(sqlcmd, new { });
        if (Call_History.Any())
            return JsonConvert.SerializeObject(Call_History);
        return "";
    }

    public class CallHistory_INBOUND2
    {
        public int SYSID { get; set; }
        public string aName { get; set; }
        public string bName { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
        public DateTime AnswerTime { get; set; }
        public DateTime HangupTime { get; set; }
        public int Len { get; set; }
        public int CTI_FLAG { get; set; }
        public int ReCall_FLAG { get; set; }
    }
}