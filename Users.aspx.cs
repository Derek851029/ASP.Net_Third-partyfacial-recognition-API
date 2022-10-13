using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Users : System.Web.UI.Page
{
    protected string seqno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        seqno = Request.Params["seqno"];
    }

    [WebMethod(EnableSession = true)]
    public static string bindtable()
    {
        string sql = "select * from MemberData where Status = 'New'";
        var data = DBTool.Query(sql);
        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string ListHistory(string MemberNum, string startDate, string endDate)
    {
        string sql = "select * from FaceRecognitionLog where Number = @MemberNum and Date > @startDate and Date <= @endDate";
        var data = DBTool.Query(sql,new 
        { 
            MemberNum = MemberNum,
            startDate = startDate,
            endDate = endDate,
        });
        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string ListLineUser()
    {
        string sql = "select * from LineMember where flag = '0'";
        var data = DBTool.Query(sql);
        return JsonConvert.SerializeObject(data);
    }

    [WebMethod(EnableSession = true)]
    public static string AddMember(string type, string MemberNum, string MemberName, string MemberID, string LineUserID, 
        string MemberDate, string Sex, string MemberPhone, string MemberEmail)
    {
        string sql;
        try
        {
            if (type == "0")
            {
                sql = "select MemberNum from MemberData where MemberNum = @MemberNum and Status = 'New'";
                var a = DBTool.Query(sql,new { MemberNum = MemberNum });
                if (a.Any())
                {
                    return "exist";
                }

                sql = "select MemberID from MemberData where MemberID = @MemberID and Status = 'New'";
                var b = DBTool.Query(sql, new { MemberID = MemberID });
                if (b.Any())
                {
                    return "exist";
                }

                sql = @"insert into MemberData(MemberNum,MemberName,MemberID,MemberDate,Sex,MemberPhone,MemberEmail,LineUserID,Status,flag)
                            values(@MemberNum,@MemberName,@MemberID,@MemberDate,@Sex,@MemberPhone,@MemberEmail,@LineUserID,@Status,@flag)";
                DBTool.Query(sql, new
                {
                    MemberNum = MemberNum,
                    MemberName = MemberName,
                    MemberID = MemberID,
                    LineUserID = LineUserID,
                    MemberDate = MemberDate,
                    Sex = Sex,
                    MemberPhone = MemberPhone,
                    MemberEmail = MemberEmail,
                    Status = "New",
                    flag = 0
                });
            }
            else if (type == "1")
            {
                sql = @"update MemberData set MemberName = @MemberName, LineUserID = @LineUserID,MemberDate = @MemberDate, Sex = @Sex, 
                        MemberPhone = @MemberPhone, MemberEmail = @MemberEmail where MemberID = @MemberID";
                DBTool.Query(sql, new
                {
                    MemberNum = MemberNum,
                    MemberName = MemberName,
                    LineUserID = LineUserID,
                    MemberID = MemberID,
                    MemberDate = MemberDate,
                    Sex = Sex,
                    MemberPhone = MemberPhone,
                    MemberEmail = MemberEmail,
                });
            }
            else
            {

            }
            return "Success";
        }
        catch (Exception e)
        {
            sql = @" INSERT INTO SystemLog (PageName,PageFunc,EX) 
                            VALUES ('Users','AddMember',@e,) ";
            DBTool.Query(sql, new
            {
                e = e.ToString()
            });
            return "error";
        }
        

        
    }

    [WebMethod(EnableSession = true)]
    public static string SaveImage()
    { 
        string sql;
        string ImagePath = HttpContext.Current.Server.MapPath("/MemberImage/");
        TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
        TimeSpan unixTicks = new TimeSpan(DateTime.Now.Ticks) - epochTicks;
        Int32 unixTimestamp = (Int32)unixTicks.TotalSeconds;
        string FileTime = unixTimestamp.ToString();
        string imgName;
        try
        {
            string MemberNum = HttpContext.Current.Request.Form.Get("MemberNum");
            string Size = HttpContext.Current.Request.Form.Get("SizeKB");
            double SizeKB = Convert.ToDouble(Size);

            HttpFileCollection httpFile = HttpContext.Current.Request.Files;
            HttpPostedFile files = httpFile[0];

            if (Math.Floor(SizeKB) > 200)
            {
                imgName = FileTime + ".png";
                files.SaveAs(ImagePath + imgName);

                System.Drawing.Image g = System.Drawing.Image.FromFile(ImagePath + imgName);
                ImageFormat format = g.RawFormat;
                int width = 800; //寬度
                int heigt = 600; //高度

                string NewName = MemberNum + ".jpg";
                Bitmap imgoutput = new Bitmap(g, width, heigt); //輸出一個新圖片
                imgoutput.Save(ImagePath + NewName, format); //存檔路徑,格式

                g.Dispose();
                imgoutput.Dispose();

                File.Delete(ImagePath + imgName);
            }
            else
            {
                imgName = MemberNum + ".jpg";
                files.SaveAs(ImagePath + imgName);
            }

            string IP = HttpContext.Current.Request.Url.Host;
            string ImageURL = "http://210.68.227.123:7017/MemberImage/" + imgName;
            //string ImageURL = "http://" + IP + "/MemberImage/" + imgName;
            sql = @"update MemberData set ImageURL = @ImageURL, flag = @flag where MemberNum = @MemberNum";
            DBTool.Query(sql,new { ImageURL = ImageURL, flag = 1, MemberNum = MemberNum });
            return ImageURL;
        }
        catch (Exception e)
        {
            sql = @" INSERT INTO SystemLog (PageName,PageFunc,EX) 
                            VALUES ('Users','SaveImage',@e) ";
            DBTool.Query(sql, new
            {
                e = e.ToString()
            });
            return "error";
        }
        
    }

    [WebMethod(EnableSession = true)]
    public static string DeleteMember(string MemberNum)
    {
        string sql;
        try
        {
            sql = "update MemberData set Status = 'Delete' where MemberNum = @MemberNum"; //不要刪除資料, 保留以後查閱
            DBTool.Query(sql, new { MemberNum = MemberNum });
            return "Success";
        }
        catch (Exception e)
        {
            sql = @" INSERT INTO SystemLog (PageName,PageFunc,EX) 
                            VALUES ('Users','DeleteMember',@e) ";
            DBTool.Query(sql, new
            {
                e = e.ToString()
            });
            return "error";
        }
        
        
    }

    [WebMethod(EnableSession = true)]
    public static string FaceControl(string data, int type)
    {
        string IP = "192.168.2.100";
        string url = "";
        string function_name = "";
        string return_data = "";
        switch (type)
        {
            case 0:
                url = "http://"+ IP + "/ISAPI/AccessControl/UserInfo/SetUp?format=json";
                function_name = "建立人員";
                return_data = Requests_Deivce(data, url, function_name);
                break;
            case 1:
                url = "http://"+ IP + "/ISAPI/Intelligent/FDLib/FDSetUp?format=json";
                function_name = "放置人臉";
                return_data = Requests_Deivce(data, url, function_name);
                break;
            case 2:
                url = "http://"+ IP + "/ISAPI/AccessControl/UserInfo/Modify?format=json";
                function_name = "編輯人員";
                return_data = Requests_Deivce(data, url, function_name);
                break;
            case 3:
                url = "http://"+ IP + "/ISAPI/AccessControl/UserInfo/Delete?format=json";
                function_name = "刪除人員";
                return_data = Requests_Deivce(data, url, function_name);
                break;
        }
        return return_data;
    }

    public static string Requests_Deivce(string data, string url, string function_name)
    {
        string password = "k1111111";
        try
        {
            WebRequest request = WebRequest.Create(url);
            CredentialCache mycache = new CredentialCache();
            mycache.Add(new Uri(url), "Digest", new NetworkCredential("admin", password));
            request.Credentials = mycache;
            request.ContentType = "application/json; charset=UTF-8";
            request.Headers.Add("Authorization", "Digest");
            request.Method = "PUT";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
            }

            //發送
            var httpResponse = (HttpWebResponse)request.GetResponse();
            //讀取回傳資料
            Stream stream = httpResponse.GetResponseStream();
            byte[] rsByte = new Byte[httpResponse.ContentLength];
            stream.Read(rsByte, 0, (int)httpResponse.ContentLength);
            string test = System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();
            //關閉request
            httpResponse.Close();
            return "Success";
        }
        catch (Exception ex)
        {
            string sqlcmd = @" INSERT INTO SystemLog (PageName,PageFunc,Ex) 
                            VALUES (@Page,@FunctionName,@Ex) ";
            DBTool.Query(sqlcmd, new
            {
                Page = "Users.aspx",
                FunctionName = function_name,
                Ex = ex.Message + ";" + ex.StackTrace,
            });

            return "fail";
        }
    }
}

public class file
{
    public string MemberNum { get; set; }
    public double SizeKB { get; set; }
}