using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Base64 的摘要描述
/// </summary>
public class Base64
{
    public Base64(string UserID ,string Password)
    {
        //將字串做Base64的加密
        var AStr = string.Format(@"userId={0}&password={1}&routeType=8", UserID, Password);
        var ABase64 = Base64Encode(AStr);
        HttpContext.Current.Response.Write("<script>window.open('http://172.17.225.30:80/mw/MLogin_login.action?guid=" + ABase64+ "','_new','')</script>");

        HttpContext.Current.Response.Write("<script>window.open('http://" + System.Configuration.ConfigurationManager.AppSettings["Web_Path"] + "/0010010010.aspx','_self','')</script>");
    }

    /*將字串加密*/
    public static string Base64Encode(string AStr)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(AStr));
    }

    /*將字串解密*/
    public static string Base64Decode(string ABase64)
    {
        //http://172.22.10.249:8580/mw/MLogin_login.action?guid=dXNlcklkPUIwMzQ0MSZwYXNzd29yZD1CMDM0NDFCMDM0NDEmcm91dGVUeXBlPU0=
        return Encoding.UTF8.GetString(Convert.FromBase64String(ABase64));
    }
}