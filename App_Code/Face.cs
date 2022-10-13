using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Face 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class Face : System.Web.Services.WebService
{
    private static string CHANNEL_ACCESS_TOKEN = "1vEIs6ahp2h8F7PwNGPA6hzsFEocYlyQhWX5RonzCBEl9PKyT1LGwKLu9zgw2WjfixLps7bpnD0pFXKy+yG6e4T0rf4EfRWX+XMpQ5XaT3p9oUbyG+RmafqNbYsTO0WG8zGUoXE21IypXNfek77FygdB04t89/1O/w1cDnyilFU=";
    public Face()
    {

        //如果使用設計的元件，請取消註解下列一行
        //InitializeComponent(); 
    }

    [WebMethod]
    public string FaceService()
    {
        string sql;
        try
        {
            string data = HttpContext.Current.Request.Params["event_log"] == null ? null : HttpContext.Current.Request.Params["event_log"].ToString();
            
            if (string.IsNullOrEmpty(data) == false)
            {
                sql = "insert into SystemLog(EX) values(@Ex)";
                DBTool.Query(sql, new
                {
                    Ex = data,
                });
                dynamic result = JsonConvert.DeserializeObject(data);
                var SourceIP = result.ipAddress.ToString();
                var Date = result.dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                var Week = GetWeek();
                var Status = "";

                if (result.ToString().IndexOf("AccessControllerEvent") > -1)
                {

                    var AccessControllerEvent = result.AccessControllerEvent.ToString();
                    sql = "insert into SystemLog(EX) values(@Ex)";
                    DBTool.Query(sql, new
                    {
                        Ex = AccessControllerEvent,
                    });
                    dynamic result2 = JsonConvert.DeserializeObject(AccessControllerEvent);

                    var currentVerifyMode = result2.currentVerifyMode.ToString();
                    
                    if (currentVerifyMode != "invalid")
                    {
                        string Mask = "";
                        string Name = "陌生人";
                        string Number = "";
                        string Temperature = result2.currTemperature.ToString();

                        //如果json沒有name就是陌生人
                        if (AccessControllerEvent.IndexOf("name") > -1)
                        {
                            Name = result2.name.ToString();
                            Mask = result2.mask.ToString();
                            Number = result2.employeeNoString.ToString();
                            //Temperature = result2.currTemperature.ToString();
							var attendanceStatus = result2.attendanceStatus.ToString();
                            sql = @"select LineUserID from MemberData where MemberNum = @Number";
                            var LineUserID = DBTool.Query(sql, new { Number = Number }).FirstOrDefault().LineUserID;
                            if (string.IsNullOrEmpty(LineUserID) == false)
                            {
								string msg = "";
								if(attendanceStatus == "checkIn"){
									msg = "是否配戴口罩:" + Mask + "\\n體溫:" + Temperature + "\\n歡迎" + Name + "進入車鋁長照中心";
									Status = "In";
								}
								else{
									msg = "是否配戴口罩:" + Mask + "\\n體溫:" + Temperature + "\\n歡迎" + Name + "離開車鋁長照中心";
									Status = "Out";
								}
                                
                                SendMsg(LineUserID, msg);
                            }

                        }
                        sql = @"insert into FaceRecognitionLog(SourceIP,Number,Name,Mask,Temperature,Week,Date,Status) 
                                        values(@SourceIP,@Number,@Name, @Mask, @Temperature,@Week,@Date,@Status)";
                        DBTool.Query(sql, new
                        {
                            SourceIP = SourceIP,
                            Number = Number,
                            Name = Name,
                            Mask = Mask,
                            Temperature = Temperature,
                            Week = Week,
                            Date = Date,
                            Status = Status
                        });
                    }
                }
            }
        }
        catch(Exception e)
        {
            sql = "insert into SystemLog(PageName,PageFunc,EX) values(@Page,@FunctionName.@Ex)";
            DBTool.Query(sql,new {
                Page = "Face.asmx",
                FunctionName = "FaceService",
                Ex = e.ToString(),
            });
        }
        
        return "200";
    }

    public string GetWeek()
    {
        string week = "";
        string dt = DateTime.Today.DayOfWeek.ToString();
        switch (dt)
        {
            case "Monday":
                week = "1";
                break;
            case "Tuesday":
                week = "2";
                break;
            case "Wednesday":
                week = "3";
                break;
            case "Thursday":
                week = "4";
                break;
            case "Friday":
                week = "5";
                break;
            case "Saturday":
                week = "6";
                break;
            case "Sunday":
                week = "7";
                break;
        }
        return week;
    }

    public static void SendMsg(string ID, string msg)
    {
        string sqlcmd = "";

        StringBuilder json = new StringBuilder();

        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            var user = ID;

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
                json.Append("{\"to\":\"" + user + "\",");
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
            DBTool.Query(sqlcmd, new { u = user, m = msg });

        }
        catch (Exception ex)
        {
            sqlcmd = @"insert into SystemLog(Page,FunctionName,Ex) values(@Page,@FunctionName,@Ex)";
            DBTool.Query(sqlcmd, new
            {
                Page = "",
                FunctionName = "",
                Ex = ex.ToString()
            });

        }

    }

    public class resultData{
        public string ipAddress;
        public string dateTime;
        public dynamic AccessControllerEvent;
    }
    public class result2Data
    {
        public string name;
        public string employeeNoString;
        public string mask;
    }
}
