using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DocumentData 的摘要描述
/// </summary>
public class DocumentData
{
    public string SYSID { get; set; }
    public string MailID { get; set; }
    public string MailCID { get; set; }
    public DateTime CREATEDATE { get; set; }
    public string Sender { get; set; }
    public string CusID { get; set; }
    public string CusName { get; set; }
    public string SendWay { get; set; }
    public string Acczip { get; set; }
    public string AccAddr { get; set; }
    public string BigClass { get; set; }
    public string MidClass { get; set; }
    public string prepDOC { get; set; }
    public string attaDOC { get; set; }
    public string Note { get; set; }
    public string Note2 { get; set; }
    public string printYN { get; set; }
    public string printDate { get; set; }
}