using AjaxControlToolkit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Knowledge 的摘要描述
/// </summary>
public class Knowledge
{
    public string SYSID { get; set;}
    public string KnowledgeObjectID { get; set;}
    public string txt_Title { get; set;}
    public string txt_Content { get; set;}
    public string Create_Name { get; set;}
    public string Create_ID { get; set;}
    public DateTime Create_Time { get; set;}
    public string Update_Name { get; set;}
    public string Update_ID { get; set;}
    public DateTime Update_Time { get; set;}
    public string Click { get; set;}
    public string KnowledgeFlag { get; set;}
    public string txt_Answer { get; set;}
    public DateTime Answer_Time { get; set;}
    public string Answer_Name { get; set;}
    public string Answer_ID { get; set;}
    public DateTime endDate { get; set;}
    public string SavePath { get; set;}
    public string FileName { get; set;}
    public string Img1_SavePath { get; set;}
    public string Img1_FileName { get; set;}
    public string Img2_SavePath { get; set;}
    public string Img2_FileName { get; set;}
    public string txt_img1 { get; set;}
    public string txt_img2 { get; set;}
    public string Readflag { get; set;}
    public string KnowledgeObjectNameMain { get; set;}
    public string KnowledgeObjectNameSub { get; set;}

    public static string search(string flag ="0",string ID="0",string search="")
    {
        StringBuilder sqlcmd = new StringBuilder();
        sqlcmd.Append("uspKnowledge @flag="+flag+",");
        sqlcmd.Append("@ID="+ID+",");
        sqlcmd.Append("@search=N'" + search + "'");

        var result = DBTool.Query<Knowledge>(sqlcmd.ToString());
        string outputjson = JsonConvert.SerializeObject(result);
        return outputjson;
    }

}