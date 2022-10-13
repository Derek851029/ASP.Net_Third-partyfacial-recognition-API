using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ContextRead 的摘要描述
/// </summary>
public class ContextRead
{
    public int SYSID { get; set; }
    public string UserID { get; set; }
    public string ReadDate { get; set; }
    public DateTime ReadTime { get; set; }
    public int ReadFlag { get; set; }
    public ContextRead()
    {
        
    }
}