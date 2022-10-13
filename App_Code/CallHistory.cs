using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CallHistory 的摘要描述
/// </summary>
public class CallHistory
{
    public int SYSID { get; set; }
    public string aName { get; set; }
    public string bName { get; set; }
    public string Status { get; set; }
    public DateTime Time { get; set; }
    public DateTime HangupTime { get; set; }
    public string Len { get; set; }
    public string CTI_FLAG { get; set; }
    public CallHistory()
    {
        
    }
}