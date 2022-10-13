using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PushFaceData : System.Web.UI.Page
{
    private static string CHANNEL_ACCESS_TOKEN = "kQwi6k3EFNI7OS5AIONmARsiYZjH70seO10X7LRON6PK0eooF1uWaDE53br+m5AMOMf2mdfEoLWBvV75FOdFrX9MDNbvUUfKLhY2wuFsGUHdDdU2UJzJtD4S3lwlKZekSi81w+5l5jTYLfkYwRDEZgdB04t89/1O/w1cDnyilFU=";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string PushLineMsg(string ID, string msg)
    {

        string sqlcmd = "";

        StringBuilder json = new StringBuilder();

        try
        {
            sqlcmd = @" INSERT INTO SystemLog (PageName,PageFunc,PageLog,PageParams,EX,IP,UserID) 
                            VALUES ('PushFaceData','PushLineMsg','發送臉部辨識訊息,開始',@p,@e,'','') ";
            DBTool.Query(sqlcmd, new
            {
                e = "",
                p = json.ToString()
            });

            //修正 無法建立 ssl/tls 的安全通道 問題
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;//SecurityProtocolType.Tls


            //建立 WebRequest 並指定目標的 uri
            string url = "https://api.line.me/v2/bot/message/push";
            WebRequest request = WebRequest.Create(url);

            //添加從LINE官方取得資料所需要的標頭(header)
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add("Authorization", "Bearer " + CHANNEL_ACCESS_TOKEN);

            //指定 request 使用的 http verb
            request.Method = "POST";

            //將需 post 的資料內容轉為 stream 
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                //組成push LINE 訊息所需要的API
                json.Append("{\"to\":\"" + ID + "\",");
                json.Append("\"messages\":[{\"type\":\"text\",\"text\":\"" + msg + "\"}]}");
                streamWriter.Write(json.ToString());
                streamWriter.Flush();
            }

            //使用 GetResponse 方法將 request 送出，如果不是用 using 包覆，請記得手動 close WebResponse 物件，避免連線持續被佔用而無法送出新的 request
            var httpResponse = (HttpWebResponse)request.GetResponse();
            httpResponse.Close();

            //發送紀錄
            sqlcmd = @" INSERT INTO LineMsg (FromUserID,ToUserID,MsgType,Msg,pushflag) 
                        VALUES ('',@u,'text',@m,1) ";
            DBTool.Query(sqlcmd, new { u = ID, m = msg });

            return "Send Success";
        }
        catch (Exception ex)
        {
            sqlcmd = @" INSERT INTO SystemLog (PageName,PageFunc,PageLog,PageParams,EX,IP,UserID) 
                            VALUES ('PushFaceData','PushLineMsg','發送LINE訊息',@p,@e,'','') ";
            DBTool.Query(sqlcmd, new
            {
                e = ex.Message + ";" + ex.StackTrace,
                p = json.ToString()
            });

            return "Send Error";
        }

    }

}