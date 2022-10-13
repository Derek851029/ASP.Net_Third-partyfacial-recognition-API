using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CallHistory_Specail 的摘要描述
/// </summary>
public class CallHistory_Specail
{
    public int SYSID { get; set; }
    public string aName { get; set; }
    public string aName_Name { get; set; }
    public string aName_Note { get; set; }
    public string Modify { get; set; }
    public DateTime ModifyTime { get; set; }
    public CallHistory_Specail(){

    }
    public string Serch() {
        string sqlcmd = @"SELECT * 
              FROM Call_History_Specail 
              ORDER BY SYSID DESC";
        var Call_History_Specail = DBTool.Query<CallHistory_Specail2>(sqlcmd, new { });
        if (Call_History_Specail.Any())
            return JsonConvert.SerializeObject(Call_History_Specail);
        return "";
    }
    public class CallHistory_Specail2
    {
        public int SYSID { get; set; }
        public string aName { get; set; }
        public string aName_Name { get; set; }
        public string aName_Note { get; set; }
        public string Modify { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}